



namespace SimpleNote_WebAPI.Infrastructure.Entities
{
    [Index(nameof(UserName),IsUnique=true)]
    public class UsersEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }
        [Display(Name = "User Name: ")]
        [MaxLength(15, ErrorMessage = "The title should have max 15 character")]
        public string UserName { get; set; }
        [Display(Name = "Password: ")]
        [MaxLength(20, ErrorMessage = "The Password should have max 20 character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime Creation_Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime Last_Login_Date { get; set; }

        //Navigation Properties
        public ICollection<NotesEntity> Notes { get; set; }

    }
}
