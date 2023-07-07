
namespace ServerIndex.Services;
public interface ITagService
{
    /// <summary>
    /// Validating tags by checking whether they exist in the database.
    /// </summary>
    /// <param name="tags">An array with tag's names</param>
    /// <returns>An array with valid tag's names</returns>
    public string[] GetValidTagsByNames(string[] tags);
}
