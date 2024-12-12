using UserService.Infrastructure.Middlewares;

namespace UserService.Infrastructure.Swagger;

public class TerminalStartupFilter : IStartupFilter
{
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        return app =>
        {
            app.UseMiddleware<RequestLoggingMiddleware>();
            next(app);
        };
    }
}