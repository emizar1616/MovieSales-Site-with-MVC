using AspNetCoreMvc_eTicaret_MovieSales.Interfaces;
using AspNetCoreMvc_eTicaret_MovieSales.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_eTicaret_MovieSales.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IMapper _mapper;
        public MovieController(IMovieRepository movieRepo, IMapper mapper)    
        {
            _movieRepo = movieRepo;
            _mapper = mapper;
        }
        public IActionResult Index(int? id, string? search)
        {
            var movies = _movieRepo.GetAll();
            if (search != null)
            {
                movies = movies.Where(m => m.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            if (id != null)
            {
                movies = movies.Where(m => m.GenreId == id).ToList();
            }
            return View(movies);
        }

        public IActionResult AddImages(Movie model, IFormFile formFile)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", formFile.FileName);
            var stream = new FileStream(path, FileMode.Create);
            formFile.CopyTo(stream);
            model.ImageUrl = "/images/" + formFile.FileName;
            _movieRepo.Add(_mapper.Map<Movie>(model));
            return RedirectToAction("Index");
        }

        public IActionResult Populer()
        {
            var movies = _movieRepo.GetAll().Where(m => m.IsPopular == true).ToList();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movies = _movieRepo.Get(id);
            return View(movies);
        }

        public IActionResult Local(bool isLocal)
        {
            var movies = _movieRepo.GetAll();
            if (isLocal)
            {
                movies = movies.Where(m => m.IsLocal == true).ToList();
                ViewBag.Local = "Yerli";
            }
            else
            {
                movies = movies.Where(m => m.IsLocal == false).ToList();
                ViewBag.Local = "Yabancı";

            }

            return View(movies);
        }
    }
}
