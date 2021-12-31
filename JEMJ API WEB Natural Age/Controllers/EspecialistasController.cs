using System;
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
    public class EspecialistasController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Especialistas
        public IQueryable<Especialista> GetEspecialista()
        {
            return db.Especialista;
        }

        // GET: api/Especialistas/5
        [ResponseType(typeof(Especialista))]
        public IHttpActionResult GetEspecialista(int id)
        {
            Especialista especialista = db.Especialista.Find(id);
            if (especialista == null)
            {
                return NotFound();
            }

            return Ok(especialista);
        }

        // PUT: api/Especialistas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEspecialista(int id, Especialista especialista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != especialista.Id_Especialista)
            {
                return BadRequest();
            }

            db.Entry(especialista).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialistaExists(id))
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

        // POST: api/Especialistas
        [ResponseType(typeof(Especialista))]
        public IHttpActionResult PostEspecialista(Especialista especialista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Especialista.Add(especialista);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EspecialistaExists(especialista.Id_Especialista))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = especialista.Id_Especialista }, especialista);
        }

        // DELETE: api/Especialistas/5
        [ResponseType(typeof(Especialista))]
        public IHttpActionResult DeleteEspecialista(int id)
        {
            Especialista especialista = db.Especialista.Find(id);
            if (especialista == null)
            {
                return NotFound();
            }

            db.Especialista.Remove(especialista);
            db.SaveChanges();

            return Ok(especialista);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EspecialistaExists(int id)
        {
            return db.Especialista.Count(e => e.Id_Especialista == id) > 0;
        }
    }
}