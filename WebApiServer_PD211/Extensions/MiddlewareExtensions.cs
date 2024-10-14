using WebApiServer_PD211.Middlewares;
using Microsoft.EntityFrameworkCore;
using Data;

namespace WebApiServer_PD211.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UseGlobalExceptionHandler(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }

        public static async Task ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
            await context.Database.MigrateAsync();
        }
    }
}
