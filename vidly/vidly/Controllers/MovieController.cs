using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;

namespace vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customerList = new List<Movie>()
            {
                new Movie() {Id = 0, Name = "Con co be be"},
                new Movie() {Id = 1, Name = "Con chim non"}
            };
            return View(customerList);
        }

        //GET: Customer/Details/1
        public ActionResult Details(int id)
        {
            var customerList = new List<Movie>()
            {
                new Movie() {Id = 0, Name = "Con co be be"},
                new Movie() {Id = 1, Name = "Con chim non"}
            };
            if (id >= customerList.Count)
            {
                return HttpNotFound();
            }
            return View(customerList[id]);
        }
    }
}