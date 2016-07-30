using Beblue.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Beblue.Infrastructure.Repository.Mappings
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapping()
        {
            ToTable("Usuario");

            HasKey(x => x.IdUsuario);

            Property(x => x.Nome)
                .HasMaxLength(128)
                .IsRequired();

            Property(x => x.Email)
                .HasMaxLength(64)
                .IsRequired();

            Property(x => x.Senha)
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}
