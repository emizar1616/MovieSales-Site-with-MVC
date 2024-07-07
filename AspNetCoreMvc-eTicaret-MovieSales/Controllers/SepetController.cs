using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_eTicaret_MovieSales.Controllers
{
    public class SepetController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        public SepetController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        List<SepetDetay> sepet;
        SepetDetay siparis = new SepetDetay();

        public IActionResult Index()
        {
            sepet = SepetAl();
            TempData["Toplam Adet"] = siparis.ToplamAdet(sepet);
            TempData["Toplam Tutar"] = siparis.ToplamTutar(sepet);

            return View(sepet);
        }

        public IActionResult Ekle(int Id, int adet)
        {
            var movie = _movieRepository.Get(Id);
            sepet = SepetAl();
            SepetDetay siparis = new SepetDetay();
            siparis.MovieId=movie.Id;
            siparis.MovieName=movie.Name;
            siparis.MovieQuantity = adet;
            siparis.MoviePrice = movie.Price;
            sepet = siparis.SepeteEkle(sepet,siparis);
            SepetKaydet(sepet);
            return RedirectToAction("Index"); 

        }

        public List<SepetDetay> SepetAl()
        {
            var sepet = HttpContext.Session.GetJson<List<SepetDetay>>("sepet") ?? new List<SepetDetay>();
            //Buradaki 2 tane arka arkaya soru işareti null ise anlamı taşır. Tek soru işareti null değil anlamı taşırken yeni versiyonlarla gelen (??) işareti null ise anlamı taşımaktadır.

            return sepet;
        }

        public void SepetKaydet(List<SepetDetay> sepet)
        {
            HttpContext.Session.SetJson("sepet", sepet);
        }
    }
}
