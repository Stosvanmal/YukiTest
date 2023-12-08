using Microsoft.EntityFrameworkCore;
using YukiTest.Application.Interfaces;
using YukiTest.Domain.Interfaces.Repos;
using YukiTest.Domain.Model;

namespace YukiTest.Infrastructure.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository, IPostRepositoryApp
    {    

        public PostRepository(YukiContext yukiContext):base(yukiContext) { }

        public async Task<Post> GetPostNoTracking(int id)
        {
            return await yukiContext.Posts.Include(x=> x.Author).AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);            
        }
    }
}
