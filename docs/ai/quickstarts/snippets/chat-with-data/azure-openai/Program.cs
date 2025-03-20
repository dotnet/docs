using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.InMemory;
using VectorDataAI;

var cloudServices = new List<CloudService>()
{
    new CloudService
        {
            Key=0,
            Name="Azure App Service",
            Description="Host .NET, Java, Node.js, and Python web applications and APIs in a fully managed Azure service. You only need to deploy your code to Azure. Azure takes care of all the infrastructure management like high availability, load balancing, and autoscaling."
        },
    new CloudService
        {
            Key=1,
            Name="Azure Service Bus",
            Description="A fully managed enterprise message broker supporting both point to point and publish-subscribe integrations. It's ideal for building decoupled applications, queue-based load leveling, or facilitating communication between microservices."
        },
    new CloudService
        {
            Key=2,
            Name="Azure Blob Storage",
            Description="Azure Blob Storage allows your applications to store and retrieve files in the cloud. Azure Storage is highly scalable to store massive amounts of data and data is stored redundantly to ensure high availability."
        },
    new CloudService
        {
            Key=3,
            Name="Microsoft Entra ID",
            Description="Manage user identities and control access to your apps, data, and resources.."
        },
    new CloudService
        {
            Key=4,
            Name="Azure Key Vault",
            Description="Store and access application secrets like connection strings and API keys in an encrypted vault with restricted access to make sure your secrets and your application aren't compromised."
        },
    new CloudService
        {
            Key=5,
            Name="Azure AI Search",
            Description="Information retrieval at scale for traditional and conversational search applications, with security and options for AI enrichment and vectorization."
        }
};

// Load the configuration values
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string model = config["AZURE_OPENAI_GPT_NAME"];

// Create the embedding generator
IEmbeddingGenerator<string, Embedding<float>> generator =
    new AzureOpenAIClient(
        new Uri(endpoint),
        new DefaultAzureCredential())
            .AsEmbeddingGenerator(modelId: model);

// Create and populate the vector store
var vectorStore = new InMemoryVectorStore();
Microsoft.Extensions.VectorData.IVectorStoreRecordCollection<int, CloudService> cloudServicesStore = vectorStore.GetCollection<int, CloudService>("cloudServices");
await cloudServicesStore.CreateCollectionIfNotExistsAsync();

foreach (CloudService service in cloudServices)
{
    service.Vector = await generator.GenerateEmbeddingVectorAsync(service.Description);
    await cloudServicesStore.UpsertAsync(service);
}

// Convert a search query to a vector and search the vector store
string query = "Which Azure service should I use to store my Word documents?";
ReadOnlyMemory<float> queryEmbedding = await generator.GenerateEmbeddingVectorAsync(query);

VectorSearchResults<CloudService> results =
    await cloudServicesStore.VectorizedSearchAsync(queryEmbedding, new VectorSearchOptions<CloudService>()
{
    Top = 1
});

await foreach (VectorSearchResult<CloudService> result in results.Results)
{
    Console.WriteLine($"Name: {result.Record.Name}");
    Console.WriteLine($"Description: {result.Record.Description}");
    Console.WriteLine($"Vector match score: {result.Score}");
    Console.WriteLine();
}
