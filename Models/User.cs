using System;
using System.Collections.Generic;

namespace TripPlanner_1.Models;

public partial class User
{
    public int Userid { get; set; }

    public string Name { get; set; } = null!;

    public string Useremail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Mobileno { get; set; } = null!;

    public virtual ICollection<Userhotelbooking> Userhotelbookings { get; set; } = new List<Userhotelbooking>();

    public virtual ICollection<Usertransport> Usertransports { get; set; } = new List<Usertransport>();
}
