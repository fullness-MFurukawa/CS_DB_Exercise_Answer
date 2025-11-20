using CS_DB_Exercise_Answer.Infrastructures.Accessors;
using CS_DB_Exercise_Answer.Infrastructures.Contexts;
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
        
        Console.WriteLine("演習-11 指定された社員Idの社員を削除する\r\n");
        var result = employeeAccessor.DeleteById(empId);
        if (result == null)
        {
            Console.WriteLine($"社員Id:{empId}の社員は存在しないため削除できませんでした");
            return;
        }
        Console.WriteLine($"社員Id:{empId}の社員を削除しました");

    }
}
