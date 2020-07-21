using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Job> jobs = new List<Job>() { };
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.jobs = jobs;
            return View();
        }



        // TODO #3: Create an action method to process a search request and render the updated search view.
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;
            if (searchTerm == null)
            {
                jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Jobs with " + searchType + ": " + searchTerm;
            }

            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.jobs = jobs;
            return View("Index");
        }
    }
}
// If the user leaves the search box empty, call the FindAll() method from JobData.Otherwise, send the search information to FindByColumnAndValue.In either case, store the results in a jobs list.
// Pass jobs into the Search/Index view via ViewBag.
// Pass ListController.ColumnChoices into the view, as the existing search handler does.
// Display Search Results