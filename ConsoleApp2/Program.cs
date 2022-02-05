using ConsoleApp2;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<TestService>();
    })
    .Build();

Console.WriteLine("hi");

await host.RunAsync();