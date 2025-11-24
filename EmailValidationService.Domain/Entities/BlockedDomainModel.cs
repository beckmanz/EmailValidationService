namespace EmailValidationService.Domain.Entities;

public class BlockedDomainModel
{
    public Guid Id { get; set; }
    public string DomainName { get; set; }
    public DateTime DateAdded { get; set; }

    public BlockedDomainModel(string domainName)
    {
        Id  = Guid.NewGuid();
        this.DomainName = domainName;
        DateAdded = DateTime.UtcNow;
    }
}