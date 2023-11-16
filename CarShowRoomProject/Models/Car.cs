using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CarShowRoomProject.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [ForeignKey("BrandCar")]
        [Required]
        public int BrandId { get; set; }
        public BrandCar BrandCar { get; set; }

        [ForeignKey("YearRelease")]
        [Required]
        public int YearId { get; set; }
        public YearRelease YearRelease { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public float EngineCapacity { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public  int ModelId { get; set; }

        [Required]
        public decimal Price { get; set; } = 0;

        [Required]
        public bool Availability { get; set; } = true;

        [ForeignKey("TypeEngine")]
        [Required]
        public int TypeEngineId { get; set; }
        public TypeEngine TypeEngine { get; set; }

        [ForeignKey("TransmissionCar")]
        [Required]
        public int TransmissionId { get; set; }
        public TransmissionCar TransmissionCar { get; set; }

        [ForeignKey("PictureCar")]
        public int? PictureId { get; set; }
        public PictureCar PictureCar { get; set; }

        [NotMapped]
        public List<Car> Cars { get; set; }
    }
}
