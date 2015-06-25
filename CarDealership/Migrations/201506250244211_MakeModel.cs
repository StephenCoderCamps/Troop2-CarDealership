namespace CarDealership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Make", c => c.String());
            AddColumn("dbo.Cars", "Model", c => c.String());
            DropColumn("dbo.Cars", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Title", c => c.String());
            DropColumn("dbo.Cars", "Model");
            DropColumn("dbo.Cars", "Make");
        }
    }
}
