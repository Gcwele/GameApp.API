using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GameApp.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var games = new List<Game>
            {
                new Game
                {
                    Id = 1,
                    Title = "Mortal Kombat 11",
                    Platform = "PS5",
                    Status = GameStatus.Backlog,
                    Rating = 5
                },
                new Game
                {
                    Id = 2,
                    Title = "Tekken 8",
                    Platform = "PC",
                    Status = GameStatus.Backlog,
                    Rating = 3
                },
                new Game
                {
                    Id = 3,
                    Title = "Injustice 2",
                    Platform = "Xbox Series X",
                    Status = GameStatus.Backlog,
                    Rating = 4
                },
            };

            modelBuilder.Entity<Game>().HasData(games);
        }
    }
}