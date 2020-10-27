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
    //gs
    public class GenreController : ApiController
    {
        private GenreService CreateGenreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var genreService = new GenreService(userId);
            return genreService;
        }
        public IHttpActionResult Get()
        {
            GenreService genreService = CreateGenreService();
            var genres = genreService.GetAllGenres();
            return Ok(genres);
        }
        public IHttpActionResult Get(int id)
        {
            GenreService genreService = CreateGenreService();
            var genre = genreService.GetGenreById(id);
            return Ok(genre);
        }
        public IHttpActionResult Post(GenreCreate genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGenreService();

            if (!service.CreateGenre(genre))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(GenreEdit genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGenreService();

            if (!service.UpdateGenre(genre))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGenreService();

            if (!service.DeleteGenre(id))
                return InternalServerError();

            return Ok();
        }
    }
    //gs
}
