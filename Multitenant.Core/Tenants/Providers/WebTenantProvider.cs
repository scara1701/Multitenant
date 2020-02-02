using Microsoft.AspNetCore.Http;
using Multitenant.Core.Tenants.Sources;
using System.Linq;

namespace Multitenant.Core.Tenants.Providers
{
    public class WebTenantProvider : ITenantProvider
    {
        private readonly ITenantSource _tenantSource;
        private readonly string _host;

        public WebTenantProvider(ITenantSource tenantSource, IHttpContextAccessor accessor)
        {

        }
        public Tenant GetTenant()
        {
            var tenants = _tenantSource.ListTenants();
            return tenants.Where(t => t.Host.ToLower() == _host.ToLower()).FirstOrDefault(); ;
        }
    }
}
