using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TvMaze.Scraper.Models
{
    public class Show
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public ICollection<Cast> ShowCast
        {
            get; set;
        }
    }

    public class ShowViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CastViewModel> Cast { get; set; }
    }
}
