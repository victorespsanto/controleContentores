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
    public class movimentacaosController : Controller
    {
        private ControleContentoresEntities db = new ControleContentoresEntities();

        // GET: movimentacaos
        public ActionResult Index()
        {
            var movimentacao = db.movimentacao.Include(m => m.produtoQuimico).Include(m => m.situacao).Include(m => m.volume).OrderBy(m => m.dt_load);
            return PartialView(movimentacao.ToList());
        }

        // GET: movimentacaos/Details/5
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

        // GET: movimentacaos/Create
        public ActionResult Create()
        {
            ViewBag.idProduto = new SelectList(db.produtoQuimico.OrderBy(p => p.nomeProduto).Where(p => p.idStatus == 1), "idProduto", "nomeProduto");
            ViewBag.idSituacao = new SelectList(db.situacao, "idSituacao", "situacao1");
            ViewBag.idVolume = new SelectList(db.volume, "idVolume", "qtdeVolume");
            return View();
        }

        // POST: movimentacaos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,rt_load,dt_load,idProduto,idVolume,id_embalagem,idSituacao,dt_uso,rt_backload,dt_backload,comentario")] movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                db.movimentacao.Add(movimentacao);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.idProduto = new SelectList(db.produtoQuimico, "idProduto", "nomeProduto", movimentacao.idProduto);
            ViewBag.idSituacao = new SelectList(db.situacao, "idSituacao", "situacao1", movimentacao.idSituacao);
            ViewBag.idVolume = new SelectList(db.volume, "idVolume", "qtdeVolume", movimentacao.idVolume);
            return View(movimentacao);
        }

        // GET: movimentacaos/Edit/5
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
            ViewBag.idVolume = new SelectList(db.volume, "idVolume", "qtdeVolume", movimentacao.idVolume);
            return View(movimentacao);
        }

        // POST: movimentacaos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,rt_load,dt_load,idProduto,idVolume,id_embalagem,idSituacao,dt_uso,rt_backload,dt_backload,comentario")] movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimentacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            ViewBag.idProduto = new SelectList(db.produtoQuimico, "idProduto", "nomeProduto", movimentacao.idProduto);
            ViewBag.idSituacao = new SelectList(db.situacao, "idSituacao", "situacao1", movimentacao.idSituacao);
            ViewBag.idVolume = new SelectList(db.volume, "idVolume", "qtdeVolume", movimentacao.idVolume);
            return View(movimentacao);
        }

        // GET: movimentacaos/Delete/5
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

        // POST: movimentacaos/Delete/5
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
