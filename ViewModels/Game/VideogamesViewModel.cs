﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Enums;

namespace ViewModels.Game
{
    public class VideogamesViewModel
    {
        [Key]
        public int VideogameId { get; set; }
        public string? VideogameName { get; set; }
        public int ConsoleId { get; set; }
        public VideoGameType VideoGameTypeId { get; set; }
    }
}
