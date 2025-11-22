using CS_DB_Exercise_Answer.Domains.Exceptions;
namespace CS_DB_Exercise_Answer.Domains.Models;
/// <summary>
/// 社員を表すドメインオブジェクト
/// </summary>
public class Employee : IEquatable<Employee>
{
    /// <summary>
    /// 社員Id
    /// </summary>
    public int Id { get; private set; } = 0;
    /// <summary>
    /// 社員名
    /// </summary>
    public string? Name { get; private set; } = string.Empty;
    /// <summary>
    /// 所属部署
    /// </summary>
    public Department? Department { get; private set; }
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id">社員Id</param>
    /// <param name="name">社員名</param>
    /// <param name="department">所属部署</param>
    public Employee(int id, string? name, Department? department)
    {
        Id = id;
        ChangeName(name);
        ChangeDepartment(department);
    }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="name">社員名</param>
    /// <param name="department">所属部署</param>
    public Employee(string? name, Department? department):this(0, name, department) { }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="name">社員名</param>
    public Employee(string? name):this(0, name, null) { }

    /// <summary>
    /// 社員名を変更する
    /// </summary>
    /// <param name="name">変更社員名</param>
    public void ChangeName(string? name)
    {
        // 社員名がnullまたは空の場合は例外をスロー
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("社員名は必須です。");
        // 社員名が20文字以内でない場合は例外をスロー
        if (name.Length > 20)
        {
            throw new DomainException("社員名は20文字以内です。");
        }
        Name = name;
    }
    /// <summary>
    /// 所属部署を変更する
    /// </summary>
    /// <param name="department"></param>
    public void ChangeDepartment(Department? department)
    {
        Department = department;
    }

    /// <summary>
    /// 社員Idの等価性検証
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(Employee? other)
    {
        if (other is null) return false;
        return this.Id == other.Id;
    }

    /// <summary>
    /// プロパティの値を文字列に変換する
    /// </summary>
    /// <returns></returns>
    public override string? ToString()
    {
        return $"社員Id:{Id}, 社員名:{Name}, 所属部署:{Department}";
    }
}