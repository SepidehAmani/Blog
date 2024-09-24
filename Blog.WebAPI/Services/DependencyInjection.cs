using Blog.Domain.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Scrutor;

namespace Blog.WebAPI.Services;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {

        services.Scan(scan => scan.FromDependencyContext(DependencyContext.Default, a => !a.FullName.Contains("Microsoft.Data.SqlClient") 
                && a.DefinedTypes.Any(a => a is { IsClass: true, IsAbstract: false }
                && a.IsAssignableTo(typeof(ILifeTime))))
            .AddClassesFromInterfaces());
        return services;
    }

    private static IImplementationTypeSelector AddClassesFromInterfaces(this IImplementationTypeSelector selector)
    {

        selector.AddClasses(c => c.AssignableTo<IScopedDependency>())
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithScopedLifetime()

            .AddClasses(c => c.AssignableTo<ITransientDependency>())
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithTransientLifetime()

            .AddClasses(c => c.AssignableTo<ISingletonDependency>())
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithSingletonLifetime();

        return selector;
    }
   
}
