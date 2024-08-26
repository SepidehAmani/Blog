using Blog.Domain.Entities;
using System.Linq.Expressions;

namespace Blog.Domain.IRepositories;

public interface IBlogPostRepository
{
    bool BlogPostExists(Expression<Func<BlogPost, bool>> predicate);
}
