using System;
using System.Collections.Generic;

namespace TripPlanner_1.Models;

public partial class Hotel
{
    public int Hotelid { get; set; }

    public string Hotelname { get; set; } = null!;

    public decimal Pricepernight { get; set; }

    public string? Hotelimage { get; set; }

    public string? Discription { get; set; }

    public int Destinationid { get; set; }

    public virtual Holidaydestination Destination { get; set; } = null!;

    public virtual ICollection<Userhotelbooking> Userhotelbookings { get; set; } = new List<Userhotelbooking>();
}
