

namespace SimpleNote_WebAPI.Infrastructure.Entities
{
    [Index(nameof(Name),IsUnique =true)]
    public class AttributiesEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Attribute_Id { get; set; }
        [Display(Name="Name: ")]
        public string Name { get; set; }

        //Navigation Properties
        public ICollection<NotesEntity> Notes { get; set; }
    }
}
