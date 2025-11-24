using Microsoft.EntityFrameworkCore;
using EmailValidationService.Domain.Entities;
using EmailValidationService.Infrastructure.Data.Configuration;

namespace EmailValidationService.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<BlockedDomainModel> BlockedDomains{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BlockedDomainConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}