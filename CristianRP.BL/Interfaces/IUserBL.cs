using CristianRP.Common.Dtos;
using System.Threading.Tasks;

namespace CristianRP.BL.Interfaces
{
    /// <summary>
    /// IUserLogin Interface
    /// </summary>
    public interface IUserBL
    {
        /// <summary>
        /// Get an user by Login
        /// </summary>
        /// <param name="login">User Login Name</param>
        /// <returns>UserDto Object</returns>
        UserDto GetUserByLogin(string login);
    }
}
