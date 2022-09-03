using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Infrastructure.IRepositories
{
    public interface INotesRepo: IGenericRepo<NotesEntity>
    {
        public Task<IEnumerable<NotesEntity>> GetNotes(int? projectId, int? AttributeId);
    }
}
