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
using System.IO;

namespace LanceUmDesafio.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private LanceUmDesafioDBEntities db = new LanceUmDesafioDBEntities();


        public ActionResult Index()
        {
            return RedirectToAction("MinhaConta");
        }
        // GET: Usuario
        public ActionResult MinhaConta()
        {
            return View();
        }


        public PartialViewResult DesafiosLancados(string id)
        {
            var desafios = db.Desafio.Where(d => d.IDUsuario.Equals(id));
            return PartialView("DesafiosLancados", desafios);
        }

        public PartialViewResult AlterFotoPefil(string id)
        {
            var user = db.AspNetUsers.Find(id);
            return PartialView("AlterFotoPerfil", new AlterarFotoViewModel { Foto = user.Foto });
        }
        [HttpPost]
        public JsonResult EnviarFoto()
        {
            string id = User.Identity.GetUserId();
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                if (UploadDeFoto.verificaTipoDoArquivo(pic))
                {
                    if (!UploadDeFoto.verificaTamanhoDoArquivo(pic))
                    {
                        UploadDeFoto.uploadFotoPerfil(id, pic, Server);
                        return Json(new { success = true, responseText = "Foto alterada com suscesso!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                        return Json(new { success = false, responseText = "A foto é muito grande, tamanho maximo é de 500Kb." }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { success = false, responseText = "O arquivo enviado não tem o formato aceito, envie .jpg ou png" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, responseText = "Ocorreu um erro no envio da foto" }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult MeuPerfil(string id)
        {
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            return PartialView("MeuPerfil", aspNetUsers);
        }


        [HttpGet]
        public PartialViewResult EditarMeuPerfil(string id)
        {
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            EditarUsuarioViewModel usuario = new EditarUsuarioViewModel();
            return PartialView("EditarMeuPerfil", EditarUsuarioViewModel.preencherEditarUsuarioViewModel(ref usuario, aspNetUsers));
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataNascimento,Sexo")] EditarUsuarioViewModel usuario)
        {
            AspNetUsers user = db.AspNetUsers.Find(usuario.Id);
            if (ModelState.IsValid)
            {
                db.Entry(EditarUsuarioViewModel.preencherAspNetUsers(ref user, usuario)).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Sucess"] = "Perfil editado com sucesso!";
                return RedirectToAction("Index","Usuario");
            }
            return PartialView("EditarMeuPerfil",usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            if (aspNetUsers == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsers);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspNetUsers);
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
