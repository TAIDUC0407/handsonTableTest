using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebNTB.Models
{
    [Table("BangTheoDoiToCats")]
    public class BangTheoDoiToCat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã chuyền")]
        public int MaChuyen { get; set; }

        [MaxLength(50)]
        [DisplayName("Mặt hàng")]
        public string MaHang { get; set; }
        [ForeignKey("MaHang")]
        public virtual BangTenMatHang BangTenMatHang { get; set; }

        [DisplayName("SL kế hoạch")]
        public int SLKeHoach { get; set; }

        [DisplayName("Thực hiện")]
        public int ThucHien { get; set; }

        [DisplayName("Lũy kế thực hiện")]
        public int LuyKeThucHien { get; set; }

        [Required]
        [DisplayName("Đèn báo cấp BTP")]
        public bool DenBaoCapBTP { get; set; }


        [Required]
        [DisplayName("Ngày tạo")]
        public DateTime NgayTao { get; set; }
    }
}