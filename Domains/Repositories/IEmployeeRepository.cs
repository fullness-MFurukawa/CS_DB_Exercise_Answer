using CS_DB_Exercise_Answer.Domains.Models;
namespace CS_DB_Exercise_Answer.Domains.Repositories;
/// <summary>
/// 部署をCRUD操作するリポジトリインターフェイス
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// すべての社員を取得する
    /// </summary>
    /// <returns></returns>
    List<Employee> FindAll();

    /// <summary>
    /// 社員Idで社員を取得する
    /// </summary>
    /// <param name="id">社員Id</param>
    /// <returns></returns>
    Employee? FindById(int id);

    /// <summary>
    /// 新しい社員を永続化する
    /// </summary>
    /// <param name="employee"></param>
    void Create(Employee employee);

    /// <summary>
    /// 社員名を変更する
    /// </summary>
    /// <param name="employee">変更社員</param>
    /// <returns>true:変更成功 false:変更対象社員が存在しない</returns>
    bool UpdateById(Employee employee);

    /// <summary>
    /// 指定された社員Idの社員を削除する
    /// </summary>
    /// <param name="id">削除対象の社員Id</param>
    /// <returns>true:削除成功 false:削除対象社員が存在しない</returns>
    bool DeleteById(int id);
}