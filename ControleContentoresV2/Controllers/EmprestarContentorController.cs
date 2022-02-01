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
    public class EmprestarContentorController : Controller
    {
        private ControleContentoresEntities db = new ControleContentoresEntities();

        // GET: EmprestarContentor
        public ActionResult Index()
        {
            var movimentacao = db.movimentacao.Include(m => m.produtoQuimico).Include(m => m.situacao).Include(m => m.volume);
            return View(movimentacao.ToList());
        }

        // GET: EmprestarContentor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movimentacao movimentacao = db.movimentacao.Find(id);
            if (movimentacao == null)
            {
                return HttpNotFound();
            }
            return View(movimentacao);
        }

        // GET: EmprestarContentor/Create
        public ActionResult Create()
        {
            ViewBag.idProduto = new SelectList(db.produtoQuimico, "idProduto", "nomeProduto");
            ViewBag.idSituacao = new SelectList(db.situacao, "idSituacao", "situacao1");
            ViewBag.idVolume = new SelectList(db.volume, "idVolume", "idVolume");
            return View();
        }

        // POST: EmprestarContentor/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,rt_load,dt_load,idProduto,idVolume,id_embalagem,idSituacao,dt_uso,rt_backload,dt_backload,comentario")] movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                db.movimentacao.Add(movimentacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProduto = new SelectList(db.produtoQuimico, "idProduto", "nomeProduto", movimentacao.idProduto);
            ViewBag.idSituacao = new SelectList(db.situacao, "idSituacao", "situacao1", movimentacao.idSituacao);
            ViewBag.idVolume = new SelectList(db.volume, "idVolume", "idVolume", movimentacao.idVolume);
            return View(movimentacao);
        }

        // GET: EmprestarContentor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movimentacao movimentacao = db.movimentacao.Find(id);
            if (movimentacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProduto = new SelectList(db.produtoQuimico, "idProduto", "nomeProduto", movimentacao.idProduto);
            ViewBag.idSituacao = new SelectList(db.situacao, "idSituacao", "situacao1", movimentacao.idSituacao);
            ViewBag.idVolume = new SelectList(db.volume, "idVolume", "idVolume", movimentacao.idVolume);
            return View(movimentacao);
        }

        // POST: EmprestarContentor/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,rt_load,dt_load,idProduto,idVolume,id_embalagem,idSituacao,dt_uso,rt_backload,dt_backload,comentario")] movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimentacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Views/telaInicial");
            }
            ViewBag.idProduto = new SelectList(db.produtoQuimico, "idProduto", "nomeProduto", movimentacao.idProduto);
            ViewBag.idSituacao = new SelectList(db.situacao, "idSituacao", "situacao1", movimentacao.idSituacao);
            ViewBag.idVolume = new SelectList(db.volume, "idVolume", "idVolume", movimentacao.idVolume);
            return View(movimentacao);
        }

        // GET: EmprestarContentor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movimentacao movimentacao = db.movimentacao.Find(id);
            if (movimentacao == null)
            {
                return HttpNotFound();
            }
            return View(movimentacao);
        }

        // POST: EmprestarContentor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            movimentacao movimentacao = db.movimentacao.Find(id);
            db.movimentacao.Remove(movimentacao);
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
