using System;
using System.Collections.Generic;

namespace TripPlanner_1.Models;

public partial class Userhotelbooking
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Hotelid { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public virtual required User User { get; set; }

    public virtual required Hotel Hotel { get; set; }

    
}
