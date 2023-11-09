using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TblHoadon
{
    public decimal MaHd { get; set; }

    public string? MaKh { get; set; }

    public DateTime? NgayHd { get; set; }

    public virtual TblKhachHang? MaKhNavigation { get; set; }

    public virtual ICollection<TblChiTietHd> TblChiTietHds { get; set; } = new List<TblChiTietHd>();
}
