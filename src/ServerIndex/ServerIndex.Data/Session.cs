using System;
using System.Collections.Generic;

namespace ServerIndex.Data;

public partial class Session
{
    public string Token { get; set; } = null!;

    public DateTime Version { get; set; }

    public bool Revoked { get; set; }

    public virtual ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();
}
