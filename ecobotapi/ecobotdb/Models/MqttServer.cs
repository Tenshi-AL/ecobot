using System;
using System.Collections.Generic;

namespace ecobotdb.Models;

public partial class MqttServer
{
    public string Url { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string IdServer { get; set; } = null!;

    public virtual ICollection<Station> Stations { get; set; } = new List<Station>();
}
