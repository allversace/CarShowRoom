using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowRoomProject.Models
{
    public class BrandCar
    {
        [Key]
        public int BrandCarId { get; set; }

        [Required]
        public string BrandCarName { get; set; }

        [Required]
        public int ModelCarId { get; set; }
        public ModelCar ModelCar { get; set; }

        [NotMapped]
        public List<BrandCar> BrandCars { get; set;}
    }
}
