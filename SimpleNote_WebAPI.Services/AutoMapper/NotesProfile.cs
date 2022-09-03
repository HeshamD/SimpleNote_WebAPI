

namespace SimpleNote_WebAPI.Services.AutoMapper
{
    public class NotesProfile:Profile
    {
        public NotesProfile()
        {
            CreateMap<NotesEntity, NotesDto>().ReverseMap();
        }
    }
}
