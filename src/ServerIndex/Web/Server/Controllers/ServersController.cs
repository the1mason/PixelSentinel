using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerIndex.DTO.Servers;
using ServerIndex.DTO.Tags;
using ServerIndex.Services;

namespace ServerIndex.Web.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServersController : ControllerBase
{
    private readonly IServerService _serverService;
    public ServersController(IServerService serverService)
    {
        _serverService = serverService;
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetServer(long id)
    {
        return ":)";
    }

    [HttpGet()]
    public ActionResult<ServerShortDTO[]> GetServers(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50,
        [FromQuery] string v = null,
        [FromQuery] string q = null,
        [FromQuery] string[] t = null)
    {
        if (skip < 0)
            return BadRequest("skip should be greater than 0");

        if (take < 10 || take > 100)
            return BadRequest("Take should be between 10 and 100");

        if (string.IsNullOrWhiteSpace(q))
            q = null;

        if(string.IsNullOrWhiteSpace(v))
            v = null;

        var servers = _serverService.SearchServers(skip, take, q, v, t);
        return servers.Select(x =>
            new ServerShortDTO(
                x.Id, x.Displayname,
                x.ShortDescription,
                x.Icon,
                x.ServerTags.Select(
                    x => new TagShortDto(x.Tag.Name, x.Tag.DisplayName, x.Tag.Data, x.Order)
                    ),
                x.GameVersion,
                x.Website,
                x.DomainName,
                x.Address)
        ).ToArray();
    }
}
