using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using  System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        // GET
        public ViewResult Index()
        {
            using (var c = new ApplicationDbContext())
            {
                var customers = c.Customers.Include(x => x.MembershipType).ToList();

                return View(customers);

            }
        }

        public ActionResult New()
        {
            using (var c = new ApplicationDbContext())
            {
                var membershipTypes = c.MembershipTypes.ToList();
                var viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = membershipTypes
                };
                return View("CustomerForm", viewModel);
            }
        }

        public ActionResult Details(int id)
        {
            using (var c = new ApplicationDbContext())
            {
                var customer = c.Customers.Include(x => x.MembershipType).SingleOrDefault(x => x.Id == id);

                if (customer == null)
                    return HttpNotFound();

                return View(customer);
            }
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            using (var c = new ApplicationDbContext())
            {
                c.Customers.Add(customer);
                c.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
        }

        public ActionResult Edit(int id)
        {
            using (var c = new ApplicationDbContext())
            {
                var customer = c.Customers.SingleOrDefault(cu => cu.Id == id);
                if (customer == null)
                    return HttpNotFound();
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = c.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
        }
    }
}