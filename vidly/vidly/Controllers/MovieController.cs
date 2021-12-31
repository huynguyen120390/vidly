using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Validation;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customerList = _context.Movies.Include(m => m.Genre).ToList();
            return View(customerList);
        }


        //GET: Customer/Details/1
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m=>m.Id==id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Movie = new Movie(),
                Genres = genres,
                ViewTitle = "Add New Movie"
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = genres,
                ViewTitle = "Edit Movie"
            };
            return View("MovieForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            var genres = _context.Genres.ToList();
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Genres = genres,
                    Movie = movie
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id); //This will thrown an exception if customer is not found
                //TryUpdateModel(customerInDb); //Don't try to update all properties with this function
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate= movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.DateAdded = movie.DateAdded;
                //We can use Auto Mapper to map, but still consider limited amount of info which user can update

            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            return RedirectToAction("Index", "Customer");
        }
    }
}