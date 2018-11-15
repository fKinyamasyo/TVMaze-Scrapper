using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvMaze.Scraper.Interfaces
{
    interface IScrapper
    {
        /// <summary>
        ///Scraps shows form TvMaze site and stores them in local database
        /// </summary>
        /// <returns></returns>
        Task Scrape(int pageNumber);
    }
}
