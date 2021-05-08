using CristianRP.Repository.Entities;
using CristianRP.Repository.Repositories.Interfaces;

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
        #endregion
    }
}
