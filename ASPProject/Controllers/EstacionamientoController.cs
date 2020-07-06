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
    public class EstacionamientoController : Controller
    {
        private ProyectoInacapEntities db = new ProyectoInacapEntities();

        // GET: Estacionamiento
        public ActionResult Index()
        {

            


            Estacionamiento estacionamientoo = new Estacionamiento();

            //Estacionamiento[] arreglo = new Estacionamiento[30];
            //arreglo[1] = estacionamientoo;

            List<Estacionamiento> estacionamientoss = db.Estacionamiento.Where(x => x.LugarEstacionamiento>0).ToList();
           




            //var estacionamiento = db.Estacionamiento.Include(e => e.Bicicleta).Include(e => e.Trabajador);
            //return View(estacionamiento.ToList());

            return View(estacionamientoss.ToList());

        }






        public  ActionResult Resolver(int? id) {

              Estacionamiento estacionamientodb = db.Estacionamiento.Find(id);


            estacionamientodb.LugarEstacionamiento = estacionamientodb.LugarEstacionamiento;
            estacionamientodb.HoraEntrada = DateTime.Parse("2020/01/01");
            estacionamientodb.EstacionamientoOcupado = false;
            estacionamientodb.idBicicleta = 2029;
            estacionamientodb.idTrabajador = 5;

            db.SaveChanges();
            return RedirectToAction("Index");

            
        }









        // GET: Estacionamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamiento estacionamiento = db.Estacionamiento.Find(id);
            if (estacionamiento == null)
            {
                return HttpNotFound();
            }
            return View(estacionamiento);
        }

        // GET: Estacionamiento/Create
        public ActionResult Create()
        {
            ViewBag.idBicicleta = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario");
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "IdTrabajador", "Nombre");
            return View();
        }

        // POST: Estacionamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estacionamiento estacionamiento)
        {

            Estacionamiento estacionamientoDB = db.Estacionamiento.Where(x => x.LugarEstacionamiento == estacionamiento.LugarEstacionamiento).FirstOrDefault();

            
            



                if (ModelState.IsValid)
            {

                if (estacionamientoDB == null)
                {

                    estacionamiento.HoraEntrada = DateTime.Now;
                    estacionamiento.HoraSalida = null;



                    db.Estacionamiento.Add(estacionamiento);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                else
                {
                    return RedirectToAction("Index");

                }

            }
        


                
              

            ViewBag.idBicicleta = new SelectList(db.Bicicleta, "IdBicicleta", "Marca", estacionamiento.idBicicleta);
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "IdTrabajador", "Nombre", estacionamiento.idTrabajador);
            return View(estacionamiento);
        }

        // GET: Estacionamiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamiento estacionamiento = db.Estacionamiento.Find(id);
            if (estacionamiento == null)
            {
                return HttpNotFound();
            }



            ViewBag.idBicicleta = new SelectList(db.Bicicleta, "IdBicicleta", "Marca", estacionamiento.idBicicleta);
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "IdTrabajador", "Nombre", estacionamiento.idTrabajador);
            return View(estacionamiento);
        }

        // POST: Estacionamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Estacionamiento estacionamiento)
        {
            if (ModelState.IsValid)
            {

                Estacionamiento estacionamientoDB = db.Estacionamiento.Find(estacionamiento.IdEstacionamiento);

                estacionamientoDB.LugarEstacionamiento = estacionamientoDB.LugarEstacionamiento;
                estacionamientoDB.HoraEntrada = DateTime.Now;
                estacionamientoDB.EstacionamientoOcupado = estacionamiento.EstacionamientoOcupado;
                estacionamientoDB.idBicicleta = estacionamiento.idBicicleta;
                estacionamientoDB.idTrabajador = estacionamiento.idTrabajador;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBicicleta = new SelectList(db.Bicicleta, "IdBicicleta", "Marca", estacionamiento.idBicicleta);
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "IdTrabajador", "Nombre", estacionamiento.idTrabajador);
            return View(estacionamiento);
        }

        // GET: Estacionamiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamiento estacionamiento = db.Estacionamiento.Find(id);
            if (estacionamiento == null)
            {
                return HttpNotFound();
            }
            return View(estacionamiento);
        }

        // POST: Estacionamiento/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(Estacionamiento estacionamiento)
        {

            if (ModelState.IsValid)
            {

                Estacionamiento estacionamientodb = db.Estacionamiento.Find(estacionamiento.IdEstacionamiento);

                estacionamientodb.LugarEstacionamiento = estacionamiento.LugarEstacionamiento;
                estacionamientodb.HoraEntrada = DateTime.Parse("2020/01/01");
                estacionamientodb.EstacionamientoOcupado = false;
                estacionamientodb.idBicicleta = 2;
                estacionamientodb.idTrabajador = 1;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBicicleta = new SelectList(db.Bicicleta, "IdBicicleta", "Marca", estacionamiento.idBicicleta);
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "IdTrabajador", "Nombre", estacionamiento.idTrabajador);
            return View(estacionamiento);
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
