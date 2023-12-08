using Microsoft.EntityFrameworkCore;
using YukiTest.Domain.Interfaces.Repos;
using YukiTest.Domain.Model;

namespace YukiTest.Infrastructure.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {       

        public AuthorRepository(YukiContext yukiContext):base(yukiContext) { }

        public async Task<Author> GetByNameAndSurname(string name, string surname)
        {
            return await yukiContext.Authors.FirstOrDefaultAsync(x => x.Name == name && x.Surname == surname);
        }
    }
}
