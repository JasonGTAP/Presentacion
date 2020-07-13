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
    public class ReportesController : Controller
    {
        private ProyectoInacapEntities db = new ProyectoInacapEntities();

        // GET: Reportes
        public ActionResult Index()
        {
            var reporte = db.Reporte.Include(r => r.Estacionamiento);
            return View(reporte.ToList());
        }

        // GET: Reportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reporte.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            return View(reporte);
        }

        // GET: Reportes/Create
        public ActionResult Create()
        {
            ViewBag.idEstacionamiento = new SelectList(db.Estacionamiento, "IdEstacionamiento", "IdEstacionamiento");
            return View();
        }

        // POST: Reportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReporte,LugarEstacionamiento,FechaEntrada,FechaSalida,idEstacionamiento,NombreUsuario,NombreTrabajador")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                db.Reporte.Add(reporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstacionamiento = new SelectList(db.Estacionamiento, "IdEstacionamiento", "IdEstacionamiento", reporte.idEstacionamiento);
            return View(reporte);
        }

        // GET: Reportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reporte.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstacionamiento = new SelectList(db.Estacionamiento, "IdEstacionamiento", "IdEstacionamiento", reporte.idEstacionamiento);
            return View(reporte);
        }

        // POST: Reportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReporte,LugarEstacionamiento,FechaEntrada,FechaSalida,idEstacionamiento,NombreUsuario,NombreTrabajador")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstacionamiento = new SelectList(db.Estacionamiento, "IdEstacionamiento", "IdEstacionamiento", reporte.idEstacionamiento);
            return View(reporte);
        }

        // GET: Reportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = db.Reporte.Find(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            return View(reporte);
        }

        // POST: Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reporte reporte = db.Reporte.Find(id);
            db.Reporte.Remove(reporte);
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
