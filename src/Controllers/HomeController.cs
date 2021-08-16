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
            List<Forum> forums = this.dbContext.Forums
                .Where(x => !x.ParentId.HasValue)
                .Select(x => new Forum
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    Parent = x.Parent,
                    Children = x.Children.Select(c => new Forum
                    {
                        Name = c.Name,
                        ParentId = c.ParentId,
                        Parent = new Forum {
                           Name = c.Parent.Name
                        }
                    })
                    .ToList()       
                })
                .ToList();

            var test = this.dbContext.Forums
                .Where(x => !x.ParentId.HasValue)
                .Include(f => f.Children)
                .Include(p => p.Parent)
                .ToList();

            this.ViewData["forums"] = forums;

            return View();

            //var moviesTest = dbContext.Movies
            //    .Select(x => new MovieDTO
            //    {
            //        Id = x.Id,
            //        Name = x.Name,
            //        MovieNumber = x.MovieNumber,
            //        MovieLength = x.MovieLength,
            //        Director = x.Director,
            //        Producer = x.Producer,
            //        DistributedBy = x.DistributedBy,
            //        ReleaseDate = x.ReleaseDate,
            //        Country = x.Country,
            //        Language = x.Language,
            //        Budget = x.Budget,
            //        BoxOffice = x.BoxOffice,
            //        Actors = x.Actors
            //            .Select(a => new MovieActorDTO
            //            {
            //                Id = a.Id,
            //                FullName = a.FullName,
            //                Url = "https://thematrixapi.com/api/actors/" + a.Id
            //            }).ToList(),
            //        Races = x.Races
            //            .Select(r => new MovieRaceDTO
            //            {
            //                Id = r.Id,
            //                Name = r.Name,
            //                Url = "https://thematrixapi.com/api/races/" + r.Id
            //            }).ToList()
            //    }).ToList();
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
