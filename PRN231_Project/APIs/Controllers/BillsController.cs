using APIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly Prn231projectContext context;

        public BillsController(Prn231projectContext context)
        {
            this.context = context;
        }

        [HttpGet("GetAllBills")]
        public IActionResult GetAllBills()
        {
            var res = context.Bills.Include(a => a.Seat).Include(a => a.User).Include(a => a.Show).ThenInclude(a => a.Movie).ToList();
            if(res == null)
            {
                return NotFound();
            }
            var result = res.Select(a => new BillsDTO()
            {
                BillId = a.BillId,
                Username = a.User.Username,
                Title = a.Show.Movie.Title,
                StartTime = a.Show.StartTime,
                EndTime = a.Show.EndTime,
                RoomId = a.Show.RoomId,
                SeatName = a.Seat.SeatName,
                Prices = a.Show.Prices,
            });
            return Ok(result);
        }
    }
}
