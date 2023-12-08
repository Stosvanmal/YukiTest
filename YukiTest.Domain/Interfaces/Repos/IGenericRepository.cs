namespace YukiTest.Domain.Interfaces.Repos
{
    public interface IGenericRepository<T> where T : IEntity
    {
        Task Add(T entity);
        Task<T> GetById(int id);
    }
}
