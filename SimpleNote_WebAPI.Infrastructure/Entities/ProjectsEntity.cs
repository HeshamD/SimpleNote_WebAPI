using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Infrastructure.Entities
{
    [Index(nameof(Title), IsUnique = true)]
    public record ProjectsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Project_Id { get; set; }
        [MaxLength(15, ErrorMessage = "The title should have max 15 character")]
        public string Title { get; set; }
        public Boolean? Completed { get; set; }

        //Navigation Properties
        public ICollection<NotesEntity> Notes { get; set; }

    }
}
