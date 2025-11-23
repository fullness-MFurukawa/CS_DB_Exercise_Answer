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
        Console.Write("社員名を入力してください->");
        var name = Console.ReadLine();
        var results = employeeAccessor.FindByNameContainsJoinDepartment(name!);
        if (results == null)
        {
            Console.WriteLine($"{name}さんは、存在しません。");
        }
        else
        {
            foreach (var result in results)
            {
                Console.WriteLine($"{name}さんは、{result.Department!.Name}に   所属する社員です。");
            }
        }
    }
}
