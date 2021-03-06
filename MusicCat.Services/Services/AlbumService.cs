using MusicCat.Data;
using MusicCat.Data.Entities;
using MusicCat.Models;
using MusicCat.Models.Album;
using MusicCat.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Services.Services
{
    public class AlbumService
    {
        //bh

        private readonly Guid _userID;

        public AlbumService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateAlbum(AlbumCreate model)
        {
            var entity =
                new Album()
                {
                    OwnerId = _userID,
                    AlbumTitle = model.AlbumTitle,
                    Year = model.Year,
                    ArtistId = model.ArtistId,
                    GenreId = model.GenreId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Albums.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<AlbumListItem> GetAlbums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Albums
                    .Where(e => e.OwnerId == _userID)
                    .Select(
                        e =>
                        new AlbumListItem
                        {
                            AlbumId = e.AlbumId,
                            AlbumTitle = e.AlbumTitle,
                            Year = e.Year,
                            ArtistId = (int)e.ArtistId,
                            GenreId = (int)e.GenreId
                        });
                return query.ToArray();
            }
        }
        public IEnumerable<AlbumListItem> GetAllAlbumsByGenre(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Albums
                    .Where(e => e.GenreId == id && e.OwnerId == _userID)
                    .Select(
                        e =>
                        new AlbumListItem
                        {
                            AlbumId = e.AlbumId,
                            AlbumTitle = e.AlbumTitle,
                            Year = e.Year,
                            ArtistId = (int)e.ArtistId,
                        });
                return query.ToArray();
            }
        }
        public AlbumDetailAndEdit GetAlbumByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Albums
                    .Single(e => e.AlbumId == id && e.OwnerId == _userID);
                return
                    new AlbumDetailAndEdit
                    {
                        AlbumId = entity.AlbumId,
                        AlbumTitle = entity.AlbumTitle,
                        Year = entity.Year,
                        ArtistId = (int)entity.ArtistId,
                        GenreId = (int)entity.GenreId
                    };
            }
        }
        public bool UpdateAlbum(AlbumDetailAndEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Albums
                    .Single(e => e.AlbumId == model.AlbumId && e.OwnerId == _userID);

                entity.AlbumId = model.AlbumId;
                entity.AlbumTitle = model.AlbumTitle;
                entity.Year = model.Year;
                entity.ArtistId = model.ArtistId;
                entity.GenreId = model.GenreId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAlbum(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Albums
                    .Single(e => e.AlbumId == albumId && e.OwnerId == _userID);

                ctx.Albums.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
    //bh
}
