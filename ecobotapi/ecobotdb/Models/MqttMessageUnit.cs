using System;
using System.Collections.Generic;

namespace ecobotdb.Models;

public partial class MqttMessageUnit
{
    public string IdStation { get; set; } = null!;

    public string IdMeasuredUnit { get; set; } = null!;

    public string Message { get; set; } = null!;

    public decimal QueueNumber { get; set; }

    public virtual MeasurmentUnit IdMeasuredUnitNavigation { get; set; } = null!;

    public virtual Station IdStationNavigation { get; set; } = null!;
}
