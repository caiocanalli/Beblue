using Beblue.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Beblue.Infrastructure.Repository.Mappings
{
    public class CategoriaMapping : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMapping()
        {
            ToTable("Categoria");

            HasKey(x => x.IdCategoria);

            Property(x => x.Nome)
               .HasMaxLength(128)
               .IsRequired();
        }
    }
}
