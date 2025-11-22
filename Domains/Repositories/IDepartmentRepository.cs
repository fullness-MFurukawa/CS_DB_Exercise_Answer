using CS_DB_Exercise_Answer.Domains.Models;
namespace CS_DB_Exercise_Answer.Domains.Repositories;
/// <summary>
/// 部署をCRUD操作するRepositoryインターフェイス
/// </summary>
public interface IDepartmentRepository
{
    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    /// <returns></returns>
    List<Department> FindAll();

    /// <summary>
    /// 部署Idで部署を取得する
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <returns></returns>
    Department? FindById(int id);

    /// <summary>
    /// 新しい部署を永続化する
    /// </summary>
    /// <param name="department"></param>
    void Create(Department department);

    /// <summary>
    /// 部署名を変更する
    /// </summary>
    /// <param name="department">変更部署</param>
    /// <returns>true:変更成功 false:変更対象部署が存在しない</returns>
    bool UpdateById(Department department);

    /// <summary>
    /// 指定された部署Idの部署を削除する
    /// </summary>
    /// <param name="id">削除対象の部署Id</param>
    /// <returns>true:削除成功 false:削除対象部署が存在しない</returns>
    bool DeleteById(int id);
}