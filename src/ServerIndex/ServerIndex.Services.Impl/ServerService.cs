using Microsoft.EntityFrameworkCore;
using ServerIndex.Data;

namespace ServerIndex.Services.Impl;
public class ServerService : IServerService
{
    private readonly IndexContext _dbContext;
    private readonly ITagService _tagService;
    public ServerService(IndexContext dbContext, ITagService tagService)
    {
        _dbContext = dbContext;
        _tagService = tagService;

    }
    public ValueTask<Server> GetServer(long id)
    {
        return _dbContext.Servers.FindAsync(id);
    }

    public IQueryable<Server> GetServers(int skip = 0, int take = 50, string query = null, string gameVersion = null, string[] tags = null)
    {
        IQueryable<Server> servers = _dbContext.Servers;

        if (query is not null)
        {
            query = query.Trim();
            servers = servers.Where(
                x => x.Displayname.Contains(query) ||
                x.ShortDescription.Contains(query) ||
                x.DomainName.Contains(query));
        }

        if (gameVersion is not null)
        {
            gameVersion = gameVersion.Trim();
            servers = servers.Where(x => x.GameVersion == gameVersion);
        }

        var validTags = _tagService.GetValidTagsByNames(tags);

        if (validTags.Length > 0)
        {
            IQueryable<Tag> tagsQuery = _dbContext.Tags.Where(
                x => validTags.Contains(x.Name));

            servers = servers.Where(
                s => tagsQuery.All(
                    st => s.ServerTags.Any(
                        st2 => st2.TagName == st.Name)));
        }

        return servers.Include(x => x.ServerTags).ThenInclude(x => x.Tag).OrderBy(x => x.Score)
            .ThenBy(x => x.PlayerCount)
            .ThenBy(x => x.Version)
            .Skip(skip)
            .Take(take);
    }

    public ICollection<Server> SearchServers(int skip, int take, string query, string gameVersion, string[] tags)
    {
        return GetServers(skip, take, query, gameVersion, tags)
            .Select(s => new Server
            {
                Id = s.Id,
                Displayname = s.Displayname,
                ShortDescription = s.ShortDescription,
                Icon = s.Icon,
                ServerTags = s.ServerTags,
                GameVersion = s.GameVersion,
                Website = s.Website,
                DomainName = s.DomainName,
                Address = s.Address
            }).ToArray();
    }
}
