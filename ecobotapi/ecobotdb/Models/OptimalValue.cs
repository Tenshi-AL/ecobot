using System;
using System.Collections.Generic;

namespace ecobotdb.Models;

public partial class OptimalValue
{
    public double? BottomBorder { get; set; }

    public double? UpperBorder { get; set; }

    public string? IdCategory { get; set; }

    public string? IdMeasurmentUnit { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual MeasurmentUnit? IdMeasurmentUnitNavigation { get; set; }
}
