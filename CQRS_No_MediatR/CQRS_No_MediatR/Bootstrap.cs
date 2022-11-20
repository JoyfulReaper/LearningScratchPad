using CQRS_No_MediatR.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_No_MediatR;
internal class Bootstrap
{
    internal static IServiceProvider Init(string[] args)
    {
        IServiceCollection services = new ServiceCollection();

        services.TryAddSingleton<IApplication, Application>();
        services.TryAddSingleton<IPersonRepo, PersonRepo>();

        services.TryAddSingleton<ICommandDispatcher, CommandDispatcher>();
        services.TryAddSingleton<IQueryDispatcher, QueryDispatcher>();

        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(IQueryHandler<,>));
                    })
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime();
        });
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(ICommandHandler<,>));
                    })
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime();
        });

        return services.BuildServiceProvider();
    }
}
