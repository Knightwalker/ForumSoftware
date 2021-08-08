namespace ForumSoftware.Controllers
{
    using System.Linq;
    using System.Diagnostics;
    using System.Collections.Generic;
    using ForumSoftware.Data;
    using ForumSoftware.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Forum> forums = this.dbContext.Forums.Include(x => x.Topics).ToList();
            this.ViewData["forums"] = forums;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
