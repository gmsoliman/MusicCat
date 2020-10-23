using MusicCat.Data;
using MusicCat.Models;
using MusicCat.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Services
{
    public class AlbumService
    {

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
                        Year = model.Year
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
                                Year = e.Year
                            });
                    return query.ToArray();
                }
            }
            public AlbumDetail GetAlbumByID(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Albums
                        .Single(e => e.AlbumId == id && e.OwnerId == _userID);
                    return
                        new AlbumDetail
                        {
                            AlbumId = entity.AlbumId,
                            AlbumTitle = entity.AlbumTitle,
                            Year = entity.Year
                        };
                }
            }
            public bool UpdateAlbum(AlbumEdit model)
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
}
