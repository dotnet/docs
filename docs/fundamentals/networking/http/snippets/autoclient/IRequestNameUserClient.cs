using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IRequestNameUserClient), "User Service")]
public interface IRequestNameUserClient
{
    [Get("/api/users", RequestName = "CustomRequestName")]
    public Task<List<User>> GetUsersAsync(
        CancellationToken cancellationToken = default);
}
