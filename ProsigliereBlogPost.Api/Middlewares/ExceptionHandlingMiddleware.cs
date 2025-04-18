using System.Net;
using System.ComponentModel.DataAnnotations;
using ProsigliereBlogPost.Api.Extensions;

namespace ProsigliereBlogPost.Api.Middlewares
{
    internal sealed class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                await context.Response.SendErrorMessageAsync(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unexpected error occurred.");
#if DEBUG
                var message = ex.Message;
#else
                const string message = "Internal Server Error";
#endif
                await context.Response.SendErrorMessageAsync(HttpStatusCode.InternalServerError, message);
            }
        }
    }
}