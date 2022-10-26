using EntityFrameworkRepository.Repository;
using EntityFrameworkRepository.Tests.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkRepository.Tests.IntegrationTests;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove current DbContext
            var serviceDescriptor = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
            if (serviceDescriptor != null) services.Remove(serviceDescriptor);

            // Add DbContext for testing
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseNpgsql("Server=localhost; Database=books_db_test; Username=postgres; Password=My@Passw0rd;"));

            //
            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                try
                {
                    // Don't update/remove this initial data
                    db.Authors?.AddRange(Utilities.GetAuthors());
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the database with test messages. Error: {Message}", ex.Message);
                }
            }
        });
    }
}