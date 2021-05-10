using CristianRP.BL.Interfaces;
using CristianRP.Common.Dtos;
using CristianRP.Common.Exceptions;
using CristianRP.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace CristianRP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        #region Attributes
        private readonly ISecurityBL _securityBL;
        #endregion

        #region Constructor
        public SecurityController(ISecurityBL security)
        {
            _securityBL = security;
        }

        #endregion

        #region Actions
        [HttpPost]
        [Route("GenerateToken")]
        [SwaggerOperation("Generate token")]
        [SwaggerResponse(200, type: typeof(TokenDto))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<TokenDto>> GetToken([FromBody] UserDto user)
        {
            try
            {
                return new JsonResult(await _securityBL.GenerateTokenAsync(user));
            }
            catch (Exception ex)
            {
                BusinessException businessException = (BusinessException)ex;
                if (!(ex is BusinessException))
                {
                    throw ex;
                }
                
                return await ActionResultExceptionHelper.ResultException(businessException, HttpContext);
            }
        }
        #endregion
    }
}
