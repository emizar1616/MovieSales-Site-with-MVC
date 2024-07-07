namespace AspNetCoreMvc_eTicaret_MovieSales.Models
{
    public class Genre                     //Film Turleri
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
