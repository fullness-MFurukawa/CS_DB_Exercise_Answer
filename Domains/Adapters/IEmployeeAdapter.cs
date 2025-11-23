using CS_DB_Exercise_Answer.Domains.Models;
namespace CS_DB_Exercise_Answer.Domains.Adapters;
/// <summary>
/// ドメインオブジェクトEmployeeと他の形式のオブジェクトとの
/// 相互変換を行うアダプターインターフェイス
/// </summary>
public interface IEmployeeAdapter<T>
{
    /// <summary>
    /// 外部オブジェクトからドメインオブジェクトEmployeeを復元する
    /// </summary>
    /// <param name="source">外部オブジェクト</param>
    /// <returns>ドメインオブジェクトEmployee</returns>
    Employee ToDomain(T source);

    /// <summary>
    /// 外部オブジェクトのリストからドメインオブジェクトEmployeeのリストを復元する
    /// </summary>
    /// <param name="sources">外部オブジェクトのリスト</param>
    /// <returns>ドメインオブジェクトEmployeeのリスト</returns>
    List<Employee> ToDomainList(List<T> sources);

    /// <summary>
    /// ドメインオブジェクトEmployeeから外部オブジェクトへ変換する
    /// </summary>
    /// <param name="employee">ドメインオブジェクトEmployee</param>
    /// <returns>外部オブジェクト</returns>
    T FromDomain(Employee employee);

    /// <summary>
    /// ドメインオブジェクトEmployeeのリストから外部オブジェクトのリストへ変換する
    /// </summary>
    /// <param name="employees">ドメインオブジェクトEmployeeのリスト</param>
    /// <returns>外部オブジェクト</returns>
    List<T> FromDomainList(List<Employee> employees);
}