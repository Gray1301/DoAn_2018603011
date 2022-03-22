using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wibuShop.Models;

namespace wibuShop.Controllers
{
   
    public class ChinhSachController : Controller
    { 
        waifuShop db = new waifuShop();
        // GET: ChinhSach
        public ActionResult DieuKhoan()
        {
            return View();
        }
        public ActionResult BaoMat()
        {
            return View();
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        public ActionResult HeThong()
        {
            return View();
        }
        public ActionResult DoiTra()
        {
            return View();
        }
        public ActionResult KhachSi()
        {
            return View();
        }
        public ActionResult VanChuyen()
        {
            return View();
        }
        public ActionResult ThanhToan()
        {
            return View();
        }
        
    }
}