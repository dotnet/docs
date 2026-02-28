// <GetStarted1>
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var kernelBuilder = Kernel
    .CreateBuilder()
    .AddVolatileVectorStore();
// </GetStarted1>

// <GetStarted2>
using Microsoft.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddVolatileVectorStore();
// </GetStarted2>

// <GetStarted3>
using Microsoft.SemanticKernel.Data;

var vectorStore = new VolatileVectorStore();
// </GetStarted3>

// <GetStarted4>
using Microsoft.SemanticKernel.Data;

var collection = new VolatileVectorStoreRecordCollection<string, Hotel>("skhotels");
// </GetStarted4>