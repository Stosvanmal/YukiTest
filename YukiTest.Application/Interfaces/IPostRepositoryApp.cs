using YukiTest.Domain.Model;

namespace YukiTest.Application.Interfaces
{
    public interface IPostRepositoryApp
    {
        Task<Post> GetPostNoTracking(int id);
    }
}
