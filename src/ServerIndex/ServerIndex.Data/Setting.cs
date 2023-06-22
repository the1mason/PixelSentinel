using System;
using System.Collections.Generic;

namespace ServerIndex.Data;

public partial class Setting
{
    public string Key { get; set; } = null!;

    public string? Value { get; set; }

    public DateTime Version { get; set; }
}
