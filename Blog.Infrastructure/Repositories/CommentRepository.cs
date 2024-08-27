using Blog.Domain.DependencyInjection;
using Blog.Domain.Entities;
using Blog.Domain.IRepositories;
using Blog.Infrastructure.DBContext;

namespace Blog.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository, IScopedDependency
{
    private readonly BlogDbContext _context;

    public CommentRepository(BlogDbContext context)
    {
        _context = context;
    }

    public void CreateComment(Comment comment)
    {
        _context.Set<Comment>().Add(comment);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
