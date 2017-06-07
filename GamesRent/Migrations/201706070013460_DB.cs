namespace GamesRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Genre = c.String(),
                    GameAdded = c.DateTime(nullable: false),
                    InStock = c.Int(nullable: false),
                    ReleaseDate = c.DateTime(nullable: false)
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
        }
    }
}
