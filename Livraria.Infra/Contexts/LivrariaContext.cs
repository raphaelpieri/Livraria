using System.Data.Entity;
using Livraria.Domain.Entities;
using Livraria.Infra.Mappings;
using Livraria.Shared;

namespace Livraria.Infra.Contexts
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext() : base(Runtime.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMap());
        }
    }
}