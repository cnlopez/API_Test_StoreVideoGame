using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Data.Interfaces;
using NUnit.Framework;
using System.Text.Json;

namespace Tests.Base
{
    public partial class VideoGamesUnitTest
    {
        private const string JsonBasePath = "Json/";
        public IEnumerable<Videogames> VideogamesModel { get; set; }

        public virtual void Init()
        {
            GameRepositoryMock = new Mock<IGameRepository>();
        }

        [SetUp]
        public virtual void Setup()
        {
            Init();
            PopulateDatabase();
        }

        public static T LoadFromJsonFile<T>(string route)
        {
            var path = Path.GetFullPath(route);
            using var reader = new StreamReader(path);
            var json = reader.ReadToEnd();
            return JsonSerializer.Deserialize<T>(json);
        }

        private void PopulateDatabase()
        {
            VideogamesModel = LoadFromJsonFile<IEnumerable<Videogames>>(JsonBasePath + "Videogames.json");
        }
    }
}
