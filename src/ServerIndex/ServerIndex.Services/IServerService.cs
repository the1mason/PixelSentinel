using ServerIndex.Data;

namespace ServerIndex.Services;
public interface IServerService
{
    ValueTask<Server> GetServer(long id);
    IQueryable<Server> GetServers(int skip, int take, string query, string gameVersion, string[] tags);
    ICollection<Server> SearchServers(int skip, int take, string query, string gameVersion, string[] tags);
}
