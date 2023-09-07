using System.ComponentModel.DataAnnotations;

namespace NLayer.Core.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
