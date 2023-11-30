using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(ICustomQueryUserClient))]
public interface ICustomQueryUserClient
{
    [Get("/api/users")]
    public Task<List<User>> GetUsersAsync(
        [Query("customQueryKey")] string search,
        CancellationToken cancellationToken = default);
}
