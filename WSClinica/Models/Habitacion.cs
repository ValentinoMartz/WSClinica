using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    [Table("Habitacion")]

    public class Habitacion
    {
        public int Id { get; set; }

        [Range(1,100, ErrorMessage = "Solo se aceptan entre 1 y 100")]
        public int Numero { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Estado { get; set; }
        public int ClinicaID { get; set; }
        [ForeignKey("ClinicaID")]
        public Clinica Clinica { get; set; }
    }
}