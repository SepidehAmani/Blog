using Blog.Domain.Entities;
using Blog.Domain.IRepositories;
using MediatR;

namespace Blog.Application.Features.BlogPost.Command;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
{
    private readonly ICommentRepository commentRepository;
    private readonly IBlogPostRepository blogPostRepository;

    public CreateCommentCommandHandler(ICommentRepository commentRepository,IBlogPostRepository blogPostRepository)
    {
        this.commentRepository = commentRepository;
        this.blogPostRepository = blogPostRepository;
    }


    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new Comment(request.BlogPostId, request.UserName, request.Context, blogPostRepository);

        commentRepository.CreateComment(comment);
        commentRepository.SaveChanges();
    }
}
