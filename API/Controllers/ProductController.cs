using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Prn231projectContext context;

        public ProductController(Prn231projectContext context)
        {
            this.context = context;
        }

        [HttpGet("ListProduct")]
        public IActionResult Index()
        {
            List<TblMatHang> products = context.TblMatHangs.Where(a => a.Active == true).ToList();
            return Ok(products);
        }

        [HttpGet("GetTypeProduct")]
        public IEnumerable<string> GetTypeProduct() 
        {
            var res = context.TblMatHangs.Select(a => a.Dvt).ToList();
            return res;
        }
        [HttpPut("DeleteProduct")]
        public IActionResult Delete(string id)
        {
            TblMatHang c = context.TblMatHangs.FirstOrDefault(a => a.MaHang.Equals(id));
            if (c != null)
            {
                c.Active = false;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("cant delete product");
            }
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(TblMatHang p)
        {
            try
            {
                context.TblMatHangs.Add(p);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Can't add Product");
            }
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateOrderDetail(TblMatHang p)
        {
            TblMatHang data = context.TblMatHangs.FirstOrDefault(a => a.MaHang.Equals(p.MaHang));

            data.TenHang = p.TenHang;
            data.Dvt = p.Dvt;
            data.Gia = p.Gia;
            context.SaveChanges();
            return Ok();
        }
    }
}
