using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TvMaze.Scraper.Models
{
    public class Functions
    {
        static public readonly int PAGE_SIZE = 250;

        private const int RateLimitSleepTimerSecs = 1;
        private const int HttpStatusCodeReachedRateLimit = 429;
        private const string _baseUrl = "http://api.tvmaze.com";

        /// <summary>
        /// Get list of tv shows from TvMaze. 
        /// Shows are paginated by pages where each page is 250 rows
        /// </summary>
        /// <param name="pageNumber">pagenumber</param>
        /// <returns>list of tv shows</returns>
       
    }
}
