using Blog.Domain.Entities;
using System.Linq.Expressions;

namespace Blog.Domain.IRepositories;

public interface IBlogPostRepository
{
    bool BlogPostExists(Expression<Func<BlogPost, bool>> predicate);
    void CreateBlogPost(BlogPost blogPost);
    void UpdateBlogPost(BlogPost blogPost);
    void DeleteBlogPost(BlogPost blogPost);
    void SaveChanges();
    BlogPost GetbyId(int id);
    ICollection<BlogPost> GetAll();
}
