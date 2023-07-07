namespace ServerIndex.Data;
public partial class Modifier
{
    public int Id { get; set; }

    public short? DefaultValue { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<ServerModifier> ServerModifiers { get; set; } = new List<ServerModifier>();
}