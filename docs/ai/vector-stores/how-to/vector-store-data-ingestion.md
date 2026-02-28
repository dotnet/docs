---
title: How to ingest data into a Vector Store
description: Step by step instructions on how to ingest data into a Vector Store.
ms.topic: tutorial
ms.date: 07/08/2024
---
# How to ingest data into a Vector Store

This article demonstrates how to create an application to:

1. Take text from each paragraph in a Microsoft Word document.
2. Generate an embedding for each paragraph.
3. Upsert the text, embedding, and a reference to the original location into a Redis instance.

## Prerequisites

For this sample you need:

- An embedding generation model hosted in Azure or another provider of your choice.
- An instance of Redis or Docker Desktop so that you can run Redis locally.
- A Word document to parse and load. Here is a zip containing a sample Word document you can download and use: [vector-store-data-ingestion-input.zip](../../../media/vector-store-data-ingestion-input.zip).

## Set up Redis

If you already have a Redis instance, you can use that. If you prefer to test your project locally,
you can easily start a Redis container using Docker:

```docker
docker run -d --name redis-stack -p 6379:6379 -p 8001:8001 redis/redis-stack:latest
```

To verify that it's running successfully, navigate to [http://localhost:8001/redis-stack/browser](http://localhost:8001/redis-stack/browser) in your browser.

The rest of these instructions assume that you're using a container with these settings.

## Create your project

Create a new project and add NuGet package references for the Redis connector, the OpenXml package to read the Word document, and the Azure OpenAI packages for generating embeddings.

```dotnetcli
dotnet new console --framework net8.0 --name SKVectorIngest
cd SKVectorIngest
dotnet add package Azure.AI.OpenAI
dotnet add package Microsoft.Extensions.AI.OpenAI
dotnet add package Microsoft.SemanticKernel.Connectors.Redis --prerelease
dotnet add package DocumentFormat.OpenXml
```

## Add a data model

To upload data, you must first describe what format the data should have in the database.
You can do this by creating a data model with attributes that describe the function of each property.

Add a new file to the project called `TextParagraph.cs` and add the following model to it.

```csharp
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
```

The value `1536`, which is the dimension size of the vector, is passed to the <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute>. This value must match the size of vector that your chosen embedding generator produces.

> [!TIP]
> For more information on how to annotate your data model and what additional options are available for each attribute, see [defining your data model](../../../concepts/vector-store-connectors/defining-your-data-model.md).

## Read the paragraphs in the document

Next, you add the code to read the Word document and find the text of each paragraph in it.

Add a new file to the project called `DocumentReader.cs` and add the following class to read the paragraphs from a document.

```csharp
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
```

## Generate embeddings and upload the data

Next, you add a new class to generate embeddings and upload the paragraphs to Redis.

Add a new file called `DataUploader.cs` with the following contents:

```csharp
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
```

## Put it all together

Finally, you put together the different pieces.
In this example, you use standard .NET dependency injection to register the Redis vector store and the embedding generator.

Add the following code to your `Program.cs` file to set up the container, register the Redis vector store, and register the embedding service. Replace the text embedding generation settings with your own values.

```csharp
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
```

Lastly, add code to read the paragraphs from the Word document and call the data uploader
to generate the embeddings and upload the paragraphs.

```csharp
// Load the data.
var textParagraphs = DocumentReader.ReadParagraphs(
    new FileStream(
        "vector-store-data-ingestion-input.docx",
        FileMode.Open),
    "file:///c:/vector-store-data-ingestion-input.docx");

await dataUploader.GenerateEmbeddingsAndUpload(
    "sk-documentation",
    textParagraphs);
```

## See your data in Redis

Navigate to the Redis stack browser, for example, [http://localhost:8001/redis-stack/browser](http://localhost:8001/redis-stack/browser), where you should now be able to see
your uploaded paragraphs. Following is an example of what you should see for one of the uploaded paragraphs.

```json
{
    "DocumentUri" : "file:///c:/vector-store-data-ingestion-input.docx",
    "ParagraphId" : "14CA7304",
    "Text" : "Version 1.0+ support across C#, Python, and Java means it’s reliable, committed to non breaking changes. Any existing chat-based APIs are easily expanded to support additional modalities like voice and video.",
    "TextEmbedding" : [...]
}
```