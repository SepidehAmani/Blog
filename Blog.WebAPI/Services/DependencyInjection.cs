using Blog.Domain.DependencyInjection;
using Scrutor;

namespace Blog.WebAPI.Services;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.ManageScopedDependencies();
        services.ManageTransientDependencies();
        services.ManageSingletonDependencies();
        return services;
    }

    private static IServiceCollection ManageScopedDependencies(this IServiceCollection services)
    {
        return services.Scan(selector => selector
            .FromApplicationDependencies(a => !a.FullName.Contains("Microsoft.Data.SqlClient"))
            .AddClasses(c => c.AssignableTo<IScopedDependency>())
            .UsingRegistrationStrategy(RegistrationStrategy.Throw)
            .AsMatchingInterface()
            .WithScopedLifetime());
    }

    private static IServiceCollection ManageTransientDependencies(this IServiceCollection services)
    {
        return services.Scan(selector => selector
            .FromApplicationDependencies(a => !a.FullName.Contains("Microsoft.Data.SqlClient"))
            .AddClasses(c => c.AssignableTo<ITransientDependency>())
            .UsingRegistrationStrategy(RegistrationStrategy.Throw)
            .AsMatchingInterface()
            .WithTransientLifetime());
    }

    private static IServiceCollection ManageSingletonDependencies(this IServiceCollection services)
    {
        return services.Scan(selector => selector
            .FromApplicationDependencies(a => !a.FullName.Contains("Microsoft.Data.SqlClient"))
            .AddClasses(c => c.AssignableTo<ISingletonDependency>())
            .UsingRegistrationStrategy(RegistrationStrategy.Throw)
            .AsMatchingInterface()
            .WithSingletonLifetime());
    }
}
