using EmailValidationService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailValidationService.Infrastructure.Data.Configuration;

public class BlockedDomainConfiguration : IEntityTypeConfiguration<BlockedDomainModel>
{
    public void Configure(EntityTypeBuilder<BlockedDomainModel> builder)
    {
        builder.ToTable("BlockedDomains");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DomainName)
            .IsRequired()
            .HasMaxLength(200);
                
        builder.HasIndex(x => x.DomainName)
            .IsUnique();
    }
}