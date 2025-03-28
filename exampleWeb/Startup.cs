using ExampleWeb.Application.Repositories;
using ExampleWeb.Extentions;
using ExampleWeb.Infrastracture.Repositories;
using ExampleWeb.Infrastracture.Settings;
using ExampleWeb.Midlewares;
using Microsoft.AspNetCore.Builder;

namespace ExampleWeb;

public class Startup
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Startup"/> class.
    /// </summary>
    /// <param name="configuration">configuration</param>
    /// <param name="webHostEnvironment">webHostEnvironment</param>
    public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        Configuration = configuration;
        WebHostEnvironment = webHostEnvironment;
    }

    private IWebHostEnvironment WebHostEnvironment { get; }

    private IConfiguration Configuration { get; }

    /// <summary>
    /// ConfigureServices
    /// </summary>
    /// <param name="services">services</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCommonServices(Configuration);

        services.Configure<MongoSettings>(options =>
        {
            options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            options.Database = Configuration.GetSection("MongoConnection:Database").Value;
        });

        services.Configure<RedisSettings>(options =>
        {
            options.ConnectionString = Configuration.GetSection("RedisConnection:ConnectionString").Value;
        });

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    /// <summary>
    /// Configure
    /// </summary>
    /// <param name="app">app</param>
    /// <param name="env">env</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseMiddleware<ApiExceptionMiddleware>();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}

