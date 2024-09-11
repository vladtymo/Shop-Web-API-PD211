using Core.Exceptions;
using System.Globalization;

namespace WebApiServer_PD211.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Call the next delegate/middleware in the pipeline.
                await _next(context);
            }
            catch (HttpException ex)
            {
                context.Response.StatusCode = (int)ex.StatusCode;
                await context.Response.WriteAsJsonAsync(new { ex.Message, Status = (int)ex.StatusCode });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(new { ex.Message, Status = 404 });
            }
        }
    }
}
