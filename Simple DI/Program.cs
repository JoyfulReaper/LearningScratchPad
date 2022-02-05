// https://medium.com/swlh/how-to-take-advantage-of-dependency-injection-in-net-core-2-2-console-applications-274e50a6c350

using Microsoft.Extensions.DependencyInjection;
using Simple_DI;

var services = ConfigureServices();
var serviceProvider = services.BuildServiceProvider();
serviceProvider.GetRequiredService<ConsoleApplication>().Run();

static IServiceCollection ConfigureServices()
{
    IServiceCollection services = new ServiceCollection();
    services.AddTransient<ITestService, TestService>();
    services.AddTransient<ConsoleApplication>();

    return services;
}