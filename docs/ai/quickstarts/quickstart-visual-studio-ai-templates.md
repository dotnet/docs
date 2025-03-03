---
title: Quickstart - Create a .NET AI app using the AI app template
description: Create a .NET AI app to chat with custom data using the AI app template extensions and the Microsoft.Extensions.AI libraries
ms.date: 2/21/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
zone_pivot_groups: meai-targets
---

# Create a .NET AI app to chat with custom data using the AI app template extensions

In this quickstart, you learn how to create a .NET AI app to chat with custom data using the .NET AI app template extensions. These extensions provide additional starter app templates for Visual Studio and the .NET CLI. The templates are designed to streamline the  getting started experience for building AI apps with .NET by handling common setup tasks and configurations for you.

## Prerequisites

:::zone target="docs" pivot="azure-openai"

* .NET 9.0 SDK - [Install the .NET 9.0 SDK](https://dotnet.microsoft.com/download)
* Visual Studio 2022 - [Install Visual Studio 2022](https://code.visualstudio.com/) (optional)

:::zone-end

:::zone target="docs" pivot="openai"

* .NET 9.0 SDK - [Install the .NET 9.0 SDK](https://dotnet.microsoft.com/download)
* Visual Studio 2022 - [Install Visual Studio 2022](https://code.visualstudio.com/) (optional)
* Access to an [OpenAI service](https://openai.com/api/) with the following configurations:

:::zone-end

:::zone target="docs" pivot="ollama"

* .NET 9.0 SDK - [Install the .NET 9.0 SDK](https://dotnet.microsoft.com/download)
* Visual Studio 2022 - [Install Visual Studio 2022](https://code.visualstudio.com/) (optional)
* Ollama installed locally - [Install Ollama](https://ollama.com/) locally on your device

:::zone-end

## Install the .NET AI app template

The **AI Chat Web App** template is available as a template package through NuGet. Use the [`dotnet new`](../../core/tools/dotnet-new-install.md) command to install the package:

```dotnetcli
dotnet new --install Microsoft.Extensions.AI.Templates
```

## Create the .NET AI app

After you have installed the new AI app templates, the template is available through the Visual Studio UI or the .NET CLI.

:::zone target="docs" pivot="azure-openai"

# [Visual Studio](#tab/visual-studio)

1. Inside Visual Studio, navigate to **File > New > Project**.
1. On the **Create a new project** screen, search for **AI Chat Web App**. Select the matching result and then choose **Next**.
1. On the **Configure your new project** screen, enter the desired name and location for your project and then choose **Next**.
1. On the **Additional information** screen:
    - For the **Framework** option, select **.NET 9.0**.
    - For the **AI service provider** option, select **Azure OpenAI**.
    - Make sure the **Use managed identity** checkbox is checked.
    - For the **Vector store** option, select **Local on-disc (for prototyping)**.
1. Select **Create** to complete the process.

# [.NET CLI](#tab/dotnet-cli)

1. In a terminal window, navigate to an empty directory on your device.
1. Create a new app with the `dotnet new` command and the following parameters:

    ```dotnetcli
    dotnet new aichatweb --framework "net9.0" --AIServiceProvider "azureopenai" --VectorStore "local"
    ```

    The .NET CLI creates a new .NET 9.0 app with the configurations you specified.

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

---

:::zone-end

:::zone target="docs" pivot="openai"

# [Visual Studio](#tab/visual-studio)

1. Inside Visual Studio, navigate to **File > New > Project**.
1. On the **Create a new project** screen, search for **AI Chat Web App**. Select the matching result and then choose **Next**.
1. On the **Configure your new project** screen, enter the desired name and location for your project and then choose **Next**.
1. On the **Additional information** screen:
    - For the **Framework** option, select **.NET 9.0**.
    - For the **AI service provider** option, select **OpenAI**.
    - For the **Vector store** option, select **Local on-disk (for prototyping)**.
1. Select **Create** to complete the process.

# [.NET CLI](#tab/dotnet-cli)

1. In a terminal window, navigate to an empty directory on your device.
1. Create a new app with the `dotnet new` command and the following parameters:

    ```dotnetcli
    dotnet new aichatweb --framework "net9.0" --AIServiceProvider "openai" --VectorStore "local"
    ```

    The .NET CLI creates a new .NET 9.0 app with the configurations you specified.

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

---

:::zone-end

:::zone target="docs" pivot="ollama"

# [Visual Studio](#tab/visual-studio)

1. Inside Visual Studio, navigate to **File > New > Project**.
1. On the **Create a new project** screen, search for **AI Chat Web App**. Select the matching result and then choose **Next**.
1. On the **Configure your new project** screen, enter the desired name and location for your project and then choose **Next**.
1. On the **Additional information** screen:
    - For the **Framework** option, select **.NET 9.0**.
    - For the **AI service provider** option, select **Ollama**.
    - For the **Vector store** option, select **Local on-disk (for prototyping)**.
1. Select **Create** to complete the process.

# [.NET CLI](#tab/dotnet-cli)

1. In a terminal window, navigate to an empty directory on your device.
1. Create a new app with the `dotnet new` command and the following parameters:

    ```dotnetcli
    dotnet new aichatweb --framework "net9.0" --AIServiceProvider "ollama" --VectorStore "local"
    ```

    The .NET CLI creates a new .NET 9.0 app with the configurations you specified.

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

---

:::zone-end

### Explore the sample app

The sample app you created is a Blazor Interactive Server web app preconfigured with common AI and data services. The app handles the following concerns for you:

- Includes essential `Microsoft.Extensions.AI` packages and other dependencies in the `csproj` file to help you get started working with AI.
- Creates various AI services and registers them for dependency injection in the `Program.cs` file:
  - An `IChatClient` service to chat back and forth with the generative AI model
  - An `IEmbeddingGenerator` service that's used to generate embeddings, which are essential for vector search functionality
  - A `JsonVectorStore` to act as an in-memory vector store
- Registers a SQLite database context service to handle ingesting documents. The app is preconfigured to ingest whatever documents you add to the `Data` folder of the project, including the provided example files.
- Provides a complete chat UI using Blazor components. The UI handles rich formatting for the AI responses and provides features such as citations for response data.

:::zone target="docs" pivot="azure-openai"

## Create and configure the Azure OpenAI resource

To use the .NET AI templates, you'll need to create and authenticate to an Azure OpenAI service:

1. [Create an Azure OpenAI Service resource](https://learn.microsoft.com/azure/ai-services/openai/how-to/create-resource?pivots=web-portal) if you don't already have one available.

2. Deploy the `gpt-4o-mini` and `text-embedding-3-small` models to your Azure OpenAI Service resource. When creating those deployments, give them the same names as the models (`gpt-4o-mini` and `text-embedding-3-small`). See the Azure OpenAI documentation to learn how to [Deploy a model](https://learn.microsoft.com/azure/ai-services/openai/how-to/create-resource?pivots=web-portal#deploy-a-model).

3. Configure Azure OpenAI for Keyless Authentication. The AI template is configured to use keyless authentication (also known as Managed Identity, with Entra ID). In the Azure Portal, on the Azure OpenAI resource overview page, navigate to the access control settings. Assign yourself the `Cognitive Services OpenAI User` role. [Learn more](https://learn.microsoft.com/azure/developer/ai/keyless-connections).

:::zone-end

## Configure the app

:::zone target="docs" pivot="azure-openai"

The **AI Chat Web App** app is almost ready to go as soon as it's created. However, you'll need to provide the endpoint for your Azure OpenAI service for the app to connect to. By default, the app template searches for this value in the project's local .NET user secrets.

1. Create a local .NET user secret to store the Azure OpenAI service endpoint:

# [Visual Studio](#tab/visual-studio)

1. In Visual Studio, right-click on your project in the Solution Explorer and select "Manage User Secrets". This opens a `secrets.json` file where you can store your API keys without them being tracked in source control.

2. Add the following key and value:

```json
{
    "GitHubModels:Token": "YOUR-TOKEN"
}
```

# [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet user-secrets set AzureOpenAi:Endpoint <your-azure-openai-endpoint>
```

---

1. By default, the app template assumes your AI model deployment names are the same as the underlying models. If necessary, update the deployment name parameters to match your `gpt-4o-mini` and `text-embedding-3-small` deployment names:

    ```csharp
    // Update these parameter values to match your Azure OpenAI model deployment names
    var chatClient = azureOpenAi.AsChatClient("gpt-4o-mini");
    var embeddingGenerator = azureOpenAi.AsEmbeddingGenerator("text-embedding-3-small");
    ```

:::zone-end

:::zone target="docs" pivot="openai"

The **AI Chat Web App** app is almost ready to go as soon as it's created. However, you'll need to provide the key for your OpenAI service that the app will use to connect and authenticate. By default, the app template searches for this value in the project's local .NET user secrets.

1. Create a local .NET user secret to store the Azure OpenAI service endpoint:

    ```dotnetcli
    dotnet user-secrets set OpenAI:Key <your-api-key>
    ```

1. By default, the app template assumes the use of certain AI models. If necessary, update the model name parameters to match your the models you want to target:

    ```csharp
    // Update these parameter values to match your preferred OpenAI models
    var chatClient = openAIClient.AsChatClient("gpt-4o-mini");
    var embeddingGenerator = openAIClient.AsEmbeddingGenerator("text-embedding-3-small");
    ```

:::zone-end

:::zone target="docs" pivot="ollama"

The **AI Chat Web App** app is almost ready to go as soon as it's created. However, you should verify that certain configurations match your needs before you run the app.

1. In a local terminal window, make sure Ollama is running on your computer using the `ollama serve` command:

    ```bash
    ollama serve
    ```

1. By default, the app template targets the default Ollama host address at `http://localhost:11434` and assumes the use of certain AI models. If you are using a different address or AI models, update the client configuration code to your target values:

    ```csharp
    // Update these parameter values to match your preferred OpenAI models
    IChatClient chatClient = new OllamaApiClient(
        new Uri("http://localhost:11434"),
        "llama3.2");
    IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator = new OllamaApiClient(
        new Uri("http://localhost:11434"),
        "all-minilm");
    ```

:::zone-end

## Run and test the app

1. Select the run button at the top of Visual Studio to launch the app. After a moment, you should see the following UI load in the browser:

    > [!NOTE]
    > To avoid authentication errors, make sure you are signed-in to Visual Studio or the Azure CLI with a user that is assigned the **Azure AI Developer** role on your Azure OpenAI resource.

    :::image type="content" source="../media/ai-templates/app-ui.png" alt-text="A screenshot showing the UI of the .NET AI app template.":::

1. Enter a prompt into the input box such as *"What are some essential tools in the survival kit?"* to ask your AI model a question about the ingested data from the example files.

    :::image type="content" source="../media/ai-templates/app-ui-question.png" alt-text="A screenshot showing the conversational UI of the .NET AI app template.":::

    The app responds with an answer to the question and provides citations of where it found the data. You can click on one of the citations to be directed to the relevant section of the example files.

## Next steps

- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
