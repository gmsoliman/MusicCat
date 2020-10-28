﻿using MusicCat.Data.Entities;
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
        { _userId = userId;
        }
        public bool CreateSong(SongCreate model)
        {
            var entity =
                new Song()
                {
                   
                    Title = model.Title,
                    Length = model.Length,
                    
                };
            using ( var ctx = new ApplicationDbContext())
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
                                          
                    }
            );
                return query.ToArray();

            }
        }
        public object GetSongById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSong(SongEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == model.SongId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Length = model.Length;
                ;

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
