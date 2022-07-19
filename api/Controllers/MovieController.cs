using dp.api.Services;
using dp.api.Authorization;
using dp.business.Enums;
using dp.business.Helpers;
using dp.business.Models;
using dp.data;
using dp.data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using dp.api.Filters;

namespace dp.api.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : BaseController
    {
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Get a list of all Moves
        /// </summary>
        /// <param name="search">Search String for Movie Title</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll(String search)
        {
            //add skip/take... later on
            List<Movie> movies = await _movieService.GetMovies(search);
            return Ok(movies);
        }

        /// <summary>
        /// Add a movie - only for admins
        /// </summary>
        /// <param name="movie">Move you want to add</param>
        /// <returns></returns>
        [Authorize(Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieRequest movie)
        {
            //add skip/take... later on
            int? movieId = await _movieService.AddMovie(movie);
            return Ok(movieId);
        }


    }
}