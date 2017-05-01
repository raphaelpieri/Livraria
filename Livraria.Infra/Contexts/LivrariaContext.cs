using System.Data.Entity;
using Livraria.Domain.Entities;
using Livraria.Infra.Mappings;

namespace Livraria.Infra.Contexts
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext() : base(@"Server=.\sqlexpress;Database=livraria;User ID=sa;Password=1")
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