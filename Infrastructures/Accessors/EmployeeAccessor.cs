using CS_DB_Exercise_Answer.Infrastructures.Contexts;
using CS_DB_Exercise_Answer.Infrastructures.Entities;

namespace CS_DB_Exercise_Answer.Infrastructures.Accessors;
/// <summary>
/// employeeテーブルにアクセスするクラス
/// </summary>
public class EmployeeAccessor
{
     private readonly AppDbContext _context;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">演習用DbContext</param>
    public EmployeeAccessor(AppDbContext context)
    {
        _context = context;
    }
    /// <summary>
    /// 演習-07 employeeテーブルから部署Idで該当社員を取得する
    /// </summary>
    /// <param name="deptId">部署Id</param>
    /// <returns>問合せ結果</returns>
    public List<EmployeeEntity>? FindByDeptId(int deptId)
    {
        var employees = _context.Employees
            .Where(e => e.DeptId == deptId)
            .ToList();
        if (employees.Count == 0)
            return null;

        return employees;
    }

    /// <summary>
    /// 演習-08 employeeテーブルから社員名の部分一致検索で該当社員を取得する
    /// </summary>
    /// <param name="keyword">検索キーワード</param>
    /// <returns>検索結果</returns>
    public List<EmployeeEntity>? FindByContaintsName(string keyword)
    {
        var employees = _context.Employees
            .Where(e => e.Name!.Contains(keyword))
            .ToList();
        if (employees.Count == 0)
        {
            return null;
        }
        return employees;
    }

    /// <summary>
    /// 演習-09 employeeテーブルに新しい社員の情報を登録する
    /// </summary>
    /// <param name="employee"></param>
    public void Create(EmployeeEntity employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

     /// <summary>
    /// 演習-10 指定された社員Idの社員名を変更する
    /// </summary>
    /// <param name="employee">変更する社員情報</param>
    /// <returns>変更結果</returns>
    public EmployeeEntity? UpdateById(EmployeeEntity employee)
    {
        var existingEmployee = _context.Employees.Find(employee.Id);
        if (existingEmployee != null)
        {
            existingEmployee.Name = employee.Name;
            _context.SaveChanges();
        }
        return existingEmployee;
    }

    /// <summary>
    /// 演習-11 指定された社員Idの社員を削除する
    /// </summary>
    /// <param name="id">社員Id</param>
    /// <returns>削除した社員情報</returns>
    public EmployeeEntity? DeleteById(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
        return employee;
    }
}
