namespace ServerIndex.DTO.Tags;
public class TagShortDto
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Data { get; set; }
    public long Order { get; set; }
    public TagShortDto(string name, string displayName, string data, long order)
    {
        Name = name;
        DisplayName = displayName;
        Data = data;
        Order = order;
    }
}
