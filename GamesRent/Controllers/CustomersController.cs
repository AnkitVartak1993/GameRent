using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesRent.Models;
using System.Data.Entity;
using GamesRent.ViewModels;
namespace GamesRent.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList(); 

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var MembershipType = _context.MembershipType.ToList();
            var viewModel = new CustomerViewModel {MembershipType = MembershipType };


            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Save (Customer customer)
        {

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {

                var customerUpdate = _context.Customers.Single(c => c.Id == customer.Id);

                customerUpdate.Id = customer.Id;
                customerUpdate.BirthDate = customer.BirthDate;
                customerUpdate.IsSubscribedtoNews = customer.IsSubscribedtoNews;
                customerUpdate.MemberShipType = customer.MemberShipType;
                customerUpdate.Name = customer.Name;

            }

            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerViewModel
            {
                Customer = customer,
             MembershipType = _context.MembershipType.ToList()

            };
           return View("New",viewModel);

        }

    }
}