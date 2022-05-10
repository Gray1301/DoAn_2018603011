using System;
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
            decimal all = 0;
            //Doanh thu sau khi giảm giá
            foreach (var item in doanhThu)
            {
                slDaBan += item.SoLuongMua;
                doanht += item.SoLuongMua * Convert.ToDouble(item.GiaSP);
            }
            foreach (var item in sanpham)
            {
                slton += item.SoLuongTon;
            }

            //Doanh thu trước khi giảm giá          
            foreach (var item in doanhThu)
            {
                SanPham sp = db.SanPhams.Where(g => g.MaSP == item.MaSP).FirstOrDefault();
                all += item.SoLuongMua * sp.Gia;
            }
            //Tính doanh thu theo 7 ngày gần nhất
            List<double> ListDoanhThu = new List<double>();//Lưu doanh thu 7 ngày vào đây
            List<string> ListDoanhThu1 = new List<string>();//Lưu doanh thu 7 ngày vào đây
            DateTime dateNow = DateTime.Now;
            double DoanhThuNgay = 0;
            double DoanhThuNgay1 = 0;
            double DoanhThuNgay2 = 0;
            double DoanhThuNgay3 = 0;
            double DoanhThuNgay4 = 0;
            double DoanhThuNgay5 = 0;
            double DoanhThuNgay6 = 0;
            var day = dateNow.Day;
            var month = dateNow.Month;
            var year = dateNow.Year;
            var ngayHienTai = day + "/" + month + "/" + year;
            var ngayHienTai1 = day - 1 + "/" + month + "/" + year;
            var ngayHienTai2 = day - 2 + "/" + month + "/" + year;
            var ngayHienTai3 = day - 3 + "/" + month + "/" + year;
            var ngayHienTai4 = day - 4 + "/" + month + "/" + year;
            var ngayHienTai5 = day - 5 + "/" + month + "/" + year;
            var ngayHienTai6 = day - 6 + "/" + month + "/" + year;
            int a = 0;
            int a1 = 0;
            int a2 = 0;
            int a3 = 0;
            int a4 = 0;
            int a5 = 0;
            int a6 = 0;
            foreach (var item in hoadon)
            {
                var NgaySoSanh = item.NgayTao.Day + "/" + item.NgayTao.Month + "/" + item.NgayTao.Year;

                if (NgaySoSanh == ngayHienTai && item.TinhTrang == "Đã nhận")
                {
                    var ListChiTietGioHangNgayHienTai = db.Chi_Tiet_Gio_Hang.Where(s => s.MaGioHang == item.MaGioHang).ToList();
                    foreach (var item1 in ListChiTietGioHangNgayHienTai)
                    {
                        DoanhThuNgay += item1.SoLuongMua * Convert.ToDouble(item1.GiaSP);
                    }
                    a++;
                }
            }
            if (DoanhThuNgay != 0)
            {
                ListDoanhThu.Add(DoanhThuNgay);
            }
            if (a == 0)
            {
                ListDoanhThu.Add(0);
            }
            //
            foreach (var item in hoadon)
            {
                var NgaySoSanh = item.NgayTao.Day + "/" + item.NgayTao.Month + "/" + item.NgayTao.Year;

                if (NgaySoSanh == ngayHienTai1 && item.TinhTrang == "Đã nhận")
                {
                    var ListChiTietGioHangNgayHienTai = db.Chi_Tiet_Gio_Hang.Where(s => s.MaGioHang == item.MaGioHang).ToList();
                    foreach (var item1 in ListChiTietGioHangNgayHienTai)
                    {
                        DoanhThuNgay1 += item1.SoLuongMua * Convert.ToDouble(item1.GiaSP);
                    }
                    a1++;
                }
            }
            if (DoanhThuNgay1 != 0)
            {
                ListDoanhThu.Add(DoanhThuNgay1);
            }
            if (a1 == 0)
            {
                ListDoanhThu.Add(0);
            }
            //
            foreach (var item in hoadon)
            {
                var NgaySoSanh = item.NgayTao.Day + "/" + item.NgayTao.Month + "/" + item.NgayTao.Year;

                if (NgaySoSanh == ngayHienTai2 && item.TinhTrang == "Đã nhận")
                {
                    var ListChiTietGioHangNgayHienTai = db.Chi_Tiet_Gio_Hang.Where(s => s.MaGioHang == item.MaGioHang).ToList();
                    foreach (var item1 in ListChiTietGioHangNgayHienTai)
                    {
                        DoanhThuNgay2 += item1.SoLuongMua * Convert.ToDouble(item1.GiaSP);
                    }
                    a2++;
                }

            }
            if (DoanhThuNgay2 != 0)
            {
                ListDoanhThu.Add(DoanhThuNgay2);
            }
            if (a2 == 0)
            {
                ListDoanhThu.Add(0);
            }
            foreach (var item in hoadon)
            {
                var NgaySoSanh = item.NgayTao.Day + "/" + item.NgayTao.Month + "/" + item.NgayTao.Year;

                if (NgaySoSanh == ngayHienTai3 && item.TinhTrang == "Đã nhận")
                {
                    var ListChiTietGioHangNgayHienTai = db.Chi_Tiet_Gio_Hang.Where(s => s.MaGioHang == item.MaGioHang).ToList();
                    foreach (var item1 in ListChiTietGioHangNgayHienTai)
                    {
                        DoanhThuNgay3 += item1.SoLuongMua * Convert.ToDouble(item1.GiaSP);
                    }
                    a3++;
                }
            }
            if (DoanhThuNgay3 != 0)
            {
                ListDoanhThu.Add(DoanhThuNgay3);
            }
            if (a3 == 0)
            {
                ListDoanhThu.Add(0);
            }
            foreach (var item in hoadon)
            {
                var NgaySoSanh = item.NgayTao.Day + "/" + item.NgayTao.Month + "/" + item.NgayTao.Year;

                if (NgaySoSanh == ngayHienTai4 && item.TinhTrang == "Đã nhận")
                {
                    var ListChiTietGioHangNgayHienTai = db.Chi_Tiet_Gio_Hang.Where(s => s.MaGioHang == item.MaGioHang).ToList();
                    foreach (var item1 in ListChiTietGioHangNgayHienTai)
                    {
                        DoanhThuNgay4 += item1.SoLuongMua * Convert.ToDouble(item1.GiaSP);
                    }
                    a4++;
                }

            }
            if (DoanhThuNgay4 != 0)
            {
                ListDoanhThu.Add(DoanhThuNgay4);
            }
            if (a4 == 0)
            {
                ListDoanhThu.Add(0);
            }
            foreach (var item in hoadon)
            {
                var NgaySoSanh = item.NgayTao.Day + "/" + item.NgayTao.Month + "/" + item.NgayTao.Year;

                if (NgaySoSanh == ngayHienTai5 && item.TinhTrang == "Đã nhận")
                {
                    var ListChiTietGioHangNgayHienTai = db.Chi_Tiet_Gio_Hang.Where(s => s.MaGioHang == item.MaGioHang).ToList();
                    foreach (var item1 in ListChiTietGioHangNgayHienTai)
                    {
                        DoanhThuNgay5 += item1.SoLuongMua * Convert.ToDouble(item1.GiaSP);
                    }

                    a5++;
                }

            }
            if (DoanhThuNgay5 != 0)
            {
                ListDoanhThu.Add(DoanhThuNgay5);
            }
            if (a5 == 0)
            {
                ListDoanhThu.Add(0);
            }
            foreach (var item in hoadon)
            {
                var NgaySoSanh = item.NgayTao.Day + "/" + item.NgayTao.Month + "/" + item.NgayTao.Year;

                if (NgaySoSanh == ngayHienTai6 && item.TinhTrang == "Đã nhận")
                {
                    var ListChiTietGioHangNgayHienTai = db.Chi_Tiet_Gio_Hang.Where(s => s.MaGioHang == item.MaGioHang).ToList();
                    foreach (var item1 in ListChiTietGioHangNgayHienTai)
                    {
                        DoanhThuNgay6 += item1.SoLuongMua * Convert.ToDouble(item1.GiaSP);
                    }
                    a6++;
                }
            }
            if (DoanhThuNgay6 != 0)
            {
                ListDoanhThu.Add(DoanhThuNgay6);
            }
            if (a6 == 0)
            {
                ListDoanhThu.Add(0);
            }
            double DoanhThuTuan = 0;
            List<double> ListView = new List<double>();
            foreach (var item in ListDoanhThu)
            {
                ListView.Add(item);
                DoanhThuTuan += item;
            }
            ViewBag.DTTuan = DoanhThuTuan;
            ViewBag.View = ListView;
            ViewBag.DoanhThu = doanht;
            ViewBag.TonKho = slton;
            ViewBag.SLBan = slDaBan;
            ViewBag.SLKhach = taikhoan.Count;
            ViewBag.all = all;
            return View();
        }
    }
}