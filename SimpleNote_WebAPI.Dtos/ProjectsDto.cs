

namespace SimpleNote_WebAPI.Dtos
{
    public class ProjectsDto
    {
        public int Project_Id { get; set; }
        [MaxLength(15, ErrorMessage = "The title should have max 15 character")]
        public string Title { get; set; }
        public Boolean? Completed { get; set; }

        //Navigation Properties
        public ICollection<NotesDto> Notes { get; set; }
    }
}
