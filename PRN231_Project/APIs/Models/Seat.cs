using System;
using System.Collections.Generic;

namespace APIs.Models;

public partial class Seat
{
    public int SeatId { get; set; }

    public int? RoomId { get; set; }

    public bool? Status { get; set; }

    public string? SeatName { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual Room? Room { get; set; }
}
