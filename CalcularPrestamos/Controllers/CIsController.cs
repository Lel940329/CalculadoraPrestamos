using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CalcularPrestamos.Models;

namespace CalcularPrestamos.Controllers
{
    public class CIsController : Controller
    {
        private CX db = new CX();

        // GET: CIs
        public async Task<ActionResult> Index()
        {
            return View(await db.CI.ToListAsync());
        }

        // GET: CIs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CI cI = await db.CI.FindAsync(id);
            if (cI == null)
            {
                return HttpNotFound();
            }
            return View(cI);
        }

        // GET: CIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CIs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,Cedula,Correo,FechaIngreso")] CI cI)
        {
            if (ModelState.IsValid)
            {
                db.CI.Add(cI);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cI);
        }

        // GET: CIs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CI cI = await db.CI.FindAsync(id);
            if (cI == null)
            {
                return HttpNotFound();
            }
            return View(cI);
        }

        // POST: CIs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Cedula,Correo,FechaIngreso")] CI cI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cI).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cI);
        }

        // GET: CIs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CI cI = await db.CI.FindAsync(id);
            if (cI == null)
            {
                return HttpNotFound();
            }
            return View(cI);
        }

        // POST: CIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CI cI = await db.CI.FindAsync(id);
            db.CI.Remove(cI);
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
    }
}
