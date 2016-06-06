using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebNTB.Models
{
    public class TrackerDbContext:DbContext
    {
        public TrackerDbContext() : base("TrackerConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<BangTheoDoiToCat> BangTheoDoiToCats { set; get; }
        public DbSet<BangTenMatHang> BangTenMatHangs { set; get; }
    }
}