// <AddADataModel>
using Microsoft.Extensions.VectorData;

namespace SKVectorIngest;

internal class TextParagraph
{
    /// <summary>A unique key for the text paragraph.</summary>
    [VectorStoreKey]
    public required string Key { get; init; }

    /// <summary>A uri that points at the original location of the document containing the text.</summary>
    [VectorStoreData]
    public required string DocumentUri { get; init; }

    /// <summary>The id of the paragraph from the document containing the text.</summary>
    [VectorStoreData]
    public required string ParagraphId { get; init; }

    /// <summary>The text of the paragraph.</summary>
    [VectorStoreData]
    public required string Text { get; init; }

    /// <summary>The embedding generated from the Text.</summary>
    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> TextEmbedding { get; set; }
}
// </AddADataModel>

// <ReadTheParagraphsInTheDocument>
using System.Text;
using System.Xml;
using DocumentFormat.OpenXml.Packaging;

namespace SKVectorIngest;

internal class DocumentReader
{
    public static IEnumerable<TextParagraph> ReadParagraphs(Stream documentContents, string documentUri)
    {
        // Open the document.
        using WordprocessingDocument wordDoc = WordprocessingDocument.Open(documentContents, false);
        if (wordDoc.MainDocumentPart == null)
        {
            yield break;
        }

        // Create an XmlDocument to hold the document contents
        // and load the document contents into the XmlDocument.
        XmlDocument xmlDoc = new();
        XmlNamespaceManager nsManager = new(xmlDoc.NameTable);
        nsManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
        nsManager.AddNamespace("w14", "http://schemas.microsoft.com/office/word/2010/wordml");

        xmlDoc.Load(wordDoc.MainDocumentPart.GetStream());

        // Select all paragraphs in the document and break if none found.
        XmlNodeList? paragraphs = xmlDoc.SelectNodes("//w:p", nsManager);
        if (paragraphs == null)
        {
            yield break;
        }

        // Iterate over each paragraph.
        foreach (XmlNode paragraph in paragraphs)
        {
            // Select all text nodes in the paragraph and continue if none found.
            XmlNodeList? texts = paragraph.SelectNodes(".//w:t", nsManager);
            if (texts == null)
            {
                continue;
            }

            // Combine all non-empty text nodes into a single string.
            var textBuilder = new StringBuilder();
            foreach (XmlNode text in texts)
            {
                if (!string.IsNullOrWhiteSpace(text.InnerText))
                {
                    textBuilder.Append(text.InnerText);
                }
            }

            // Yield a new TextParagraph if the combined text is not empty.
            var combinedText = textBuilder.ToString();
            if (!string.IsNullOrWhiteSpace(combinedText))
            {
                Console.WriteLine("Found paragraph:");
                Console.WriteLine(combinedText);
                Console.WriteLine();

                yield return new TextParagraph
                {
                    Key = Guid.NewGuid().ToString(),
                    DocumentUri = documentUri,
                    ParagraphId = paragraph.Attributes?["w14:paraId"]?.Value ?? string.Empty,
                    Text = combinedText
                };
            }
        }
    }
}
// </ReadTheParagraphsInTheDocument>

// <GenerateEmbeddingsAndUploadTheData>
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;

namespace SKVectorIngest;

internal class DataUploader(VectorStore vectorStore, IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator)
{
    /// <summary>
    /// Generate an embedding for each text paragraph and upload it to the specified collection.
    /// </summary>
    /// <param name="collectionName">The name of the collection to upload the text paragraphs to.</param>
    /// <param name="textParagraphs">The text paragraphs to upload.</param>
    /// <returns>An async task.</returns>
    public async Task GenerateEmbeddingsAndUpload(string collectionName, IEnumerable<TextParagraph> textParagraphs)
    {
        var collection = vectorStore.GetCollection<string, TextParagraph>(collectionName);
        await collection.EnsureCollectionExistsAsync();

        foreach (var paragraph in textParagraphs)
        {
            // Generate the text embedding.
            Console.WriteLine($"Generating embedding for paragraph: {paragraph.ParagraphId}");
            paragraph.TextEmbedding = (await embeddingGenerator.GenerateEmbeddingAsync(paragraph.Text)).Vector;

            // Upload the text paragraph.
            Console.WriteLine($"Upserting paragraph: {paragraph.ParagraphId}");
            await collection.UpsertAsync(paragraph);

            Console.WriteLine();
        }
    }
}
// </GenerateEmbeddingsAndUploadTheData>

// <PutItAllTogether1>
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.Redis;
using SKVectorIngest;

// Replace with your values.
var deploymentName = "text-embedding-ada-002";
var endpoint = "https://sksample.openai.azure.com/";
var apiKey = "your-api-key";

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
var serviceProvider = services.BuildServiceProvider();
var dataUploader = serviceProvider.GetRequiredService<DataUploader>();
// </PutItAllTogether1>

// <PutItAllTogether2>
// Load the data.
var textParagraphs = DocumentReader.ReadParagraphs(
    new FileStream(
        "vector-store-data-ingestion-input.docx",
        FileMode.Open),
    "file:///c:/vector-store-data-ingestion-input.docx");

await dataUploader.GenerateEmbeddingsAndUpload(
    "sk-documentation",
    textParagraphs);
// </PutItAllTogether2>