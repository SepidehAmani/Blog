using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Security.Principal;

namespace Blog.Infrastructure.DBContext;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        RegisterEntities(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);
    }

    private void RegisterEntities(ModelBuilder builder)
    {
        var entityAssembly = Assembly.Load("Blog.Domain");
        var entityTypes = entityAssembly.GetTypes()
            .Where(t => typeof(IEntity).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

        foreach (var entityType in entityTypes)
        {
            if (builder.Model.FindEntityType(entityType) == null)
            {
                builder.Model.AddEntityType(entityType);
            }
        }
    }
}
