﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wibuShop.Models;

namespace wibuShop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private waifuShop db = new waifuShop();
        public ActionResult Index()
        {
            var doanhThu = db.Chi_Tiet_Gio_Hang.ToList();
            var hoadon = db.HoaDons.ToList();
            var taikhoan = db.TaiKhoans.Where(s => s.MaQuyen == 3).ToList();
            var sanpham = db.SanPhams.ToList();

            double doanht = 0;
            int slton = 0;
            int slDaBan = 0;
            foreach (var item in doanhThu)
            {
                slDaBan += item.SoLuongMua;
                doanht += item.SoLuongMua * Convert.ToDouble(item.GiaSP);
            }
            foreach (var item in sanpham)
            {
                slton += item.SoLuongTon;
            }
            ViewBag.DoanhThu = doanht;
            ViewBag.TonKho = slton;
            ViewBag.SLBan = slDaBan;
            ViewBag.SLKhach = taikhoan.Count;
            return View();
        }
    }
}