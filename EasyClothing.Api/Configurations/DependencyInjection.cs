using EasyClothing.App;
using EasyClothing.App.Common.Behaviors;
using EasyClothing.App.Services.Interfaces;
using EasyClothing.Domain.Repositories;
using EasyClothing.Infra.Persistence;
using EasyClothing.Infra.Repositories;
using EasyClothing.Infra.Services.Secutiry;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace OChefia.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddOpenApi();

            //services.AddJwtAuthentication(configuration);
            services.AddDatabase(configuration);

            services.AddApplication();
            services.AddInfrastructure();

            return services;
        }

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<EasyClothingDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        private static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(
                    typeof(ApplicationAssemblyReference).Assembly));

            services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(ExceptionHandlingBehavior<,>));

            services.AddAutoMapper(cfg => { }, typeof(ApplicationAssemblyReference).Assembly);

            return services;
        }

        private static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            //// Segurança
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            //services.AddScoped<ITokenService, JwtTokenService>();

            //// Repositórios
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            //services.AddScoped<ILojaRepository, LojaRepository>();
            //services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
