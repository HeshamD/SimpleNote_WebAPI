using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Infrastructure.IRepositoriesImp
{
    public class ProjectsRepoImp : GenericRepoImp<ProjectsEntity>, IProjectsRepo
    {
        public ProjectsRepoImp(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<int> GetNullProjectNoteCounts()
        {
            var allnotes = await _db.Notes.ToListAsync();

            var AttributeNotes = from note in allnotes
                                 where note.Project_ID_FK != null
                                 select note;

            return AttributeNotes.Count();
        }

        public async Task<int> GetProjectNoteCounts()
        {
            var allnotes = await _db.Notes.ToListAsync();

            var AttributeNotes = from note in allnotes
                                 where note.Project_ID_FK == null
                                 select note;

            return AttributeNotes.Count();
        }
    }
}
