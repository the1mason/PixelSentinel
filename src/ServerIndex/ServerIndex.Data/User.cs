using System;
using System.Collections.Generic;

namespace ServerIndex.Data;

public partial class User
{
    public long Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? DsplayName { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<ServerReaction> ServerReactions { get; set; } = new List<ServerReaction>();

    public virtual ICollection<UserServer> UserServers { get; set; } = new List<UserServer>();

    public virtual ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();
}
