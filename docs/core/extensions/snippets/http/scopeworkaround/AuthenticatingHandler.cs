using System.Security.Claims;

internal class AuthenticatingHandler : DelegatingHandler
{
    private readonly UserContext _userContext;

    public AuthenticatingHandler(IHttpContextAccessor httpContext, UserContext userContext)
    {
        _userContext = userContext;
        _userContext.User = httpContext.HttpContext!.User;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.TryAddWithoutValidation("X-Auth", _userContext.GetCurrentUserName());

        // Emulate server checking auth: this will catch scope mismatch error
        // when ScopeAwareHttpClientFactory isn't used.
        if (!request.RequestUri!.Query.Contains($"userId={_userContext.GetCurrentUserId()}"))
        {
            return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized));
        }

        return base.SendAsync(request, cancellationToken);
    }
}

class UserContext
{
    public static readonly HttpRequestOptionsKey<UserContext> Key = new("userContext");

    public ClaimsPrincipal? User { get; set; }

    public string? GetCurrentUserName() =>
        User?.Identity?.Name;

    public string? GetCurrentUserId() =>
        User?.FindFirstValue(ClaimTypes.NameIdentifier);
}
