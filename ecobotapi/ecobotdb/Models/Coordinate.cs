using System;
using System.Collections.Generic;

namespace ecobotdb.Models;

public partial class Coordinate
{
    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string IdStation { get; set; } = null!;

    public virtual Station IdStationNavigation { get; set; } = null!;
}
