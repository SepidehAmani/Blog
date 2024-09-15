using Asp.Versioning;
using Blog.Application.Features.BlogPost.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BlogController : v1.BlogController
    {
        public BlogController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public override async Task<IActionResult> CreateBlogPost(CreateBlogPostCommand createBlogPostCommand)
        {
            return await base.CreateBlogPost(createBlogPostCommand);
        }
    }
}
