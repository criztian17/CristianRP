using CristianRP.BL.Interfaces;
using CristianRP.BL.Mappers;
using CristianRP.Common.Dtos;
using CristianRP.Repository.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CristianRP.BL.Implementations
{
    public class UserBL : IUserBL
    {
        #region Attributes
        private readonly IUserRepository _userRepository;
        #endregion


        #region Constructor
        public UserBL(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Public Methods
        public UserDto GetUserByLogin(string login)
        {
            try
            {
                var user = _userRepository.GetUserEntityByLogin(login);
                if (!user.Any())
                {
                    return new UserDto { Login = string.Empty , Pwd = string.Empty};
                }

                return user.FirstOrDefault().ToUserDtoMapper();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}
