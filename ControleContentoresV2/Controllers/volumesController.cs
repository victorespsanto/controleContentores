using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleContentoresV2.Models;

namespace ControleContentoresV2.Controllers
{
    public class volumesController : Controller
    {
        private ControleContentoresEntities db = new ControleContentoresEntities();

        // GET: volumes
        public ActionResult Index()
        {
            return View(db.volume.ToList());
        }

        // GET: volumes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            volume volume = db.volume.Find(id);
            if (volume == null)
            {
                return HttpNotFound();
            }
            return View(volume);
        }

        // GET: volumes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: volumes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVolume,qtdeVolume")] volume volume)
        {
            if (ModelState.IsValid)
            {
                db.volume.Add(volume);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volume);
        }

        // GET: volumes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            volume volume = db.volume.Find(id);
            if (volume == null)
            {
                return HttpNotFound();
            }
            return View(volume);
        }

        // POST: volumes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVolume,qtdeVolume")] volume volume)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volume).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volume);
        }

        // GET: volumes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            volume volume = db.volume.Find(id);
            if (volume == null)
            {
                return HttpNotFound();
            }
            return View(volume);
        }

        // POST: volumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            volume volume = db.volume.Find(id);
            db.volume.Remove(volume);
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
