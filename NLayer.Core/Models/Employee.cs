using System.ComponentModel.DataAnnotations;

namespace NLayer.Core.Models
{
    public class Employee : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Mail { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        public string ImageUrl { get; set; }

        public bool Status { get; set; }
    }
}
