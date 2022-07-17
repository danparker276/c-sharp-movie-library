namespace dp.business.Models

{
    public class MovieRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

    public class Movie : MovieRequest
    {
        public int Id { get; set; }
    }

}