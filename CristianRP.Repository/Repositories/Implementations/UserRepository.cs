using CristianRP.Repository.Entities;
using CristianRP.Repository.Repositories.Interfaces;
using System.Linq;

namespace CristianRP.Repository.Repositories.Implementations
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        #region Attibutes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IQueryable<UserEntity> GetUserEntityByLogin(string login)
        {
            try
            {
                return _unitOfWork.DataContext.Users.Where(u => u.Login == login);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
