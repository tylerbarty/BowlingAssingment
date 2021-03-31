using Bowling4.Models;
using Bowling4.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BowlingContext context;

        public HomeController(ILogger<HomeController> logger, BowlingContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index(long? teamid, string teamname, int pageNum = 0)
        {
            int pageSize = 5;

            return View(new IndexViewModel
            {
                Bowlers = context.Bowlers
                .Where(m => m.TeamId == teamid || teamid == null)
                .OrderBy(m => m.BowlerLastName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList(),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,

                    // IF no meal has been seleted, then get the full count.
                    // Otherwise only count the number from the meal type that has been selected
                    TotalNumItems = (teamid == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == teamid).Count())
                },

                TeamName = teamname
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
