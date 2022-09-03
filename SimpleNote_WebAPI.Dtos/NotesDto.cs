using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Dtos
{
    public class NotesDto
    {
        //public int Note_Id { get; set; }
        public string Note { get; set; }
        public bool Completed { get; set; }

        //Nav prop 
        //public ProjectsDto? Project { get; set; }
        public int? Project_ID_FK { get; set; }

        //public AttributeDto? Attributies { get; set; }
        public int? Attribute_Id_FK { get; set; }

        //public UsersDto? Users { get; set; }
        public int User_Id_FK { get; set; }
    }
}
