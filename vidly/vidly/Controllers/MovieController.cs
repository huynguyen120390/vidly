using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using vidly.Models;

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
    }
}