using ServerIndex.DTO.Tags;

namespace ServerIndex.DTO.Servers;
public class ServerShortDTO
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string ShortDescription { get; set; }

    public byte[] Icon { get; set; }

    public IEnumerable<TagShortDto> Tags { get; set; }

    public string GameVersion { get; set; }
    public string Website { get; set; }
    public string DomainName { get; set; }
    public long Address { get; set; }
    public ServerShortDTO(long id, string name, string shortDescription, byte[] icon, IEnumerable<TagShortDto> tags, string gameVersion, string website, string domainName, long address)
    {
        Id = id;
        Name = name;
        ShortDescription = shortDescription;
        Icon = icon;
        Tags = tags;
        GameVersion = gameVersion;
        Website = website;
        DomainName = domainName;
        Address = address;
    }
}
