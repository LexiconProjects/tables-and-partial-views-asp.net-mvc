using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TablesAndViews.Models;

namespace TablesAndViews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PeopleTable()
        {
            PeopleModel.GenerateResultList();
            return View();
        }

        public IActionResult RegisteredPeople()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterPeople(string name,string phone,string city)
        {
            PeopleModel.AddPerson(name,phone,city);
            return View("PeopleTable");
        }

        public IActionResult RemovePerson(int index)
        {
            PeopleModel.RemovePerson(index);
            return View("PeopleTable");
        }

        [HttpPost]
        public IActionResult FilterPeople(string filter)
        {       
            PeopleModel.FilterBy(filter);
            return View("PeopleTable");
        }

        [HttpPost]
        public IActionResult ResetFilter(string filterReset)
        {
            if(filterReset == "reset")
                PeopleModel.ResetFilter();
            return View("PeopleTable");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
