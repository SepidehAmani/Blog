using Asp.Versioning;
using Blog.Application.Features.BlogPost.Command;
using Blog.Application.Features.BlogPost.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator mediator;

        public BlogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAllBlogPosts()
        {
            var dto = await mediator.Send(new GetBlogPostsQuery());
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPost(int id)
        {
            var dto = await mediator.Send(new GetBlogPostWithCommentsQuery { Id = id });
            return Ok(dto);
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateBlogPost(CreateBlogPostCommand createBlogPostCommand)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var blogPostId = await mediator.Send(createBlogPostCommand);
            return Ok(blogPostId);
        }

        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(CreateCommentCommand createCommentCommand)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await mediator.Send(createCommentCommand);
            return Ok();
        }        
    }
}
