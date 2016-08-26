using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace TestApp.Filters
{
    public class ValidationFiler : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException("actionContext");
            HttpRequestMessage request = actionContext.Request;
            if (request == null)
                throw new ArgumentException("context.request");

            if (!actionContext.ModelState.IsValid)
            {
                IHttpActionResult result = new InvalidModelStateResult(
                    actionContext.ModelState,
                    true,
                    actionContext.RequestContext.Configuration.Services.GetContentNegotiator(),
                    actionContext.Request,
                    actionContext.RequestContext.Configuration.Formatters);
                var response = result.ExecuteAsync(CancellationToken.None);
                actionContext.Response = response.Result;
                return;
            }
            base.OnActionExecuting(actionContext);
        }

        public override async Task OnActionExecutingAsync(HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            if (!actionContext.ModelState.IsValid)
            {
                IHttpActionResult result = new InvalidModelStateResult(
                    actionContext.ModelState,
                    true,
                    actionContext.RequestContext.Configuration.Services.GetContentNegotiator(),
                    actionContext.Request,
                    actionContext.RequestContext.Configuration.Formatters);
                actionContext.Response = await result.ExecuteAsync(cancellationToken);
                return;
            }
            await base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }

}