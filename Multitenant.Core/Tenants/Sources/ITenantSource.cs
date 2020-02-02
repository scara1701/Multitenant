namespace Multitenant.Core.Tenants.Sources
{
    public interface ITenantSource
    {
        Tenant[] ListTenants();
    }
}
