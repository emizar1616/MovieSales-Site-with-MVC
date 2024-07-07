using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;

namespace AspNetCoreMvc_eTicaret_MovieSales.Repositories
{
    public class MovieSaleRepository : IMovieSalesRepository
    {
        private readonly MovieDbContext _context;
        public MovieSaleRepository(MovieDbContext context)
        {
            _context = context;
        }

        public void Add(MovieSale sale)
        {
            _context.MovieSales.Add(sale);
            _context.SaveChanges();
        }

        public int AddSale(MovieSale sale)
        {
            _context.MovieSales.Add(sale);
            _context.SaveChanges();
            return sale.Id;
        }

        public void Delete(MovieSale sale)
        {
            _context.MovieSales.Remove(sale);
            _context.SaveChanges();
        }

        public MovieSale Get(int id)
        {
            return _context.MovieSales.Find(id);
        }

        public List<MovieSale> GetAll()
        {
            return _context.MovieSales.ToList();
        }

        public void Update(MovieSale sale)
        {
            _context.MovieSales.Update(sale);
            _context.SaveChanges();
        }
    }
}
