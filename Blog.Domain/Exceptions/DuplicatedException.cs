namespace Blog.Domain.Exceptions;

public class DuplicatedException : Exception
{
    public DuplicatedException(string? message) : base(message)
    {
    }
}
