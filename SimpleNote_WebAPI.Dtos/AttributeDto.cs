using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Dtos
{
    public class AttributeDto
    {
        public int Attribute_Id { get; set; }
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        //Navigation Properties
        public ICollection<NotesDto> Notes { get; set; }
    }
}
