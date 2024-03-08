using System;
using System.Collections.Generic;

namespace TripPlanner_1.Models;

public partial class Holidaydestination
{
    public int Destinationid { get; set; }

    public string DestinationName { get; set; } = null!;

    public string? Image { get; set; }

    public string? Discription { get; set; }

    public virtual ICollection<Holidaydestinationtransport> Holidaydestinationtransports { get; set; } = new List<Holidaydestinationtransport>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
