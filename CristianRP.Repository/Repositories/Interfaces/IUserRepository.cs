using CristianRP.Repository.Entities;
using System.Linq;

namespace CristianRP.Repository.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        /// <summary>
        /// Get an user by login
        /// </summary>
        /// <param name="login">User Login Name</param>
        /// <returns>UserEntity object</returns>
        IQueryable<UserEntity> GetUserEntityByLogin(string login);
    }
}
