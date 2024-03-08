using System;
using System.Collections.Generic;

namespace TripPlanner_1.Models;

public partial class Usertransport
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Transportid { get; set; }

    public virtual Transport Transport { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
