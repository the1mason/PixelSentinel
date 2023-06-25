using System;
using System.Collections.Generic;

namespace ServerIndex.Data;

public partial class Server
{
    public long Id { get; set; }

    public string? Displayname { get; set; }

    public DateTime Version { get; set; }

    public byte[]? Icon { get; set; }

    public string? ShortDescription { get; set; }

    public string? LongDescription { get; set; }

    public int? PlayerCount { get; set; }

    public long Address { get; set; }

    public string? DomainName { get; set; }

    public string? GameVersion { get; set; }

    public string? Website { get; set; }

    public string? LastMetadata { get; set; }
    public int Score { get; set; }

    public virtual ICollection<AnalyticServer> AnalyticServers { get; set; } = new List<AnalyticServer>();

    public virtual ICollection<ServerReaction> ServerReactions { get; set; } = new List<ServerReaction>();

    public virtual ICollection<ServerTag> ServerTags { get; set; } = new List<ServerTag>();

    public virtual ICollection<UserServer> UserServers { get; set; } = new List<UserServer>();
}
