

namespace SimpleNote_WebAPI.Infrastructure.Entities
{
    public record NotesEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Note_Id { get; set; }
        public string Note { get; set; }
        public bool Completed { get; set; }

        //Nav prop 
        public ProjectsEntity? Project { get; set; }
        [ForeignKey("Project")]
        public int? Project_ID_FK { get; set; }

        [ForeignKey("Attribute_Id_FK")]
        public AttributiesEntity? Attributies { get; set; }
        public int? Attribute_Id_FK { get; set; }

        [ForeignKey("User_Id_FK")]
        public UsersEntity? Users { get; set; }
        public int? User_Id_FK { get; set; }


    }
}
