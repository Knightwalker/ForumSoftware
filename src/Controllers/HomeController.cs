namespace ForumSoftware.Controllers
{
    using ForumSoftware.Data;
    using ForumSoftware.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Forum> forums = this.dbContext.Forums
                .Where(x => !x.ParentId.HasValue)
                .Select(x => new Forum
                {
                    Id = x.Id,
                    Name = x.Name,           
                    Children = x.Children.Select(c => new Forum
                    {
                        Name = c.Name,
                        Description = x.Description,
                    })
                    .ToList()       
                })
                .ToList();

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
