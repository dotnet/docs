using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// DefaultAzureCredential attempts several auth flows in order until one is available
// For example, will discover Visual Studio or Azure CLI credentials
// in local environments and managed identity credentials in production deployments
var credential = new DefaultAzureCredential(
    new DefaultAzureCredentialOptions
    {
        // If necessary, specify the tenant ID,
        // user-assigned identity client or resource ID, or other options
    }
);

// Retrieve the Azure OpenAI endpoint and deployment name
string endpoint = builder.Configuration["AZURE_OPENAI_ENDPOINT"];
string deployment = builder.Configuration["AZURE_OPENAI_GPT_NAME"];

builder.Services.AddChatClient(
    new AzureOpenAIClient(new Uri(endpoint), credential)
    .AsChatClient(deployment));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/test-prompt", async (IChatClient chatClient) =>
{
    return await chatClient.GetResponseAsync("Test prompt", new ChatOptions());
})
.WithName("Test prompt");

app.Run();
