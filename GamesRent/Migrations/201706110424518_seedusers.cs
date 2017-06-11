namespace GamesRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4eca7bbc-4e7a-4489-ad02-9ae486ed6eee', N'admin@gamesrent.com', 0, N'ANjd9p5LBsq8sdhgxnIz3zZ3joD1ohtIyWKtc/Eck63WoLxWzIEQJm3a7VLL1hJSAA==', N'602a98f4-5c6c-48b0-8ff3-ac4b0bde9ecf', NULL, 0, 0, NULL, 1, 0, N'admin@gamesrent.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6f549f4e-dd28-4dfb-8a78-85c1248eba51', N'Guest@amesrent.com', 0, N'AGpVvpn2UaHL28b7eQk5J3TnworeWocJT4++W9MJdcwBVj/W5LEmEHar7V948OlX0A==', N'2cb2d922-216d-4d22-8354-3802c27d8493', NULL, 0, 0, NULL, 1, 0, N'Guest@amesrent.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b5b18beb-a8f1-47bf-85ff-75cd7003d757', N'CanManageGames')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4eca7bbc-4e7a-4489-ad02-9ae486ed6eee', N'b5b18beb-a8f1-47bf-85ff-75cd7003d757')


");
        }
        
        public override void Down()
        {
        }
    }
}
