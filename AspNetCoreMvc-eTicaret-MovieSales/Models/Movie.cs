namespace AspNetCoreMvc_eTicaret_MovieSales.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Summary { get; set; }
        public DateTime RelaseDate { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsLocal { get; set; }  //yerli-yabancı
        public bool IsPopular { get; set; }
        public bool IsDiscount { get; set; }
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public List<MovieSaleDetail> Sales { get; set; }
    }
}
