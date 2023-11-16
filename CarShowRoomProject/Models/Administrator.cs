using System.ComponentModel.DataAnnotations;

namespace CarShowRoomProject.Models
{
    public class Administrator
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}
