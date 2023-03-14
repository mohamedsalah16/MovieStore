using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoivestoreMvc.Models.Domin;
using MoivestoreMvc.Repositories.Abstract;
using MoivestoreMvc.Repositories.Implementation;
using MoviestoreMvc.Repositories.Implementation;
using MovieStoreMvc.Models.Domin;

namespace MoivestoreMvc.Controllers
{
//    [Authorize]
    public class MoiveController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IFileService _fileService;
        private readonly IGenreService _genService;
        public MoiveController(IGenreService genService, IMovieService MovieService, IFileService fileService)
        {
            _movieService = MovieService;
            _fileService = fileService;
            _genService = genService;
        }
        public IActionResult Add()
        {
            var model = new Movie();
            model.GenreList = _genService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Movie model)
        {
            model.GenreList = _genService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileReult = this._fileService.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileReult.Item2;
                model.MovieImage = imageName;
            }
            var result = _movieService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult Edit(int id)
        {
            var model = _movieService.GetById(id);
            var selectedGenres = _movieService.GetGenreByMovieId(model.Id);
            MultiSelectList multiGenreList = new MultiSelectList(_genService.List(), "Id", "GenreName", selectedGenres);
            model.MultiGenreList = multiGenreList;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Movie model)
        {
            var selectedGenres = _movieService.GetGenreByMovieId(model.Id);
            MultiSelectList multiGenreList = new MultiSelectList(_genService.List(), "Id", "GenreName", selectedGenres);
            model.MultiGenreList = multiGenreList;
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileReult = this._fileService.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileReult.Item2;
                model.MovieImage = imageName;
            }
            var result = _movieService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(MoiveList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult MoiveList()
        {
            var data = this._movieService.List();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _movieService.Delete(id);
            return RedirectToAction(nameof(MoiveList));
        }




        //private readonly IMovieService _moiveService;
        //private readonly IFileService _fileService;
        //private readonly IGenreService _genreService;

        //public MoiveController(IGenreService genreService, IMovieService moiveService, IFileService fileService)
        //{
        //    _moiveService = moiveService;
        //    _fileService = fileService;
        //    _genreService = genreService;
        //}
        //public IActionResult Add()
        //{
        //    var model = new Movie();
        //    model.GenreList = _genreService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.ToString() });
        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult Add(Movie model)
        //{
        //    model.GenreList = _genreService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.ToString() });

        //    if (!ModelState.IsValid)
        //        return View(model);
        //    if (model.ImageFile != null)
        //    {
        //        var fileResult = this._fileService.SaveImage(model.ImageFile);
        //        if (fileResult.Item1 == 0)
        //        {
        //            TempData["msg"] = "File cloud not saved";
        //            return View(model);

        //        }
        //        var imageName = fileResult.Item2;
        //        model.MovieImage = imageName;
        //    }
        //    var result = _moiveService.Add(model);
        //    if (result)
        //    {
        //        TempData["msg"] = "Added Successfully";
        //        return RedirectToAction(nameof(Add));
        //    }
        //    else
        //    {
        //        TempData["msg"] = "Error on server side";
        //        return View(model);
        //    }
        //}

        //public IActionResult Edit(int id)
        //{
        //    var model = _moiveService.GetById(id);
        //    var selectedGenres = _moiveService.GetGenreByMovieId(model.Id);
        //    MultiSelectList multiGenreList = new MultiSelectList(_genreService.List(), "Id", "GenreName", selectedGenres);
        //    model.MultiGenreList = multiGenreList;
        //    return View(model);
        //}
        //[HttpPost]
        //public IActionResult Edit(Movie model)
        //{
        //    var selectedGenres = _moiveService.GetGenreByMovieId(model.Id);
        //    MultiSelectList multiGenreList = new MultiSelectList(_genreService.List(), "Id", "GenreName", selectedGenres);
        //    model.MultiGenreList = multiGenreList;
        //    if (!ModelState.IsValid)
        //        return View(model);
        //    if (model.ImageFile != null)
        //    {
        //        var fileResult = this._fileService.SaveImage(model.ImageFile);
        //        if (fileResult.Item1 == 0)
        //        {
        //            TempData["msg"] = "File cloud not saved";
        //            return View(model);
        //        }
        //        var imageName = fileResult.Item2;
        //        model.MovieImage = imageName;
        //    }
        //    var result = _moiveService.Update(model);
        //    if (result)
        //    {
        //        TempData["msg"] = "Added Successfully";
        //        return RedirectToAction(nameof(MoiveList));
        //    }
        //    else
        //    {
        //        TempData["msg"] = "Error on server side";
        //        return View(model);
        //    }
        //}

        //public IActionResult MoiveList()
        //{
        //    var data = this._moiveService.List();
        //    return View(data);
        //}

        //public IActionResult Delete(int id)
        //{
        //    var result = _moiveService.Delete(id);
        //    return RedirectToAction(nameof(MoiveList));
        //}



    }
}
