using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebNTB.Models;

namespace WebNTB.Controllers
{
    public class BangTheoDoiAJController : Controller
    {
        private TrackerDbContext _context;

        public BangTheoDoiAJController()
        {
            _context = new TrackerDbContext();
        }
        // GET: BangTheoDoiAJ
        public ActionResult Index()
        {

            //ViewBag.MaHang = new SelectList(_context.BangTenMatHangs.OrderBy(n => n.MaHang), "MaHang", "TenHang");
            return View();
        }

        public ActionResult GetBangTheoDoi()
        {
            var bangtheodois = _context.BangTheoDoiToCats.ToList();

            return Json(bangtheodois, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int MaChuyen)
        {
            var bangtheodoi = _context.BangTheoDoiToCats.ToList().Find(x => x.MaChuyen==MaChuyen);
            return Json(bangtheodoi, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude ="MaChuyen")] BangTheoDoiToCat bangTheoDoiToCat)
        {
            if (ModelState.IsValid)
            {
                _context.BangTheoDoiToCats.Add(bangTheoDoiToCat);
                _context.SaveChanges();
            }

            return Json(bangTheoDoiToCat, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(BangTheoDoiToCat bangTheoDoiToCat)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(bangTheoDoiToCat).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return Json(bangTheoDoiToCat, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int MaChuyen)
        {
            var bangTheoDoiToCat = _context.BangTheoDoiToCats.ToList().Find(x => x.MaChuyen == MaChuyen);
            if (bangTheoDoiToCat != null)
            {
                _context.BangTheoDoiToCats.Remove(bangTheoDoiToCat);
                _context.SaveChanges();
            }

            return Json(bangTheoDoiToCat, JsonRequestBehavior.AllowGet);

        }
    }
}