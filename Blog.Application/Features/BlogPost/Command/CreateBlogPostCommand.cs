using Blog.Domain.DTOs;
using Blog.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Features.BlogPost.Command
{
    public class CreateBlogPostCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
