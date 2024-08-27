using Blog.Domain.Entities;
using Blog.Domain.IRepositories;
using MediatR;

namespace Blog.Application.Features.BlogPost.Command;

public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, int>
{
    private readonly IBlogPostRepository blogPostRepository;

    public CreateBlogPostCommandHandler(IBlogPostRepository blogPostRepository)
    {
        this.blogPostRepository = blogPostRepository;
    }

    public async Task<int> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
    {
        var blogPost = new Blog.Domain.Entities.BlogPost(request.Title, request.Description, blogPostRepository);
        blogPostRepository.CreateBlogPost(blogPost);
        blogPostRepository.SaveChanges();
        return blogPost.Id;
    }
}
