using EmailValidationService.Application.Interfaces;
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
}