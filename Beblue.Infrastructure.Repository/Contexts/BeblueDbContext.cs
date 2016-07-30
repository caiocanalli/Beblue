using Beblue.Domain.Entities;
using Beblue.Infrastructure.Repository.Mappings;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Beblue.Infrastructure.Repository.Contexts
{
    public class BeblueDbContext : DbContext
    {
        public BeblueDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Prioridade> Prioridades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == "Id" + p.ReflectedType.Name)
                .Configure(p => p.IsKey());

            modelBuilder.Configurations.Add(new TarefaMapping());
            modelBuilder.Configurations.Add(new CategoriaMapping());
            modelBuilder.Configurations.Add(new UsuarioMapping());
            modelBuilder.Configurations.Add(new PrioridadeMapping());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
