using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLayer.Core.Models
{
    public class DetailsOfProduct 
    {
        [Key]
        public int DetailId { get; set; }
        public int ProductSize { get; set; }

        public byte BedroomCount { get; set; }

        public byte BathroomCount { get; set; }

        public byte RoomCount { get; set; }

        public byte GarageSize { get; set; }

        [MaxLength(4)]
        public string BuildYear { get; set; }

        [MaxLength(500)]
        public string VideoUrl { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
