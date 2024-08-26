using Blog.Domain.DependencyInjection;
using Blog.Domain.Entities;
using Blog.Domain.IRepositories;
using Blog.Infrastructure.DBContext;
using System.Linq.Expressions;

namespace Blog.Infrastructure.Repositories;

public class BlogPostRepository : IBlogPostRepository,IScopedDependency
{
    private readonly BlogDbContext _context;

    public BlogPostRepository(BlogDbContext context)
    {
        _context = context;
    }

    public bool BlogPostExists(Expression<Func<BlogPost, bool>> predicate)
    {
        return _context.Set<BlogPost>().Where(predicate).Any();
    }
}
