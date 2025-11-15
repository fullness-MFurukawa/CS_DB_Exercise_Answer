using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CS_DB_Exercise_Answer.Infrastructures.Entities;
/// <summary>
/// 演習-03 Entityクラスを実装する
/// departmentテーブルとマッピングするエンティティクラス
/// </summary>
[Table("department")]
public class DepartmentEntity
{
    /// <summary>
    /// 部署Id
    /// </summary>
    [Key]
    public int Id       { get; set; }
    /// <summary>
    /// 部署名
    /// </summary>
    public string? Name { get; set; }

    public override string? ToString()
    {
        return $"部署Id={Id} , 部署名={Name}";
    }
}
