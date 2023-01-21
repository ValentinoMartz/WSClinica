using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WSClinica.Models
{
    [Table("Especialidad")]

    public class Especialidad
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        List<Medico> Medicos { get; set; }
    }
}
