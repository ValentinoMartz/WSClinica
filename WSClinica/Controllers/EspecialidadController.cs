using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WSClinica.Data;
using System.Linq;
using WSClinica.Models;
using WSClinica.Migrations;
namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly DBWSClinicaContext context;

        public EspecialidadController(DBWSClinicaContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Especialidad>> Get()
        {
            return context.Especialidades.ToList();
        }

        [HttpGet("{Id}")]
        public ActionResult<Especialidad> GetById(int ID)
        {
            Especialidad especialidad = (from e in context.Especialidades
                               where e.Id == ID
                               select e).SingleOrDefault();
            return especialidad;
        }

        [HttpPost]

        public ActionResult<Especialidad> Post(Especialidad especialidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Especialidades.Add(especialidad);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{ID}")]
        public ActionResult<Especialidad> Put(int id, [FromBody] Especialidad especialidad)
        {
            if (id != especialidad.Id)
            {
                return BadRequest();
            }
            context.Entry(especialidad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Especialidad> Delete(int id, [FromBody] Especialidad especialidad)
        {
            var especialidadOriginal = (from e in context.Especialidades
                                   where e.Id == id
                                   select e).SingleOrDefault();

            if (especialidadOriginal == null)
            {
                return NotFound();
            }
            context.Especialidades.Remove(especialidadOriginal);
            context.SaveChanges();
            return especialidad;
        }
    }
}
