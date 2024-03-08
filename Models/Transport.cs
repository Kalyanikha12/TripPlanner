using System;
using System.Collections.Generic;

namespace TripPlanner_1.Models;

public partial class Transport
{
    public int Transportid { get; set; }

    public string Modeoftransport { get; set; } = null!;

    public decimal Cost { get; set; }

    public virtual ICollection<Holidaydestinationtransport> Holidaydestinationtransports { get; set; } = new List<Holidaydestinationtransport>();

    public virtual ICollection<Usertransport> Usertransports { get; set; } = new List<Usertransport>();
}
