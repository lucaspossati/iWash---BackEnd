namespace ExemploAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoDataTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parceiros", "DataCriacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Parceiros", "DataAlteracao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Produtos", "DataCriacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Produtos", "DataAlteracao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtos", "DataAlteracao");
            DropColumn("dbo.Produtos", "DataCriacao");
            DropColumn("dbo.Parceiros", "DataAlteracao");
            DropColumn("dbo.Parceiros", "DataCriacao");
        }
    }
}
