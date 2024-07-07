using AspNetCoreMvc_eTicaret_MovieSales.Data;
using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;

namespace AspNetCoreMvc_eTicaret_MovieSales.Repositories
{
    public class MovieSaleDetailRepository : IMovieSaleDetailRepository
    {
        private readonly MovieDbContext _context;
        public MovieSaleDetailRepository(MovieDbContext context)
        {
            _context = context;
        }

        public void Add(MovieSaleDetail detail)
        {
            _context.MovieSalesDetail.Add(detail);
            _context.SaveChanges();
        }

        public bool AddRange(List<MovieSaleDetail>? sepet, int movieSaleId)
        {
            foreach (var item in sepet)
            {
                MovieSaleDetail newDetail = new MovieSaleDetail()
                {
                    MovieSaleId = movieSaleId,
                    MovieId = item.MovieId,
                    Number = item.Number,
                    UnitPrice = item.UnitPrice,

                };
                _context.MovieSalesDetail.Add(newDetail); // ara katmana ekler 

                try
                {
                    _context.SaveChanges(); //veritabanına hepsini birden gönderdik. Çünkü SaveChanges methodunun transaction özelliğinden yararlandık.
                    return true;
                }
                catch (Exception ex) 
                {
                    string message = ex.Message;
                }
            }
            return false;

        }

        public void Delete(MovieSaleDetail detail)
        {
            _context.MovieSalesDetail.Remove(detail);
            _context.SaveChanges();
        }

        public MovieSaleDetail Get(int id)
        {
            return _context.MovieSalesDetail.Find(id);
        }

        public List<MovieSaleDetail> GetAll()
        {
            return _context.MovieSalesDetail.ToList();
        }

        public void Update(MovieSaleDetail detail)
        {
            _context.MovieSalesDetail.Update(detail);
            _context.SaveChanges();
        }
    }
}
