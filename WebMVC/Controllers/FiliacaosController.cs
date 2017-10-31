using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class FiliacaosController : Controller
    {
        private NobelEntities db = new NobelEntities();

        // GET: Filiacaos
        public ActionResult Index()
        {
            var filiacao = db.Filiacao.Include(f => f.Cidade);
            return View(filiacao.ToList());
        }

        // GET: Filiacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filiacao filiacao = db.Filiacao.Find(id);
            if (filiacao == null)
            {
                return HttpNotFound();
            }
            return View(filiacao);
        }

        // GET: Filiacaos/Create
        public ActionResult Create()
        {
            ViewBag.CidadeId = new SelectList(db.Cidade, "CidadeId", "Nome");
            return View();
        }

        // POST: Filiacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FiliacaoId,Nome,CidadeId")] Filiacao filiacao)
        {
            if (ModelState.IsValid)
            {
                db.Filiacao.Add(filiacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CidadeId = new SelectList(db.Cidade, "CidadeId", "Nome", filiacao.CidadeId);
            return View(filiacao);
        }

        // GET: Filiacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filiacao filiacao = db.Filiacao.Find(id);
            if (filiacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeId = new SelectList(db.Cidade, "CidadeId", "Nome", filiacao.CidadeId);
            return View(filiacao);
        }

        // POST: Filiacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FiliacaoId,Nome,CidadeId")] Filiacao filiacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filiacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CidadeId = new SelectList(db.Cidade, "CidadeId", "Nome", filiacao.CidadeId);
            return View(filiacao);
        }

        // GET: Filiacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filiacao filiacao = db.Filiacao.Find(id);
            if (filiacao == null)
            {
                return HttpNotFound();
            }
            return View(filiacao);
        }

        // POST: Filiacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filiacao filiacao = db.Filiacao.Find(id);
            db.Filiacao.Remove(filiacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
