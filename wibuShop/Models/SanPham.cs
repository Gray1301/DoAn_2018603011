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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            Chi_Tiet_Gio_Hang = new HashSet<Chi_Tiet_Gio_Hang>();
        }

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
        [DisplayName("Tác giả")]
        public string TacGia { get; set; }

        [StringLength(4000)]
        [DisplayName("Giới thiệu")]
        public string GioiThieu { get; set; }

        [DisplayName("Giảm giá")]
        public double? GiamGia { get; set; }

        [DisplayName("Mã danh mục")]
        public int MaDM { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Ảnh sản phẩm")]
        public string AnhSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chi_Tiet_Gio_Hang> Chi_Tiet_Gio_Hang { get; set; }

        public virtual DanhMucSP DanhMucSP { get; set; }
    }
}
