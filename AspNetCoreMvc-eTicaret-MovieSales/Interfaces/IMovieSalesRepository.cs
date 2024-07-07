using AspNetCoreMvc_eTicaret_MovieSales.Models;

namespace AspNetCoreMvc_eTicaret_MovieSales.Interfaces
{
    public interface IMovieSalesRepository
    {
        public List<MovieSale> GetAll();
        public MovieSale Get(int id);
        public void Add(MovieSale sale);
        public int AddSale(MovieSale sale);
        public void Update(MovieSale sale);
        public void Delete(MovieSale sale);
    }
}
