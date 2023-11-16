using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CarShowRoomProject.Models
{
    public class PictureCar
    {
        [Key]
        public int PictureCarId { get; set; }

        public byte[]? PictureOne { get; set; }

        public byte[]? PictureTwo { get; set; }

        public byte[]? PictureThree { get; set; }

        [NotMapped]
        public List<PictureCar> PictureCars { get; set;}
    }
}
