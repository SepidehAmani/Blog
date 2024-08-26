using Blog.Domain.DependencyInjection;
using Blog.Domain.IRepositories;
using Blog.Infrastructure.DBContext;

namespace Blog.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository,IScopedDependency
{
    private readonly BlogDbContext _context;

    public CommentRepository(BlogDbContext context)
    {
        _context = context;
    }


}
