using System.Data.Entity.ModelConfiguration;
using Livraria.Domain.Entities;

namespace Livraria.Infra.Mappings
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            ToTable("Book");
            HasKey(x => x.Id);

            Property(x => x.Title.CompleteName).IsRequired().HasMaxLength(100).HasColumnName("Title");
            Property(x => x.PublishingCompany.CompleteName).IsRequired().HasMaxLength(100).HasColumnName("PublishingCompany");
            Property(x => x.Author.CompleteName).IsRequired().HasMaxLength(100).HasColumnName("Author");
            Property(x => x.Page).IsRequired();
            Property(x => x.Value).IsRequired().HasColumnName("BookValue").HasColumnType("money");
            Property(x => x.QuantityOnHand).IsRequired();
        }
    }
}