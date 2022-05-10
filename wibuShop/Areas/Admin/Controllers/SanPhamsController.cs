using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wibuShop.Models;

namespace wibuShop.Areas.Admin.Controllers
{
    public class SanPhamsController : BaseController
    {
        private waifuShop db = new waifuShop();

        // GET: Admin/SanPhams
        public ActionResult Index(int? page, string error, string maDM,string Name)
        {

            if (error != null)
                ViewBag.Error = error;
            var sanPham = db.SanPhams.Include(s => s.DanhMucSP);
            ViewBag.DanhMuc = db.DanhMucSPs.ToList();
            ViewBag.TK = db.SanPhams.Where(s => s.TenSP == Name).ToList();
            if(Name != null)
            {
                sanPham = sanPham.Where(s => s.TenSP == Name);
                ViewBag.Name = Name;
            }
            if(Name == " ")
            {
                sanPham = sanPham.OrderBy(s => s.MaSP);
            }
            if (maDM != null && maDM != "macdinh")
            {
                sanPham = sanPham.Where(s => s.MaDM.ToString().Equals(maDM));
                ViewBag.MaDM = maDM;
            }
            sanPham = sanPham.OrderBy(s => s.MaSP);
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(sanPham.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DanhMucSPs, "MaDM", "TenDM");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,Gia,NhaXuatBan,SoLuongTon,TacGia,GioiThieu,GiamGia,MaDM,AnhSP")] SanPham sanPham)
        {
            try
            {
                //if (ModelState.IsValid)
                {
                    sanPham.AnhSP = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/images/SanPham/" + FileName);
                        f.SaveAs(UploadPath);
                        sanPham.AnhSP = FileName;
                    }
                    db.SanPhams.Add(sanPham);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu! " + ex.Message;
                ViewBag.MaDM = new SelectList(db.DanhMucSPs, "MaDM", "TenDM", sanPham.MaDM);
                return View(sanPham);
            }
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.DanhMucSPs, "MaDM", "TenDM", sanPham.MaDM);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,Gia,TacGia,SoLuongTon,NhaXuatBan,GiamGia,MaDM,AnhSP")] SanPham sanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/images/SanPham/" + FileName);
                        f.SaveAs(UploadPath);
                        sanPham.AnhSP = FileName;
                    } 
                    db.Entry(sanPham).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu! " + ex.Message;
                ViewBag.MaDM = new SelectList(db.DanhMucSPs, "MaDM", "TenDM", sanPham.MaDM);
                return View(sanPham);
            }
        }

        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteConfirmedCustom(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);

            try
            {
                db.SanPhams.Remove(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "SanPhams", new { error = "Không  xóa  được  bản  ghi  này! " });
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
