using dp.api.Authorization;
using dp.api.Helpers;
using dp.business.Enums;
using dp.business.Models;
using dp.data;
using dp.data.Interfaces;
using Microsoft.Extensions.Options;

namespace dp.api.Services
{
    public interface IRentalService
    {
        Task<List<RentalMovies>> GetRentals(int userId);
        Task<int?> AddRental(RentalRequest rental, int userId);
        Task UpdateRental(RentalUpdateRequest rentalUpdate);

    }

    public class RentalService : IRentalService
    {

        private readonly ConnectionStrings _connectionStrings;

        private IDaoFactory AdoDao => DaoFactories.GetFactory(DataProvider.AdoNet, _connectionStrings.DpDbConnectionString);


        public RentalService(IOptions<AppSettings> appSettings, IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public async Task<List<RentalMovies>> GetRentals(int userId)
        {
            //TODO Paging
            return await AdoDao.RentalDao.GetCurrentRentals(userId);
        }

        public async Task<int?> AddRental(RentalRequest rental, int userId)
        {
            return await AdoDao.RentalDao.AddRental(userId, rental.MovieId);

        }
        public async Task UpdateRental(RentalUpdateRequest rentalUpdate)
        {
            await AdoDao.RentalDao.UpdateRental(rentalUpdate.RentalId, rentalUpdate.Status);

        }
    }
}