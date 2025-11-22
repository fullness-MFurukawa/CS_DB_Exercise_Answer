namespace CS_DB_Exercise_Answer.Domains.Exceptions;
/// <summary>
/// 業務制約違反を表す例外クラス
/// </summary>
public class DomainException : Exception
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public DomainException(){}
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="message">エラーメッセージ</param>
    public DomainException(string? message) : base(message){}
}