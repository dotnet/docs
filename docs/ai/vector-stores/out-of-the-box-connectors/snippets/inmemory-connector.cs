// <GetStarted1>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddInMemoryVectorStore();
// </GetStarted1>

// <GetStarted2>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInMemoryVectorStore();
// </GetStarted2>

// <GetStarted3>
using Microsoft.SemanticKernel.Connectors.InMemory;

var vectorStore = new InMemoryVectorStore();
// </GetStarted3>

// <GetStarted4>
using Microsoft.SemanticKernel.Connectors.InMemory;

var collection = new InMemoryCollection<string, Hotel>("skhotels");
// </GetStarted4>