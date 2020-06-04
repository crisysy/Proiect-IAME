using Microsoft.AspNet.Identity;
using Proiect_IAME.Models;
using Proiect_IAME.SqlViews;
using Proiect_IAME.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Proiect_IAME.Controllers
{
    public class ProgramareController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Programari
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var programari = db.Programari.Where(x => x.IdUtilizator == currentUserId && x.Interval.HasValue).OrderBy(x => x.Data).ThenBy(x => x.Interval);

            return View(programari.ToList());
        }

        public ActionResult Admin()
        {
            var programari = db.Programari.Where(x => x.Interval.HasValue).OrderBy(x => x.Data).ThenBy(x => x.Interval);

            return View(programari.ToList());
        }

        public ActionResult SelectDate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelectDate([Bind(Include = "Id,IdUtilizator,Data,Serviciu,Interval")] Programare programare)
        {
            try
            {

                var oreLucrate = Enum.GetValues(typeof(Interval)).Cast<Interval>();
                var oreOcupate = db.Programari.Where(x => x.Interval.HasValue && x.Data == programare.Data).Select(x => x.Interval).ToList();
                var alteOre = oreLucrate.Where(x => !oreOcupate.Contains(x)).Select(e => e.GetDescription()).ToList();
                var altIntervalDisponibil = alteOre.Any();

                if (!altIntervalDisponibil)
                {
                    ViewBag.alteOre = string.Join(", ", alteOre);
                    ViewBag.indisponibil = 1;

                    return View(programare);
                }

                programare.Id = Guid.NewGuid();
                programare.IdUtilizator = User.Identity.GetUserId();
                db.Programari.Add(programare);
                db.SaveChanges();

                return RedirectToAction("Create");
            }
            catch
            {
                return View(programare);
            }
        }

        // GET: Programari/Create
        public ActionResult Create()
        {
            //DateTime data = DataAleasa;
            //var oreOcupate = db.Programari.Where(x => x.Data.Date == data.Date).Select(x => x.Data.TimeOfDay);
            //var oreLucrate = from i in Enumerable.Range(9, 17)
            //                 let h = new DateTime(2014, 1, 1, i, 0, 0)
            //                 select h.TimeOfDay;/*.ToString("t", CultureInfo.CreateSpecificCulture("es-ES"));*/
            //var oreLibere = oreLucrate.Where(x => !oreOcupate.Contains(x));

            var placeholder = db.Programari.FirstOrDefault(x => !x.Interval.HasValue);
            var oreLucrate = Enum.GetValues(typeof(Interval)).Cast<Interval>();
            var oreOcupate = db.Programari.Where(x => x.Interval.HasValue && x.Data == placeholder.Data).Select(x => x.Interval).ToList();

            ViewBag.ocupare = 100 * oreOcupate.Count() / oreLucrate.Count(); 

            ViewBag.oreDisponibile = oreLucrate.Where(x => !oreOcupate.Contains(x)).Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.GetDescription()
            }); 

            return View(placeholder);
        }

        // POST: Programari/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,IdUtilizator,Data,Serviciu,Interval,Nume,Contact")] Programare programare)
        {
            try
            {
                Programare placeholder = db.Programari.Find(programare.Id);
                placeholder.Interval = programare.Interval;

                if (User.IsInRole("Administrator"))
                {
                    placeholder.Nume = programare.Nume;
                    placeholder.Contact = programare.Contact;
                }
                else
                {
                    placeholder.Nume = placeholder.User.Nume;
                    placeholder.Contact = placeholder.User.Contact ?? placeholder.User.Email;
                }
     

                if (ModelState.IsValid)
                {
                    db.Entry(placeholder).State = EntityState.Modified;
                    db.SaveChanges();

                    if (User.IsInRole("Administrator"))
                    {
                        return RedirectToAction("Admin");
                    }

                    return RedirectToAction("Index");
                }
                if (User.IsInRole("Administrator"))
                {
                    return RedirectToAction("Admin");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Programari/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programare programare = db.Programari.Find(id);
            if (programare == null)
            {
                return HttpNotFound();
            }

            return View(programare);
        }

        // POST: Programari/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,IdUtilizator,Data,Serviciu,Interval,Nume,Contact")] Programare programare)
        {
            if (db.Programari.Any(x => x.Data == programare.Data && x.Interval == programare.Interval && x.Id != programare.Id))
            {
                ViewBag.show = 1;

                var oreLucrate = Enum.GetValues(typeof(Interval)).Cast<Interval>();
                var oreOcupate = db.Programari.Where(x => x.Interval.HasValue && x.Data == programare.Data).Select(x => x.Interval).ToList();
                var alteOre = oreLucrate.Where(x => !oreOcupate.Contains(x)).Select(e => e.GetDescription()).ToList();
                ViewBag.altIntervalDisponibil = alteOre.Any();
                ViewBag.alteOre = string.Join(", ", alteOre);

                return View();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    

                    db.Entry(programare).State = EntityState.Modified;
                    db.SaveChanges();

                    if (User.IsInRole("Administrator"))
                    {
                        return RedirectToAction("Admin");
                    }

                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Programari/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programare programare = db.Programari.Find(id);
            if (programare == null)
            {
                return HttpNotFound();
            }

            return View(programare);
        }

        // POST: Donatie/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                Programare programare = db.Programari.Find(id);
                db.Programari.Remove(programare);
                db.SaveChanges();

                if (User.IsInRole("Administrator"))
                {
                    return RedirectToAction("Admin");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
