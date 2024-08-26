namespace Blog.Domain.Exceptions;

public class BlogPostNotFoundException : Exception
{
    public BlogPostNotFoundException(string? message) : base(message)
    {
    }
}
