using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowRoomProject.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        [MaxLength(11)]
        public string NumberPhone { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }

        [NotMapped]
        public List<Client> Clients { get; set;}
    }
}
