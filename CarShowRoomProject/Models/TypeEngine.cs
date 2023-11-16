using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowRoomProject.Models
{
    public class TypeEngine
    {
        [Key]
        public int TypeEngineId { get; set; }

        [Required]
        public string TypeEngineName { get; set;}

        [NotMapped]
        public List<TypeEngine> TypeEngines { get; set; }
    }
}
