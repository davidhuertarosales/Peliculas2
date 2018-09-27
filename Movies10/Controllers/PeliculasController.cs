using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movies.Models;
using Movies10.Models;

namespace Movies10.Controllers
{
    public class PeliculasController : Controller
    {
        private Pelidb db = new Pelidb();

        // GET: Peliculas
        public async Task<ActionResult> Index()
        {
            return View(await db.Pelicula.ToListAsync());
        }

        // GET: Peliculas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = await db.Pelicula.FindAsync(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PeliID,Title,Poster,ImageMimeType,Sinopsis,Fecha_estreno,Director")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Pelicula.Add(pelicula);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = await db.Pelicula.FindAsync(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PeliID,Title,Poster,ImageMimeType,Sinopsis,Fecha_estreno,Director")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = await db.Pelicula.FindAsync(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pelicula pelicula = await db.Pelicula.FindAsync(id);
            db.Pelicula.Remove(pelicula);
            await db.SaveChangesAsync();
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
        ///// otros
        public ActionResult Create2()
        {
            Pelicula newPeli = new Pelicula();
            newPeli.Fecha_estreno = DateTime.Today;

            return View("Create", newPeli);
        }

        [HttpPost]
        public ActionResult Create2(Pelicula pelicula, HttpPostedFileBase image)
        {
            pelicula.Fecha_estreno = DateTime.Today;

            if (!ModelState.IsValid)
            {
                return View("Create", pelicula);
            }
            else
            {
                if (image != null)
                {
                    pelicula.ImageMimeType = image.ContentType;
                    pelicula.Poster = new byte[image.ContentLength];
                    image.InputStream.Read(pelicula.Poster, 0, image.ContentLength);
                }

                db.Pelicula.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
        }





        public FileContentResult GetImage(int id)
        {
            Pelicula pelicula = db.Pelicula.Find(id);
               

            if (pelicula != null)
            {
                return File(pelicula.Poster, pelicula.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
