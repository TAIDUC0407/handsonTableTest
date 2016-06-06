using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebNTB.Models;

namespace WebNTB.Controllers
{
    public class BangTheoDoiToCatsController : Controller
    {
        private TrackerDbContext db = new TrackerDbContext();

        // GET: BangTheoDoiToCats
        public ActionResult Index()
        {
            var bangTheoDoiToCats = db.BangTheoDoiToCats.Include(b => b.BangTenMatHang);
            return View(bangTheoDoiToCats.ToList());
        }

        // GET: BangTheoDoiToCats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangTheoDoiToCat bangTheoDoiToCat = db.BangTheoDoiToCats.Find(id);
            if (bangTheoDoiToCat == null)
            {
                return HttpNotFound();
            }
            return View(bangTheoDoiToCat);
        }

        // GET: BangTheoDoiToCats/Create
        public ActionResult Create()
        {
            ViewBag.MaHang = new SelectList(db.BangTenMatHangs, "MaHang", "TenHang");
            return View();
        }

        // POST: BangTheoDoiToCats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChuyen,MaHang,SLKeHoach,ThucHien,LuyKeThucHien,DenBaoCapBTP")] BangTheoDoiToCat bangTheoDoiToCat)
        {
            if (ModelState.IsValid)
            {
                db.BangTheoDoiToCats.Add(bangTheoDoiToCat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHang = new SelectList(db.BangTenMatHangs, "MaHang", "TenHang", bangTheoDoiToCat.MaHang);
            return View(bangTheoDoiToCat);
        }

        // GET: BangTheoDoiToCats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangTheoDoiToCat bangTheoDoiToCat = db.BangTheoDoiToCats.Find(id);
            if (bangTheoDoiToCat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHang = new SelectList(db.BangTenMatHangs, "MaHang", "TenHang", bangTheoDoiToCat.MaHang);
            return View(bangTheoDoiToCat);
        }

        // POST: BangTheoDoiToCats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChuyen,MaHang,SLKeHoach,ThucHien,LuyKeThucHien,DenBaoCapBTP")] BangTheoDoiToCat bangTheoDoiToCat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangTheoDoiToCat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHang = new SelectList(db.BangTenMatHangs, "MaHang", "TenHang", bangTheoDoiToCat.MaHang);
            return View(bangTheoDoiToCat);
        }

        // GET: BangTheoDoiToCats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangTheoDoiToCat bangTheoDoiToCat = db.BangTheoDoiToCats.Find(id);
            if (bangTheoDoiToCat == null)
            {
                return HttpNotFound();
            }
            return View(bangTheoDoiToCat);
        }

        // POST: BangTheoDoiToCats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BangTheoDoiToCat bangTheoDoiToCat = db.BangTheoDoiToCats.Find(id);
            db.BangTheoDoiToCats.Remove(bangTheoDoiToCat);
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
