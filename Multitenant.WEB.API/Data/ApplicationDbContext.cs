
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Multitenant.Core.Data;
using Multitenant.Core.Tenants;
using Multitenant.Core.Tenants.Data;
using Multitenant.Core.Tenants.Providers;


namespace Multitenant.WEB.API.Data
{
    public class ApplicationDbContext : IdentityDbContext, IMultitenantDbContext
    {
        private readonly Tenant _tenant;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,ITenantProvider tenantProvider) : base(options)
        {
            _tenant = tenantProvider.GetTenant();
        }

        
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        public int TenantId
        {
            get { return _tenant.Id; }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_tenant.DatabaseType == DatabaseType.SQLServer) { optionsBuilder.UseSqlServer(_tenant.DatabaseConnectionString); }
            if(_tenant.DatabaseType == DatabaseType.MySQL) { optionsBuilder.UseMySQL(_tenant.DatabaseConnectionString); }
            optionsBuilder.ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var navigation = builder.Entity<BookCategory>().Metadata.FindNavigation(nameof(BookCategory.Books));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            base.OnModelCreating(builder);
        }
    }
}
