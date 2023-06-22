using System;
using System.Collections.Generic;

namespace ServerIndex.Data;

public partial class AnalyticServer
{
    public long Id { get; set; }

    public long Type { get; set; }

    public string? Data { get; set; }

    public long ServerId { get; set; }

    public virtual Server Server { get; set; } = null!;
}
