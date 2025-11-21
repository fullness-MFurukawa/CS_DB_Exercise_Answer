using CS_DB_Exercise_Answer.Infrastructures.Accessors;
using CS_DB_Exercise_Answer.Infrastructures.Contexts;
namespace CS_DB_Exercise_Answer;
class Program
{
    static void Main(string[] args)
    {
        // 演習用DbContextを生成する
        var context = new AppDbContext();
        // departmentテーブルアクセスクラスを生成する
        var departmentAccessor = new DepartmentAccessor(context);

        Console.Write("部署Idを入力してください->");
        var deptId = int.Parse(Console.ReadLine()!);
        
        Console.WriteLine("演習-14 指定された部署Idの部署と所属社員を取得する");
        var result = departmentAccessor.FindByIdJoinEmployee(deptId);
        if (result == null)
        {
            Console.WriteLine($"部署Id:{deptId}の部署は存在しませんでした");
            return;
        }
        Console.WriteLine(result);
        foreach(var employee in result.Employees!)
        {
            Console.WriteLine(employee);
        }
    }
}
