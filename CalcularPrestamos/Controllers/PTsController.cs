using CalcularPrestamos.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CalcularPrestamos.Controllers
{
    public class PTsController : Controller
    {
        private CX db = new CX();

        // GET: PTs
        public async Task<ActionResult> Index()
        {
            var pT = db.PT.Include(p => p.CI);
            return View(await pT.ToListAsync());
        }

        // GET: PTs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT pT = await db.PT.FindAsync(id);
            if (pT == null)
            {
                return HttpNotFound();
            }
            return View(pT);
        }

        // GET: PTs/Create
        public ActionResult Create()
        {
            ViewBag.CIID = new SelectList(db.CI, "Id", "Nombre");
            return View();
        }

        // POST: PTs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Monto,Interes,Plazo,Cuota,CIID,FechaInicioPrestamo")] PT pT)
        {
            if (ModelState.IsValid)
            {
                double cantidadPagar = 0d;
                double interes = 0d;
                double cuota = 0d;

                cantidadPagar = pT.Monto / (pT.Plazo * 12);
                interes = (pT.Monto * pT.Interes / 100) / 12;
                cuota = cantidadPagar + interes;

                pT.Cuota = cuota; 

                db.PT.Add(pT);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CIID = new SelectList(db.CI, "Id", "Nombre", pT.CIID);
            return View(pT);
        }

        // GET: PTs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT pT = await db.PT.FindAsync(id);
            if (pT == null)
            {
                return HttpNotFound();
            }
            ViewBag.CIID = new SelectList(db.CI, "Id", "Nombre", pT.CIID);
            return View(pT);
        }

        // POST: PTs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Monto,Interes,Plazo,Cuota,CIID,FechaInicioPrestamo")] PT pT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pT).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CIID = new SelectList(db.CI, "Id", "Nombre", pT.CIID);
            return View(pT);
        }

        // GET: PTs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT pT = await db.PT.FindAsync(id);
            if (pT == null)
            {
                return HttpNotFound();
            }
            return View(pT);
        }

        // POST: PTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PT pT = await db.PT.FindAsync(id);
            db.PT.Remove(pT);
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
