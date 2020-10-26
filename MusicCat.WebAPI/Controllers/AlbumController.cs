﻿using Microsoft.AspNet.Identity;
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
    public class AlbumController : ApiController
    {
        private AlbumService CreateAlbumService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var albumService = new AlbumService(userID);
            return albumService;
        }

        public IHttpActionResult Get()
        {
            AlbumService albumService = CreateAlbumService();
            var albums = albumService.GetAlbums();
            return Ok(albums);
        }

        public IHttpActionResult Post(AlbumCreate album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.CreateAlbum(album))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            AlbumService albumService = CreateAlbumService();
            var album = albumService.GetAlbumByID(id);
            return Ok(album);
        }

        public IHttpActionResult Put(AlbumEdit album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.UpdateAlbum(album))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAlbumService();

            if (!service.DeleteAlbum(id))
                return InternalServerError();

            return Ok();
        }
    }
}