namespace Multitenant.Core.Tenants
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public DatabaseType DatabaseType { get; set; }
        public string DatabaseConnectionString { get; set; }
        public StorageType storageType { get; set; }
        public string StorageConnectionString { get; set; }

    }
}
