using System;
using System.Collections.Generic;

namespace TripPlanner_1.Models;

public partial class Holidaydestinationtransport
{
    public int Id { get; set; }

    public int Destinationid { get; set; }

    public int Transportid { get; set; }

    public virtual Holidaydestination Destination { get; set; } = null!;

    public virtual Transport Transport { get; set; } = null!;
}
