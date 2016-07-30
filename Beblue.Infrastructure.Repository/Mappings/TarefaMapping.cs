using Beblue.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Beblue.Infrastructure.Repository.Mappings
{
    public class TarefaMapping : EntityTypeConfiguration<Tarefa>
    {
        public TarefaMapping()
        {
            ToTable("Tarefa");

            HasKey(x => x.IdTarefa);

            Property(x => x.Nome)
                .HasMaxLength(128)
                .IsRequired();

            Property(x => x.Descricao)
                .HasMaxLength(512)
                .IsOptional();

            Property(x => x.DataCadastro)
                .IsRequired();

            Property(x => x.Concluida)
                .IsRequired();
        }
    }
}
