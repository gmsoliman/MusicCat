namespace MusicCat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GenreAlbum", "Genre_GenreId", "dbo.Genre");
            DropForeignKey("dbo.GenreAlbum", "Album_AlbumId", "dbo.Album");
            DropForeignKey("dbo.SongGenre", "Song_SongId", "dbo.Song");
            DropForeignKey("dbo.SongGenre", "Genre_GenreId", "dbo.Genre");
            DropIndex("dbo.GenreAlbum", new[] { "Genre_GenreId" });
            DropIndex("dbo.GenreAlbum", new[] { "Album_AlbumId" });
            DropIndex("dbo.SongGenre", new[] { "Song_SongId" });
            DropIndex("dbo.SongGenre", new[] { "Genre_GenreId" });
            AddColumn("dbo.Album", "Genre_GenreId", c => c.Int());
            AddColumn("dbo.Genre", "Song_SongId", c => c.Int());
            AddColumn("dbo.Genre", "Album_AlbumId", c => c.Int());
            AddColumn("dbo.Song", "Genre_GenreId", c => c.Int());
            CreateIndex("dbo.Album", "GenreId");
            CreateIndex("dbo.Album", "Genre_GenreId");
            CreateIndex("dbo.Song", "GenreId");
            CreateIndex("dbo.Song", "Genre_GenreId");
            CreateIndex("dbo.Genre", "Song_SongId");
            CreateIndex("dbo.Genre", "Album_AlbumId");
            AddForeignKey("dbo.Album", "Genre_GenreId", "dbo.Genre", "GenreId");
            AddForeignKey("dbo.Song", "Genre_GenreId", "dbo.Genre", "GenreId");
            AddForeignKey("dbo.Song", "GenreId", "dbo.Genre", "GenreId");
            AddForeignKey("dbo.Genre", "Song_SongId", "dbo.Song", "SongId");
            AddForeignKey("dbo.Album", "GenreId", "dbo.Genre", "GenreId");
            AddForeignKey("dbo.Genre", "Album_AlbumId", "dbo.Album", "AlbumId");
            DropTable("dbo.GenreAlbum");
            DropTable("dbo.SongGenre");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SongGenre",
                c => new
                    {
                        Song_SongId = c.Int(nullable: false),
                        Genre_GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Song_SongId, t.Genre_GenreId });
            
            CreateTable(
                "dbo.GenreAlbum",
                c => new
                    {
                        Genre_GenreId = c.Int(nullable: false),
                        Album_AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreId, t.Album_AlbumId });
            
            DropForeignKey("dbo.Genre", "Album_AlbumId", "dbo.Album");
            DropForeignKey("dbo.Album", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Genre", "Song_SongId", "dbo.Song");
            DropForeignKey("dbo.Song", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Song", "Genre_GenreId", "dbo.Genre");
            DropForeignKey("dbo.Album", "Genre_GenreId", "dbo.Genre");
            DropIndex("dbo.Genre", new[] { "Album_AlbumId" });
            DropIndex("dbo.Genre", new[] { "Song_SongId" });
            DropIndex("dbo.Song", new[] { "Genre_GenreId" });
            DropIndex("dbo.Song", new[] { "GenreId" });
            DropIndex("dbo.Album", new[] { "Genre_GenreId" });
            DropIndex("dbo.Album", new[] { "GenreId" });
            DropColumn("dbo.Song", "Genre_GenreId");
            DropColumn("dbo.Genre", "Album_AlbumId");
            DropColumn("dbo.Genre", "Song_SongId");
            DropColumn("dbo.Album", "Genre_GenreId");
            CreateIndex("dbo.SongGenre", "Genre_GenreId");
            CreateIndex("dbo.SongGenre", "Song_SongId");
            CreateIndex("dbo.GenreAlbum", "Album_AlbumId");
            CreateIndex("dbo.GenreAlbum", "Genre_GenreId");
            AddForeignKey("dbo.SongGenre", "Genre_GenreId", "dbo.Genre", "GenreId", cascadeDelete: true);
            AddForeignKey("dbo.SongGenre", "Song_SongId", "dbo.Song", "SongId", cascadeDelete: true);
            AddForeignKey("dbo.GenreAlbum", "Album_AlbumId", "dbo.Album", "AlbumId", cascadeDelete: true);
            AddForeignKey("dbo.GenreAlbum", "Genre_GenreId", "dbo.Genre", "GenreId", cascadeDelete: true);
        }
    }
}
