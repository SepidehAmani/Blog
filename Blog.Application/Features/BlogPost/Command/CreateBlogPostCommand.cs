using MediatR;

namespace Blog.Application.Features.BlogPost.Command
{
    public class CreateBlogPostCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
