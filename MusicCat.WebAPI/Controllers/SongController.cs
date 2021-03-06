﻿using Microsoft.AspNet.Identity;
using MusicCat.Models.Song;
using MusicCat.Services.Services;
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
        private SongService CreateSongService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var songService = new SongService(userID);
            return songService;
        }

        public IHttpActionResult Get()
        {
            SongService songService = CreateSongService();
            var song = songService.GetSongs();
            return Ok(song);
        }

        public IHttpActionResult Post(SongCreate song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.CreateSong(song))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            SongService songService = CreateSongService();
            var song = songService.GetSongById(id);
            return Ok(song);
        }

        [Route("api/GetSongsByGenre/{id}")]
        [HttpGet]
        public IHttpActionResult GetSongsByGenre(int id)
        {
            SongService songService = CreateSongService();
            var song = songService.GetAllSongsByGenre(id);
            return Ok(song);
        }

        public IHttpActionResult Put(SongDetailAndEdit song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.UpdateSong(song))
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
