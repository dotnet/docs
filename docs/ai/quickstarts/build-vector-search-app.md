---
title: Quickstart - Build a minimal .NET AI RAG app
description: Create an AI powered app to search and integrate with vector stores using embeddings and the Microsoft.Extensions.VectorData package for .NET
ms.date: 05/29/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to AI, I want deploy and use sample code to interact to learn from the sample code.
---

# Build a .NET AI vector search app

In this quickstart, you create a .NET console app to perform semantic search on a _vector store_ to find relevant results for the user's query. You learn how to generate embeddings for user prompts and use those embeddings to query the vector data store.

Vector stores, or vector databases, are essential for tasks like semantic search, retrieval augmented generation (RAG), and other scenarios that require grounding generative AI responses. While relational databases and document databases are optimized for structured and semi-structured data, vector databases are built to efficiently store, index, and manage data represented as embedding vectors. As a result, the indexing and search algorithms used by vector databases are optimized to efficiently retrieve data that can be used downstream in your applications.

## About the libraries

The app uses the <xref:Microsoft.Extensions.AI> and <xref:Microsoft.Extensions.VectorData> libraries so you can write code using AI abstractions rather than a specific SDK. AI abstractions help create loosely coupled code that allows you to change the underlying AI model with minimal app changes.

[📦 Microsoft.Extensions.VectorData.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions/) is a .NET library developed in collaboration with Semantic Kernel and the broader .NET ecosystem to provide a unified layer of abstractions for interacting with vector stores. The abstractions in `Microsoft.Extensions.VectorData.Abstractions` provide library authors and developers with the following functionality:

- Perform create-read-update-delete (CRUD) operations on vector stores.
- Use vector and text search on vector stores.

> [!NOTE]
> The [Microsoft.Extensions.VectorData.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions/) library is currently in preview.

<!--Prerequisites section-->

:::zone target="docs" pivot="openai"

[!INCLUDE [openai-prereqs](includes/prerequisites-openai.md)]

:::zone-end

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [azure-openai-prereqs](includes/prerequisites-azure-openai.md)]

:::zone-end

## Create the app

Complete the following steps to create a .NET console app that can:

- Create and populate a vector store by generating embeddings for a data set.
- Generate an embedding for the user prompt.
- Query the vector store using the user prompt embedding.
- Display the relevant results from the vector search.

1. In an empty directory on your computer, use the `dotnet new` command to create a new console app:

    ```dotnetcli
    dotnet new console -o VectorDataAI
    ```

1. Change directory into the app folder:

    ```dotnetcli
    cd VectorDataAI
    ```

1. Install the required packages:

    :::zone target="docs" pivot="azure-openai"

    ```bash
    dotnet add package Azure.Identity
    dotnet add package Azure.AI.OpenAI
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.VectorData.Abstractions --prerelease
    dotnet add package Microsoft.SemanticKernel.Connectors.InMemory --prerelease
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    dotnet add package System.Linq.AsyncEnumerable
    ```

    The following list describes each package in the `VectorDataAI` app:

    - [`Azure.Identity`](https://www.nuget.org/packages/Azure.Identity) provides [`Microsoft Entra ID`](/entra/fundamentals/whatis) token authentication support across the Azure SDK using classes such as `DefaultAzureCredential`.
    - [`Azure.AI.OpenAI`](https://www.nuget.org/packages/Azure.AI.OpenAI) is the official package for using OpenAI's .NET library with the Azure OpenAI Service.
    - [`Microsoft.Extensions.VectorData.Abstractions`](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions) enables Create-Read-Update-Delete (CRUD) and search operations on vector stores.
    - [`Microsoft.SemanticKernel.Connectors.InMemory`](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.InMemory) provides an in-memory vector store class to hold queryable vector data records.
    - [Microsoft.Extensions.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration) provides an implementation of key-value pair&mdash;based configuration.
    - [`Microsoft.Extensions.Configuration.UserSecrets`](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets) is a user secrets configuration provider implementation for `Microsoft.Extensions.Configuration`.

    :::zone-end

    :::zone target="docs" pivot="openai"

    ```bash
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.VectorData.Abstractions --prerelease
    dotnet add package Microsoft.SemanticKernel.Connectors.InMemory --prerelease
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    dotnet add package System.Linq.AsyncEnumerable
    ```

    The following list describes each package in the `VectorDataAI` app:

    - [`Microsoft.Extensions.AI.OpenAI`](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI) provides AI abstractions for OpenAI-compatible models or endpoints. This library also includes the official [`OpenAI`](https://www.nuget.org/packages/OpenAI) library for the OpenAI service API as a dependency.
    - [`Microsoft.Extensions.VectorData.Abstractions`](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions) enables Create-Read-Update-Delete (CRUD) and search operations on vector stores.
    - [`Microsoft.SemanticKernel.Connectors.InMemory`](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.InMemory) provides an in-memory vector store class to hold queryable vector data records.
    - [Microsoft.Extensions.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration) provides an implementation of key-value pair&mdash;based configuration.
    - [`Microsoft.Extensions.Configuration.UserSecrets`](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets) is a user secrets configuration provider implementation for `Microsoft.Extensions.Configuration`.

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
    dotnet user-secrets set ModelName <your-OpenAI-model-name>
    ```

:::zone-end

> [!NOTE]
> For the model name, you need to specify a text embedding model such as `text-embedding-3-small` or `text-embedding-3-large` to generate embeddings for vector search in the sections that follow. For more information about embedding models, see [Embeddings](/azure/ai-services/openai/concepts/models#embeddings).

## Add the app code

1. Add a new class named `CloudService` to your project with the following properties:

   :::code language="csharp" source="snippets/chat-with-data/azure-openai/CloudService.cs" :::

    The <xref:Microsoft.Extensions.VectorData> attributes, such as <xref:Microsoft.Extensions.VectorData.VectorStoreKeyAttribute>, influence how each property is handled when used in a vector store. The `Vector` property stores a generated embedding that represents the semantic meaning of the `Description` value for vector searches.

1. In the `Program.cs` file, add the following code to create a data set that describes a collection of cloud services:

   :::code language="csharp" source="snippets/chat-with-data/azure-openai/program.cs" id="DataSet":::

1. Create and configure an `IEmbeddingGenerator` implementation to send requests to an embedding AI model:

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/chat-with-data/azure-openai/program.cs" id="EmbeddingGenerator":::

    > [!NOTE]
    > <xref:Azure.Identity.DefaultAzureCredential> searches for authentication credentials from your local tooling. You'll need to assign the `Azure AI Developer` role to the account you used to sign in to Visual Studio or the Azure CLI. For more information, see [Authenticate to Azure AI services with .NET](../azure-ai-services-authentication.md).

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/chat-with-data/openai/program.cs" id="EmbeddingGenerator":::

    :::zone-end

1. Create and populate a vector store with the cloud service data. Use the `IEmbeddingGenerator` implementation to create and assign an embedding vector for each record in the cloud service data:

    :::code language="csharp" source="snippets/chat-with-data/azure-openai/program.cs" id="VectorStore":::

   The embeddings are numerical representations of the semantic meaning for each data record, which makes them compatible with vector search features.

1. Create an embedding for a search query and use it to perform a vector search on the vector store:

    :::code language="csharp" source="snippets/chat-with-data/azure-openai/program.cs" id="Search":::

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

    The app prints out the top result of the vector search, which is the cloud service that's most relevant to the original query. You can modify the query to try different search scenarios.

:::zone target="docs" pivot="azure-openai"

## Clean up resources

If you no longer need them, delete the Azure OpenAI resource and model deployment.

1. In the [Azure Portal](https://aka.ms/azureportal), navigate to the Azure OpenAI resource.
1. Select the Azure OpenAI resource, and then select **Delete**.

:::zone-end

## Next steps

- [Quickstart - Chat with a local AI model](chat-local-model.md)
- [Generate images using AI with .NET](generate-images.md)
