using ServerIndex.Data;

namespace ServerIndex.Services.Impl;
public class TagService : ITagService
{
    private readonly IndexContext _dbContext;
    public TagService(IndexContext dbContext)
    {
        _dbContext = dbContext;
    }
    public string[] GetValidTagsByNames(string[] tags)
    {
        var result = _dbContext.Tags.Where(x => x.IsVisible == true && tags.Contains(x.Name))
            .Select(x => x.Name)
            .ToArray();
        return result;
    }
}
