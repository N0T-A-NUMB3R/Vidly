using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using  System.Data.Entity;

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
       
    }
}