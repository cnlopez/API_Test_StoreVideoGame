using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Videogames
    {
        [Key]
        public int VideogameId { get; set; }
        public string VideogameName { get; set; }
        public int ConsoleId { get; set; }
    }
}
