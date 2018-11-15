using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvMaze.Scraper.Models
{
    public class MovieContext:DbContext
    {
        public DbSet<Show> Shows { get; set; }
        public DbSet<Cast> Casts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MovieDatabase.db");
        }
        
    }
}
