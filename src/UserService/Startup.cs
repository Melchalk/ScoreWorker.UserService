using AutoMapper;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using UserService.Business.Credentials;
using UserService.Business.Credentials.Interfaces;
using UserService.Business.User;
using UserService.Business.User.Interfaces;
using UserService.Data;
using UserService.Data.Interfaces;
using UserService.Data.Provider;
using UserService.DataProvider.PostgreSql.Ef;
using UserService.Infrastructure.Mapper;
using UserService.Infrastructure.Middlewares;

namespace UserService;

internal class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

        services.AddDbContext<UserServiceDbContext>(options =>
        {
            options.UseNpgsql(Configuration.GetConnectionString("SQLConnectionString"),
                b => b.MigrationsAssembly(typeof(UserServiceDbContext).Assembly.FullName));
        });

        services.AddSingleton(new MapperConfiguration(mc =>
        {
            mc.AddProfile<MappingProfile>();
        }).CreateMapper());

        services.AddControllers();

        ConfigureDI(services);

        //ConfigureMassTransit(services);

        services.AddEndpointsApiExplorer();

        services.AddHttpContextAccessor();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
        services.AddAuthorization();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors("CorsPolicy");

        app.UseHttpsRedirection();

        app.UseMiddleware<GlobalExceptionMiddleware>();

        UpdateDatabase(app);

        app.UseRouting();

        app.UseMiddleware<TokenMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private void ConfigureMassTransit(IServiceCollection services)
    {
        ConfigurePublishers(services);

        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost");
                cfg.ConfigureEndpoints(context);
            });

            ConfigureConsumers(busConfigurator);
        });
    }

    private void ConfigurePublishers(IServiceCollection services)
    {
        //services.AddScoped<IMessagePublisher<CreateLibraryRequest, CreateLibraryResponse>, CreateLibraryMessagePublisher>();
    }

    private void ConfigureConsumers(IServiceCollectionBusConfigurator x)
    {
        //x.AddConsumer<>();
    }

    private void ConfigureDI(IServiceCollection services)
    {
        services.AddScoped<IDataProvider, UserServiceDbContext>();
        services.AddScoped<DbContext, UserServiceDbContext>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<ICreateUserCommand, CreateUserCommand>();
        services.AddScoped<IDeleteUserCommand, DeleteUserCommand>();
        services.AddScoped<IGetUsersByTeamCommand, GetUsersByTeamCommand>();
        services.AddScoped<IGetUserCommand, GetUserCommand>();
        services.AddScoped<IGetCurrentUserCommand, GetCurrentUserCommand>();
        services.AddScoped<IUpdateUserCommand, UpdateUserCommand>();

        services.AddScoped<ICreateCredentialsCommand, CreateCredentialsCommand>();
    }

    private void UpdateDatabase(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();

        using var context = serviceScope.ServiceProvider
            .GetService<UserServiceDbContext>();

        context!.Database.Migrate();
    }
}