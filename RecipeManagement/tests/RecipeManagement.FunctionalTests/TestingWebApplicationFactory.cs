
namespace RecipeManagement.FunctionalTests;

using RecipeManagement.Databases;
using RecipeManagement.Resources;
using RecipeManagement;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

public class TestingWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment(Consts.Testing.FunctionalTestingEnvName);

        builder.ConfigureServices(services =>
        {
            var provider = services.BuildServiceProvider();

            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
            var mapperConfig = new Mapper(typeAdapterConfig);
            services.AddSingleton<IMapper>(mapperConfig);

            services.AddDbContext<RecipesDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
                options.UseInternalServiceProvider(provider);
            });

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<RecipesDbContext>();
            db.Database.EnsureCreated();
        });
        
        return base.CreateHost(builder);
    }
}