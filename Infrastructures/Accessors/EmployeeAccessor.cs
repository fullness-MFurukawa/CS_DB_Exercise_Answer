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
}
