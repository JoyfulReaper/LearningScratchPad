using DapperSlapper;
using DapperSlapper.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var services = ConfigureServices();
var serviceProvider = services.BuildServiceProvider();

await serviceProvider.GetRequiredService<ConsoleApplication>().Run();

static IServiceCollection ConfigureServices()
{
    IConfigurationBuilder configBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");
    IConfiguration configuration = configBuilder.Build();

    IServiceCollection services = new ServiceCollection();
    services.AddTransient<ConsoleApplication>();
    services.AddTransient<IDataAccess, SQLServerDataAccess>();
    services.AddSingleton(configuration);

    return services;
}