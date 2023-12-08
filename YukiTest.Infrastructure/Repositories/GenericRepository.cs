using YukiTest.Domain.Interfaces;
using YukiTest.Domain.Interfaces.Repos;

namespace YukiTest.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class,IEntity
    {
        protected readonly YukiContext yukiContext;

        public GenericRepository(YukiContext yukiContext)
        {
            this.yukiContext = yukiContext;
        }
        public virtual async Task Add(T entity)
        {
            await yukiContext.AddAsync(entity);
        }

        public virtual async Task<T> GetById(int id)
        {
            return await yukiContext.FindAsync<T>(id);
        }
    }
}
