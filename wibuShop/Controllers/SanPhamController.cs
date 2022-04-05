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
    public class SanPhamController : Controller
    {
        // GET: SanPham
        waifuShop db = new waifuShop();
        public ActionResult SanPham(string id, string ThongBao)
        {
            if (ThongBao != null)
            {
                ViewBag.ThongBao = ThongBao;
            }
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
        public List<string> NXB1(int id)
        {
            List<string> tinhs2 = new List<string>();
            var nxb = db.SanPhams.Where(e => e.MaDM == id).Select(e => new { e.NhaXuatBan }).Distinct().ToList();
            foreach (var item in nxb)
            {
                tinhs2.Add(item.NhaXuatBan);
            }
            tinhs2.Sort();
            return tinhs2;
        }
        
    
        public ActionResult XemSanPhamTheoDanhMuc(string id, int? page, string loc, int cost = 0)
        {
            //ViewBag.tacgia = tacgia();
            //ViewBag.nxb = NXB();
            ViewBag.MaDM = id;
            ViewBag.cost = cost;          
            bool abc = false;
            bool abc1 = false;
            bool abc2 = false;
            bool abc3 = false;
            var sanpham = db.SanPhams.Where(s => s.MaDM.ToString().Equals(id)).Select(s => s);
            if (cost == 100000)
            {
                decimal a = Convert.ToDecimal(cost);
                sanpham = sanpham.Where(s => s.Gia <= a).Select(s => s);
                abc = true;
            }
           
            else if (cost == 200000)
            {
                decimal a = Convert.ToDecimal(cost);
                sanpham = sanpham.Where(s => s.Gia > 100000 && s.Gia <= a).Select(s => s);
                abc1 = true;

            }
            else if (cost == 300000)
            {
                decimal a = Convert.ToDecimal(cost);
                sanpham = sanpham.Where(s => s.Gia > 200000 && s.Gia <= a).Select(s => s);
                abc2 = true;

            }
            else if (cost == 300001)
            {
                decimal a = Convert.ToDecimal(cost);
                sanpham = sanpham.Where(s => s.Gia > a).Select(s => s);
                abc3 = true;

            }

            int madm = int.Parse(id);
            List<DanhMucSP> s1 = new List<DanhMucSP>();
            s1 = db.DanhMucSPs.Where(h => h.MaDM == madm).ToList();
            ViewBag.TenDM = s1[0].TenDM;
            ViewBag.CanhBao = abc;
            ViewBag.CanhBao1 = abc1;
            ViewBag.CanhBao2 = abc2;
            ViewBag.CanhBao3 = abc3;           
            int pageSize = 8;
            int pageNumber = (page ?? 1);               
            return View(sanpham.ToList().ToPagedList(pageNumber, pageSize));
        }
    }
}