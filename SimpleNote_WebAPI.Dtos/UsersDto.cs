using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Dtos
{
    public class UsersDto
    {
        public int User_Id { get; set; }
        [Display(Name = "User Name: ")]
        [MaxLength(15, ErrorMessage = "The title should have max 15 character")]
        public string UserName { get; set; }
        [Display(Name = "Password: ")]
        [MaxLength(20, ErrorMessage = "The Password should have max 20 character")]
        public string Password { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Last_Login_Date { get; set; }

        //Navigation Properties
        public ICollection<NotesDto> Notes { get; set; }
    }
}
