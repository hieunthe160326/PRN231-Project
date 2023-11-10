using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2023PRN231.Models
{
    public class OrderDetailDTO
    {
        public decimal MaHd { get; set; }
        public string MakH { get; set; } 
        public string? TenHang { get; set; }
        public float? Gia { get; set; }
        public int? Soluong { get; set; }
    }
}
