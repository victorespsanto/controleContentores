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
    public class produtoQuimicoesController : Controller
    {
        private ControleContentoresEntities db = new ControleContentoresEntities();

        // GET: produtoQuimicoes
        public ActionResult Index()
        {
            var produtoQuimico = db.produtoQuimico.Include(p => p.funcaoProduto).Include(p => p.status).OrderBy(p => p.nomeProduto);
            return View(produtoQuimico.ToList().OrderBy(p => p.nomeProduto)) ;
        }

        // GET: produtoQuimicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produtoQuimico produtoQuimico = db.produtoQuimico.Find(id);
            if (produtoQuimico == null)
            {
                return HttpNotFound();
            }
            return View(produtoQuimico);
        }

        // GET: produtoQuimicoes/Create
        public ActionResult Create()
        {
            ViewBag.idFuncaoProduto = new SelectList(db.funcaoProduto, "idFuncaoProduto", "funcaoProduto1");
            ViewBag.idStatus = new SelectList(db.status, "idStatus", "status1");
            return View();
        }

        // POST: produtoQuimicoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nmProduto,nomeProduto,idFuncaoProduto,idStatus,idProduto")] produtoQuimico produtoQuimico)
        {
            if (ModelState.IsValid)
            {
                db.produtoQuimico.Add(produtoQuimico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFuncaoProduto = new SelectList(db.funcaoProduto, "idFuncaoProduto", "funcaoProduto1", produtoQuimico.idFuncaoProduto);
            ViewBag.idStatus = new SelectList(db.status, "idStatus", "status1", produtoQuimico.idStatus);
            return View(produtoQuimico);
        }

        // GET: produtoQuimicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produtoQuimico produtoQuimico = db.produtoQuimico.Find(id);
            if (produtoQuimico == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFuncaoProduto = new SelectList(db.funcaoProduto, "idFuncaoProduto", "funcaoProduto1", produtoQuimico.idFuncaoProduto);
            ViewBag.idStatus = new SelectList(db.status, "idStatus", "status1", produtoQuimico.idStatus);
            return View(produtoQuimico);
        }

        // POST: produtoQuimicoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nmProduto,nomeProduto,idFuncaoProduto,idStatus,idProduto")] produtoQuimico produtoQuimico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoQuimico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFuncaoProduto = new SelectList(db.funcaoProduto, "idFuncaoProduto", "funcaoProduto1", produtoQuimico.idFuncaoProduto);
            ViewBag.idStatus = new SelectList(db.status, "idStatus", "status1", produtoQuimico.idStatus);
            return View(produtoQuimico);
        }

        // GET: produtoQuimicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produtoQuimico produtoQuimico = db.produtoQuimico.Find(id);
            if (produtoQuimico == null)
            {
                return HttpNotFound();
            }
            return View(produtoQuimico);
        }

        // POST: produtoQuimicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            produtoQuimico produtoQuimico = db.produtoQuimico.Find(id);
            db.produtoQuimico.Remove(produtoQuimico);
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
