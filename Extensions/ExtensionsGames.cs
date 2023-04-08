using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Game;

namespace Extensions
{
    public static class ExtensionsGames
    {
        public static string GetVideoGameName(this VideogamesViewModel videoGame)
        {
            return videoGame.VideogameName;
        }
    }
}
