using System;
using System.Threading.Tasks;

namespace CristianRP.Repository.Repositories.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        DataContext DataContext { get; }

        Task<bool> CommitAsync();
    }
}
