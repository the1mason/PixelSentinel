using System;
using System.Collections.Generic;

namespace ServerIndex.Data;

public partial class UserSession
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string SessionToken { get; set; } = null!;

    public string? Displayname { get; set; }

    public long Address { get; set; }

    public virtual Session SessionTokenNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
