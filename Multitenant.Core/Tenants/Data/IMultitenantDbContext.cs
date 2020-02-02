namespace Multitenant.Core.Tenants.Data
{
    public interface IMultitenantDbContext
    {
        int TenantId { get; }
    }
}
