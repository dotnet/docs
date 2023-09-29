using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IQueryUserClient))]
public interface IQueryUserClient
{
    [Get("/api/users")]
    public Task<List<User>> GetUsersAsync(
        [Query] string search,
        CancellationToken cancellationToken = default);
}
