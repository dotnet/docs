---
title: Quickstart - Process custom data for AI
description: Create a data ingestion pipeline to process and prepare custom data for AI applications using Microsoft.Extensions.DataIngestion.
ms.date: 12/11/2025
ms.topic: quickstart
ai-usage: ai-assisted
---

# Process custom data for AI applications

In this quickstart, you learn how to create a data ingestion pipeline to process and prepare custom data for AI applications. The app uses the <xref:Microsoft.Extensions.DataIngestion> library to read documents, enrich content with AI, chunk text semantically, and store embeddings in a vector database for semantic search.

Data ingestion is essential for retrieval-augmented generation (RAG) scenarios where you need to process large amounts of unstructured data and make it searchable for AI applications.

[!INCLUDE [azure-openai-prereqs](includes/prerequisites-azure-openai.md)]

## Create the app

Complete the following steps to create a .NET console app.

1. In an empty directory on your computer, use the `dotnet new` command to create a new console app:

    ```dotnetcli
    dotnet new console -o ProcessDataAI
    ```

1. Change directory into the app folder:

    ```dotnetcli
    cd ProcessDataAI
    ```

1. Install the required packages:

    ```bash
    dotnet add package Azure.AI.OpenAI
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    dotnet add package Microsoft.Extensions.DataIngestion --prerelease
    dotnet add package Microsoft.Extensions.DataIngestion.Markdig --prerelease
    dotnet add package Microsoft.Extensions.Logging.Console
    dotnet add package Microsoft.ML.Tokenizers.Data.O200kBase
    dotnet add package Microsoft.SemanticKernel.Connectors.SqliteVec --prerelease

## Create the AI service

1. To provision an Azure OpenAI service and model, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource) article.

1. From a terminal or command prompt, navigate to the root of your project directory.

1. Run the following commands to configure your Azure OpenAI endpoint and model name for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set AZURE_OPENAI_ENDPOINT <your-Azure-OpenAI-endpoint>
    dotnet user-secrets set AZURE_OPENAI_API_KEY <your-Azure-OpenAI-key>
    ```

## Open the app in an editor

1. Open the app in Visual Studio Code (or your editor of choice).

   ```bash
   code .
   ```

1. Copy the [sample.md](https://raw.githubusercontent.com/dotnet/docs/refs/heads/main/docs/ai/quickstarts/snippets/process-data/sample.md) file to your project directory. Configure the project to copy this file to the output directory. If you're using Visual Studio, right-click on the file in Solution Explorer, select **Properties**, and then set **Copy to Output Directory** to **Copy if newer**.

## Add the app code

The data ingestion pipeline consists of several components that work together to process documents:

- **Document reader**: Reads Markdown files from a directory.
- **Document processor**: Enriches images with AI-generated alternative text.
- **Chunker**: Splits documents into semantic chunks using embeddings.
- **Chunk processor**: Generates AI summaries for each chunk.
- **Vector store writer**: Stores chunks with embeddings in a SQLite database.

1. In the `Program.cs` file, delete any existing code and add the following code to configure the document reader:

   :::code language="csharp" source="snippets/process-data/Program.cs" id="ConfigureReader":::

   The <xref:Microsoft.Extensions.DataIngestion.MarkdownReader> class reads Markdown documents and converts them into a unified format that works well with large language models.

1. Add code to configure logging for the pipeline:

   :::code language="csharp" source="snippets/process-data/Program.cs" id="ConfigureLogging":::

1. Add code to configure the AI client for enrichment and chat:

   :::code language="csharp" source="snippets/process-data/Program.cs" id="ConfigureChatClient":::

1. Add code to configure the document processor that enriches images with AI-generated descriptions:

   :::code language="csharp" source="snippets/process-data/Program.cs" id="ConfigureDocumentProcessor":::

   The <xref:Microsoft.Extensions.DataIngestion.ImageAlternativeTextEnricher> uses large language models to generate descriptive alternative text for images within documents. That text makes them more accessible and improves their semantic meaning.

1. Add code to configure the embedding generator for creating vector representations:

   :::code language="csharp" source="snippets/process-data/Program.cs" id="ConfigureEmbeddingGenerator":::

   Embeddings are numerical representations of the semantic meaning of text, which enables vector similarity search.

1. Add code to configure the chunker that splits documents into semantic chunks:

   :::code language="csharp" source="snippets/process-data/Program.cs" id="ConfigureChunker":::

   The <xref:Microsoft.Extensions.DataIngestion.Chunkers.SemanticSimilarityChunker> intelligently splits documents by analyzing the semantic similarity between sentences, ensuring that related content stays together. This process produces chunks that preserve meaning and context better than simple character or token-based chunking.

1. Add code to configure the chunk processor that generates summaries:

   :::code language="csharp" source="snippets/process-data/Program.cs" id="ConfigureChunkProcessor":::

   The <xref:Microsoft.Extensions.DataIngestion.SummaryEnricher> automatically generates concise summaries for each chunk, which can improve retrieval accuracy by providing a high-level overview of the content.

1. Add code to configure the SQLite vector store for storing embeddings:

   :::code language="csharp" source="snippets/process-data/Program.cs" id="ConfigureVectorStore":::

   The vector store stores chunks along with their embeddings, enabling fast semantic search capabilities.

1. Add code to compose all the components into a complete pipeline:

   :::code language="csharp" source="snippets/process-data/Program.cs" id="ComposePipeline":::

   The <xref:Microsoft.Extensions.DataIngestion.IngestionPipeline`1> combines all the components into a cohesive workflow that processes documents from start to finish.

1. Add code to process documents from a directory:

   :::code language="csharp" source="snippets/process-data/Program.cs" id="ProcessDocuments":::

   The pipeline processes all Markdown files in the `./data` directory and reports the status of each document.

1. Add code to enable interactive search of the processed documents:

   :::code language="csharp" source="snippets/process-data/Program.cs" id="SearchVectorStore":::

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

## Clean up resources

If you no longer need them, delete the Azure OpenAI resource and model deployment.

1. In the [Azure Portal](https://aka.ms/azureportal), navigate to the Azure OpenAI resource.
1. Select the Azure OpenAI resource, and then select **Delete**.

## Next steps

- [Data ingestion concepts](../conceptual/data-ingestion.md)
- [Implement RAG using vector search](../tutorials/tutorial-ai-vector-search.md)
- [Build a .NET AI vector search app](build-vector-search-app.md)
