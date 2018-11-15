using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvMaze.Scraper.Models
{
    
    
    
    public class Person
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public Country country { get; set; }
        public string birthday { get; set; }
        public object deathday { get; set; }
        public string gender { get; set; }
        public Image image { get; set; }
        public Links _links { get; set; }
    }

    public class Image2
    {
        public string medium { get; set; }
        public string original { get; set; }
    }

    public class Self2
    {
        public string href { get; set; }
    }

    public class Links2
    {
        public Self2 self { get; set; }
    }

    public class Character
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public Image2 image { get; set; }
        public Links2 _links { get; set; }
    }

    public class TVCastModel
    {
        public Person person { get; set; }
        public Character character { get; set; }
        public bool self { get; set; }
        public bool voice { get; set; }
    }
}
