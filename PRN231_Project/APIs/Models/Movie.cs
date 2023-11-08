using System;
using System.Collections.Generic;

namespace APIs.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string? Title { get; set; }

    public int? DurationMinutes { get; set; }

    public bool? IsReleased { get; set; }

    public string? Urlimages { get; set; }

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
