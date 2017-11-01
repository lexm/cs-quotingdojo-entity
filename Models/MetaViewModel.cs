using System.ComponentModel.DataAnnotations;
namespace quoteme.Models
{
    public class MetaViewModel : BaseEntity
    {
        [Display(Name = "notes")]
        [Required]
        [MinLength(5)]
        public string notes { get; set; }
    }
}