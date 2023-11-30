using Microsoft.Extensions.Http.AutoClient;

[AutoClient("GeneratedClient")]
public interface IUserClient
{
    [Get("/api/users")]
    public Task<User[]> GetUsersAsync(
        CancellationToken cancellationToken = default);
}
