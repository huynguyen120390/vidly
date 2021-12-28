using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;

namespace vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customerList = new List<Customer>()
            {
                new Customer() {Id = 0, Name = "Huy"},
                new Customer() {Id = 1, Name = "Ai"}
            };
            return View(customerList);
        }

        //GET: Customer/Details/1
        public ActionResult Details(int id)
        {
            var customerList = new List<Customer>()
            {
                new Customer() {Id = 0, Name = "Huy"},
                new Customer() {Id = 1, Name = "Ai"}
            };
            if (id >= customerList.Count)
            {
                return HttpNotFound();
            }
            return View(customerList[id]);
        }
    }
}