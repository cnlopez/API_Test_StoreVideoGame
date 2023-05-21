using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Base;

namespace Tests
{
    public class GetVideoGamesMapperTest : VideoGamesUnitTest
    {
        [Test]
        public async Task GetGetVideoGamesMapper_ReturnSuccess()
        {
            var response = await GameService.GetVideoGamesMapper();
            Assert.IsNotNull(response);
        }
    }
}
