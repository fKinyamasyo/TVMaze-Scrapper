using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TvMaze.Scraper.Implementations;
using TvMaze.Scraper.Models;

namespace TvMaze.Scraper.Controllers
{
    [Route("api/Shows/{pageNumber}")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        [HttpGet]
        public string GetShows(int pageNumber)
        {
            //start scrapping
            Scrapper scrapper = new Scrapper();
            Task result = scrapper.Scrape(pageNumber);
            List<ShowViewModel> shows = new List<ShowViewModel>();
            if (result.IsCompleted)
            {

                using (var db =  new MovieContext())
                {
                    var tvshows = db.Shows.Where(p => p.PageNumber == pageNumber).ToList();
                    foreach (var item in tvshows)
                    {
                        var show = new ShowViewModel
                        {
                            Id = item.Id,
                            Name = item.Name
                        };
                        show.Cast = new List<CastViewModel>();
                        var casts = db.Casts.Where(p => p.ShowId == item.Id).OrderByDescending(p=>p.Birthday);
                        foreach (var castItem in casts)
                        {
                            var model = new CastViewModel
                            {
                                Id = castItem.Id,
                                Birthday = castItem.Birthday,
                                Name = castItem.Name
                            };
                            show.Cast.Add(model);
                        }

                        shows.Add(show);
                    }
                }
            }
            return JsonConvert.SerializeObject(shows);
           
        }
    }
}