namespace ServerIndex.Data;
public partial class ServerModifier
{
    public long Id { get; set; }

    public long ServerId { get; set; }

    public int ModifierId { get; set; }

    public short Value { get; set; }

    public virtual Modifier Modifier { get; set; } = null!;

    public virtual Server Server { get; set; } = null!;
}

