using System.ComponentModel.DataAnnotations;
namespace quoteme.Models
{
    public class CategoryViewModel : BaseEntity
    {
        [Display(Name = "Category")]
        [Required]
        [MinLength(5)]
        public string name { get; set; }
    }
}