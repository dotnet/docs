using System.Security.Claims;

var random = new Random();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<UserContext>();

builder.Services.AddHttpClient("backend")
    .AddScopeAwareHttpHandler<AuthenticatingHandler>();

var app = builder.Build();

app.Use((context, next) =>
{
    // Pretend the incoming request has a random user
    context.User = MakeRandomUser()!;

    var userContext = context.RequestServices.GetRequiredService<UserContext>();
    userContext.User = context.User;
    return next(context);
});

ClaimsPrincipal? MakeRandomUser()
{
    var id = random.Next(1, 11).ToString();
    var name = Guid.NewGuid().ToString();
    var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, name), new Claim(ClaimTypes.NameIdentifier, id) }, "CustomAuth"));
    return user;
}

app.MapGet("/", async (IHttpClientFactory c, UserContext context) =>
{
    var client = c.CreateClient("backend");
    var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/todos?userId={context.GetCurrentUserId()}");
    response.EnsureSuccessStatusCode();

    return Results.Stream(await response.Content.ReadAsStreamAsync(), response.Content.Headers.ContentType!.ToString());
});

app.Run();
