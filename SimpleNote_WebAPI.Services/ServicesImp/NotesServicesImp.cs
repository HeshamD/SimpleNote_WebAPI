    using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Services.ServicesImp
{
    public class NotesServicesImp : GenericServicesImp<NotesDto,NotesEntity>, INotesServices
    {
        private readonly INotesRepo notesRepo;
        public NotesServicesImp(IGenericRepo<NotesEntity> baseRepository, IMapper mapper, INotesRepo _notesRepo) : base(baseRepository, mapper)
        {
            notesRepo = _notesRepo;
        }

        public async Task<IEnumerable<NotesDto>> GetNotes(int? projectId, int? AttributeId)
        {
            var notes = await notesRepo.GetNotes(projectId, AttributeId);

            var notes_Dtos = _mapper.Map<IEnumerable<NotesDto>>(notes);

            return notes_Dtos;
        }
    }
}
