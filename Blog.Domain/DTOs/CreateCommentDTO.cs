using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.DTOs;

public class CreateCommentDTO
{
    public string UserName { get; set; }
    public string Context { get; set; }
    [Required]
    public int BlogPostId { get; private set; }
}
