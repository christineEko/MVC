using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class MoviesController : Controller
    {
        MyDbContext _context;

        public MoviesController()
        {
            _context = new MyDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).Where(c => c.Id == id).SingleOrDefault();

            return View(movie);
        }

        // GET: Movies
        public ActionResult Random()
        {
            Movie movie = new Movie { Name = "Shrek" };
            List<Customer> customers = new List<Customer>
            {
                new Customer{Name="customer 1"},
                new Customer{Name="customer 2"}
            };

            RandomMovieViewModels randomMovies = new RandomMovieViewModels
            {
                Movie = movie,
                Customers = customers
            };

            return View(randomMovies);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
			var movieFormViewModel = new MovieFormViewModel (movie)
			{
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", movieFormViewModel);
        }

		public ActionResult New()
		{
			var movieFormViewModel = new MovieFormViewModel
			{
				Genres = _context.Genres.ToList()
			};
			return View("MovieForm", movieFormViewModel);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel (movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

			if (movie.Id == 0)
			{
				_context.Movies.Add(movie);
			}
			else
			{
				var existingMovie = _context.Movies.Where(m => m.Id == movie.Id).FirstOrDefault();
				existingMovie.Name = movie.Name;
				existingMovie.NumberInStock = movie.NumberInStock;
				existingMovie.ReleaseDate = movie.ReleaseDate;
				existingMovie.GenreId = movie.GenreId;
			}

			_context.SaveChanges();

			return RedirectToAction("Index");
		}

        //public ActionResult Edit(int movieId)
        //{
        //    return Content("Id = " + movieId);
        //}

        //public ActionResult Index(int? pageIndex, String sortBy)
        //{
        //    if(!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }

        //    if(String.IsNullOrEmpty(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content($"pageIndex={pageIndex} and sortBy={sortBy}");
        //}

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content($"year={year}, month = {month}");
        }
    }
}