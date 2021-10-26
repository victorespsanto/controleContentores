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
    public class funcaoProdutoesController : Controller
    {
        private ControleContentoresEntities db = new ControleContentoresEntities();

        // GET: funcaoProdutoes
        public ActionResult Index()
        {
            return View(db.funcaoProduto.ToList());
        }

        // GET: funcaoProdutoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcaoProduto funcaoProduto = db.funcaoProduto.Find(id);
            if (funcaoProduto == null)
            {
                return HttpNotFound();
            }
            return View(funcaoProduto);
        }

        // GET: funcaoProdutoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: funcaoProdutoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "funcaoProduto1,idFuncaoProduto")] funcaoProduto funcaoProduto)
        {
            if (ModelState.IsValid)
            {
                db.funcaoProduto.Add(funcaoProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funcaoProduto);
        }

        // GET: funcaoProdutoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcaoProduto funcaoProduto = db.funcaoProduto.Find(id);
            if (funcaoProduto == null)
            {
                return HttpNotFound();
            }
            return View(funcaoProduto);
        }

        // POST: funcaoProdutoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "funcaoProduto1,idFuncaoProduto")] funcaoProduto funcaoProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcaoProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcaoProduto);
        }

        // GET: funcaoProdutoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcaoProduto funcaoProduto = db.funcaoProduto.Find(id);
            if (funcaoProduto == null)
            {
                return HttpNotFound();
            }
            return View(funcaoProduto);
        }

        // POST: funcaoProdutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            funcaoProduto funcaoProduto = db.funcaoProduto.Find(id);
            db.funcaoProduto.Remove(funcaoProduto);
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
