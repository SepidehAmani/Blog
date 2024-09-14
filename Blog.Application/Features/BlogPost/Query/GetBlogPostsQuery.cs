using Blog.Domain.DTOs;
using MediatR;

namespace Blog.Application.Features.BlogPost.Query;

public class GetBlogPostsQuery : IRequest<ICollection<GetBlogpostDTO>>
{
}
