using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Services.IServices
{
    public interface INotesServices : IGenericServices<NotesDto,NotesEntity>
    {
        public Task<IEnumerable<NotesDto>> GetNotes(int? projectId, int? AttributeId);

    }
}
