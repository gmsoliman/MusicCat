namespace MusicCat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thrid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genre", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Genre", "SongId", "dbo.Song");
            DropIndex("dbo.Genre", new[] { "AlbumId" });
            DropIndex("dbo.Genre", new[] { "SongId" });
            AddColumn("dbo.Album", "GenreId", c => c.Int());
            AddColumn("dbo.Song", "GenreId", c => c.Int());
            CreateIndex("dbo.Album", "GenreId");
            CreateIndex("dbo.Song", "GenreId");
            AddForeignKey("dbo.Song", "GenreId", "dbo.Genre", "GenreId");
            AddForeignKey("dbo.Album", "GenreId", "dbo.Genre", "GenreId");
            DropColumn("dbo.Genre", "AlbumId");
            DropColumn("dbo.Genre", "SongId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genre", "SongId", c => c.Int());
            AddColumn("dbo.Genre", "AlbumId", c => c.Int());
            DropForeignKey("dbo.Album", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Song", "GenreId", "dbo.Genre");
            DropIndex("dbo.Song", new[] { "GenreId" });
            DropIndex("dbo.Album", new[] { "GenreId" });
            DropColumn("dbo.Song", "GenreId");
            DropColumn("dbo.Album", "GenreId");
            CreateIndex("dbo.Genre", "SongId");
            CreateIndex("dbo.Genre", "AlbumId");
            AddForeignKey("dbo.Genre", "SongId", "dbo.Song", "SongId");
            AddForeignKey("dbo.Genre", "AlbumId", "dbo.Album", "AlbumId");
        }
    }
}
