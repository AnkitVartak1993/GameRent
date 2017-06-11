namespace GamesRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGamesoneprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "NumbersInStock", c => c.Int(nullable: false));

            Sql("UPDATE Games SET NumbersInStock= InStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "NumbersInStock");
        }
    }
}
