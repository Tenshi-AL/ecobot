using System;
using System.Collections.Generic;

namespace ecobotdb.Models;

public partial class Station
{
    public string City { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string IdStation { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? IdServer { get; set; }

    public string? IdSaveecobot { get; set; }

    public virtual MqttServer? IdServerNavigation { get; set; }

    public virtual ICollection<Measurment> Measurments { get; set; } = new List<Measurment>();
}
