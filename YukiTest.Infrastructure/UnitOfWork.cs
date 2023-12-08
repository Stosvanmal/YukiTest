using YukiTest.Domain.Interfaces;

namespace YukiTest.Infrastructure
{
    public class UnitOfWork:IUnitOfWork 
    {
        private readonly YukiContext yukiContext;

        public UnitOfWork(YukiContext yukiContext)
        {
            this.yukiContext = yukiContext;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await this.yukiContext.SaveChangesAsync();
        }
    }
}
