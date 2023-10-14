using System;
using System.Collections.Generic;

namespace ecobotdb.Models;

public partial class FavoriteStation
{
    public string? IdUser { get; set; }

    public string IdStation { get; set; } = null!;

    public virtual Station IdStationNavigation { get; set; } = null!;
}
