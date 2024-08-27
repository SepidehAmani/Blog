using AutoMapper;
using Blog.Domain.DTOs;
using Blog.Domain.IRepositories;
using MediatR;

namespace Blog.Application.Features.BlogPost.Query;

public class GetBlogPostWithCommentsQueryHandler : IRequestHandler<GetBlogPostWithCommentsQuery, GetBlogPostWithCommentsDTO>
{
    private readonly IMapper mapper;
    private readonly IBlogPostRepository blogPostRepository;

    public GetBlogPostWithCommentsQueryHandler(IMapper mapper,IBlogPostRepository blogPostRepository)
    {
        this.mapper = mapper;
        this.blogPostRepository = blogPostRepository;
    }

    public async Task<GetBlogPostWithCommentsDTO> Handle(GetBlogPostWithCommentsQuery request, CancellationToken cancellationToken)
    {
        var blogPost = blogPostRepository.GetbyId(request.Id);
        var dto = mapper.Map<GetBlogPostWithCommentsDTO>(blogPost);
        return dto;
    }
}
