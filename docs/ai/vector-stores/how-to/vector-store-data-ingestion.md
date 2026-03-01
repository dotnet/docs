---
title: How to ingest data into a Vector Store
description: Step by step instructions on how to ingest data into a Vector Store.
ms.topic: tutorial
ms.date: 02/28/2026
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
- A Word document to parse and load.

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

:::code language="csharp" source="./snippets/conceptual/DataIngestion.cs" id="AddADataModel":::

The value `1536`, which is the dimension size of the vector, is passed to the <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute>. This value must match the size of vector that your chosen embedding generator produces.

> [!TIP]
> For more information on how to annotate your data model and what additional options are available for each attribute, see [defining your data model](../defining-your-data-model.md).

## Read the paragraphs in the document

Next, you add the code to read the Word document and find the text of each paragraph in it.

Add a new file to the project called `DocumentReader.cs` and add the following class to read the paragraphs from a document.

:::code language="csharp" source="./snippets/conceptual/DataIngestion.cs" id="ReadTheParagraphsInTheDocument":::

## Generate embeddings and upload the data

Next, you add a new class to generate embeddings and upload the paragraphs to Redis.

Add a new file called `DataUploader.cs` with the following contents:

:::code language="csharp" source="./snippets/conceptual/DataIngestion.cs" id="GenerateEmbeddingsAndUploadTheData":::

## Put it all together

Finally, you put together the different pieces. In this example, you use standard .NET dependency injection to register the Redis vector store and the embedding generator.

Add the following code to your `Program.cs` file to set up the container, register the Redis vector store, and register the embedding service. Replace the text embedding generation settings with your own values.

:::code language="csharp" source="./snippets/conceptual/DataIngestion.cs" id="PutItAllTogether1":::

Lastly, add code to read the paragraphs from the Word document and call the data uploader to generate the embeddings and upload the paragraphs.

:::code language="csharp" source="./snippets/conceptual/DataIngestion.cs" id="PutItAllTogether2":::

## See your data in Redis

Navigate to the Redis stack browser, for example, [http://localhost:8001/redis-stack/browser](http://localhost:8001/redis-stack/browser), where you should now be able to see your uploaded paragraphs. Following is an example of what you should see for one of the uploaded paragraphs.

```json
{
    "DocumentUri" : "file:///c:/vector-store-data-ingestion-input.docx",
    "ParagraphId" : "14CA7304",
    "Text" : "Version 1.0+ support across C#, Python, and Java means it’s reliable, committed to non breaking changes. Any existing chat-based APIs are easily expanded to support additional modalities like voice and video.",
    "TextEmbedding" : [...]
}
```
