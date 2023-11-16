using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowRoomProject.Models
{
    public class ModelCar
    {
        [Key]
        public int ModelCarId { get; set; }

        [Required]
        public string ModelCarName { get; set; }

        [NotMapped]
        public List<ModelCar> ModelCars { get; set; }
    }
}
