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
    public class ClinicaController : ControllerBase
    {
        private readonly DBWSClinicaContext context;

        public ClinicaController(DBWSClinicaContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Clinica>> Get()
        {
            return context.Clinicas.ToList();
        }

        [HttpGet("{ID}")]
        public ActionResult<Clinica> GetById(int ID)
        {
            Clinica clinica = (from c in context.Clinicas
                               where c.ID == ID
                               select c).SingleOrDefault();
            return clinica;
        }
        [HttpPost]

        public ActionResult<Clinica> Post(Clinica clinica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Clinicas.Add(clinica);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{ID}")]
        public ActionResult<Clinica> Put(int id, [FromBody]Clinica clinica)
        {
            if (id != clinica.ID)
            {
                return BadRequest();
            }
            context.Entry(clinica).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Clinica> Delete(int id, [FromBody] Clinica clinica)
        {
            var clinicaOriginal = (from c in context.Clinicas
                           where c.ID == id
                           select c).SingleOrDefault();

            if (clinicaOriginal == null)
            {
                return NotFound();
            }
            context.Clinicas.Remove(clinicaOriginal);
            context.SaveChanges();
            return clinica;
        }

    }
}
