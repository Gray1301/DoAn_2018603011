namespace wibuShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int MaHD { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime NgayTao { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Hình thức vận chuyển")]
        public string HinhThucVanChuyen { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Hình thức thanh toán")]
        public string HinhThucThanhToan { get; set; }

        [DisplayName("Mã giỏ hàng")]
        public int MaGioHang { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [DisplayName("Địa chỉ")]
        [Column(TypeName = "ntext")]
        public string DiaChi { get; set; }

        [StringLength(10)]
        [DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tình trạng")]
        public string TinhTrang { get; set; }

        public virtual GioHang GioHang { get; set; }
    }
}
