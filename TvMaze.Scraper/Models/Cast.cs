using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TvMaze.Scraper.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public int ShowId { get; set; }
        public virtual Show show { get; set; }
    }
    public class CastViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
    }
}
