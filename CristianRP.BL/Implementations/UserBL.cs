using CristianRP.BL.Helpers;
using CristianRP.BL.Interfaces;
using CristianRP.Common.Dtos;
using CristianRP.Repository.Entities;
using CristianRP.Repository.Repositories.Interfaces;
using System;
using System.Linq;

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

                return MapperGenericHelper<UserEntity, UserDto>.ToMapper(user.FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}
