namespace DoAn_LTWin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETPHIEUNHAP")]
    public partial class CHITIETPHIEUNHAP
    {
        [Key]
        [StringLength(12)]
        public string MaCTPN { get; set; }

        [StringLength(12)]
        public string MaPN { get; set; }

        [StringLength(12)]
        public string MaSP { get; set; }

        public int? SoLuong { get; set; }

        public decimal? DonGiaNhap { get; set; }

        public virtual PHIEUNHAP PHIEUNHAP { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
