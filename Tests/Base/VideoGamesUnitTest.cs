using Business.Interfaces;
using Data.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;
using System.Threading.Tasks;
using Business.Mappers;

namespace Tests.Base
{
    public abstract partial class VideoGamesUnitTest
    {
        protected IGameService GameService { get; set; }
        protected Mock<IGameRepository> GameRepositoryMock { get; set; }
        protected IMapper Mapper { get; set; }

        protected VideoGamesUnitTest()
        {
            var profiles = new Profile[] { new VideoGamesProfile() };
            var mappingConfig = new MapperConfiguration(x=>x.AddProfiles(profiles));
            Mapper = mappingConfig.CreateMapper();
        }
    }
}
