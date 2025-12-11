---
title: Quickstart - Process custom data for AI with .NET
description: Create a data ingestion pipeline to process and prepare custom data for AI applications using Microsoft.Extensions.DataIngestion
ms.date: 12/11/2025
ms.topic: quickstart
zone_pivot_groups: openai-library
ai-usage: ai-assisted
---

# Process custom data for AI applications

In this quickstart, you learn how to create a data ingestion pipeline to process and prepare custom data for AI applications. The app uses the <xref:Microsoft.Extensions.DataIngestion> library to read documents, enrich content with AI, chunk text semantically, and store embeddings in a vector database for semantic search.

Data ingestion is essential for Retrieval-Augmented Generation (RAG) scenarios where you need to process large amounts of unstructured data and make it searchable for AI applications.

:::zone target="docs" pivot="openai"

[!INCLUDE [openai-prereqs](includes/prerequisites-openai.md)]

:::zone-end

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [azure-openai-prereqs](includes/prerequisites-azure-openai.md)]

:::zone-end

## Create the app

Complete the following steps to create a .NET console app that can:

- Read Markdown documents from a directory
- Enrich content with AI-generated image descriptions
- Chunk text using semantic similarity
- Generate AI summaries for each chunk
- Store embeddings in a SQLite vector database
- Search the vector store using natural language queries

1. In an empty directory on your computer, use the `dotnet new` command to create a new console app:

    ```dotnetcli
    dotnet new console -o ProcessDataAI
    ```

1. Change directory into the app folder:

    ```dotnetcli
    cd ProcessDataAI
    ```

1. Install the required packages:

    :::zone target="docs" pivot="azure-openai"

    ```bash
    dotnet add package Azure.Identity
    dotnet add package Azure.AI.OpenAI
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.DataIngestion --prerelease
    dotnet add package Microsoft.Extensions.DataIngestion.Markdig --prerelease
    dotnet add package Microsoft.Extensions.Logging.Console
    dotnet add package Microsoft.ML.Tokenizers.Data.Cl100kBase
    dotnet add package Microsoft.SemanticKernel.Connectors.SqliteVec --prerelease
    ```

    The following list describes each package in the `ProcessDataAI` app:

    - [`Azure.Identity`](https://www.nuget.org/packages/Azure.Identity) provides [`Microsoft Entra ID`](/entra/fundamentals/whatis) token authentication support across the Azure SDK using classes such as `DefaultAzureCredential`.
    - [`Azure.AI.OpenAI`](https://www.nuget.org/packages/Azure.AI.OpenAI) is the official package for using OpenAI's .NET library with the Azure OpenAI Service.
    - [`Microsoft.Extensions.AI.OpenAI`](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI) provides AI abstractions for OpenAI-compatible models or endpoints.
    - [`Microsoft.Extensions.DataIngestion`](https://www.nuget.org/packages/Microsoft.Extensions.DataIngestion) provides foundational .NET building blocks for data ingestion pipelines.
    - [`Microsoft.Extensions.DataIngestion.Markdig`](https://www.nuget.org/packages/Microsoft.Extensions.DataIngestion.Markdig) provides a Markdown document reader for the data ingestion pipeline.
    - [`Microsoft.Extensions.Logging.Console`](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Console) provides logging support for the console.
    - [`Microsoft.ML.Tokenizers.Data.Cl100kBase`](https://www.nuget.org/packages/Microsoft.ML.Tokenizers.Data.Cl100kBase) provides tokenizer data for the GPT-4 model.
    - [`Microsoft.SemanticKernel.Connectors.SqliteVec`](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.SqliteVec) provides an in-memory vector store using SQLite for storing and searching embeddings.

    :::zone-end

    :::zone target="docs" pivot="openai"

    ```bash
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.DataIngestion --prerelease
    dotnet add package Microsoft.Extensions.DataIngestion.Markdig --prerelease
    dotnet add package Microsoft.Extensions.Logging.Console
    dotnet add package Microsoft.ML.Tokenizers.Data.Cl100kBase
    dotnet add package Microsoft.SemanticKernel.Connectors.SqliteVec --prerelease
    ```

    The following list describes each package in the `ProcessDataAI` app:

    - [`Microsoft.Extensions.AI.OpenAI`](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI) provides AI abstractions for OpenAI-compatible models or endpoints. This library also includes the official [`OpenAI`](https://www.nuget.org/packages/OpenAI) library for the OpenAI service API as a dependency.
    - [`Microsoft.Extensions.DataIngestion`](https://www.nuget.org/packages/Microsoft.Extensions.DataIngestion) provides foundational .NET building blocks for data ingestion pipelines.
    - [`Microsoft.Extensions.DataIngestion.Markdig`](https://www.nuget.org/packages/Microsoft.Extensions.DataIngestion.Markdig) provides a Markdown document reader for the data ingestion pipeline.
    - [`Microsoft.Extensions.Logging.Console`](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Console) provides logging support for the console.
    - [`Microsoft.ML.Tokenizers.Data.Cl100kBase`](https://www.nuget.org/packages/Microsoft.ML.Tokenizers.Data.Cl100kBase) provides tokenizer data for the GPT-4 model.
    - [`Microsoft.SemanticKernel.Connectors.SqliteVec`](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.SqliteVec) provides an in-memory vector store using SQLite for storing and searching embeddings.

    :::zone-end

1. Open the app in Visual Studio Code (or your editor of choice).

    ```bash
    code .
    ```

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [create-ai-service](includes/create-ai-service.md)]

:::zone-end

:::zone target="docs" pivot="openai"

## Configure the app

1. Navigate to the root of your .NET project from a terminal or command prompt.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-OpenAI-key>
    ```

:::zone-end

## Add the app code

The data ingestion pipeline consists of several components that work together to process documents:

- **Document reader**: Reads Markdown files from a directory
- **Document processor**: Enriches images with AI-generated alternative text
- **Chunker**: Splits documents into semantic chunks using embeddings
- **Chunk processor**: Generates AI summaries for each chunk
- **Vector store writer**: Stores chunks with embeddings in a SQLite database

### Configure the document reader

1. In the `Program.cs` file, delete any existing code and add the following code to configure the document reader:

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/process-data/azure-openai/ProcessData/Program.cs" id="ConfigureReader":::

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/process-data/openai/ProcessData/Program.cs" id="ConfigureReader":::

    :::zone-end

    The `MarkdownReader` class reads Markdown documents and converts them into a unified format that works well with large language models.

### Configure logging

1. Add code to configure logging for the pipeline:

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/process-data/azure-openai/ProcessData/Program.cs" id="ConfigureLogging":::

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/process-data/openai/ProcessData/Program.cs" id="ConfigureLogging":::

    :::zone-end

### Configure the AI client

1. Add code to configure the AI client for enrichment and chat:

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/process-data/azure-openai/ProcessData/Program.cs" id="ConfigureChatClient":::

    > [!NOTE]
    > <xref:Azure.Identity.DefaultAzureCredential> searches for authentication credentials from your local tooling. You'll need to assign the `Azure AI Developer` role to the account you used to sign in to Visual Studio or the Azure CLI. For more information, see [Authenticate to Azure AI services with .NET](../azure-ai-services-authentication.md).

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/process-data/openai/ProcessData/Program.cs" id="ConfigureChatClient":::

    :::zone-end

### Configure the document processor

1. Add code to configure the document processor that enriches images with AI-generated descriptions:

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/process-data/azure-openai/ProcessData/Program.cs" id="ConfigureDocumentProcessor":::

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/process-data/openai/ProcessData/Program.cs" id="ConfigureDocumentProcessor":::

    :::zone-end

    The `ImageAlternativeTextEnricher` uses large language models to generate descriptive alternative text for images within documents, making them more accessible and improving their semantic meaning.

### Configure the embedding generator

1. Add code to configure the embedding generator for creating vector representations:

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/process-data/azure-openai/ProcessData/Program.cs" id="ConfigureEmbeddingGenerator":::

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/process-data/openai/ProcessData/Program.cs" id="ConfigureEmbeddingGenerator":::

    :::zone-end

    Embeddings are numerical representations of the semantic meaning of text, which enables vector similarity search.

### Configure the chunker

1. Add code to configure the chunker that splits documents into semantic chunks:

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/process-data/azure-openai/ProcessData/Program.cs" id="ConfigureChunker":::

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/process-data/openai/ProcessData/Program.cs" id="ConfigureChunker":::

    :::zone-end

    The `SemanticSimilarityChunker` intelligently splits documents by analyzing the semantic similarity between sentences, ensuring that related content stays together. This produces chunks that preserve meaning and context better than simple character or token-based chunking.

### Configure the chunk processor

1. Add code to configure the chunk processor that generates summaries:

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/process-data/azure-openai/ProcessData/Program.cs" id="ConfigureChunkProcessor":::

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/process-data/openai/ProcessData/Program.cs" id="ConfigureChunkProcessor":::

    :::zone-end

    The `SummaryEnricher` automatically generates concise summaries for each chunk, which can improve retrieval accuracy by providing a high-level overview of the content.

### Configure the vector store

1. Add code to configure the SQLite vector store for storing embeddings:

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/process-data/azure-openai/ProcessData/Program.cs" id="ConfigureVectorStore":::

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/process-data/openai/ProcessData/Program.cs" id="ConfigureVectorStore":::

    :::zone-end

    The vector store stores chunks along with their embeddings, enabling fast semantic search capabilities.

### Compose the pipeline

1. Add code to compose all the components into a complete pipeline:

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/process-data/azure-openai/ProcessData/Program.cs" id="ComposePipeline":::

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/process-data/openai/ProcessData/Program.cs" id="ComposePipeline":::

    :::zone-end

    The `IngestionPipeline` combines all the components into a cohesive workflow that processes documents from start to finish.

### Process documents

1. Add code to process documents from a directory:

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/process-data/azure-openai/ProcessData/Program.cs" id="ProcessDocuments":::

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/process-data/openai/ProcessData/Program.cs" id="ProcessDocuments":::

    :::zone-end

    The pipeline processes all Markdown files in the `./data` directory and reports the status of each document.

### Search the vector store

1. Add code to enable interactive search of the processed documents:

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/process-data/azure-openai/ProcessData/Program.cs" id="SearchVectorStore":::

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/process-data/openai/ProcessData/Program.cs" id="SearchVectorStore":::

    :::zone-end

    The search functionality converts user queries into embeddings and finds the most semantically similar chunks in the vector store.

## Create sample data

1. Create a `data` folder in your project directory:

    ```bash
    mkdir data
    ```

1. Create a sample Markdown file in the `data` folder. For example, create a file named `sample.md` with the following content:

    ```markdown
    # Data Ingestion

    Data ingestion is the process of collecting and preparing data for AI applications.

    ## Key Concepts

    - Extract data from various sources
    - Transform data into usable formats
    - Load data into storage systems

    ## Benefits

    Data ingestion enables AI applications to work with custom data, improving accuracy and relevance.
    ```

## Run the app

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

    The app processes all Markdown files in the `data` directory and displays the processing status for each document. Once processing is complete, you can enter natural language questions to search the processed content.

1. Enter a question at the prompt to search the data:

    ```output
    Enter your question (or 'exit' to quit): What is data ingestion?
    ```

    The app returns the most relevant chunks from your documents along with their similarity scores.

1. Type `exit` to quit the application.

:::zone target="docs" pivot="azure-openai"

## Clean up resources

If you no longer need them, delete the Azure OpenAI resource and model deployment.

1. In the [Azure Portal](https://aka.ms/azureportal), navigate to the Azure OpenAI resource.
1. Select the Azure OpenAI resource, and then select **Delete**.

:::zone-end

## Next steps

- [Data ingestion concepts](../conceptual/data-ingestion.md)
- [Implement RAG using vector search](../tutorials/tutorial-ai-vector-search.md)
- [Build a .NET AI vector search app](build-vector-search-app.md)
