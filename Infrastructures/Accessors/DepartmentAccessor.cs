using CS_DB_Exercise_Answer.Infrastructures.Contexts;
using CS_DB_Exercise_Answer.Infrastructures.Entities;

namespace CS_DB_Exercise_Answer.Infrastructures.Accessors;

/// <summary>
/// departmentテーブルにアクセスするクラス
/// </summary>
public class DepartmentAccessor
{
    private readonly AppDbContext _context;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">演習用DbContext</param>
    public DepartmentAccessor(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// 演習-05 departmentテーブルからすべての部署を取得する
    /// </summary>
    /// <returns>取得結果</returns>
    public List<DepartmentEntity> FindAll()
    {
        return _context.Departments.ToList();
    }

    /// <summary>
    /// 演習-06 departmentテーブルから主キー値で部署を取得する
    /// </summary>
    /// <returns>取得結果</returns>
    /*
    public DepartmentEntity? FindById(int id)
    {
        var department = _context.Departments.Find(id);
        return department;
    }
    */
    
    /// <summary>
    /// 演習-06 departmentテーブルから主キー値で部署を取得する
    /// </summary>
    /// <returns>取得結果</returns>
    public DepartmentEntity? FindById(int id)
    {
        var department = _context.Departments
            .Where(d => d.Id == id)
            .SingleOrDefault();
        return department;
    }
}
