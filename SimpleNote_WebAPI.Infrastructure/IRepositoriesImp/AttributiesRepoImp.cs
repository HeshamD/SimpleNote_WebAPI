using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Infrastructure.IRepositoriesImp
{
    public class AttributiesRepoImp : GenericRepoImp<AttributiesEntity>, IAttributiesRepo
    {
        public AttributiesRepoImp(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<int> GetAttributeNoteCounts() // Returns a count of notes for each attribute, and a count of notes without attributes.
        {
            var allnotes = await _db.Notes.ToListAsync();

            var AttributeNotes = from note in allnotes
                                 where note.Attribute_Id_FK != null
                                 select note;

            return AttributeNotes.Count();

        }

        public async Task<int> GetNullAttributeNoteCounts()
        {
            var allnotes = await _db.Notes.ToListAsync();

            var AttributeNotes = from note in allnotes
                                 where note.Attribute_Id_FK == null
                                 select note;

            return AttributeNotes.Count();
        }
    }
}
