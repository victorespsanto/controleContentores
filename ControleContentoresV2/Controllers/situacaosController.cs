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
    public class situacaosController : Controller
    {
        private ControleContentoresEntities db = new ControleContentoresEntities();

        // GET: situacaos
        public ActionResult Index()
        {
            return View(db.situacao.ToList());
        }

        // GET: situacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            situacao situacao = db.situacao.Find(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // GET: situacaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: situacaos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSituacao,situacao1")] situacao situacao)
        {
            if (ModelState.IsValid)
            {
                db.situacao.Add(situacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(situacao);
        }

        // GET: situacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            situacao situacao = db.situacao.Find(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // POST: situacaos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSituacao,situacao1")] situacao situacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(situacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(situacao);
        }

        // GET: situacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            situacao situacao = db.situacao.Find(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // POST: situacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            situacao situacao = db.situacao.Find(id);
            db.situacao.Remove(situacao);
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
