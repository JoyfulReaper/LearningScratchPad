//https://cezarypiatek.github.io/post/why-i-dont-use-mediatr-for-cqrs/

using CQRS_No_MediatR;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private async static Task Main(string[] args)
    {
        IServiceProvider serviceProvider = Bootstrap.Init(args);
        IApplication app = serviceProvider.GetRequiredService<IApplication>();

        await app.Start();
    }
}