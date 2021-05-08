using CristianRP.Repository.Entities;
using CristianRP.Repository.Repositories.Interfaces;

namespace CristianRP.Repository.Repositories.Implementations
{
    public class PropertyRepository : GenericRepository<PropertyEntity>, IPropertyRepository
    {
        #region Attibutes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public PropertyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        #endregion
    }
}
