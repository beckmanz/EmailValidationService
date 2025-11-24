using Microsoft.EntityFrameworkCore;
using EmailValidationService.Domain.Entities;

namespace EmailValidationService.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    {
        
    }

    public DbSet<BlockedDomainModel> BlockedDomains{ get; set; }
}