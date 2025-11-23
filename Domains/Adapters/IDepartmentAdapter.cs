using CS_DB_Exercise_Answer.Domains.Models;
namespace CS_DB_Exercise_Answer.Domains.Adapters;
/// <summary>
/// ドメインオブジェクトDepartmentと他の形式のオブジェクトとの
/// 相互変換を行うアダプターインターフェイス
/// </summary>
public interface IDepartmentAdapter<T>
{
    /// <summary>
    /// 外部オブジェクトからドメインオブジェクトDepartmentを復元する
    /// </summary>
    /// <param name="source">外部オブジェクト</param>
    /// <returns>ドメインオブジェクトDepartment</returns>
    Department ToDomain(T source);

    /// <summary>
    /// 外部オブジェクトのリストからドメインオブジェクトDepartmentのリストを復元する
    /// </summary>
    /// <param name="sources">外部オブジェクトのリスト</param>
    /// <returns>ドメインオブジェクトDepartmentのリスト</returns>
    List<Department> ToDomainList(List<T> sources);

    /// <summary>
    /// ドメインオブジェクトDepartmentから外部オブジェクトへ変換する
    /// </summary>
    /// <param name="department">ドメインオブジェクトDepartment</param>
    /// <returns>外部オブジェクト</returns>
    T FromDomain(Department department);

    /// <summary>
    /// ドメインオブジェクトDepartmentのリストから外部オブジェクトのリストへ変換する
    /// </summary>
    /// <param name="departments">ドメインオブジェクトDepartmentのリスト</param>
    /// <returns>外部オブジェクト</returns>
    List<T> FromDomainList(List<Department> departments);
}