using CS_DB_Exercise_Answer.Domains.Adapters;
using CS_DB_Exercise_Answer.Domains.Models;
using CS_DB_Exercise_Answer.Domains.Repositories;
using CS_DB_Exercise_Answer.Infrastructures.Contexts;
using CS_DB_Exercise_Answer.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
namespace CS_DB_Exercise_Answer.Infrastructures.Repositories;
/// <summary>
/// 部署をCRUD操作するリポジトリインターフェイスの実装
/// </summary>
public class DepartmentRepository : IDepartmentRepository
{
    private readonly AppDbContext _context;
    private readonly IDepartmentAdapter<DepartmentEntity> _adapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="appDbContext">アプリケーション用DbContext</param>
    /// <param name="adapter">DepartmentとDepartmentEntityとの相互変換</param>
    public DepartmentRepository(
        AppDbContext context, IDepartmentAdapter<DepartmentEntity> adapter)
    {
        _context = context;
        _adapter = adapter;
    }

    /// <summary>
    /// 新しい部署を永続化する
    /// </summary>
    /// <param name="department"></param>
    public void Create(Department department)
    {
        // DepartmentからDepartmentEntityへ変換する
        var entity = _adapter.FromDomain(department);
        // 部署を追加して永続化する
        _context.Add(entity);
        _context.SaveChanges();
    }

    /// <summary>
    /// 指定された部署Idの部署を削除する
    /// </summary>
    /// <param name="id">削除対象の部署Id</param>
    /// <returns>true:削除成功 false:削除対象部署が存在しない</returns>
    public bool DeleteById(int id)
    {
          // 削除対象を取得する
        var entity = _context.Departments
           .SingleOrDefault(i => i.Id == id);
        if (entity == null)
        {
            // 削除対象が存在しない場合はfalseを返す
            return false;
        }
        // 削除する
        _context.Departments.Remove(entity);
        _context.SaveChanges();
        // 削除が成功したらtrueを返す
        return true;
    }

    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    /// <returns></returns>
    public List<Department> FindAll()
    {
        // すべての部署を取得する
        var entities = _context.Departments
            .AsNoTracking()
            .ToList();
        // DepartmentEntityのリストをDepartmentのリストに変換して返す
        var departments = _adapter.ToDomainList(entities);
        return departments;
    }

    /// <summary>
    /// 部署Idで部署を取得する
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <returns></returns>
    public Department? FindById(int id)
    {
        // 部署Idで部署を取得する
        var entity = _context.Departments
           .Find(id);
        // 取得できない場合はnullを返す
        if (entity == null)
        {
            return null;
        }
        // DepartmentEntityをDepartmentに変換して返す
        var department = _adapter.ToDomain(entity!);
        return department;
    }

    /// <summary>
    /// 部署名を変更する
    /// </summary>
    /// <param name="department">変更部署</param>
    /// <returns>true:変更成功 false:変更対象部署が存在しない</returns>
    public bool UpdateById(Department department)
    {
        // 部署Idで変更対象部署を取得する
        var entity = _context.Departments
            .SingleOrDefault(i => i.Id == department.Id);
        if (entity == null)
        {
            // 変更対象部署が見つからない場合はfalseを返す
            return false;
        }
        // 部署名を変更してデータベースに反映させる
        entity!.Name = department.Name!;
        _context.Departments.Update(entity);
        _context.SaveChanges();
        // 変更が成功したらtrueを返す
        return true;
    }
}