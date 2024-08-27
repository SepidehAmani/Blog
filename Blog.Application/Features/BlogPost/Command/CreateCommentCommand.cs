using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Features.BlogPost.Command;

public class CreateCommentCommand : IRequest
{
    public string UserName { get; set; }
    public string Context { get; set; }
    [Required]
    public int BlogPostId { get; set; }
}
