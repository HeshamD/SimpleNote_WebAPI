using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Infrastructure.IRepositoriesImp
{
    public class NotesRepoImp : GenericRepoImp<NotesEntity>, INotesRepo
    {
        public NotesRepoImp(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<NotesEntity>> GetNotes(int? projectId, int? AttributeId)
        {
            var Allnotes = await GetAllAsync();

            if (projectId.HasValue && AttributeId == null)// returning all the notes that has this project id only
            {
                var notes = from note in Allnotes
                            where note.Project_ID_FK == projectId
                            select note;

                return notes;

            }

            else if(AttributeId.HasValue && projectId == null)// returning all the notes that has this project id only
            {
                var notes = from note in Allnotes
                            where note.Attribute_Id_FK == AttributeId
                            select note;

                return notes;

            }
            else
            {
                return Allnotes;
            }

        }
    }
}
