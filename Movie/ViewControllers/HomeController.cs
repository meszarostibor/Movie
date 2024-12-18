using Microsoft.AspNetCore.Mvc;
using Movie.Models;
using Movie.Services;
using System.Diagnostics;
using System.Dynamic;

namespace Movie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult FilmekDTO()
        {
            return View(FilmService.GetFilmekDTO());
        }

        public IActionResult BoritokepView(int id)
        {
            return View(FilmService.GetBoritokep(id));
        }

        public IActionResult FilmKarbantartas(int id)
        {
            dynamic myModel=new ExpandoObject();
            myModel.Film=FilmService.GetFilm(id);
            myModel.Rendezok = RendezoService.GetRendezok();
            myModel.Mufajok = MufajService.GetMufajok();
            return View(myModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
