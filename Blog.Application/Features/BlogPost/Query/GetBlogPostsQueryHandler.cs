using AutoMapper;
using Blog.Domain.DTOs;
using Blog.Domain.IRepositories;
using MediatR;

namespace Blog.Application.Features.BlogPost.Query;

public class GetBlogPostsQueryHandler : IRequestHandler<GetBlogPostsQuery, ICollection<GetBlogpostDTO>>
{
    private readonly IMapper mapper;
    private readonly IBlogPostRepository blogPostRepository;

    public GetBlogPostsQueryHandler(IMapper mapper,IBlogPostRepository blogPostRepository)
    {
        this.mapper = mapper;
        this.blogPostRepository = blogPostRepository;
    }

    public async Task<ICollection<GetBlogpostDTO>> Handle(GetBlogPostsQuery request, CancellationToken cancellationToken)
    {
        var blogPosts = blogPostRepository.GetAll();
        var dtos = mapper.Map<ICollection<GetBlogpostDTO>>(blogPosts);
        return dtos;
    }
}
