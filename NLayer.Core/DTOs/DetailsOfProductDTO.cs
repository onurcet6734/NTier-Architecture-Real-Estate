namespace NLayer.Core.DTOs
{
    public class DetailsOfProductDTO
    {
        public int DetailId { get; set; }
        public int ProductSize { get; set; }
        public byte BedroomCount { get; set; }
        public byte BathroomCount { get; set; }
        public byte RoomCount { get; set; }
        public byte GarageSize { get; set; }
        public string BuildYear { get; set; }
        public string VideoUrl { get; set; }
        public int ProductId { get; set; }
    }
}
