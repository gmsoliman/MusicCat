﻿using MusicCat.Data.Entities;
using MusicCat.Models.Genre;
using MusicCat.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCat.Services.Services
{
    //gs
    public class GenreService
    {
        private readonly Guid _userId;
        public GenreService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateGenre(GenreCreate model)
        {
            var entity =
                new Genre()
                {
                    OwnerId = _userId,
                    Type = model.Type,
                    Description = model.Description,
                    //AlbumId = model.AlbumId,
                    //SongId = model.SongId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GenreListItem> GetAllGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Genres
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new GenreListItem
                                {
                                    GenreId = e.GenreId,
                                    Type = e.Type,
                                }
                         );
                return query.ToArray();
            }
        }
        public GenreDetailAndEdit GetGenreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Genres
                        .Single(e => e.GenreId == id && e.OwnerId == _userId);
                return
                    new GenreDetailAndEdit
                    {
                        GenreId = entity.GenreId,
                        Type = entity.Type,
                        Description = entity.Description
                    };
            }
        }

        public bool UpdateGenre(GenreDetailAndEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Genres
                        .Single(e => e.GenreId == model.GenreId && e.OwnerId == _userId);
                entity.Type = model.Type;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGenre(int genreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Genres
                        .Single(e => e.GenreId == genreId && e.OwnerId == _userId);

                ctx.Genres.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
    //gs
}
