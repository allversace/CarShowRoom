using CarShowRoomProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowRoomProject.DTO
{
    public class BookedCarDTO
    {
        public int BookedCarId { get; set; }
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string NumberPhone { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal BookingPrice { get; set; }
    }
}
