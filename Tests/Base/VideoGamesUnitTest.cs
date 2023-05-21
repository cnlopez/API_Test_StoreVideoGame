using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Base
{
    public abstract partial class VideoGamesUnitTest
    {
        protected IGameService GameService { get; set; }
    }
}
