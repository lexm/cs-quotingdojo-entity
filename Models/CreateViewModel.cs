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
        [MinLength(5)]
        public string Quote { get; set; }
    }
}