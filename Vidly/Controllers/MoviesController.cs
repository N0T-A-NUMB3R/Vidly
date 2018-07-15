using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek"};
            var customer = new List<Customer>
            {
                new Customer() {Name = "Customer1"},
                new Customer() {Name = "Customer2"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customer
            };
            return View(viewModel);

        }
        //[Route("movies/released/{year}/{month:regex(\\d{4}:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year} --- {month}");
        }


        public ActionResult Edit(int id)
        {
            return Content($"Id ={id}");
        }
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content($"page index ={pageIndex} and sortby ={sortBy}");
        }
    }
}