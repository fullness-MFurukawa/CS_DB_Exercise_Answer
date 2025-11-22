using CS_DB_Exercise_Answer.Domains.Exceptions;
namespace CS_DB_Exercise_Answer.Domains.Models;
/// <summary>
/// 部署を表すドメインオブジェクト
/// </summary>
public class Department : IEquatable<Department>
{
    /// <summary>
    /// 部署Id
    /// </summary>
    public int Id { get; private set; } = 0;
    /// <summary>
    /// 部署名
    /// </summary>
    public string? Name { get; private set; } = string.Empty;
    /// <summary>
    /// 部署に所属する社員
    /// </summary>
    public List<Employee>? Employees { get; private set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <param name="name">部署名</param>
    /// <param name="employees">部署に所属する社員</param>
    public Department(int id, string? name , List<Employee>? employees)
    {
        Id = id;
        ChangeName(name!);
        ChangeEmployees(employees);
    }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="name">部署名</param>
    /// <param name="employees">部署に所属する社員</param>
    public Department(string? name, List<Employee>? employees):this(0, name, employees) { }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="name">部署名</param>
    public Department(string? name):this(0, name, null) { }

    /// <summary>
    /// 部署名を変更する
    /// </summary>
    /// <param name="name">変更部署名</param>
    public void ChangeName(string name)
    {
        // 部署名がnullまたは空の場合は例外をスロー
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("部署名は必須です。");
        // 部署名が20文字以内でない場合は例外をスロー
        if (name.Length > 20)
        {
            throw new DomainException("部署名は20文字以内です。");
        }
        Name = name;
    }
    
    /// <summary>
    /// 部署に所属する社員を変更する
    /// </summary>
    /// <param name="employees"></param>
    public void ChangeEmployees(List<Employee>? employees)
    {
        Employees = employees;
    }

    /// <summary>
    /// 部署Idの等価性検証
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(Department? other)
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
        return $"部署Id:{Id}, 部署名:{Name}, 部署に所属する社員:{Employees}";
    }
}