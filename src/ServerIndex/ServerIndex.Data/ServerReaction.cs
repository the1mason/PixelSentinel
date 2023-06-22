using System;
using System.Collections.Generic;

namespace ServerIndex.Data;

public partial class ServerReaction
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long ServerId { get; set; }

    public long Type { get; set; }

    public virtual Server Server { get; set; } = null!;

    public virtual User? User { get; set; }
}
