using System;
using System.Collections.Generic;

namespace ecobotdb.Models;

public partial class MeasurmentUnit
{
    public string Title { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public string IdMeasurmentUnit { get; set; } = null!;

    public virtual ICollection<Measurment> Measurments { get; set; } = new List<Measurment>();
}
