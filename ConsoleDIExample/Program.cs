using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var serviceProvider = new ServiceCollection()
    .AddLogging()
    .BuildServiceProvider();

//configure console logging
serviceProvider
    .GetService<ILoggerFactory>()
    .AddConsole(LogLevel.Debug);