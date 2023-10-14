using System;
using System.Collections.Generic;

namespace ecobotdb.Models;

public partial class Measurment
{
    public string Value { get; set; } = null!;

    public string IdMeasurment { get; set; } = null!;

    public string IdStation { get; set; } = null!;

    public string IdMeasuredUnit { get; set; } = null!;

    public string? CompressionLevel { get; set; }

    public DateTime? Time { get; set; }

    public virtual MeasurmentUnit IdMeasuredUnitNavigation { get; set; } = null!;

    public virtual Station IdStationNavigation { get; set; } = null!;
}
