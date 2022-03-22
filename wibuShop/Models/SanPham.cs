namespace wibuShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {

        [Key]
        [DisplayName("Mã sản phẩm")]
        public int MaSP { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống!")]

        [DisplayName("Tên sản phẩm")]
        public string TenSP { get; set; }

        [Required(ErrorMessage = "Giá không được để trống!")]
        [Column(TypeName = "money")]
        [DisplayName("Giá")]
        public decimal Gia { get; set; }

        [StringLength(80)]
        [DisplayName("Nhà xuất bản")]
        public string NhaXuatBan { get; set; }

        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Số lượng không được để trống!")]
        public int SoLuongTon { get; set; }

        [StringLength(80)]

        public string TacGia { get; set; }
        [DisplayName("Giới thiệu")]
        [StringLength(4000)]
        public string GioiThieu { get; set; }

        [DisplayName("Giảm giá")]
        public double? GiamGia { get; set; }
        [Required(ErrorMessage = "Mã danh mục không được để trống!")]
        [DisplayName("Mã danh mục")]
        public int MaDM { get; set; }

        [StringLength(100)]
        [DisplayName("Ảnh")]
        public string AnhSP { get; set; }

        public virtual DanhMucSP DanhMucSP { get; set; }
    }
}
