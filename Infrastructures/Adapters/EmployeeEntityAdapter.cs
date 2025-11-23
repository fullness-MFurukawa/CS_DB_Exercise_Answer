using CS_DB_Exercise_Answer.Domains.Adapters;
using CS_DB_Exercise_Answer.Domains.Models;
using CS_DB_Exercise_Answer.Infrastructures.Entities;
namespace CS_DB_Exercise_Answer.Infrastructures.Adapters;
/// <summary>
/// ドメインオブジェクトEmployeeとEmployeeEntityとの
/// 相互変換を行うアダプターインターフェイスの実装
/// </summary>
public class EmployeeEntityAdapter : IEmployeeAdapter<EmployeeEntity>
{
    /// <summary>
    /// EmployeeEntityからドメインオブジェクトEmployeeを復元する
    /// </summary>
    /// <param name="source">EmployeeEntity</param>
    /// <returns>ドメインオブジェクトEmployee</returns>
    public Employee ToDomain(EmployeeEntity source)
    {
        if (source == null)
            throw new ArgumentNullException("引数がnullのため復元できません。");
        Department? department = null;
        // 部署がnulでない
        if (source.Department != null) 
        {
            // 所属部署を生成する
            department = new Department(source.Department.Id, source.Department.Name, null);
        }
        // 社員を生成して返す
        var employee = new Employee(source.Id, source.Name, department);
        return employee;
    }

    /// <summary>
    /// EmployeeEntityのリストからドメインオブジェクトEmployeeのリストを復元する
    /// </summary>
    /// <param name="sources">EmployeeEntityのリスト</param>
    /// <returns>ドメインオブジェクトEmployeeのリスト</returns>
    public List<Employee> ToDomainList(List<EmployeeEntity> sources)
    {
        if (sources == null)
            throw new ArgumentNullException("引数がnullのため復元できません。");        
        // Employeeのリストを生成する
        var employees = new List<Employee>();
        // EmployeeEntirtyのリストからEmployeeのリストへ変換する
        foreach (var source in sources)
        {
            employees.Add(ToDomain(source));   
        }
        return employees;
    }

    /// <summary>
    /// ドメインオブジェクトEmployeeから外部EmployeeEntityへ変換する
    /// </summary>
    /// <param name="employee">ドメインオブジェクトEmployee</param>
    /// <returns>EmployeeEntity</returns>
    public EmployeeEntity FromDomain(Employee employee)
    {
        if (employee == null)
            throw new ArgumentNullException("引数がnullのため変換できません。");
        // EmployeeEntityを生成する
        var entity = new EmployeeEntity
        {
            Id = employee.Id,
            Name = employee.Name,
            DeptId = employee.Department!.Id
        };
        return entity;
    }

    /// <summary>
    /// ドメインオブジェクトEmployeeのリストからEmployeeEntityのリストへ変換する
    /// </summary>
    /// <param name="employees">ドメインオブジェクトEmployeeのリスト</param>
    /// <returns>EmployeeEntityのリスト</returns>
    public List<EmployeeEntity> FromDomainList(List<Employee> employees)
    {
        if (employees == null)
            throw new ArgumentNullException("引数がnullのため変換できません。");
        // EmployeeEntityのリストを生成する
        var entities = new List<EmployeeEntity>();
        // EmployeeのリストからEmployeeEntityのリストへ変換する
        foreach (var employee in employees) { 
            entities.Add(FromDomain(employee));
        }
        return entities;
    }
}