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
                        Parceiros_Id = c.Int(),
                        ParceirosId_Id = c.Int(),
                        Parceiros_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parceiros", t => t.Parceiros_Id)
                .ForeignKey("dbo.Parceiros", t => t.ParceirosId_Id)
                .ForeignKey("dbo.Parceiros", t => t.Parceiros_Id1)
                .Index(t => t.Parceiros_Id)
                .Index(t => t.ParceirosId_Id)
                .Index(t => t.Parceiros_Id1);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimeiroNome = c.String(),
                        Sobrenome = c.String(),
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "Parceiros_Id1", "dbo.Parceiros");
            DropForeignKey("dbo.Produtos", "ParceirosId_Id", "dbo.Parceiros");
            DropForeignKey("dbo.Produtos", "Parceiros_Id", "dbo.Parceiros");
            DropIndex("dbo.Produtos", new[] { "Parceiros_Id1" });
            DropIndex("dbo.Produtos", new[] { "ParceirosId_Id" });
            DropIndex("dbo.Produtos", new[] { "Parceiros_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Produtos");
            DropTable("dbo.Parceiros");
        }
    }
}
