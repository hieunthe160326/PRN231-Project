using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly Prn231projectContext context;

        public CustomersController(Prn231projectContext context)
        {
            this.context = context;
        }

        [HttpGet("GetCustomernNameList")]
        public IActionResult GetCustomerNameList()
        {
            var res = context.TblKhachHangs.Where(a => a.Active == true).Select(a => a.TenKh).ToList();
            return Ok(res);
        }

        [HttpGet("GetCustomerList")]
        public IActionResult GetCustomerList()
        {
            var res = context.TblKhachHangs.Where(a => a.Active == true).ToList();
            return Ok(res);
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(TblKhachHang c)
        {
            try
            {
                context.TblKhachHangs.Add(c);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Can't add Customer");
            }
        }


        [HttpGet("DisableCustomer/{id}")]
        public IActionResult DisableCustomer(string id)
        {
            TblKhachHang c = context.TblKhachHangs.FirstOrDefault(a => a.MakH.Equals(id));
            if (c != null)
            {
                c.Active = false;
                context.SaveChanges();
                return Ok(c);
            }
            else
            {
                return BadRequest("Can't disable Customer");
            }
        }

        [HttpPut("UpdateCustomer/{id}")]
        public IActionResult UpdateCustomer(TblKhachHang c)
        {
            context.TblKhachHangs.Update(c);
            context.SaveChanges();
            return Ok();
        }
    }
}
