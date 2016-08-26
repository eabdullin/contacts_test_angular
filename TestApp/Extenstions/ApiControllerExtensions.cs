using System.Web.Http;
using System.Web.Http.Results;
using BLL;
using Microsoft.AspNet.Identity;

namespace TestApp.Extenstions
{
    public static class ApiControllerExtensions
    {
        public static IHttpActionResult GetErrorResult(this ApiController controller, Result result)
        {
            if (result == null)
            {
                return new InternalServerErrorResult(controller);
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        controller.ModelState.AddModelError("", error);
                    }
                }

                if (controller.ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return new BadRequestResult(controller);
                }
                return new InvalidModelStateResult(controller.ModelState, controller);
            }

            return null;
        }
    }
}