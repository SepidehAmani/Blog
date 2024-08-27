using Blog.Domain.Entities;

namespace Blog.Domain.DTOs;

public class GetCommentDTO
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Context { get; set; }
    public DateTime CreatedTime { get; set; }
    public int BlogPostId { get; set; }
}
