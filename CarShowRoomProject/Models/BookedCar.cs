using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowRoomProject.Models
{
    public class BookedCar
    {
        [Key]
        public int BookedCarId { get; set; }

        [ForeignKey("Car")]
        [Required]
        public int CarId { get; set; }

        public Car Car { get; set; }

        [ForeignKey("Client")]
        [Required]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public decimal BookingPrice { get; set; }
    }
}
