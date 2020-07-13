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
    public class BicicletasController : Controller
    {
        private ProyectoInacapEntities db = new ProyectoInacapEntities();


     


        public string foto = "";

      


        


        // GET: Bicicletas
        public ActionResult Index()
        {
            int id = (int)Session["ID"];



            List<Bicicleta> listado = db.Bicicleta.Where(x => x.idUsuario == id).ToList();

      
            // var bicicleta = db.Bicicleta.Include(b => b.Usuario);
            // return View(bicicleta.ToList());
            return View(listado);


        }




        [HttpPost]
        public ActionResult SubirBicicleta(HttpPostedFileBase file, string color, string modelo)
        {
            Bicicleta bicicletadb = new Bicicleta();


            int id = (int)Session["ID"];
            Usuario usu = db.Usuario.Find(id);


            string relativo = "/Content/img/";
            string ruta = Server.MapPath(relativo);
            file.SaveAs(ruta + file.FileName);
            foto = relativo + file.FileName;

            bicicletadb.idUsuario = id;
            bicicletadb.Marca = usu.NombreUsuario;
            bicicletadb.Color = color;
            bicicletadb.Modelo = modelo;

            bicicletadb.ImagenBicicleta = foto;

            db.Bicicleta.Add(bicicletadb);
            db.SaveChanges();
            return RedirectToAction("Index");






        }














        // GET: Bicicletas/Details/5
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

        // GET: Bicicletas/Create
        public ActionResult Create()
        {
           //  ViewBag.idUsuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario");
            return View();
        }

        // POST: Bicicletas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBicicleta,Marca,Color,Modelo,ImagenBicicleta,idUsuario")] Bicicleta bicicleta)
        {
            int id = (int)Session["ID"];

            if (ModelState.IsValid)
            {


                bicicleta.idUsuario = id;

                db.Bicicleta.Add(bicicleta);
                db.SaveChanges();
                Session["Registro"]="Registro Exitoso";
              
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.Usuario, "IdUsuario", "NombreUsuario", bicicleta.idUsuario);
            return View(bicicleta);
        }

        // GET: Bicicletas/Edit/5
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
          
            return View(bicicleta);
        }

        // POST: Bicicletas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bicicleta bicicleta)
        {
            int id = (int)Session["ID"];


            if (ModelState.IsValid)
            {

                Bicicleta bicicletaDB = db.Bicicleta.Find(bicicleta.IdBicicleta);


                bicicletaDB.Marca = bicicleta.Marca;
                bicicletaDB.Color = bicicleta.Color;
                bicicletaDB.Modelo = bicicleta.Modelo;
                bicicletaDB.ImagenBicicleta = bicicletaDB.ImagenBicicleta;
                bicicleta.idUsuario = id;

                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(bicicleta);
        }

        // GET: Bicicletas/Delete/5
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

        // POST: Bicicletas/Delete/5
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
