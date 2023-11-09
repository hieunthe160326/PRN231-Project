using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly Prn231projectContext context;

        public OrdersController(Prn231projectContext context)
        {
            this.context = context;
        }

        [HttpGet("GetOrderDetailListById/{id}")]
        public IActionResult GetOrderDetailListById(int id)
        {
                var res = context.TblChiTietHds.Select(a => new
                {
                    MaHd = a.MaHd,
                    MaKh = a.MaHdNavigation.MaKh,
                    TenHang = a.MaHangNavigation.TenHang,
                    Gia = a.MaHangNavigation.Gia,
                    Soluong = a.Soluong.ToString()
                }).Where(a => a.MaHd == id).ToList();
                return Ok(res);
        }

        [HttpGet("GetOrderDetailList")]
        public IActionResult GetOrderDetailList()
        {
                var res = context.TblChiTietHds.Select(a => new
                {
                    MaHd = a.MaHd,
                    MaKh = a.MaHdNavigation.MaKh,
                    TenHang = a.MaHangNavigation.TenHang,
                    Gia = a.MaHangNavigation.Gia,
                    Soluong = a.Soluong.ToString()
                }).ToList();
                return Ok(res);
        }

        [HttpPost("AddOrder")]
        public IActionResult AddOrder(TblHoadon p)
        {
            try
            {
                context.TblHoadons.Add(p);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Can't add Order");
            }
        }

        [HttpPut("UpdateOrderDetail")]
        public IActionResult UpdateOrderDetail(int orderId, string productName, int quantity)
        {
            TblChiTietHd data = context.TblChiTietHds.FirstOrDefault(a => a.MaHd == orderId
        && a.MaHangNavigation.TenHang.Equals(productName));
            
            data.Soluong = quantity;
            context.SaveChanges();
            return Ok();
        }

        [HttpPost("addOrderDetail")]
        public IActionResult addOrderDetail(TblChiTietHd p)
        {
            context.TblChiTietHds.Add(p);
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeleteOrderDetail/{id}")]
        public IActionResult deleteOrderDetail(int id)
        {
            TblChiTietHd data = context.TblChiTietHds.OrderBy(a => a.MaChiTietHd).LastOrDefault(a => a.MaHd == id);
            if (data != null)
            {
                context.TblChiTietHds.Remove(data);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("Can't delete order detail");
            }
        }

        [HttpGet("GetListProductName")]
        public IEnumerable<string> GetListProductName()
        {
            var res = context.TblMatHangs.Where(a => a.Active == true).Select(a => a.TenHang).ToList();
            return res;
        }

        [HttpGet("CheckOrderDetailExist/{orderId}/{productName}")]
        public IActionResult CheckOrderDetailExist(int orderId, string productName)
        {
            TblChiTietHd data = context.TblChiTietHds.FirstOrDefault(a => a.MaHd == orderId
         && a.MaHangNavigation.TenHang.Equals(productName));
            if(data != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
    }
}
