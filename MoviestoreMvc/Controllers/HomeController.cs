using Microsoft.AspNetCore.Mvc;
using MoivestoreMvc.Repositories.Abstract;
using MoiveStoreMvc.Models.Domin;
namespace MoivestoreMvc.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }
 
        public IActionResult Index()
        {
            var movies = _movieService.List();
            return View(movies);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult MovieDetail(int movieId)
        {
            var movie = _movieService.GetById(movieId);
            return View(movie);
        }
    }
}
