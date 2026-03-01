using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.Redis;
using VectorIngest;

public class PutItAllTogether
{
    public static async Task Main()
    {
        // <PutItAllTogether1>
        // Replace with your values.
        string deploymentName = "text-embedding-ada-002";
        string endpoint = "https://sksample.openai.azure.com/";
        string apiKey = "your-api-key";

        // Register Azure OpenAI embedding generator and Redis vector store.
        var services = new ServiceCollection();
        services.AddSingleton<IEmbeddingGenerator<string, Embedding<float>>>(
            new AzureOpenAIClient(new Uri(endpoint), new AzureKeyCredential(apiKey))
                .GetEmbeddingClient(deploymentName)
                .AsIEmbeddingGenerator());

        services.AddRedisVectorStore("localhost:6379");

        // Register the data uploader.
        services.AddSingleton<DataUploader>();

        // Build the service provider and get the data uploader.
        ServiceProvider serviceProvider = services.BuildServiceProvider();
        DataUploader dataUploader = serviceProvider.GetRequiredService<DataUploader>();
        // </PutItAllTogether1>

        // <PutItAllTogether2>
        // Load the data.
        IEnumerable<TextParagraph> textParagraphs = DocumentReader.ReadParagraphs(
            new FileStream(
                "vector-store-data-ingestion-input.docx",
                FileMode.Open),
            "file:///c:/vector-store-data-ingestion-input.docx");

        await dataUploader.GenerateEmbeddingsAndUpload(
            "sk-documentation",
            textParagraphs);

        // </PutItAllTogether2>
    }
}
