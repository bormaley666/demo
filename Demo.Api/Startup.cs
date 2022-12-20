using Microsoft.EntityFrameworkCore;
using Demo.Application.Services;
using Demo.DataLayer.Repositories;
using Demo.DataLayer;
using Demo.Api.Middlewares;
using Microsoft.OpenApi.Models;
using Demo.Application;
using Demo.Application.Repositories;
using Demo.Application.Implementation.Services;

namespace Demo.Api;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(provider => {

            var optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder.UseInMemoryDatabase("db");
            var context = new DataDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        });

        services.AddSwaggerGen(options =>
        {
            foreach (var xmlFile in Directory.GetFiles(AppContext.BaseDirectory, "*.xml"))
            {
                options.IncludeXmlComments(xmlFile);
            }

            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Consort API", Version = "v1" });
        });

        services.AddControllers();
        services.AddScoped<ISalePointService, SalePointService>();
        services.AddScoped<IBuyerService, BuyerService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ISaleService, SaleService>();
        services.AddScoped<IBuyerRepository, BuyerRepository>();
        services.AddScoped<ISalePointRepository, SalePointRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment _)
    {
        app.UseMiddleware<ErrorHandlingMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Consort API");
        });
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
