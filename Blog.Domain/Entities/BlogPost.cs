using Blog.Domain.Exceptions;
using Blog.Domain.IRepositories;

namespace Blog.Domain.Entities;

public class BlogPost : IEntity
{
    public BlogPost(string title,string description, IBlogPostRepository blogPostRepository)
    {
        SetTitle(title, blogPostRepository);
        Description = description;
    }

    public int Id { get; set; }
    public string Title { get; private set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public IEnumerable<Comment>? Comments { get; set; }

    public void SetTitle(string title, IBlogPostRepository blogPostRepository)
    {
        var anotherBlogPostExists = blogPostRepository.BlogPostExists(x => x.Title == title);

        if (anotherBlogPostExists) throw new DuplicatedException("There is another Blog Post having this title");

        Title = title;
    }

    public void UpdateTitle(string title, IBlogPostRepository blogPostRepository)
    {
        var anotherBlogPostExists = blogPostRepository.BlogPostExists(x => x.Title == title && x.Id!=Id);

        if (anotherBlogPostExists) throw new DuplicatedException("There is another Blog Post having this title");

        Title = title;
    }
}
