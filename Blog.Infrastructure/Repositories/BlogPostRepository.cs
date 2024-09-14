using Blog.Domain.DependencyInjection;
using Blog.Domain.Entities;
using Blog.Domain.IRepositories;
using Blog.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
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

    public void CreateBlogPost(BlogPost blogPost)
    {
        _context.Add(blogPost);
    }

    public void UpdateBlogPost(BlogPost blogPost)
    {
        _context.Update(blogPost);
    }

    public void DeleteBlogPost(BlogPost blogPost)
    {
        _context.Remove(blogPost);
    }

    public void SaveChanges() 
    {
        _context.SaveChanges();
    }

    public BlogPost GetbyId(int id)
    {
        return _context.Set<BlogPost>().Where(x => x.Id == id).Include(x=> x.Comments).First();
    }

    public ICollection<BlogPost> GetAll()
    {
        return _context.Set<BlogPost>().ToList();
    }
}
