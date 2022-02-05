using GenericHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<TestService>();
    })
    .Build();

var app = ActivatorUtilities.CreateInstance<MyApp>(host.Services);
app.Run();