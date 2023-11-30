using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IRouteParameterUserClient), "User Service")]
public interface IRouteParameterUserClient
{
    [Get("/api/users/{userId}")]
    public Task<User> GetUserAsync(
        string userId,
        CancellationToken cancellationToken = default);
}
