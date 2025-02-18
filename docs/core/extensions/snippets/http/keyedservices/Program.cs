var builder = WebApplication.CreateBuilder(args);

// --- (1) Registration ---
builder.Services.AddHttpClient("github", c =>
    {
        c.BaseAddress = new Uri("https://api.github.com/");
        c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
        c.DefaultRequestHeaders.Add("User-Agent", "dotnet");
    })
    .AddAsKeyed(); // Add HttpClient as a Keyed Scoped service for key="github"

var app = builder.Build();

// --- (2) Obtaining HttpClient instance ---
// Directly inject the Keyed HttpClient by its name
app.MapGet("/", ([FromKeyedServices("github")] HttpClient httpClient) =>
    // --- (3) Using HttpClient instance ---
    httpClient.GetFromJsonAsync<Repo>("/repos/dotnet/runtime"));

app.Run();

record Repo(string Name, string Url);
