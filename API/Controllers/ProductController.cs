﻿using API.Models;
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
    }
}