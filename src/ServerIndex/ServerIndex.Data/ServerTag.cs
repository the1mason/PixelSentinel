using System;
using System.Collections.Generic;

namespace ServerIndex.Data;

public partial class ServerTag
{
    public long Id { get; set; }

    public long ServerId { get; set; }

    public string TagName { get; set; } = null!;

    public long Order { get; set; }

    public virtual Server Server { get; set; } = null!;
}
