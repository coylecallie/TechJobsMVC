using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        List<Dictionary<string, string>> jobs;

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType == "all")
            {
                jobs = JobData.FindByValue(searchTerm);
            }

            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search Results";
            ViewBag.jobs = jobs;

            return View("Index");
        }

    }
}
