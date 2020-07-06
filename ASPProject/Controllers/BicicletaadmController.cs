using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Conexion.Models;

namespace ASPProject.Controllers
{
    public class BicicletaadmController : Controller
    {
        private ProyectoInacapEntities db = new ProyectoInacapEntities();

        // GET: Bicicletaadm
        public ActionResult Index()
        {
            var bicicleta = db.Bicicleta.Include(b => b.Usuario);
            return View(bicicleta.ToList());
        }

        // GET: Bicicletaadm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicleta bicicleta = db.Bicicleta.Find(id);
            if (bicicleta == null)
            {
                return HttpNotFound();
            }
            return View(bicicleta);
        }

        // GET: Bicicletaadm/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario");
            return View();
        }

        // POST: Bicicletaadm/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBicicleta,Marca,Color,Modelo,ImagenBicicleta,idUsuario")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                db.Bicicleta.Add(bicicleta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario", bicicleta.idUsuario);
            return View(bicicleta);
        }

        // GET: Bicicletaadm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicleta bicicleta = db.Bicicleta.Find(id);
            if (bicicleta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario", bicicleta.idUsuario);
            return View(bicicleta);
        }

        // POST: Bicicletaadm/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBicicleta,Marca,Color,Modelo,ImagenBicicleta,idUsuario")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bicicleta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario", bicicleta.idUsuario);
            return View(bicicleta);
        }

        // GET: Bicicletaadm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicleta bicicleta = db.Bicicleta.Find(id);
            if (bicicleta == null)
            {
                return HttpNotFound();
            }
            return View(bicicleta);
        }

        // POST: Bicicletaadm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bicicleta bicicleta = db.Bicicleta.Find(id);
            db.Bicicleta.Remove(bicicleta);
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
