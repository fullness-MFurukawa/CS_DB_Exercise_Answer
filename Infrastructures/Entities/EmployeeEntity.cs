using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CS_DB_Exercise_Answer.Infrastructures.Entities;
/// <summary>
/// 演習-03 Entityクラスを実装する
/// employeeテーブルとマッピングするエンティティクラス
/// </summary>
[Table("employee")]
public class EmployeeEntity
{
    /// <summary>
    /// 社員Id
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// 社員名
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// 部署Id
    /// </summary>
    [Column("dept_id")]
    public int DeptId { get; set; }

    /// <summary>
    /// 演習-12 employeeテーブルとdepartmentテーブルを結合可能にする
    /// 所属部署
    /// </summary>
    [ForeignKey("DeptId")]
    public DepartmentEntity? Department { get; set; }

    public override string? ToString()
    {
        return $"社員Id={Id} , 社員名={Name} , 部署Id={DeptId}";
    }
}
