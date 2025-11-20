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
        var departmentAccessor = new DepartmentAccessor(context);

        Console.Write("社員名を入力してください->");
        var name = Console.ReadLine();
        Console.Write("部署Idを入力してください->");
        var deptId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("演習-09 employeeテーブルに新しい社員の情報を登録する");
        if ( departmentAccessor.FindById(deptId) == null)
        {
            Console.WriteLine($"部署Id:{deptId}は存在しないため、社員登録できません");
            return;
        }
        var newEployee = new EmployeeEntity
        {
            Name = name,
            DeptId = deptId
        };
        employeeAccessor.Create(newEployee);
        Console.WriteLine($"社員名:{name}、部署Id:{deptId}の社員を登録しました");
    }
}
