﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using JEMJ_API_WEB_Natural_Age.Models;

namespace JEMJ_API_WEB_Natural_Age.Controllers
{
    public class CitasController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Citas
        public IQueryable<Cita> GetCita()
        {
            return db.Cita;
        }

        // GET: api/Citas/5
        [ResponseType(typeof(Cita))]
        public IHttpActionResult GetCita(int id)
        {
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return NotFound();
            }

            return Ok(cita);
        }

        // PUT: api/Citas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCita(int id, Cita cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cita.Id_Cita)
            {
                return BadRequest();
            }

            db.Entry(cita).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Citas
        [ResponseType(typeof(Cita))]
        public IHttpActionResult PostCita(Cita cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cita.Add(cita);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CitaExists(cita.Id_Cita))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cita.Id_Cita }, cita);
        }

        // DELETE: api/Citas/5
        [ResponseType(typeof(Cita))]
        public IHttpActionResult DeleteCita(int id)
        {
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return NotFound();
            }

            db.Cita.Remove(cita);
            db.SaveChanges();

            return Ok(cita);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CitaExists(int id)
        {
            return db.Cita.Count(e => e.Id_Cita == id) > 0;
        }
    }
}