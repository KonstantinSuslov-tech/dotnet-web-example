using ExampleWeb.Application;
using ExampleWeb.Application.Cache;
using ExampleWeb.Application.Repositories;
using ExampleWeb.Infrastracture.Contexts;
using ExampleWeb.Infrastracture.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace ExampleWeb.Extentions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавление общих сервисов приложения.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="configuration">Конфигурация <see cref="IConfiguration"/>.</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddCommonServices(this IServiceCollection services, IConfiguration configuration) => services
                .AddDataContext(configuration)
                .AddRepositories()
                .AddCache()
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IApplicationAssembly>());

        private static IServiceCollection AddCache(this IServiceCollection services) =>
           services
               .AddScoped<IUserCache, UserCache>();

        private static IServiceCollection AddRepositories(this IServiceCollection services) => 
            services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserDocumentRepository, UserDocumentRepository>()
                .AddScoped<IRedisRepository, RedisRepository>();

        private static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            var t = configuration.GetConnectionString(nameof(PostgresContext));
            var dataSourceBuilder = new Npgsql.NpgsqlDataSourceBuilder(configuration.GetConnectionString(nameof(PostgresContext)));
            var dataSource = dataSourceBuilder.Build();

            services.AddEntityFrameworkNpgsql()
              .AddEntityFrameworkNamingConventions()
              .AddDbContext<PostgresContext>((sp, opt) => opt
              .UseNpgsql(dataSource)
              .UseInternalServiceProvider(sp)
              .UseSnakeCaseNamingConvention());

            return services;
        }

    }



}
