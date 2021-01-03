namespace Nortwind.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoriEntitiesPictureSil : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "Picture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Picture", c => c.Binary());
        }
    }
}
