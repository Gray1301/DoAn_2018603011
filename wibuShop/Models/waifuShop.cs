using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace wibuShop.Models
{
    public partial class waifuShop : DbContext
    {
        public waifuShop()
            : base("name=waifuShop2")
        {

        }

        public virtual DbSet<Chi_Tiet_Gio_Hang> Chi_Tiet_Gio_Hang { get; set; }
        public virtual DbSet<DanhMucSP> DanhMucSPs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chi_Tiet_Gio_Hang>()
                .Property(e => e.GiaSP)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DanhMucSP>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.DanhMucSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GioHang>()
                .HasMany(e => e.Chi_Tiet_Gio_Hang)
                .WithRequired(e => e.GioHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength();

            modelBuilder.Entity<PhanQuyen>()
                .HasMany(e => e.TaiKhoans)
                .WithRequired(e => e.PhanQuyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Gia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength();

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.GioHangs)
                .WithRequired(e => e.TaiKhoan)
                .WillCascadeOnDelete(false);
        }
    }
}