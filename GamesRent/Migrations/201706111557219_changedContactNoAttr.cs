namespace GamesRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedContactNoAttr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ContactNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ContactNo", c => c.Int(nullable: false));
        }
    }
}
