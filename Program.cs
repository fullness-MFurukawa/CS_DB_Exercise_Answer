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
        var accessor = new DepartmentAccessor(context);

        Console.Write("部署Idを入力してください->");
        var deptId = int.Parse(Console.ReadLine()!);
        var department = accessor.FindById(deptId);
        Console.WriteLine("演習-06 departmentテーブルから主キー値で部署を取得する");
        if (department != null)
        {
            Console.WriteLine(department);
        }
        else
        {
            Console.WriteLine($"部署Id:{deptId}の部署は存在しません");
        }
    }
}
