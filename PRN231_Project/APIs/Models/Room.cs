using System;
using System.Collections.Generic;

namespace APIs.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string? RoomName { get; set; }

    public int? NumberOfSeats { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
