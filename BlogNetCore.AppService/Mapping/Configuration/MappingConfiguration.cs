using AutoMapper;
using BlogNetCore.AppService.Domain;
using BlogNetCore.AppService.DTO;

namespace BlogNetCore.AppService.Mapping.Configuration
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<CategoryDto, Category>();

            CreateMap<Post, PostDto>()
                .ForMember(des => des.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                .ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();

            CreateMap<Comment, CommentDto>()
                .ForMember(des => des.PostCategory, opt => opt.MapFrom(src => src.Post.Category.Name))
                .ForMember(des => des.PostTitle, opt => opt.MapFrom(src => src.Post.Title))
                .ReverseMap();
        }
    }
}
