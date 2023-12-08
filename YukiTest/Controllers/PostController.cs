using MediatR;
using Microsoft.AspNetCore.Mvc;
using YukiTest.Application.Commands;
using YukiTest.Application.Queries;
using YukiTest.Presentation.Bases;
using YukiTest.Presentation.Request;
using YukiTest.Presentation.Response;

namespace YukiTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseController
    {
        private readonly IMediator mediator;

        public PostController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetPost(int id) =>
            ReturnOk(Result<PostResponse>.Build(await mediator.Send(new GetPostQuery(id))));


        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> Post(CreatePostRequest request) =>
          ReturnCreated(Result<int>.Build(await mediator.Send(new CreatePostCommand(request))));

    }
}
