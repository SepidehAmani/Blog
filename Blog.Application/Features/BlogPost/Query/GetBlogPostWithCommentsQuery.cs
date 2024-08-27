using Blog.Domain.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Features.BlogPost.Query;

public class GetBlogPostWithCommentsQuery : IRequest<GetBlogPostWithCommentsDTO>
{
    public int Id { get; set; }
}
