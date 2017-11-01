using System.ComponentModel.DataAnnotations;
namespace quoteme.Models
{
    public class CreateAuthorViewModel : BaseEntity
    {
        [Display(Name = "name")]
        [Required]
        [MinLength(5)]
        public string name { get; set; }
    }
}