namespace APIs.Models
{
    public class BillsDTO
    {
        public int BillId { get; set; }

        public string? Username { get; set; }

        public string? Title { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int? RoomId { get; set; }

        public string? SeatName { get; set; }

        public decimal? Prices { get; set; }
    }
}
