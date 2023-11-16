using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowRoomProject.Models
{
    public class TransmissionCar
    {
        [Key]
        public int TransmissionCarId { get; set; }

        [Required]
        public string TransmissionCarName { get; set; }

        [NotMapped]
        public List<TransmissionCar> TransmissionCars { get; set; }
    }
}
