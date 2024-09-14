using AutoMapper;
using Blog.Domain.DTOs;
using Blog.Domain.Entities;

namespace Blog.Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Comment, GetCommentDTO>();
        CreateMap<BlogPost, GetBlogPostWithCommentsDTO>()
            .ForMember(des => des.Comments, opt => opt.MapFrom(src => src.Comments));

        CreateMap<BlogPost, GetBlogpostDTO>();
    }
}
