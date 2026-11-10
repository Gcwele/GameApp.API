using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameApp.API.Models
{
    public enum GameStatus
    {
        Backlog,
        Playing,
        Finished
    }
    public class Game
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public required string Title { get; set; }

        [MaxLength(150)]
        public string? Platform { get; set; }
        public GameStatus Status { get; set; } = GameStatus.Backlog;

        [Range(1, 5)]
        public int? Rating { get; set; }
     }
}