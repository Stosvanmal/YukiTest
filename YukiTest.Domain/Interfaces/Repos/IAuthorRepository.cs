using YukiTest.Domain.Model;

namespace YukiTest.Domain.Interfaces.Repos
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author> GetByNameAndSurname(string name, string surname);
    }
}
