using MediatR;
using YukiTest.Presentation.Response;

namespace YukiTest.Application.Queries
{
    public record GetPostQuery(int Id):IRequest<PostResponse>
    {
    }
}
