using CristianRP.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CristianRP.WebApi.Helpers
{
    public static class ActionResultException
    {
        public static async Task<ActionResult> ResultException(BusinessException businessException , HttpContext httpContext)
        {
            httpContext.Response.StatusCode = businessException.StatusCode;
            return new JsonResult(await Task.FromResult(businessException.Result));
        }
    }
}
