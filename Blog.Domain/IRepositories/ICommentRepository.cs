using Blog.Domain.Entities;

namespace Blog.Domain.IRepositories;

public interface ICommentRepository
{
    void CreateComment(Comment comment);
    void SaveChanges();
}
