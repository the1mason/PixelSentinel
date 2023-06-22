using System;
using System.Collections.Generic;

namespace ServerIndex.Data;

public partial class Tag
{
    public string Name { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string? Data { get; set; }

    public bool IsVisible { get; set; }
}
