namespace GamesRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMigrationtype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Membershiptype", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Membershiptype");
        }
    }
}
