// <GetStarted1>
using Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddAzureAISearchVectorStore(new Uri(azureAISearchUri), new AzureKeyCredential(secret));
// </GetStarted1>

// <GetStarted2>
using Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAzureAISearchVectorStore(new Uri(azureAISearchUri), new AzureKeyCredential(secret));
// </GetStarted2>

// <GetStarted3>
using Azure;
using Azure.Search.Documents.Indexes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddSingleton<SearchIndexClient>(
    sp => new SearchIndexClient(
        new Uri(azureAISearchUri),
        new AzureKeyCredential(secret)));
services.AddAzureAISearchVectorStore();
// </GetStarted3>

// <GetStarted4>
using Azure;
using Azure.Search.Documents.Indexes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<SearchIndexClient>(
    sp => new SearchIndexClient(
        new Uri(azureAISearchUri),
        new AzureKeyCredential(secret)));
builder.Services.AddAzureAISearchVectorStore();
// </GetStarted4>

// <GetStarted5>
using Azure;
using Azure.Search.Documents.Indexes;
using Microsoft.SemanticKernel.Connectors.AzureAISearch;

var vectorStore = new AzureAISearchVectorStore(
    new SearchIndexClient(
        new Uri(azureAISearchUri),
        new AzureKeyCredential(secret)));
// </GetStarted5>

// <GetStarted6>
using Azure;
using Azure.Search.Documents.Indexes;
using Microsoft.SemanticKernel.Connectors.AzureAISearch;

var collection = new AzureAISearchCollection<string, Hotel>(
    new SearchIndexClient(new Uri(azureAISearchUri), new AzureKeyCredential(secret)),
    "skhotels");
// </GetStarted6>

// <DataMapping>
var jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper };
var collection = new AzureAISearchCollection<string, Hotel>(
    new SearchIndexClient(
        new Uri(azureAISearchUri),
        new AzureKeyCredential(secret),
        new() { Serializer = new JsonObjectSerializer(jsonSerializerOptions) }),
    "skhotels",
    new() { JsonSerializerOptions = jsonSerializerOptions });
// </DataMapping>