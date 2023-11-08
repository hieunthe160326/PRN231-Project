using System;
using System.Collections.Generic;

namespace APIs.Models;

public partial class Show
{
    public int ShowId { get; set; }

    public int? MovieId { get; set; }

    public decimal? Prices { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? RoomId { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual Movie? Movie { get; set; }

    public virtual Room? Room { get; set; }
}
