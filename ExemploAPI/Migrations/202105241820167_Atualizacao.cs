namespace ExemploAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atualizacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Sexo", c => c.String());
            AddColumn("dbo.Usuarios", "Latitude", c => c.String());
            AddColumn("dbo.Usuarios", "Longitude", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Longitude");
            DropColumn("dbo.Usuarios", "Latitude");
            DropColumn("dbo.Usuarios", "Sexo");
        }
    }
}
