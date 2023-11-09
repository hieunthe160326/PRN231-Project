using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TblKhachHang
{
    public string MakH { get; set; } = null!;

    public string? TenKh { get; set; }

    public bool? Gt { get; set; }

    public string? Diachi { get; set; }

    public DateTime? NgaySinh { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<TblHoadon> TblHoadons { get; set; } = new List<TblHoadon>();
}
