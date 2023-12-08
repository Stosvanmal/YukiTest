using Microsoft.AspNetCore.Mvc;
using System.Net;
using YukiTest.Presentation.Bases;

namespace YukiTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ReturnOk<T>(Result<T> result)
        {
            if (result.Succeeded)
            {
                return Ok(result.Value);
            }

            return ReturnError(result);
        }

        protected IActionResult ReturnCreated<T>(Result<T> result)
        {
            if (result.Succeeded)
            {
                return Created("Get", new
                {
                    id = result.Value
                });
            }

            return ReturnError(result);
        }
        public IActionResult ReturnError<T>(Result<T> result)
        {            
            return result.Error.StatusCode switch
            {
                HttpStatusCode.BadRequest => BadRequest(),
                HttpStatusCode.Conflict => Conflict(),
                HttpStatusCode.Unauthorized => Unauthorized(),
                HttpStatusCode.Forbidden => Forbid(),
                _ => BadRequest(),
            };
        }

    }
}
