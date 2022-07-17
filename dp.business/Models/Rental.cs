using dp.business.Enums;
using System;

namespace dp.business.Models

{
    public class RentalRequest
    {
        public int MovieId { get; set; }
    }

    public class Rental
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// Date Rented
        /// </summary>
        public DateTime Rented { get; set; }
        /// <summary>
        /// Date Returned
        /// </summary>
        public DateTime Returned { get; set; }
        public RentalStatus Status { get; set; }
    }
    public class RentalMovies : Rental
    {
        /// <summary>
        /// Movie Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Movie Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Url to Movie thumbnail
        /// </summary>
        public string ImageUrl { get; set; }
    }
}