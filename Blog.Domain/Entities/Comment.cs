using Blog.Domain.Exceptions;
using Blog.Domain.IRepositories;

namespace Blog.Domain.Entities;

public class Comment : IEntity
{
    public Comment(int blogPostId,string userName,string context, IBlogPostRepository blogPostRepository)
    {
        SetBlogPostId(blogPostId, blogPostRepository);
        UserName = userName;
        Context = context;
    }

    public int Id { get; set; }
    public string UserName { get; set; }
    public string Context { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public int BlogPostId { get; private set; }

    private void SetBlogPostId(int blogPostId, IBlogPostRepository blogPostRepository)
    {
        var blogPostExists = blogPostRepository.BlogPostExists(x => x.Id == blogPostId);

        if (!blogPostExists) throw new BlogPostNotFoundException("There is no Blog Post having this Id");

        BlogPostId = blogPostId;
    }
}
