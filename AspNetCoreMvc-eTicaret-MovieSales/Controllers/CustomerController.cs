using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;
using AspNetCoreMvc_eTicaret_MovieSales.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_eTicaret_MovieSales.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _cRepo;
        private readonly IMapper _mapper;
        private readonly IMovieSalesRepository _movieSaleRepo;
        private readonly IMovieSaleDetailRepository _movieSaleDetailRepo;

        public CustomerController(ICustomerRepository cRepo, IMapper mapper, IMovieSalesRepository movieSaleRepo, IMovieSaleDetailRepository movieSaleDetailRepo)
        {
            _cRepo = cRepo;
            _mapper = mapper;
            _movieSaleRepo = movieSaleRepo;
            _movieSaleDetailRepo = movieSaleDetailRepo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(CustomerLoginViewModel model)
        {
            var customer = _cRepo.GetAll().FirstOrDefault(c => c.Email == model.Email && c.Password == model.Password);
            if (ModelState.IsValid)
            {
                if (customer == null)
                {
                    ModelState.AddModelError(string.Empty, "Hatalı email veya şifre girişi.");
                }
            }
            else
            {
                HttpContext.Session.SetJson("user", customer); //Login olan kullanıcı bilgilerini session'a kayıt ediyoruz.
                return RedirectToAction("ConfirmAddress");
            }
            return View(model);  
        }

        public IActionResult ConfirmAddress() 
        {
            //Dışarıdan gelebilecek olan ataklara karşı öncelikle kullanıcıyı session'dan çekip kontrol ediyoruz.
            var customer = HttpContext.Session.GetJson<Customer>("user");
            if (customer == null)
            {
                return RedirectToAction("Login");
            }
            return View(_mapper.Map<CustomerViewModel>(customer));
        }
        [HttpPost]
        public IActionResult ConfirmAddress(CustomerViewModel model)
        {
            _cRepo.Update(_mapper.Map<Customer>(model));
            return RedirectToAction("ConfirmPayment");
        }

        public IActionResult ConfirmPayment()
        {
            //Dışarıdan gelebilecek olan ataklara karşı öncelikle kullanıcıyı session'dan çekip kontrol ediyoruz.
            var customer = HttpContext.Session.GetJson<Customer>("user");
            if (customer == null)
            {
                return RedirectToAction("Login");
            }
            //sepet bilgileri session'dan çekilecek
            var sepet = HttpContext.Session.GetJson<List<SepetDetay>>("sepet");
                SepetDetay sd = new SepetDetay();
                int toplamAdet = sd.ToplamAdet(sepet);
                decimal toplamTutar = sd.ToplamTutar(sepet);

            MovieSaleViewModel movieSale = new MovieSaleViewModel(); 
            movieSale.CustomerId = customer.Id;
            movieSale.Date=DateTime.Now;
            movieSale.TotalQuantity = toplamAdet;
            movieSale.TotalPrice = toplamTutar;

            CustomerFaturaViewModel customerFaturaViewModel = new CustomerFaturaViewModel() //Birden fazla modelden veri çekmek istiyorsan sorun yaşamamak için bir modeli içerisinde almak istediğin modellerin bilgilerini alarak çıkartabilirsin.
            {
                customerViewModel = _mapper.Map<CustomerViewModel>(customer),
                satisViewModel = movieSale,
                sepetDetayListesi = sepet,

            };
                return View(customerFaturaViewModel);
            }
        [HttpPost]
        public IActionResult ConfirmPayment(CustomerFaturaViewModel model)
        {
            var satisId = _movieSaleRepo.AddSale(_mapper.Map<MovieSale>(model.satisViewModel));
            var sepet = HttpContext.Session.GetJson<List<SepetDetay>>("sepet");
            //if (_movieSaleDetailRepo.AddRange(sepet, satisId))
            //{
            //    TempData["mesaj"] = "Satış işlemi başarıyla tamamlandı.";
            //    HttpContext.Session.Remove("sepet"); //Sepet bilgileri session'dan silinir. Ancak müşteri isterse yeniden alışverişe devam edebilir.
            //}else
            //{
            //    TempData["mesaj"] = "Satış işlemi gerçekleşmedi. Bilgilerinizi kontrol edin.";
            //}

            return View();
        }



        public IActionResult Create()
        {
            return View(); //Direkt oluşturup create view ını oluşturduk. 
        }

    }
}
