using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using LanceUmDesafio.Models;

namespace LanceUmDesafio.Controllers
{
    public class ComentariosController : Controller
    {
        private LanceUmDesafioDBEntities db = new LanceUmDesafioDBEntities();

        // POST: Comentarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Conteudo,IdDesafio")] string Conteudo, string IdDesafio)
        {
            var comentarios = db.Comentario.Where(c => c.IDDesafio.Equals(IdDesafio)).OrderByDescending(c => c.DataComentario);
            var user = User.Identity.GetUserId();
            DateTime data = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                db.Comentario.Add(new Comentario
                { IDDesafio = Int32.Parse(IdDesafio), IDUsuario = user,
                  Conteudo = Conteudo, DataComentario = data});
                db.SaveChanges();
                TempData["Sucess"] = "Seu comentário foi recebido com sucesso!";
                return RedirectToAction("Details", "Desafio", new { id = IdDesafio });
            }
            TempData["Warning"] = "Ocorreu um erro ao comentar, Tente novamente";
            return RedirectToAction("Details", "Desafio", new { id = IdDesafio });
        }

        // GET: Comentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDUsuario = new SelectList(db.AspNetUsers, "Id", "Hometown", comentario.IDUsuario);
            ViewBag.IDDesafio = new SelectList(db.Desafio, "IdDesafio", "Titulo", comentario.IDDesafio);
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComentario,Conteudo,IDUsuario,DataComentario,IDDesafio")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDUsuario = new SelectList(db.AspNetUsers, "Id", "Hometown", comentario.IDUsuario);
            ViewBag.IDDesafio = new SelectList(db.Desafio, "IdDesafio", "Titulo", comentario.IDDesafio);
            return View(comentario);
        }

        // GET: Comentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentario comentario = db.Comentario.Find(id);
            db.Comentario.Remove(comentario);
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
