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
    public class TratamientoesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Tratamientoes
        public IQueryable<Tratamiento> GetTratamiento()
        {
            return db.Tratamiento;
        }

        // GET: api/Tratamientoes/5
        [ResponseType(typeof(Tratamiento))]
        public IHttpActionResult GetTratamiento(int id)
        {
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            if (tratamiento == null)
            {
                return NotFound();
            }

            return Ok(tratamiento);
        }

        // PUT: api/Tratamientoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTratamiento(int id, Tratamiento tratamiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tratamiento.Id_Tratamiento)
            {
                return BadRequest();
            }

            db.Entry(tratamiento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TratamientoExists(id))
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

        // POST: api/Tratamientoes
        [ResponseType(typeof(Tratamiento))]
        public IHttpActionResult PostTratamiento(Tratamiento tratamiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tratamiento.Add(tratamiento);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TratamientoExists(tratamiento.Id_Tratamiento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tratamiento.Id_Tratamiento }, tratamiento);
        }

        // DELETE: api/Tratamientoes/5
        [ResponseType(typeof(Tratamiento))]
        public IHttpActionResult DeleteTratamiento(int id)
        {
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            if (tratamiento == null)
            {
                return NotFound();
            }

            db.Tratamiento.Remove(tratamiento);
            db.SaveChanges();

            return Ok(tratamiento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TratamientoExists(int id)
        {
            return db.Tratamiento.Count(e => e.Id_Tratamiento == id) > 0;
        }
    }
}