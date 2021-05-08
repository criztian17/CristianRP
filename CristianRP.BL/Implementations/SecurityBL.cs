using CristianRP.BL.Interfaces;
using CristianRP.Common.Dtos;
using System;
using System.Threading.Tasks;

namespace CristianRP.BL.Implementations
{
    public class SecurityBL : ISecurityBL
    {
        public Task<TokenDto> GenerateTokenAsync(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
