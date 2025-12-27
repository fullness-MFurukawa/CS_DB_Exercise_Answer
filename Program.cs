using CS_DB_Exercise_Answer.Domains.Repositories;
using CS_DB_Exercise_Answer.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace CS_DB_Exercise_Answer;
class Program
{
    static void Main(string[] args)
    {
        var provider  = ServiceProviderBuilder.Build();
        var departmentRepository    = provider.GetRequiredService<IDepartmentRepository>();
        var employeeRepository      = provider.GetRequiredService<IEmployeeRepository>();
        Console.Write("部署番号を入力してください->");
        var departmentId = int.Parse(Console.ReadLine()!);
        var department = departmentRepository.FindById(departmentId);
        if (department is null)
        {
            Console.WriteLine("指定された部署は存在しません。");
            return;
        }
        else
        {
            Console.WriteLine($"部署Id:{department.Id},部署名:{department.Name}");
        }

        Console.Write("社員番号を入力してください->");
        var employeeId = int.Parse(Console.ReadLine()!);
        var employee = employeeRepository.FindById(employeeId);
        if (employee is null)
        {
            Console.WriteLine("指定された社員は存在しません。");
            return;
        }
        else
        {
            Console.WriteLine($"社員Id:{employee.Id},社員名:{employee.Name}");
        }
    }
}
