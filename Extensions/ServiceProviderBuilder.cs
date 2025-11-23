using CS_DB_Exercise_Answer.Domains.Adapters;
using CS_DB_Exercise_Answer.Domains.Repositories;
using CS_DB_Exercise_Answer.Infrastructures.Adapters;
using CS_DB_Exercise_Answer.Infrastructures.Contexts;
using CS_DB_Exercise_Answer.Infrastructures.Entities;
using CS_DB_Exercise_Answer.Infrastructures.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace CS_DB_Exercise_Answer.Extensions;
/// <summary>
/// DIコンテナを生成しServiceProviderを返すクラス
/// </summary>
public static class ServiceProviderBuilder
{
    /// <summary>
    /// IServiceProviderを生成して返す
    /// </summary>
    /// <returns></returns>
    public static IServiceProvider Build()
    {
        // IServiceCollectionインターフェイス実装クラスを生成する
        var services = new ServiceCollection();

        // AppDBContextクラスを生成して登録する
        services.AddDbContext<AppDbContext>();

        // IDepartmentAdapterインタフェース実装クラスを生成して登録する
        services.AddScoped<IDepartmentAdapter<DepartmentEntity>, DepartmentEntityAdapter>();
        // IEmployeeAdapterインタフェース実装クラスを生成して登録する
        services.AddScoped<IEmployeeAdapter<EmployeeEntity>, EmployeeEntityAdapter>();
        
        // IDepartmentRepositioryインターフェイス実装クラスを生成して登録する
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        // IEmployeeRepositioryインターフェイス実装クラスを生成して登録する
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        // IServiceProviderを生成して返す
        var provider = services.BuildServiceProvider();
        return provider;
    }
}