namespace ExemploAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TblEndereco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Rua = c.String(),
                        Numero = c.Int(nullable: false),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        Complemento = c.String(),
                        PontoReferencia = c.String(),
                        CEP = c.String(),
                        UsuariosId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuariosId, cascadeDelete: true)
                .Index(t => t.UsuariosId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enderecos", "UsuariosId", "dbo.Usuarios");
            DropIndex("dbo.Enderecos", new[] { "UsuariosId" });
            DropTable("dbo.Enderecos");
        }
    }
}
