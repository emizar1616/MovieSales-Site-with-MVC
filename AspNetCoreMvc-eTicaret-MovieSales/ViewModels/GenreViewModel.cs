using AspNetCoreMvc_eTicaret_MovieSales.Models;

namespace AspNetCoreMvc_eTicaret_MovieSales.ViewModels
{
    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
