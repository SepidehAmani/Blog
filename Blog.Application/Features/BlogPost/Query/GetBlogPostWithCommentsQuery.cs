using Blog.Domain.DTOs;
using MediatR;

namespace Blog.Application.Features.BlogPost.Query;

public class GetBlogPostWithCommentsQuery : IRequest<GetBlogPostWithCommentsDTO>
{
    public int Id { get; set; }
}
