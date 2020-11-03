using MusicCat.Data.Entities;
using MusicCat.Models.Song;
using MusicCat.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Services.Services
{
    public class SongService
    {
        private readonly Guid _userId;

        public SongService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateSong(SongCreate model)
        {
            var entity =
                new Song()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Length = model.Length,
                    AlbumId = model.AlbumId,
                    GenreId = model.GenreId

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Songs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SongListItem> GetSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Songs
                    .Where(e => e.OwnerId == _userId)
                        .Select(
                                e =>
                    new SongListItem
                    {
                        SongID = e.SongId,
                        Title = e.Title,
                        Length = e.Length,
                        AlbumId = (int)e.AlbumId
                    }
            );
                return query.ToArray();
            }
        }

        public SongDetailAndEdit GetSongById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Songs
                    .Single(e => e.SongId == id && e.OwnerId == _userId);
                return
                    new SongDetailAndEdit
                    {
                        SongID = entity.SongId,
                        Title = entity.Title,
                        Length = entity.Length,
                        AlbumId = (int)entity.AlbumId,
                        GenreId = (int)entity.GenreId
                    };
            }
        }
        public IEnumerable<SongListItem> GetAllSongsByGenre(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Songs
                    .Where(e => e.GenreId == id && e.OwnerId == _userId)
                    .Select(
                        e =>
                        new SongListItem
                        {
                            SongID = e.SongId,
                            Title = e.Title,
                            Length = e.Length,
                            AlbumId = (int)e.AlbumId,
                        });
                return query.ToArray();
            }
        }
        public bool UpdateSong(SongDetailAndEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == model.SongID && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Length = model.Length;
                entity.AlbumId = model.AlbumId;
                entity.GenreId = model.GenreId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSong(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == songId && e.OwnerId == _userId);

                ctx.Songs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
//JAH

