using Microsoft.EntityFrameworkCore;
using Multitenant.Core.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multitenant.WEB.API.Data
{
    public class TenantsContext : DbContext
    {
        private DbSet<Tenant> Tenants { get; set; }

        public TenantsContext(DbContextOptions<TenantsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().HasKey(e => e.Id);
        }

        public int GetTenantId(string host)
        {
            Tenant tenant = Tenants.FirstOrDefault(t => t.Host == host);
            if (tenant == null) { return 0; }
            return tenant.Id;
        }
    }
}
