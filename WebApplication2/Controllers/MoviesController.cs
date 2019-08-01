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
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
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