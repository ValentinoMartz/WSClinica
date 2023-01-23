﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WSClinica.Controllers;
using WSClinica.Data;
using WSClinica.Models;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly DBWSClinicaContext context;

        public MedicosController(DBWSClinicaContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Medico>> Get()
        {
            return context.Medicos.ToList();
        }

        [HttpGet("{IdMedico}")]
        public ActionResult<Medico> GetById(int IdMedico)
        {
            Medico medico = (from m in context.Medicos
                            where m.IdMedico == IdMedico
                            select m).SingleOrDefault();
            return medico;
        }

        [HttpPost]
        public ActionResult<Medico> Post(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Medicos.Add(medico);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{IdMedico}")]
        public ActionResult<Medico> Put(int IdMedico, [FromBody] Medico medico)
        {
            if (IdMedico != medico.IdMedico)
            {
                return BadRequest();
            }
            context.Entry(medico).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{IdMedico}")]
        public ActionResult<Medico> Delete (int IdMedico) 
        {
            var medicoOriginal = (from m in context.Medicos
                                  where m.IdMedico == IdMedico
                                  select m).SingleOrDefault();
            if (medicoOriginal == null)
            {
                return NotFound();
                
            }
            context.Medicos.Remove(medicoOriginal);
            context.SaveChanges();
            return medicoOriginal;
        }
    }
}
