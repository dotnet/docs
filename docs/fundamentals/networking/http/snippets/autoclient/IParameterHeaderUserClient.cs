using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IParameterHeaderUserClient), "User Service")]
public interface IParameterHeaderUserClient
{
    [Get("/api/users")]
    public Task<List<User>> GetUsersAsync(
        [Header("X-MyHeader")] string myHeader,
        CancellationToken cancellationToken = default);
}
