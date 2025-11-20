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
        // employeeテーブルアクセスクラスを生成する
        var employeeAccessor = new EmployeeAccessor(context);

        Console.Write("社員Idを入力してください->");
        var empId = int.Parse(Console.ReadLine()!);
        Console.Write("社員名を入力してください->");
        var name = Console.ReadLine();
        Console.WriteLine("演習-10 指定された社員Idの社員名を変更する");
        var updateEployee = new EmployeeEntity
        {
            Id = empId,
            Name = name,
        };
        var result = employeeAccessor.UpdateById(updateEployee);
        if (result == null)
        {
            Console.WriteLine($"社員Id:{empId}の社員は存在しないため変更できませんでした");
            return;
        }
        Console.WriteLine($"社員名:を{result.Name}に変更しました");
    }
}
