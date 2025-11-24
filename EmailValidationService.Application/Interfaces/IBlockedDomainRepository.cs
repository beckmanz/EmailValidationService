namespace EmailValidationService.Application.Interfaces;

public interface IBlockedDomainRepository
{
    Task<IEnumerable<string>> GetAllDomainsAsync( CancellationToken cancellationToken);
}