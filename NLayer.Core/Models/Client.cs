using System.ComponentModel.DataAnnotations;

namespace NLayer.Core.Models
{
    public class Client : BaseEntity
    {

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Comment { get; set; }
    }
}
