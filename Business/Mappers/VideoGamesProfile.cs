using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Models;
using ViewModels.Game;

namespace Business.Mappers
{
    public class VideoGamesProfile : Profile
    {
        public VideoGamesProfile() 
        {
            DomainToViewModel();
        }

        public void DomainToViewModel()
        {
            CreateMap<Videogames, VideogamesViewModel>();
            CreateMap<VideogamesViewModel, Videogames>();
        }
    }
}
