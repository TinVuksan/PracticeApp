using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PracticeAppWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display order")]
        [Range(1,100, ErrorMessage = "The number must be between 1-100")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
