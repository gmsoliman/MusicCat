namespace MusicCat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        AlbumTitle = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        ArtistId = c.Int(),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Artist", t => t.ArtistId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ArtistName = c.String(nullable: false),
                        Hometown = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Song",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OwnerId = c.Guid(nullable: false),
                        AlbumId = c.Int(),
                        Artist_ArtistId = c.Int(),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.Album", t => t.AlbumId)
                .ForeignKey("dbo.Artist", t => t.Artist_ArtistId)
                .Index(t => t.AlbumId)
                .Index(t => t.Artist_ArtistId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Type = c.String(nullable: false),
                        Description = c.String(),
                        AlbumId = c.Int(),
                        SongId = c.Int(),
                    })
                .PrimaryKey(t => t.GenreId)
                .ForeignKey("dbo.Album", t => t.AlbumId)
                .ForeignKey("dbo.Song", t => t.SongId)
                .Index(t => t.AlbumId)
                .Index(t => t.SongId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Album", "ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Song", "Artist_ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Genre", "SongId", "dbo.Song");
            DropForeignKey("dbo.Genre", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Song", "AlbumId", "dbo.Album");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Genre", new[] { "SongId" });
            DropIndex("dbo.Genre", new[] { "AlbumId" });
            DropIndex("dbo.Song", new[] { "Artist_ArtistId" });
            DropIndex("dbo.Song", new[] { "AlbumId" });
            DropIndex("dbo.Album", new[] { "ArtistId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Genre");
            DropTable("dbo.Song");
            DropTable("dbo.Artist");
            DropTable("dbo.Album");
        }
    }
}
