using CristianRP.BL.Interfaces;
using CristianRP.Common.Dtos;
using CristianRP.Common.Exceptions;
using CristianRP.WebApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CristianRP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {
        #region Attributes
        private readonly IPropertyBL _propertyBl;
        #endregion

        #region Constructor
        public PropertyController(IPropertyBL propertyBL)
        {
            _propertyBl = propertyBL;
        }
        #endregion

        #region Actions
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        [Route("CreatePropertyAsync")]
        [SwaggerOperation("Create Property")]
        [SwaggerResponse(200, type: typeof(PropertyDto))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<PropertyDto>> CreatePropertyAsync([FromBody] PropertyDto property)
        {
            try
            {
                return new JsonResult(await _propertyBl.CreatePropertyAsync(property));
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete]
        [Route("DeletePropertyAsync")]
        [SwaggerOperation("Delete Property")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> DeletePropertyAsync([FromBody] PropertyDto property)
        {
            try
            {
                return new JsonResult(await _propertyBl.DeletePropertyAsync(property));
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "External,Regular,Admin")]
        [HttpGet]
        [Route("GetAllPropertiesAsync")]
        [SwaggerOperation("Get All Properties")]
        [SwaggerResponse(200, type: typeof(ICollection<PropertyDto>))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<ICollection<PropertyDto>>> GetAllPropertiesAsync()
        {
            try
            {
                return new JsonResult(await _propertyBl.GetAllPropertiesAsync());
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "External,Regular,Admin")]
        [HttpGet]
        [Route("GetPropertyByIdAsync/{id}")]
        [SwaggerOperation("Get Property")]
        [SwaggerResponse(200, type: typeof(PropertyDto))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<PropertyDto>> GetPropertyByIdAsync(int id)
        {
            try
            {
                return new JsonResult(await _propertyBl.GetPropertyByIdAsync(id));
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Regular,Admin")]
        [HttpPut]
        [Route("UpdatePropertyAsync")]
        [SwaggerOperation("Get Property")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> UpdatePropertyAsync([FromBody] PropertyDto property)
        {
            try
            {
                return new JsonResult(await _propertyBl.UpdatePropertyAsync(property));
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
