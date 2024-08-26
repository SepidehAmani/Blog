using Blog.Domain.IRepositories;
using Blog.Infrastructure.DBContext;

namespace Blog.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly BlogDbContext _context;

    public CommentRepository(BlogDbContext context)
    {
        _context = context;
    }


}
