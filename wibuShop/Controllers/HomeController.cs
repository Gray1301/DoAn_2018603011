using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wibuShop.Models;

namespace wibuShop.Controllers
{
    public class HomeController : Controller
    {
        waifuShop db = new waifuShop();

        public ActionResult Index()
        {

            List<SanPham> hangs = new List<SanPham>();
            
            var sanphams = db.SanPhams.Select(h => h).Take(15);
            ViewBag.tacgia = tacgia();
            ViewBag.nxb = NXB();
            var danhmuc = db.DanhMucSPs.Select(h => h);
           
            return View(sanphams);
        }
        public int DaBan(int id)
        {
            int all = 0;
            var DaBan = db.Chi_Tiet_Gio_Hang.Where(s => s.MaSP == id).ToList();
            foreach (var item in DaBan)
            {
                all += item.SoLuongMua;
            }
            ViewBag.all = all;
            return all;
        }
        public List<string> tacgia()
        {
            List<string> tinhs1 = new List<string>();
            var tacgia = db.SanPhams.Select(e => new { e.TacGia }).Distinct().ToList();
            foreach (var item in tacgia)
            {
                tinhs1.Add(item.TacGia);
            }
            tinhs1.Sort();
            return tinhs1;
        }
        public List<string> NXB()
        {
            List<string> tinhs2 = new List<string>();
            var nxb = db.SanPhams.Select(e => new { e.NhaXuatBan }).Distinct().ToList();
            foreach (var item in nxb)
            {
                tinhs2.Add(item.NhaXuatBan);
            }
            tinhs2.Sort();
            return tinhs2;
        }     
        public ActionResult TimKiem(string strSearch, int? page)
        {
            var sanpham = db.SanPhams.ToList();
            if (strSearch != null)
            {
                sanpham = db.SanPhams.Where(s => s.TenSP.ToUpper().Trim().Contains(strSearch.ToUpper().Trim())).ToList();
            }
            ViewBag.strSearch = strSearch;
            if (sanpham.Count > 0)
            {
                int pageSize = 8;
                int pageNumber = (page ?? 1);
                return View(sanpham.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                ViewBag.Thongbao = "Không có sản phẩm nào";
                return View();
            }
        }
        public PartialViewResult _Nav()
        {
            ViewBag.tacgia = tacgia();
            ViewBag.nxb = NXB();  
            var danhmuc = db.DanhMucSPs.Select(n => n);          
            return PartialView(danhmuc);
        }
        public ActionResult SanPham(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sp = db.SanPhams.Find(int.Parse(id));
            if (sp == null)
            {
                return HttpNotFound();
            }
            int madm = db.SanPhams.Find(int.Parse(id)).MaDM;
            ViewBag.ma = madm;

            List<SanPham> Sp = new List<SanPham>();
            Sp = db.SanPhams.Where(h => h.MaDM.Equals(madm)).OrderByDescending(h => h.Gia).Take(8).ToList();
            ViewBag.sp = Sp;


            List<DanhMucSP> s = new List<DanhMucSP>();
            s = db.DanhMucSPs.Where(h => h.MaDM == madm).ToList();
            ViewBag.TenDM = s[0].TenDM;

            return View(sp);
        }
        public ActionResult XemSanPhamTheoDanhMuc(string id)
        {
            List<SanPham> sanpham = new List<SanPham>();
            if (id == null)
            {

            }
            else
            {
                sanpham = db.SanPhams.Where(s => s.MaDM.ToString().Equals(id)).Select(s => s).ToList();

            }
            int madm = int.Parse(id);
            List<DanhMucSP> s1 = new List<DanhMucSP>();
            s1 = db.DanhMucSPs.Where(h => h.MaDM == madm).ToList();
            ViewBag.TenDM = s1[0].TenDM;

            return View(sanpham);
        }
        public ActionResult XemSanPhamTheoTacGia(string id)
        {
            List<SanPham> sanpham = new List<SanPham>();
            if (id == null)
            {

            }
            else
            {
                sanpham = db.SanPhams.Where(s => s.TacGia.ToString().Equals(id)).Select(s => s).ToList();
            }
            int madm = int.Parse(id);
            List<DanhMucSP> s1 = new List<DanhMucSP>();
            s1 = db.DanhMucSPs.Where(h => h.MaDM == madm).ToList();
            ViewBag.TenDM = s1[0].TenDM;

            return View(sanpham);
        }
        public ActionResult XemSanPhamTheoNXB(string id)
        {
            List<SanPham> sanpham = new List<SanPham>();
            if (id == null)
            {

            }
            else
            {
                sanpham = db.SanPhams.Where(s => s.NhaXuatBan.ToString().Equals(id)).Select(s => s).ToList();

            }
            int madm = int.Parse(id);
            List<DanhMucSP> s1 = new List<DanhMucSP>();
            s1 = db.DanhMucSPs.Where(h => h.MaDM == madm).ToList();
            ViewBag.TenDM = s1[0].TenDM;
            return View(sanpham);
        }
    }
}