namespace ExemploAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioseParceiros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parceiros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeFantasia = c.String(),
                        RazaoSocial = c.String(),
                        CNPJ = c.String(),
                        Endereco = c.String(),
                        Numero = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        CEP = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descricao = c.String(),
                        ParceirosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parceiros", t => t.ParceirosId, cascadeDelete: true)
                .Index(t => t.ParceirosId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePerfil = c.String(),
                        PrimeiroNome = c.String(),
                        Sobrenome = c.String(),
                        Email = c.String(),
                        Endereco = c.String(),
                        Numero = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        CEP = c.String(),
                        CPF = c.String(),
                        Login = c.String(),
                        Senha = c.String(),
                        DatadeNascimento = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "ParceirosId", "dbo.Parceiros");
            DropIndex("dbo.Produtos", new[] { "ParceirosId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Produtos");
            DropTable("dbo.Parceiros");
        }
    }
}
