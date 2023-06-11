using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Videogames
    {
        [Key]
        public int VideogameId { get; set; }
        public string? VideogameName { get; set; }
        public int ConsoleId { get; set; }
        public int VideoGameTypeId { get; set; }
    }
}
