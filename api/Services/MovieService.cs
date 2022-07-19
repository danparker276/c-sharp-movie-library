using dp.api.Authorization;
using dp.api.Helpers;
using dp.business.Enums;
using dp.business.Models;
using dp.data;
using dp.data.Interfaces;
using Microsoft.Extensions.Options;

namespace dp.api.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMovies(string searchStr);
        Task<Movie> GetById(int movieId);
        Task<int?> AddMovie(MovieRequest movie);

    }

    public class MovieService : IMovieService
    {

        private readonly ConnectionStrings _connectionStrings;

        private IDaoFactory AdoDao => DaoFactories.GetFactory(DataProvider.AdoNet, _connectionStrings.DpDbConnectionString);


        public MovieService(IOptions<AppSettings> appSettings, IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public async Task<List<Movie>> GetMovies(string searchStr)
        {
            //TODO Paging
            return await AdoDao.MovieDao.GetMovies(searchStr);
        }

        public async Task<Movie> GetById(int movieId)
        {
            throw new NotImplementedException();
        }
        public async Task<int?> AddMovie(MovieRequest movie)
        {
            return await AdoDao.MovieDao.AddMovie(movie);

        }
    }
}