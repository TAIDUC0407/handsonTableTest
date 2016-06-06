using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNTB.Models;
using System.Web.Script.Serialization;

namespace WebNTB.Controllers
{
    public class HomeController : Controller
    {
        private TrackerDbContext _context;

        public HomeController()
        {
            _context = new TrackerDbContext();
        }
        #region databse and load update data in table(BachNgocToan)
        List<EmployeeModel> listEmployee = new List<EmployeeModel>()
        {
            new EmployeeModel()
            {
            ID = 1,
                Name = "Nguyễn Văn A",
                Salary = 2000000,
                Status = true
            },
            new EmployeeModel()
            {
                ID = 2,
                Name = "Nguyễn Văn B",
                Salary = 3000000,
                Status = false
            },
            new EmployeeModel()
            {
                ID = 3,
                Name = "Nguyễn Văn C",
                Salary = 4000000,
                Status = true
            }
        };

        public ActionResult Index()
        {
            return View();

        }

        [HttpGet]
        public JsonResult LoadData()
        {
            return Json(new { data = listEmployee, status = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            EmployeeModel employee = serializer.Deserialize<EmployeeModel>(model);

            //save db...
            var entity = listEmployee.Single(x => x.ID == employee.ID);
            entity.Salary = employee.Salary;

            return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult jquery()
        {
            return View();
        }

        #region table handsontable not data
        public ActionResult HandsonTable()
        {
            return View();
        }
        
        public ActionResult GetBangTheoDoi()
        {
            var bangtheodois = _context.BangTheoDoiToCats.ToList();

            return Json(bangtheodois, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region getdata and AutoSave in HandsonTable
        public ActionResult HandsonTableSec()
        {

            return View();
        }

        public ActionResult AddCar(List<string[]> dataListFromTable)
        {

            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //BangTheoDoiToCat bangtheodoi = serializer.Deserialize<BangTheoDoiToCat>(model);
            //_context.SaveChanges();
            var dataListTable = dataListFromTable;
            return Json("Response, Data Received Successfully");
        }
        public JsonResult GetCar()
        {
            var listDB = _context.BangTheoDoiToCats.ToList();

            var items = new List<object>();
            int MaChuyen, SLKeHoach, ThucHien, LuyKeThucHien;
            string MaHang, NgayTao;
            bool DenBaoCapBTP;
            foreach (var item in listDB)
            {
                MaChuyen = item.MaChuyen;
                MaHang = item.MaHang;
                SLKeHoach = item.SLKeHoach;
                ThucHien = item.ThucHien;
                LuyKeThucHien = item.LuyKeThucHien;
                DenBaoCapBTP = item.DenBaoCapBTP;
                NgayTao = item.NgayTao.ToString();

                items.Add(new {MaChuyen,MaHang,SLKeHoach,ThucHien,LuyKeThucHien,DenBaoCapBTP,NgayTao });
            }
            //string result = Convert.ToString(listDB);
            //JavaScriptSerializer s = new JavaScriptSerializer();
            //var json = s.Serialize(listDB);
            //Response.Write(json);

            return Json(items, JsonRequestBehavior.AllowGet);
            //var jsonData = new[]
            //             {
            //             new[] {" ", "Kia", "Nissan",
            //             "Toyota", "Honda", "Mazda", "Ford"},
            //             new[] {"2012", "10", "11",
            //             "12", "13", "15", "16"},
            //             new[] {"2013", "10", "11",
            //             "12", "13", "15", "16"},
            //             new[] {"2014", "10", "11",
            //             "12", "13", "15", "16"},
            //             new[] {"2015", "10", "11",
            //             "12", "13", "15", "16"},
            //             new[] {"2016", "10", "11",
            //             "12", "13", "15", "16"}
            //        
            //return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region About and Contact
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
        #endregion


    }
}