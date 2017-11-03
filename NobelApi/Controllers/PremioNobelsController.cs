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
using NobelApi.Models;

namespace NobelApi.Controllers
{
    public class PremioNobelsController : ApiController
    {
        private NobelEntities db = new NobelEntities();

        // GET: api/PremioNobels
        public IQueryable<PremioNobel> GetPremioNobel()
        {
            return db.PremioNobel;
        }

        // GET: api/PremioNobels/5
        [ResponseType(typeof(PremioNobel))]
        public IHttpActionResult GetPremioNobel(int id)
        {
            PremioNobel premioNobel = db.PremioNobel.Find(id);
            if (premioNobel == null)
            {
                return NotFound();
            }

            return Ok(premioNobel);
        }

        // PUT: api/PremioNobels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPremioNobel(int id, PremioNobel premioNobel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != premioNobel.PremioNobelId)
            {
                return BadRequest();
            }

            db.Entry(premioNobel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PremioNobelExists(id))
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

        // POST: api/PremioNobels
        [ResponseType(typeof(PremioNobel))]
        public IHttpActionResult PostPremioNobel(PremioNobel premioNobel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PremioNobel.Add(premioNobel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = premioNobel.PremioNobelId }, premioNobel);
        }

        // DELETE: api/PremioNobels/5
        [ResponseType(typeof(PremioNobel))]
        public IHttpActionResult DeletePremioNobel(int id)
        {
            PremioNobel premioNobel = db.PremioNobel.Find(id);
            if (premioNobel == null)
            {
                return NotFound();
            }

            db.PremioNobel.Remove(premioNobel);
            db.SaveChanges();

            return Ok(premioNobel);
        }

        /*public IHttpActionResult GetPremioNobel (int id)
        {
            if(!PremioNobelExists(id))
            {
                return NotFound;
            }
            PremioNobelDetailsDTO premioNobel = db.PremioNobel
                .Include("Categoria").Include("Laureado")
                .Where(p=>p.PremioNobelId == id).Select(p=> new PremioNobelDetailsDTO())
                {
                    Ano = p.Ano,
                    Motivacao = p.Motivacao,
                    PremioNobelId = premioNobel.Titulo,
                    Categoria = new CategoriaDTO()
                    {
                        CategoriaId = p.Categoria.CategoriaId,
                        Nome = p.Categoria.Nome
                    },
                    Individuo = premioNobel.Laureado.Select(r=> new LaureadoIndividuoDTO()
                    {
                    }).ToList()
                }
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PremioNobelExists(int id)
        {
            return db.PremioNobel.Count(e => e.PremioNobelId == id) > 0;
        }
    }
}