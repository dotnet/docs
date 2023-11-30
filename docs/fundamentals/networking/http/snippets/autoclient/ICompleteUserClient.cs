using Microsoft.Extensions.Http.AutoClient;

[AutoClient(nameof(ICompleteUserClient))]
[StaticHeader("User-Agent", "dotnet-auto-client sample")]
public interface ICompleteUserClient
{
    [Get("users")]
    public Task<User[]> GetAllUsersAsync(
        CancellationToken cancellationToken = default);

    [Get("users")]
    public Task<User[]> GetUserByNameAsync(
        [Query] string name,
        CancellationToken cancellationToken = default);

    [Get("users/{userId}")]
    public Task<User> GetUserByIdAsync(
        int userId,
        CancellationToken cancellationToken = default);

    [Post("users")]
    [StaticHeader("X-CustomHeader", "custom-value")]
    public Task<HttpResponseMessage> CreateUserAsync(
        [Body(BodyContentType.ApplicationJson)] User user,
        CancellationToken cancellationToken = default);

    [Delete("user/{userId}")]
    public Task<User> DeleteUserAsync(
        int userId,
        [Header("If-None-Match")] string eTag,
        CancellationToken cancellationToken = default);
}

