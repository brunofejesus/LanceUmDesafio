using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using LanceUmDesafio.Models;

namespace LanceUmDesafio.Controllers
{

    public class DesafioController : Controller
    {
        private LanceUmDesafioDBEntities db = new LanceUmDesafioDBEntities();

        // GET: Desafio
        public ActionResult Index()
        {
            var desafio = db.Desafio.Include(d => d.AspNetUsers).Include(d => d.Categoria);
            return View(desafio.ToList());
        }

        public ActionResult Votar(int IdDesafio, double Rank)
        {
            var desafio = db.Desafio.Find(IdDesafio);
            desafio.Rank = Rank;
            db.Entry(desafio).State = EntityState.Modified;
            db.SaveChanges();
            TempData["Sucess"] = "Obrigado por votar neste desafio !";
            return RedirectToAction("Details","Desafio", new { id = IdDesafio });
        }

        public ActionResult Categorias()
        {
            var categorias = db.Categoria.Where(ca => ca.ID_Categoria != null);
            return View(categorias.ToList());
        }

        public ActionResult ListCategorias(int id)
        {
            var desafiosCategorias = db.Desafio.Where(de => de.IDCategoria == id);
            if(desafiosCategorias.Count() == 0)
                TempData["Warning"] = "Esta categoria ainda não tem desafios cadastrados";
            return View(desafiosCategorias.ToList());
        }

        // GET: Desafio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desafio desafio = db.Desafio.Find(id);
            if (desafio == null)
            {
                return HttpNotFound();
            }
            return View(desafio);
        }

        // GET: Desafio/Create
        public ActionResult Create()
        {
            ViewBag.Controller = "Desafio";
            ViewBag.IDCategoria = new SelectList(db.Categoria.Where(ca => ca.ID_Categoria != null), "ID", "Nome");
            return View();
        }

        // POST: Desafio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDesafio,Titulo,Rank,Comentarios,Conteudo,IDUsuario,IDCategoria")] Desafio desafio)
        {
            desafio.Rank = 0;
            desafio.Votos = 0;
            desafio.IDUsuario = User.Identity.GetUserId();
            desafio.DataPostagem = DateTime.Today;
            if (ModelState.IsValid)
            {
                db.Desafio.Add(desafio);
                db.SaveChanges();
                var id = desafio.IdDesafio;
                TempData["Sucess"] = "Seu desafio foi criado com sucesso! aqui está a pagina dele";
                return RedirectToAction("Details", "Desafio", new { id = id });
            }
            ViewBag.IDCategoria = new SelectList(db.Categoria.Where(ca => ca.ID_Categoria != null), "ID", "Nome", desafio.IDCategoria);
            return View(desafio);
        }

        // GET: Desafio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desafio desafio = db.Desafio.Find(id);
            if (desafio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDUsuario = new SelectList(db.AspNetUsers, "Id", "Hometown", desafio.IDUsuario);
            ViewBag.IDCategoria = new SelectList(db.Categoria, "ID", "Nome", desafio.IDCategoria);
            return View(desafio);
        }

        // POST: Desafio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDesafio,Titulo,Rank,Comentarios,Conteudo,IDUsuario,IDCategoria")] Desafio desafio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desafio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDUsuario = new SelectList(db.AspNetUsers, "Id", "Hometown", desafio.IDUsuario);
            ViewBag.IDCategoria = new SelectList(db.Categoria, "ID", "Nome", desafio.IDCategoria);
            return View(desafio);
        }

        // GET: Desafio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desafio desafio = db.Desafio.Find(id);
            if (desafio == null)
            {
                return HttpNotFound();
            }
            return View(desafio);
        }

        // POST: Desafio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Desafio desafio = db.Desafio.Find(id);
            db.Desafio.Remove(desafio);
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
