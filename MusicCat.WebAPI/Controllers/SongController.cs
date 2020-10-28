using Microsoft.AspNet.Identity;
using MusicCat.Models;
using MusicCat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicCat.WebAPI.Controllers
{
    [Authorize]
    public class SongController : ApiController
    {
        private SongService CreateAlbumService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var songService = new SongService(userID);
            return songService;
        }

        public IHttpActionResult Get()
        {
            SongService albumService = CreateSongService();
            var song = songService.GetSongs();
            return Ok(songs);
        }

        public IHttpActionResult Post(SongCreate album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.CreateSong(song)
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            SongService songService = CreateAlbumService();
            var song = songService.GetSongByID(id);
            return Ok(song);
        }

        public IHttpActionResult Put(SongEdit song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.UpdadteSong(song))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateSongService();

            if (!service.DeleteSong(id))
                return InternalServerError();

            return Ok();
        }
    }
}