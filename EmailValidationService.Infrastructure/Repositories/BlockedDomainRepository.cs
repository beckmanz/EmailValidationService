using EmailValidationService.Application.Interfaces;
using EmailValidationService.Domain.Entities;
using EmailValidationService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmailValidationService.Infrastructure.Repositories;

public class BlockedDomainRepository : IBlockedDomainRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BlockedDomainRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<string>> GetAllDomainsAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.BlockedDomains
            .AsNoTracking()
            .Select(b => b.DomainName)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateDomainAsync(IEnumerable<string> domains, CancellationToken cancellationToken)
    {
        await _dbContext.BlockedDomains.ExecuteDeleteAsync(cancellationToken);

        var newEntities = domains.Select(d => new BlockedDomainModel(d.ToLower().Trim()));
        await _dbContext.BlockedDomains.AddRangeAsync(newEntities, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}