using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebNTB.Models
{
    [Table("BangTenMatHangs")]
    public class BangTenMatHang
    {
        [Key]
        [MaxLength(50)]
        [DisplayName("Mặt hàng")]
        public string MaHang { get; set; }

        [DisplayName("Tên hàng")]
        [Required]
        public string TenHang { get; set; }

        public virtual IEnumerable<BangTheoDoiToCat> BangTheoDoiToCats { set; get; }
    }
}