﻿namespace wibuShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            GioHangs = new HashSet<GioHang>();
        }

        [Key]
        [DisplayName("Mã tài khoản")]
        public int MaTK { get; set; }


        [Required(ErrorMessage = "Bạn chưa nhập email")]
        [StringLength(50)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự")]
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Bạn chưa nhập họ tên")]
        public string HoTen { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(10)]
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập SĐT")]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        [DisplayName("Ảnh")]
        public string Anh { get; set; }
        [UIHint("Boolean")]
        [DisplayName("Tình trạng")]
        public bool TinhTrang { get; set; }
        [DisplayName("Mã quyền")]
        public int MaQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}