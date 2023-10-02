using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(IPayloadUserClient), "User Service")]
public interface IPayloadUserClient
{
    [Post("/api/users")]
    public Task<User> CreateUserAsync(
        // The content type is JSON
        // The parameter is serialized before sending
        [Body] User user,
        CancellationToken cancellationToken = default);

    [Put("/api/users/{userId}/displayName")]
    public Task<User> UpdateDisplayNameAsync(
        string userId,
        // The content type is text/plain
        // The parameter is sent as is
        [Body(BodyContentType.TextPlain)] string displayName,
        CancellationToken cancellationToken = default);
}
