namespace ExemploAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoEndereco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enderecos", "Latitude", c => c.String());
            AddColumn("dbo.Enderecos", "Longitude", c => c.String());
            DropColumn("dbo.Usuarios", "Endereco");
            DropColumn("dbo.Usuarios", "Numero");
            DropColumn("dbo.Usuarios", "Bairro");
            DropColumn("dbo.Usuarios", "Cidade");
            DropColumn("dbo.Usuarios", "Estado");
            DropColumn("dbo.Usuarios", "CEP");
            DropColumn("dbo.Usuarios", "Login");
            DropColumn("dbo.Usuarios", "Latitude");
            DropColumn("dbo.Usuarios", "Longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Longitude", c => c.String());
            AddColumn("dbo.Usuarios", "Latitude", c => c.String());
            AddColumn("dbo.Usuarios", "Login", c => c.String());
            AddColumn("dbo.Usuarios", "CEP", c => c.String());
            AddColumn("dbo.Usuarios", "Estado", c => c.String());
            AddColumn("dbo.Usuarios", "Cidade", c => c.String());
            AddColumn("dbo.Usuarios", "Bairro", c => c.String());
            AddColumn("dbo.Usuarios", "Numero", c => c.String());
            AddColumn("dbo.Usuarios", "Endereco", c => c.String());
            DropColumn("dbo.Enderecos", "Longitude");
            DropColumn("dbo.Enderecos", "Latitude");
        }
    }
}
