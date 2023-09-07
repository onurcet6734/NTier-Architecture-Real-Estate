using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLayer.Core.Models
{
    public class Product: BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [MaxLength(250)]
        public string ProductCoverImage { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string District { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        public string Description { get; set; }

        public int ProductCategory { get; set; }

        [ForeignKey("ProductCategory")]
        public Category Category { get; set; }
    }
}
