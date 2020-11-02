namespace MusicCat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedModelBuilder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Song", "AlbumId", "dbo.Album");
            AddColumn("dbo.Song", "Album_AlbumId", c => c.Int(nullable: true));
            CreateIndex("dbo.Song", "Album_AlbumId");
            AddForeignKey("dbo.Song", "Album_AlbumId", "dbo.Album", "AlbumId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Song", "Album_AlbumId", "dbo.Album");
            DropIndex("dbo.Song", new[] { "Album_AlbumId" });
            DropColumn("dbo.Song", "Album_AlbumId");
            AddForeignKey("dbo.Song", "AlbumId", "dbo.Album", "AlbumId");
        }
    }
}
