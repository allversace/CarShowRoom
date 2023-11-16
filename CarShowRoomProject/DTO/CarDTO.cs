using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowRoomProject.DTO
{
    public class CarDTO
    {
        public int CarId { get; set; }
        public string BrandCar { get; set; } = string.Empty;
        public string ModelCar { get; set; } = string.Empty;
        public int YearRelease { get; set; }
        public decimal Price { get; set; } = 0;
        public bool Availability { get; set; }
        public string Description { get; set; } = string.Empty;
        public string TypeEngine { get; set; } = string.Empty;
        public string TransmissionCar { get; set; } = string.Empty;
        public int Mileage { get; set; }
        public int Power { get; set; }
        public float EngineCapacity { get; set; }
        public byte[] PictureOne { get; set; }
        public byte[] PictureTwo { get; set; }
        public byte[] PictureThree { get; set; }
    }
}
