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
    public class perfilUsuariosController : Controller
    {
        private ControleContentoresEntities db = new ControleContentoresEntities();

        // GET: perfilUsuarios
        public ActionResult Index()
        {
            return View(db.perfilUsuario.ToList());
        }

        // GET: perfilUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            perfilUsuario perfilUsuario = db.perfilUsuario.Find(id);
            if (perfilUsuario == null)
            {
                return HttpNotFound();
            }
            return View(perfilUsuario);
        }

        // GET: perfilUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: perfilUsuarios/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPerfilUsuario,tipoPerfil")] perfilUsuario perfilUsuario)
        {
            if (ModelState.IsValid)
            {
                db.perfilUsuario.Add(perfilUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perfilUsuario);
        }

        // GET: perfilUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            perfilUsuario perfilUsuario = db.perfilUsuario.Find(id);
            if (perfilUsuario == null)
            {
                return HttpNotFound();
            }
            return View(perfilUsuario);
        }

        // POST: perfilUsuarios/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPerfilUsuario,tipoPerfil")] perfilUsuario perfilUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfilUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfilUsuario);
        }

        // GET: perfilUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            perfilUsuario perfilUsuario = db.perfilUsuario.Find(id);
            if (perfilUsuario == null)
            {
                return HttpNotFound();
            }
            return View(perfilUsuario);
        }

        // POST: perfilUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            perfilUsuario perfilUsuario = db.perfilUsuario.Find(id);
            db.perfilUsuario.Remove(perfilUsuario);
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
