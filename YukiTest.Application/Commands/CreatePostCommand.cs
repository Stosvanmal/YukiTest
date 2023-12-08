using MediatR;
using YukiTest.Presentation.Request;

namespace YukiTest.Application.Commands
{
    public record CreatePostCommand(CreatePostRequest CreatePostRequest):IRequest<int>
    {
    }
}
