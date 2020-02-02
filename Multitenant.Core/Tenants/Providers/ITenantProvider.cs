namespace Multitenant.Core.Tenants.Providers
{
    public interface ITenantProvider
    {
        Tenant GetTenant();
    }
}
