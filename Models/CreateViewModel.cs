using System.ComponentModel.DataAnnotations;
namespace quoteme.Models
{
    public abstract class BaseEntity {}
    public class CreateViewModel : BaseEntity
    {
        [Display(Name = "Author")]
        [Required]
        public int authorid { get; set; }

        [Display(Name = "Quote")]
        [Required]
        // [MinLength(5)]
        public string Quote { get; set; }

        [Display(Name = "notes")]
        [Required]
        [MinLength(5)]
        public string notes { get; set; }

        [Display(Name = "Category")]
        [Required]
        // [MinLength(5)]
        public int categoryid { get; set; }
    }
}