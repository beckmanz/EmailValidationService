using EmailValidationService.Application.Interfaces;
using EmailValidationService.Infrastructure.Data;
using EmailValidationService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailValidationService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });
        
        services.AddScoped<IBlockedDomainRepository, BlockedDomainRepository>();
        return services;
    }
}