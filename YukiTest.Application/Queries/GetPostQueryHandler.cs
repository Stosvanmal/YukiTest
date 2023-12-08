using AutoMapper;
using MediatR;
using YukiTest.Application.Interfaces;
using YukiTest.Presentation.Response;

namespace YukiTest.Application.Queries
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostResponse>
    {
        private readonly IPostRepositoryApp postRepositoryApp;
        private readonly IMapper mapper;

        public GetPostQueryHandler(IPostRepositoryApp postRepositoryApp, IMapper mapper)
        {
            this.postRepositoryApp = postRepositoryApp;
            this.mapper = mapper;
        }
        public async Task<PostResponse> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {           
           return mapper.Map<PostResponse>(await postRepositoryApp.GetPostNoTracking(request.Id));
        }
    }
}
