using System;
using System.Collections.Generic;

namespace APIs.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int? SeatId { get; set; }

    public int? UserId { get; set; }

    public int? ShowId { get; set; }

    public virtual Seat? Seat { get; set; }

    public virtual Show? Show { get; set; }

    public virtual User? User { get; set; }
}
