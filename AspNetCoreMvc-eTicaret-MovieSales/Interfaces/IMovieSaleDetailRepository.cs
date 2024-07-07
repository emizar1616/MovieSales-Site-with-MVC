using AspNetCoreMvc_eTicaret_MovieSales.Models;

namespace AspNetCoreMvc_eTicaret_MovieSales.Interfaces
{
    public interface IMovieSaleDetailRepository
    {
        public List<MovieSaleDetail> GetAll();
        public MovieSaleDetail Get(int id);
        public void Add(MovieSaleDetail detail);
        public bool AddRange(List<MovieSaleDetail>? sepet , int movieSaleId);
        public void Update(MovieSaleDetail detail);
        public void Delete(MovieSaleDetail detail);
    }
}
