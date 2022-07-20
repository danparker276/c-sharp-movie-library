using dp.api.Authorization;
using dp.api.Services;
using dp.business.Enums;
using dp.business.Models;
using Microsoft.AspNetCore.Mvc;

namespace dp.api.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : BaseController
    {
        private IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        /// <summary>
        /// Get all Rentals for current user
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            User user = GetClaimedUser();
            //add skip/take... later on
            List<RentalMovies> rentals = await _rentalService.GetRentals(user.UserId);
            return Ok(rentals);
        }

        /// <summary>
        /// Add a rental to a user
        /// </summary>
        /// <param name="rental"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddRental(RentalRequest rental)
        {
            User user = GetClaimedUser();
            //add skip/take... later on
            int? rentalId = await _rentalService.AddRental(rental,user.UserId);
            return Ok(rentalId);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rentalUpdate"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateRental(RentalUpdateRequest rentalUpdate)
        {
            User user = GetClaimedUser();
            //add skip/take... later on
            await _rentalService.UpdateRental(rentalUpdate);
            //would add error handling
            return Ok();
        }

    }
}