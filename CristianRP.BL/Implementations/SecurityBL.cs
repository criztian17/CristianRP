using CristianRP.BL.Helpers;
using CristianRP.BL.Interfaces;
using CristianRP.Common.Dtos;
using CristianRP.Common.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CristianRP.BL.Implementations
{
    public class SecurityBL : ISecurityBL
    {
        #region Attributes

        private readonly IUserBL _userBL;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public SecurityBL(IUserBL userBL, IConfiguration configuration)
        {
            _userBL = userBL;
            _configuration = configuration;
        }

        #endregion

        #region Public Methods

        public async Task<TokenDto> GenerateTokenAsync(UserDto user)
        {

            if (!ValidateDataToCreateToken(user))
            {
                throw new BusinessException(400, Constants.UserEmptyCredentialErrorMessage);
            }

            var userResult = _userBL.GetUserByLogin(user.Login);

            if (Utilities.Utilities.Decrypt(userResult.Pwd) != user.Pwd)
            {
                throw new BusinessException(400, Constants.UserCredentialErrorMessage);
            }

            return await Task.FromResult(CreateToken(user));


        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Validate if the Login and PWd are not empty or null
        /// </summary>
        /// <param name="user">Dto object</param>
        /// <returns>bool</returns>
        private bool ValidateDataToCreateToken(UserDto user)
        {
            if (!string.IsNullOrEmpty(user.Login) && !string.IsNullOrEmpty(user.Pwd))
            {
                return true;
            }

            return false;
        }

        private TokenDto CreateToken(UserDto user)
        {
            var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub , user.Login),
                    new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Tokens:Issuer"],
                _configuration["Tokens:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials);

            return new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = token.ValidTo
            };
        }

        #endregion
    }
}
