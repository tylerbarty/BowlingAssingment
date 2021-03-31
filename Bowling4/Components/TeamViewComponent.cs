using Bowling4.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling4.Components
{
    public class TeamViewComponent : ViewComponent 
    {
        private BowlingContext context;

        public TeamViewComponent(BowlingContext ctx)
        {
            context = ctx;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["TeamName"];

            return View(context.Teams
                .Distinct()
                .OrderBy(x => x)
                );
        }
    }
}
