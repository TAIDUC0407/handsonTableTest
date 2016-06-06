using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebNTB.Models;

namespace WebNTB.Controllers
{
    public class Tbl_TheoDoiController : Controller
    {

        private TrackerDbContext _context;

        public Tbl_TheoDoiController()
        {
            _context = new TrackerDbContext();
        }

        // GET: Tbl_TheoDoi
        public ActionResult Index()
        {
            ViewBag.MaHang = new SelectList(_context.BangTenMatHangs.OrderBy(n => n.MaHang), "MaHang", "TenHang");
            return View();
        }

        [HttpGet]
        public JsonResult LoadData()
        {
            var listDB = _context.BangTheoDoiToCats.ToList();
            return Json(new { data = listDB, status = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            BangTheoDoiToCat bangtheodoi = serializer.Deserialize<BangTheoDoiToCat>(model);

            //save db...
            var entity = _context.BangTheoDoiToCats.Single(x => x.MaChuyen == bangtheodoi.MaChuyen);
            if (model.Contains("LuyKeThucHien"))
            {
                entity.LuyKeThucHien = bangtheodoi.LuyKeThucHien;
            }
            else if (model.Contains("SLKeHoach"))
            {
                entity.SLKeHoach = bangtheodoi.SLKeHoach;
            }
            else if (model.Contains("ThucHien"))
            {
                entity.ThucHien = bangtheodoi.ThucHien;
            }
            _context.SaveChanges();

            return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        }
    }
}