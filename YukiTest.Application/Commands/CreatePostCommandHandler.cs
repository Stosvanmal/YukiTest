using MediatR;
using YukiTest.Domain.Interfaces;
using YukiTest.Domain.Interfaces.Repos;
using YukiTest.Domain.Model;

namespace YukiTest.Application.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IPostRepository postRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreatePostCommandHandler(IPostRepository postRepository,IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            this.postRepository = postRepository;
            this.authorRepository = authorRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Author author = await authorRepository.GetByNameAndSurname(request.CreatePostRequest.Author.Name, request.CreatePostRequest.Author.Surname);
            author ??= Author.Create(request.CreatePostRequest.Author.Name, request.CreatePostRequest.Author.Surname);
            Post post = Post.CreatePost(request.CreatePostRequest.Title, request.CreatePostRequest.Description,request.CreatePostRequest.Content, author);
            await postRepository.Add(post);
            await unitOfWork.SaveChangesAsync();
            return post.Id;
            
        }
    }
}
