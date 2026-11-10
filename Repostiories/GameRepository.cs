using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameApp.API.Data;
using GameApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GameApp.API.Repostiories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext dbContext;
        public GameRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Game> CreateAsync(Game game)
        {
            await dbContext.Games.AddAsync(game);
            await dbContext.SaveChangesAsync();

            return game;
        }

        public async Task<Game?> DeleteAsync(int id)
        {
            var game = await dbContext.Games.FindAsync(id);
            if(game == null) return null;

            dbContext.Games.Remove(game);
            await dbContext.SaveChangesAsync();

            return game;
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await dbContext.Games.ToListAsync();
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            var game = await dbContext.Games.FindAsync(id);
            if(game == null) return null;

            return game;
        }

        public async Task<Game?> UpdateAsync(int id, Game game)
        {
            var existingGame = await dbContext.Games.FindAsync(id);
            if(existingGame == null) return null;

            existingGame.Title = game.Title;
            existingGame.Platform = game.Platform;
            existingGame.Status = game.Status;
            existingGame.Rating = game.Rating;
            
            await dbContext.SaveChangesAsync();

            return existingGame;
        }
    }
}