using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IStaticHeaderUserClient), "User Service")]
[StaticHeader("X-ForAllRequests", "GlobalHeaderValue")]
public interface IStaticHeaderUserClient
{
    [Get("/api/users")]
    [StaticHeader("X-ForJustThisRequest", "RequestHeaderValue")]
    public Task<List<User>> GetUsersAsync(
        CancellationToken cancellationToken = default);
}
