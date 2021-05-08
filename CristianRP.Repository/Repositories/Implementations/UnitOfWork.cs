using CristianRP.Repository.Repositories.Interfaces;
using System.Threading.Tasks;

namespace CristianRP.Repository.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext DataContext { get; }

        public UnitOfWork(DataContext dataContext)
        {
            DataContext = dataContext;
        }
        public async Task<bool> CommitAsync()
        {
            return await DataContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }
    }
}
