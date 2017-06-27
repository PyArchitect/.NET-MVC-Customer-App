using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Navicon.Models;
using Navicon.ViewModels;

namespace Navicon.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        //public ActionResult CustomerTable()
        //{
        //    var customers = new List<Customer>
        //    {
        //        new Customer{Name = "John Williams"},
        //        new Customer{Name = "Anna Vachovski"}
        //    };

        //    var vievModel = new CustomerTableViewModel()
        //    {
        //        Clients = customers
        //    };


        //    return View(vievModel);
        //}

        //[Route("Customers/")]
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        [Route("Customers/Details/{Id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult New()
        {
            var viewModel = new NewCustomerViewModel();
            return View("CustomerFormAdd");
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer
                    
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                //ModelState.Remove(nameof(Customer.Id));
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb);
                customerInDb.Name = customer.Name;
                customerInDb.Surname = customer.Surname;
                customerInDb.Patronymic = customer.Patronymic;
                customerInDb.Sex = customer.Sex;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.Age = customer.Age; 
                customerInDb.Description = customer.Description;

            }
            
            _context.SaveChanges();
            

            return RedirectToAction("Index","Customer");
        }

        [HttpPost]
        public ActionResult Add(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer

                };
                return View("CustomerFormAdd", viewModel);
            }
            if (customer.Id == 0)
            {
                //ModelState.Remove(nameof(Customer.Id));
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb);
                customerInDb.Name = customer.Name;
                customerInDb.Surname = customer.Surname;
                customerInDb.Patronymic = customer.Patronymic;
                customerInDb.Sex = customer.Sex;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.Age = customer.Age;
                customerInDb.Description = customer.Description;

            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Customer");
        }



        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel()
            {
                Customer = customer,
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult DeleteForm()
        {
            var viewModel = new NewCustomerViewModel();
            return View("Delete");
        }
        [HttpPost]
        //public ActionResult Delete(Customer customer)
        //{
        //    //var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

        //    if (customer.Id != 0)
        //    {
        //        var customerDeleted = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
        //        _context.Customers.Remove(customerDeleted);
        //        _context.SaveChanges();


        //    }

        //    return RedirectToAction("Index", "Customer");
        //}

        public ActionResult Delete(deletionID CustomersIDs)
        {
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (!ModelState.IsValid)
        {
            var viewModel = new NewCustomerViewModel();
            return View("Delete", viewModel);
        };
            
        

        if (!String.IsNullOrEmpty(CustomersIDs.DescriptionIDs))
        {
            List<int> myList = new List<int>();
               
            myList.AddRange(CustomersIDs.DescriptionIDs.Split(',').Select(i => int.Parse(i)));
            foreach (int id in myList)
            {
                var customerDeleted = _context.Customers.SingleOrDefault(c => c.Id == id);
                _context.Customers.Remove(customerDeleted);
                _context.SaveChanges();
            }
                
        }

        return RedirectToAction("Index", "Customer");
        }
    }
}






//        public ActionResult Index(int? pageIndex, string sortBy)
//        {
//            if (!pageIndex.HasValue)
//            {
//                pageIndex = 1;
//            }
//            if (String.IsNullOrWhiteSpace(sortBy))
//                sortBy = "Name";

//            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
//        }

//        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
//    }
//}