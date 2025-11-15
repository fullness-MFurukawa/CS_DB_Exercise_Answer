using CS_DB_Exercise_Answer.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace CS_DB_Exercise_Answer.Infrastructures.Contexts;

/// <summary>
/// 演習-04 DBContext継承クラスとプロパティを実装する
/// </summary>
public class AppDbContext : DbContext
{
    // departmentテーブルにアクセスするプロパティ
    public DbSet<DepartmentEntity> Departments { get; set; }
    // employeeテーブルにアクセスするプロパティ
    public DbSet<EmployeeEntity> Employees { get; set; }
    
    /// <summary>
    /// DbContextの構成処理をする
    /// データベース接続情報の設定や、SQLログ出力の有効化する
    /// </summary>
    /// <param name="optionsBuilder">
    /// DbContextの動作設定を構築するためのオプションビルダーオブジェクト
    /// 接続先データベースやログ設定などを定義
    /// </param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // 接続文字列（サーバー名、DB名、ユーザー名、パスワード）
        string connectionString =
        "Server=localhost;Database=cs_db_exercise;User=root;Password=root;";

        optionsBuilder
        // MySQLデータベースに接続する設定
        .UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 43)))
        // 実行されたSQLをコンソールに表示する
        .LogTo(Console.WriteLine, LogLevel.Information)
        // パラメーターの値もログに表示する
        .EnableSensitiveDataLogging();
    }
}
