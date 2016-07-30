using Beblue.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Beblue.Infrastructure.Repository.Mappings
{
    public class PrioridadeMapping : EntityTypeConfiguration<Prioridade>
    {
        public PrioridadeMapping()
        {
            ToTable("Prioridade");

            HasKey(x => x.IdPrioridade);

            Property(x => x.Nome)
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}
