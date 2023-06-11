using Moq;
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
        public async Task GetGetVideoGames_ReturnSuccess()
        {
            GameRepositoryMock.Setup(x=>x.GetVideoGames()).ReturnsAsync(VideogamesModel);
            var response = await GameService.GetVideoGames();
            Assert.IsNotNull(response);
        }
    }
}
