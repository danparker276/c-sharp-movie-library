namespace dp.business.Models

{
    public class MovieRequest
    {
        /// <summary>
        /// Title of the Movie
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Movie Description
        /// </summary>
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

    public class Movie : MovieRequest
    {
        public int Id { get; set; }
    }

}