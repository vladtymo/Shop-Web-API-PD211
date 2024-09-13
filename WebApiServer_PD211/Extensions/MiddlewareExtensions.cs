using WebApiServer_PD211.Middlewares;

namespace WebApiServer_PD211.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UseGlobalExceptionHandler(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
