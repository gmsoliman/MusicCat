namespace MusicCat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genreTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Album", "ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Song", "Artist_ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Album", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Song", "GenreId", "dbo.Genre");
            DropIndex("dbo.Song", new[] { "Artist_ArtistId" });
            AddColumn("dbo.Album", "Artist_ArtistId", c => c.Int(nullable: true));
            AddColumn("dbo.Album", "Genre_GenreId", c => c.Int(nullable: true));
            AddColumn("dbo.Song", "Genre_GenreId", c => c.Int(nullable: true));
            DropColumn("dbo.Song", "Artist_ArtistId");
            CreateIndex("dbo.Album", "Artist_ArtistId");
            CreateIndex("dbo.Album", "Genre_GenreId");
            CreateIndex("dbo.Song", "Genre_GenreId");
            CreateIndex("dbo.Song", "Artist_ArtistId");
            AddForeignKey("dbo.Album", "Artist_ArtistId", "dbo.Artist", "ArtistId", cascadeDelete: true);
            AddForeignKey("dbo.Song", "Artist_ArtistId", "dbo.Artist", "ArtistId", cascadeDelete: true);
            AddForeignKey("dbo.Album", "Genre_GenreId", "dbo.Genre", "GenreId", cascadeDelete: true);
            AddForeignKey("dbo.Song", "Genre_GenreId", "dbo.Genre", "GenreId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Song", "Genre_GenreId", "dbo.Genre");
            DropForeignKey("dbo.Album", "Genre_GenreId", "dbo.Genre");
            DropForeignKey("dbo.Song", "Artist_ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Album", "Artist_ArtistId", "dbo.Artist");
            DropIndex("dbo.Song", new[] { "Artist_ArtistId" });
            DropIndex("dbo.Song", new[] { "Genre_GenreId" });
            DropIndex("dbo.Album", new[] { "Genre_GenreId" });
            DropIndex("dbo.Album", new[] { "Artist_ArtistId" });
            AlterColumn("dbo.Song", "Artist_ArtistId", c => c.Int());
            DropColumn("dbo.Song", "Genre_GenreId");
            DropColumn("dbo.Album", "Genre_GenreId");
            DropColumn("dbo.Album", "Artist_ArtistId");
            CreateIndex("dbo.Song", "Artist_ArtistId");
            AddForeignKey("dbo.Song", "GenreId", "dbo.Genre", "GenreId");
            AddForeignKey("dbo.Album", "GenreId", "dbo.Genre", "GenreId");
            AddForeignKey("dbo.Song", "Artist_ArtistId", "dbo.Artist", "ArtistId");
            AddForeignKey("dbo.Album", "ArtistId", "dbo.Artist", "ArtistId");
        }
    }
}
