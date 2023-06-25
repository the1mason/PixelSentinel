using System;
using System.Collections.Generic;

namespace ServerIndex.Data;

public partial class MasScanHistory
{
    public long Id { get; set; }

    public string Range { get; set; } = null!;

    public bool StartedServing { get; set; }

    public bool Served { get; set; }

    public DateTime Date { get; set; }
}
