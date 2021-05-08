using CristianRP.Common.Dtos;
using System.Threading.Tasks;

namespace CristianRP.BL.Interfaces
{
    /// <summary>
    /// Security Business Logic Interface
    /// </summary>
    public interface ISecurityBL
    {
        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="user">UserDto object</param>
        /// <returns>TokenDto object</returns>
        Task<TokenDto> GenerateTokenAsync(UserDto user);
    }
}
