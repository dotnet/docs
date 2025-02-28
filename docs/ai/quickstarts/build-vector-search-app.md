---
title: Quickstart - Build a minimal .NET AI RAG app
description: Create an AI powered app to search and integrate with vector stores using embeddings and the Microsoft.Extensions.VectorData package for .NET
ms.date: 12/06/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to AI, I want deploy and use sample code to interact to learn from the sample code.
---

# Build a .NET AI vector search app

In this quickstart, you create a .NET console app to perform semantic search on a vector store to find relevant results for the user's query. You learn how to generate embeddings for user prompts and use those embeddings to query the vector data store. Vector search functionality is also a key component for Retrieval Augmented Generation (RAG) scenarios. The app uses the <xref:Microsoft.Extensions.AI> and [Microsoft.Extensions.VectorData.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions) libraries so you can write code using AI abstractions rather than a specific SDK. AI abstractions help create loosely coupled code that allows you to change the underlying AI model with minimal app changes.

:::zone target="docs" pivot="openai"

[!INCLUDE [openai-prereqs](includes/prerequisites-openai.md)]

:::zone-end

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [azure-openai-prereqs](includes/prerequisites-azure-openai.md)]

:::zone-end

[!INCLUDE [clone-sample-repo](includes/clone-sample-repo.md)]

## Interact with your data using vector stores

Vector stores or vector databases are essential for tasks like semantic search, Retrieval Augmented Generation (RAG), and other scenarios that require grounding generative AI responses. While relational databases and document databases are optimized for structured and semi-structured data, vector databases are built to efficiently store, index, and manage data represented as embedding vectors. As a result, the indexing and search algorithms used by vector databases are optimized to efficiently retrieve data that can be used downstream in your applications.

### Explore Microsoft.Extensions.VectorData.Abstractions

[Microsoft.Extensions.VectorData.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions/) is a .NET library developed in collaboration with Semantic Kernel and the broader .NET ecosystem to provide a unified layer of abstractions for interacting with vector stores.

The abstractions in `Microsoft.Extensions.VectorData.Abstractions` provide library authors and developers with the following functionality:

- Perform Create-Read-Update-Delete (CRUD) operations on vector stores
- Use vector and text search on vector stores

> [!NOTE]
> The [Microsoft.Extensions.VectorData.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions/) library is currently in preview.

## Create the app

Complete the following steps to create a .NET console app that can accomplish the following:

- Create and populate a vector store by generating embeddings for a data set
- Generate an embedding for the user prompt
- Query the vector store using the user prompt embedding
- Displays the relevant results from the vector search

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
    ```

    The following list describes what each package is used for in the `VectorDataAI` app:

    - [`Azure.Identity`](https://www.nuget.org/packages/Azure.Identity) provides [`Microsoft Entra ID`](/entra/fundamentals/whatis) token authentication support across the Azure SDK using classes such as `DefaultAzureCredential`.
    - [`Azure.AI.OpenAI`](https://www.nuget.org/packages/Azure.AI.OpenAI) is the official package for using OpenAI's .NET library with the Azure OpenAI Service.
    - [`Microsoft.SemanticKernel.Connectors.InMemory`](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.InMemory) provides an in-memory vector store class to hold queryable vector data records.
    - [`Microsoft.Extensions.VectorData.Abstractions`](https://www.nuget.org/packages/Microsoft.Extensions.AI) enables Create-Read-Update-Delete (CRUD) and search operations on vector stores.
    - [Microsoft.Extensions.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration) provides implementation of key-value pair based configuration.
    - [`Microsoft.Extensions.Configuration.UserSecrets`](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets) is a user secrets configuration provider implementation for `Microsoft.Extensions.Configuration`.

    :::zone-end

    :::zone target="docs" pivot="openai"

    ```bash
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.VectorData.Abstractions --prerelease
    dotnet add package Microsoft.SemanticKernel.Connectors.InMemory --prerelease
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

    The following list describes what each package is used for in the `VectorDataAI` app:

    - [`Microsoft.Extensions.AI.OpenAI`](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI) provides AI abstractions for OpenAI-compatible models or endpoints. This library also includes the official [`OpenAI`](https://www.nuget.org/packages/OpenAI) library for the OpenAI service API as a dependency.
    - [`Microsoft.SemanticKernel.Connectors.InMemory`](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.InMemory) provides an in-memory vector store class to hold queryable vector data records.
    - [`Microsoft.Extensions.VectorData.Abstractions`](https://www.nuget.org/packages/Microsoft.Extensions.AI) enables Create-Read-Update-Delete (CRUD) and search operations on vector stores.
    - [Microsoft.Extensions.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration) provides implementation of key-value pair based configuration.
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
    dotnet user-secrets set OpenAIKey <your-openai-key>
    dotnet user-secrets set ModelName <your-openai-model-name>
    ```

    > [!NOTE]
    > For the `ModelName` value, you need to specify an OpenAI text embedding model such as `text-embedding-3-small` or `text-embedding-3-large` to generate embeddings for vector search in the sections that follow.

:::zone-end

## Add the app code

1. Add a new class named **CloudService** to your project with the following properties:

   :::code language="csharp" source="snippets/chat-with-data/azure-openai/CloudService.cs" :::

    In the preceding code:

    - The C# attributes provided by `Microsoft.Extensions.VectorData` influence how each property is handled when used in a vector store.
    - The **Vector** property stores a generated embedding that represents the semantic meaning of the **Name** and **Description** for vector searches.

1. In the **Program.cs** file, add the following code to create a data set that describes a collection of cloud services:

   :::code language="csharp" source="snippets/chat-with-data/azure-openai/program.cs" range="8-46":::

1. Create and configure an `IEmbeddingGenerator` implementation to send requests to an embedding AI model:

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/chat-with-data/azure-openai/program.cs" range="48-58":::

    > [!NOTE]
    > <xref:Azure.Identity.DefaultAzureCredential> searches for authentication credentials from your local tooling. If you aren't using the `azd` template to provision the Azure OpenAI resource, you'll need to assign the `Azure AI Developer` role to the account you used to sign in to Visual Studio or the Azure CLI. For more information, see [Authenticate to Azure AI services with .NET](../azure-ai-services-authentication.md).

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/chat-with-data/openai/program.cs" range="49-57":::

    :::zone-end

1. Create and populate a vector store with the cloud service data. Use the `IEmbeddingGenerator` implementation to create and assign an embedding vector for each record in the cloud service data:

    :::code language="csharp" source="snippets/chat-with-data/azure-openai/program.cs" range="61-70":::

   The embeddings are numerical representations of the semantic meaning for each data record, which makes them compatible with vector search features.

1. Create an embedding for a search query and use it to perform a vector search on the vector store:

    :::code language="csharp" source="snippets/chat-with-data/azure-openai/program.cs" range="72-88":::

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

    The app prints out the top result of the vector search, which is the cloud service that is most relevant to the original query. You can modify the query to try different search scenarios.

:::zone target="docs" pivot="azure-openai"

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

:::zone-end

## Next steps

- [Quickstart - Chat with a local AI model](/dotnet/ai/quickstarts/chat-local-model)
- [Generate images using AI with .NET](/dotnet/ai/quickstarts/generate-images)
