namespace GamesRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembership : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationMonth,DiscountRate) VALUES(1,0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationMonth,DiscountRate) VALUES(2,25,1,10)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationMonth,DiscountRate) VALUES(3,60,3,20)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationMonth,DiscountRate) VALUES(4,200,12,25)");


        }

        public override void Down()
        {
        }
    }
}
