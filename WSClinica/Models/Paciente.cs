using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WSClinica.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre{ get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido{ get; set; }
        public int NroHitClinica{ get; set; }

       // public Medico Medico { get; set; }

    }
}
