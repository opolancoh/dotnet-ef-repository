using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using EntityFrameworkRepository.Repository;

namespace EntityFrameworkRepository.Web.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseNpgsql(configuration.GetConnectionString("PostgresConnection"),
                x => x.MigrationsAssembly("EntityFrameworkRepository.Repository"));

        return new ApplicationDbContext(builder.Options);
    }
}