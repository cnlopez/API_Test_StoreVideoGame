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
