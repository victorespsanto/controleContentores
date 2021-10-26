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
    public class usuariosController : Controller
    {
        private ControleContentoresEntities db = new ControleContentoresEntities();

        // GET: usuarios
        public ActionResult Index()
        {
            var usuario = db.usuario.Include(u => u.perfilUsuario);
            return View(usuario.ToList());
        }

        // GET: usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: usuarios/Create
        public ActionResult Create()
        {
            ViewBag.idPerfilUsuario = new SelectList(db.perfilUsuario, "idPerfilUsuario", "tipoPerfil");
            return View();
        }

        // POST: usuarios/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nomeUsuario,senhaUsuario,idPerfilUsuario,idUsuario,chaveUsuario")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                
                db.usuario.Add(usuario);
                db.SaveChanges();
                if (Session["PerfilUsuario"] == null)
                {
                    return RedirectToAction("../Login");                   
                }
                return RedirectToAction("Index");
            }

            ViewBag.idPerfilUsuario = new SelectList(db.perfilUsuario, "idPerfilUsuario", "tipoPerfil", usuario.idPerfilUsuario);
            return View(usuario);
        }

        // GET: usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPerfilUsuario = new SelectList(db.perfilUsuario, "idPerfilUsuario", "tipoPerfil", usuario.idPerfilUsuario);
            return View(usuario);
        }

        // POST: usuarios/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nomeUsuario,senhaUsuario,idPerfilUsuario,idUsuario,chaveUsuario")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPerfilUsuario = new SelectList(db.perfilUsuario, "idPerfilUsuario", "tipoPerfil", usuario.idPerfilUsuario);
            return View(usuario);
        }

        // GET: usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuario usuario = db.usuario.Find(id);
            db.usuario.Remove(usuario);
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
