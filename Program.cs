using CS_DB_Exercise_Answer.Infrastructures.Accessors;
using CS_DB_Exercise_Answer.Infrastructures.Contexts;
using CS_DB_Exercise_Answer.Infrastructures.Entities;
namespace CS_DB_Exercise_Answer;
class Program
{
    static void Main(string[] args)
    {
        // 演習用DbContextを生成する
        var context = new AppDbContext();
        // departmentテーブルアクセスクラスを生成する
        var departmentAccessor = new DepartmentAccessor(context);

        using var transaction = context.Database.BeginTransaction();   
        Console.WriteLine("トランザクションを開始しました。");
        Console.Write("新しい部署名を入力してください->");
        var name = Console.ReadLine();
        var entity = new DepartmentEntity{
            Id = 0,
            Name = name
        };
        var result = departmentAccessor.Create(entity);
        Console.WriteLine($"新しい部署を登録しました: 部署Id={result.Id} , 部署名={result.Name}");
        transaction.Commit();
        Console.WriteLine("トランザクションをコミットしました。");

        var departments = departmentAccessor.FindAll();
        foreach (var department in departments)
        {
            Console.WriteLine(department);
        }
    }
}
