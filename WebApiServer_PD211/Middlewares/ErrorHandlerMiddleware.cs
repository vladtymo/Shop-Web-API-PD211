using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
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
                SendResponse(context, ex.Message, (int)ex.StatusCode);
            }
            catch (Exception ex)
            {
                SendResponse(context, ex.Message);
            }
        }

        private async void SendResponse(HttpContext context, string msg, int code = 500)
        {
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(new ProblemDetails 
            { 
                Title = "Error",
                Detail = msg, 
                Status = code 
            });
        }
    }
}
