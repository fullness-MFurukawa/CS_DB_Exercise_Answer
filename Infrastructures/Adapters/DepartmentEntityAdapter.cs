using CS_DB_Exercise_Answer.Domains.Adapters;
using CS_DB_Exercise_Answer.Domains.Models;
using CS_DB_Exercise_Answer.Infrastructures.Entities;
namespace CS_DB_Exercise_Answer.Infrastructures.Adapters;
/// <summary>
/// ドメインオブジェクトDepartmentとDepartmentEntityとの
/// 相互変換を行うアダプターインターフェイスの実装
/// </summary>
public class DepartmentEntityAdapter : IDepartmentAdapter<DepartmentEntity>
{
    private readonly IEmployeeAdapter<EmployeeEntity> _adapter;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="adapter">ドメインオブジェクトEmployeeとEmployeeEntityとの相互変換</param>
    public DepartmentEntityAdapter(IEmployeeAdapter<EmployeeEntity> adapter)
    {
        _adapter = adapter;
    }

    /// <summary>
    /// DepartmentEntityからドメインオブジェクトDepartmentを復元する
    /// </summary>
    /// <param name="source">DepartmentEntity</param>
    /// <returns>ドメインオブジェクトDepartment</returns>
    public Department ToDomain(DepartmentEntity source)
    {
        if (source == null)
            throw new ArgumentNullException("引数がnullのため復元できません。");
        List<Employee>? employees = null;
        // 所属社員が存在する
        if (source.Employees != null) 
        {
            // EmployeeEntityのリストからEmployeeのリストへ変換する
            employees = new List<Employee>();
            foreach (var employee in source.Employees)
            {
                employees.Add(_adapter.ToDomain(employee));
            }
        }
        // 部署を生成して返す
        var department = new Department(source.Id, source.Name, employees);
        return department;
    }

    /// <summary>
    /// DepartmentEntityのリストからドメインオブジェクトDepartmentのリストを復元する
    /// </summary>
    /// <param name="sources">DepartmentEntityのリスト</param>
    /// <returns>ドメインオブジェクトDepartmentのリスト</returns>
    public List<Department> ToDomainList(List<DepartmentEntity> sources)
    {
        if (sources == null)
            throw new ArgumentNullException("引数がnullのため復元できません。");
        var departments = new List<Department>();
        foreach (var department in sources)
        {
            departments.Add(ToDomain(department));
        }
        return departments;
    }

    /// <summary>
    /// ドメインオブジェクトDepartmentからDepartmentEntityへ変換する
    /// </summary>
    /// <param name="department">ドメインオブジェクトDepartment</param>
    /// <returns>DepartmentEntity</returns>
    public DepartmentEntity FromDomain(Department department)
    {
        if (department == null)
            throw new ArgumentNullException("引数がnullのため変換できません。");
        // DepartmentEntityを生成する
        var entity = new DepartmentEntity
        {
            Id = department.Id,
            Name = department.Name,
        };
        return entity;
    }

    /// <summary>
    /// ドメインオブジェクトDepartmentのリストからDepartmentEntityのリストへ変換する
    /// </summary>
    /// <param name="departments">ドメインオブジェクトDepartmentのリスト</param>
    /// <returns>List<DepartmentEntity></returns>
    public List<DepartmentEntity> FromDomainList(List<Department> departments)
    { 
        if (departments == null)
            throw new ArgumentNullException("引数はnullのため変換できません。");
        // DepartmentEntityのリストを生成する
        var entities = new List<DepartmentEntity>();
        // DepertmentのリストからDepartmentEntityのリストへ変換する
        foreach (var department in departments)
        {
            entities.Add(FromDomain(department));
        }
        return entities;
    }
}