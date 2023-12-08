using AutoMapper;
using YukiTest.Domain.Interfaces;
using YukiTest.Domain.Model;
using YukiTest.Presentation.Response;

namespace YukiTest.Application.Mappings
{
    public class PostMapping:Profile
    {
        public PostMapping()
        {
            CreateMap<Post, PostResponse>();
                //.ForMember(dest => dest., opt => opt.MapFrom(src => src.OrderTypeUId));
            CreateMap<Author, AuthorResponse>();
        }
    }
}
