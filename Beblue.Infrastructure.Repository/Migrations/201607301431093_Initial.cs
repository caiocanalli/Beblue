namespace Beblue.Infrastructure.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        IdCategoria = c.Short(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Prioridade",
                c => new
                    {
                        IdPrioridade = c.Short(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.IdPrioridade);
            
            CreateTable(
                "dbo.Tarefa",
                c => new
                    {
                        IdTarefa = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 128),
                        Descricao = c.String(maxLength: 512),
                        DataCadastro = c.DateTime(nullable: false),
                        Concluida = c.Boolean(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        IdCategoria = c.Short(nullable: false),
                        IdPrioridade = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.IdTarefa)
                .ForeignKey("dbo.Categoria", t => t.IdCategoria)
                .ForeignKey("dbo.Prioridade", t => t.IdPrioridade)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdUsuario)
                .Index(t => t.IdCategoria)
                .Index(t => t.IdPrioridade);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false, maxLength: 64),
                        Senha = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.IdUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefa", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Tarefa", "IdPrioridade", "dbo.Prioridade");
            DropForeignKey("dbo.Tarefa", "IdCategoria", "dbo.Categoria");
            DropIndex("dbo.Tarefa", new[] { "IdPrioridade" });
            DropIndex("dbo.Tarefa", new[] { "IdCategoria" });
            DropIndex("dbo.Tarefa", new[] { "IdUsuario" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Tarefa");
            DropTable("dbo.Prioridade");
            DropTable("dbo.Categoria");
        }
    }
}
