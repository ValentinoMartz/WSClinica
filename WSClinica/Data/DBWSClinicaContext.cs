using Microsoft.EntityFrameworkCore;
using WSClinica.Models;

namespace WSClinica.Data
{
    public class DBWSClinicaContext : DbContext
    {
       // public DBLibrosBootcampContext(DbContextOptions<DBLibrosBootcampContext> options) : base(options) { }
        public DBWSClinicaContext(DbContextOptions<DBWSClinicaContext> options) : base(options) { }

        DbSet<Clinica> Clinicas { get; set; }
        DbSet<Habitacion> Habitaciones { get; set; }
        DbSet<Medico> Medicos { get; set; }
        DbSet<Paciente> Pacientes { get; set; }
        DbSet<Especialidad> Especialidades { get; set; }
    }
}
