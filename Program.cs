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
        var accessor = new EmployeeAccessor(context);

        Console.Write("キーワードを入力してください->");
        var keyword = Console.ReadLine();
        var employees = accessor.FindByContaintsName(keyword!);
        Console.WriteLine("演習-08 employeeテーブルから社員名の部分一致検索で該当社員を取得する");
        if (employees != null)
        {
            foreach(var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        else
        {
            Console.WriteLine($"キーワード:{keyword}が含まれる社員は存在しません");
        }
    }
}
