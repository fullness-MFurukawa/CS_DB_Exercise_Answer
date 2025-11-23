using CS_DB_Exercise_Answer.Domains.Adapters;
using CS_DB_Exercise_Answer.Domains.Models;
using CS_DB_Exercise_Answer.Domains.Repositories;
using CS_DB_Exercise_Answer.Infrastructures.Contexts;
using CS_DB_Exercise_Answer.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
namespace CS_DB_Exercise_Answer.Infrastructures.Repositories;
// <summary>
/// 社員をCRUD操作するリポジトリインターフェイスの実装
/// </summary>
public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;
    private readonly IEmployeeAdapter<EmployeeEntity> _adapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーション用DbContext</param>
    /// <param name="adapter">EmployeeとEmployeeEntityとの相互変換</param>
    public EmployeeRepository(
        AppDbContext context, IEmployeeAdapter<EmployeeEntity> adapter)
    {
        _context = context;
        _adapter = adapter;
    }

    /// <summary>
    /// 新しい社員を永続化する
    /// </summary>
    /// <param name="employee"></param>
    public void Create(Employee employee)
    {
        // EmployeeからEmployeeEntityへ変換する
        var entity = _adapter.FromDomain(employee);
        // 社員を追加して永続化する
        _context.Add(entity);
        _context.SaveChanges();
    }

    /// <summary>
    /// 指定された社員Idの社員を削除する
    /// </summary>
    /// <param name="id">削除対象の社員Id</param>
    /// <returns>true:削除成功 false:削除対象社員が存在しない</returns>
    public bool DeleteById(int id)
    {
        // 削除対象を取得する
        var entity = _context.Employees
           .SingleOrDefault(i => i.Id == id);
        if (entity == null)
        {
            // 削除対象が存在しない場合はfalseを返す
            return false;
        }
        // 削除する
        _context.Employees.Remove(entity);
        _context.SaveChanges();
        // 削除が成功したらtrueを返す
        return true;
    }

    /// <summary>
    /// すべての社員を取得する
    /// </summary>
    /// <returns></returns>
    public List<Employee> FindAll()
    {
        // すべての社員を取得する
        var entities = _context.Employees
            .AsNoTracking()
            .ToList();
        // EmployeeEntityのリストをEmployeeのリストに変換して返す
        var employees = _adapter.ToDomainList(entities);
        return employees;
    }

    /// <summary>
    /// 社員Idで社員を取得する
    /// </summary>
    /// <param name="id">社員Id</param>
    /// <returns></returns>
    public Employee? FindById(int id)
    {
        // 社員Idで社員を取得する
        var entity = _context.Employees.Find(id);
        // 取得できない場合はnullを返す
        if (entity == null)
        {
            return null;
        }
        // EmployeeEntityをEmployeeに変換して返す
        var employee = _adapter.ToDomain(entity!);
        return employee;   
    }

    /// <summary>
    /// 指定された社員Idの社員名を変更する
    /// </summary>
    /// <param name="id">変更対象の社員Id</param>
    /// <returns>true:変更成功 false:変更対象社員が存在しない</returns>
    public bool UpdateById(Employee employee)
    {
        // 部署Idで変更対象社員を取得する
        var entity = _context.Employees
            .SingleOrDefault(i => i.Id == employee.Id);
        if (entity == null)
        {
            // 変更対象社員が見つからない場合はfalseを返す
            return false;
        }
        // 社員名を変更してデータベースに反映させる
        entity!.Name = employee.Name!;
        _context.Employees.Update(entity);
        _context.SaveChanges();
        // 変更が成功したらtrueを返す
        return true;
    }
}