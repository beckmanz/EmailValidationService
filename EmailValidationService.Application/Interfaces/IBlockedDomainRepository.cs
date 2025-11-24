namespace EmailValidationService.Application.Interfaces;

public interface IBlockedDomainRepository
{
    Task<IEnumerable<string>> GetAllDomainsAsync( CancellationToken cancellationToken);
    Task UpdateDomainAsync( IEnumerable<string> domains, CancellationToken cancellationToken);
}