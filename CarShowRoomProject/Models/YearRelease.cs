using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowRoomProject.Models
{
    public class YearRelease
    {
        [Key]
        public int YearReleaseId { get; set; }

        [Required]
        public int YearReleaseName { get; set; }

        [NotMapped]
        public List<YearRelease> YearReleases { get; set;}
    }
}
