using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvMaze.Scraper.Interfaces;
using TvMaze.Scraper.Models;

namespace TvMaze.Scraper.Implementations
{
    public class Scrapper : IScrapper
    {
        public Task Scrape(int pageNumber)
        {
            var client = new RestClient("http://api.tvmaze.com/");
            

            var request = new RestRequest("shows/"+pageNumber.ToString(), Method.GET);
            

            

            // execute the request
            IRestResponse response = client.Execute(request);
            if (response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                var content = response.Content; // raw content as string
                TVShowModel show = JsonConvert.DeserializeObject<TVShowModel>(content);

                //check if show exists in our database and add
                using (var db =  new MovieContext())
                {
                    
                        var check = db.Shows.FirstOrDefault(p => p.Name == show.name);
                        if (check==null)
                        {
                            check = new Show
                            {
                                Name = show.name,
                                PageNumber = pageNumber
                            };
                            db.Shows.Add(check);

                            //get show cast from tv maze
                            var castClient = new RestClient("http://api.tvmaze.com/");
                            var castRequest = new RestRequest("shows/" + pageNumber.ToString() + "/cast", Method.GET);
                            IRestResponse castRespnse = castClient.Execute(castRequest);
                            if (castRespnse.StatusCode==System.Net.HttpStatusCode.OK)
                            {
                                var castContent = castRespnse.Content;
                                List<TVCastModel> cast = JsonConvert.DeserializeObject<List<TVCastModel>>(castContent);
                                foreach (var castItem in cast)
                                {
                                    var tvcast = new Cast
                                    {
                                        Birthday = castItem.person.birthday,
                                        Name = castItem.person.name,
                                        ShowId = check.Id
                                    };
                                    db.Casts.Add(tvcast);
                                }
                            }
                        
                        //COMMIT DATABASE CHANGES
                        db.SaveChanges();
                    }
                }
                
            }

            return Task.CompletedTask;   
            
        }
    }
}
