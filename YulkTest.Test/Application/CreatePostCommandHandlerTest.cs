using AutoFixture.Xunit2;
using MediatR;
using Moq;
using YukiTest.Application.Commands;
using YukiTest.Domain.Interfaces;
using YukiTest.Domain.Interfaces.Repos;
using YukiTest.Domain.Model;

namespace YulkTest.Test.Application
{
    public class CreatePostCommandHandlerTest
    {
        private readonly Mock<IMediator> mockMediator;
        private readonly Mock<IPostRepository> mockPostRepository;
        private readonly Mock<IAuthorRepository> mockAuthorRepository;
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly CreatePostCommandHandler handler;
        public CreatePostCommandHandlerTest()
        {
            mockMediator= new Mock<IMediator>();
            mockPostRepository = new Mock<IPostRepository>();
            mockAuthorRepository= new Mock<IAuthorRepository>();
            mockUnitOfWork= new Mock<IUnitOfWork>();
            handler = new CreatePostCommandHandler(mockPostRepository.Object,mockAuthorRepository.Object, mockUnitOfWork.Object);
        }
        [Theory, AutoData]
        public async Task CheckPostCommandHandler(CreatePostCommand createPostCommand)
        {
            //var req = createPostCommand.CreatePostRequest;
            //Author author = Author.Create(req.Author.Name, req.Author.Surname);
            //Post post = Post.CreatePost(req.Title,req.Description,req.Content,author);

            mockPostRepository.Setup(x => x.Add(It.IsAny<Post>()));
            mockUnitOfWork.Setup(x => x.SaveChangesAsync());

            var result = await handler.Handle(createPostCommand,CancellationToken.None);


            mockPostRepository.Verify(x => x.Add(It.IsAny<Post>()), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);

            
        }
    }
}
