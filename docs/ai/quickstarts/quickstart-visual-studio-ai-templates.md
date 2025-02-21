---
title: Quickstart - Connect to and chat with a local AI using .NET
description: Set up a local AI model and chat with it using a .NET console app and the Microsoft.Extensions.AI libraries
ms.date: 12/19/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
---

# create a .NET AI app to chat with custom data using the AI app template extensions

In this quickstart, you learn how to create a .NET AI app to chat with custom data using the .NET AI app template extensions. These extensions provide additional starter app templates for Visual Studio and the .NET CLI. The templates are designed to streamline the  getting started experience for building AI apps with .NET by handling common setup tasks and configurations for you.

## Prerequisites

* .NET 9.0 SDK - [Install the .NET 9.0 SDK](https://dotnet.microsoft.com/download)
* Visual Studio 2022 [Install Visual Studio 2022](https://code.visualstudio.com/) (optional)
* Access to an [Azure OpenAI service](/azure/ai-services/openai/how-to/provisioned-get-started) with the following configurations:
  - A `gpt-4o-mini` model deployed
  - A `text-embedding-3-small` model deployed
  - The [Azure AI Developer](/azure/role-based-access-control/built-in-roles/ai-machine-learning#azure-ai-developer) role assigned to the user you used to sign-in to Visual Studio or the Azure CLI with locally

## Install the .NET AI app template

The **AI Chat with Custom Data** template is available as a template package through NuGet. Use the `dotnet new` command to install  the package:

```dotnetcli
dotnet new --install AIChatCustomData
```

## Create the .NET AI app

After you have installed the new AI app templates, the template is available through the Visual Studio UI or the .NET CLI.

# [Visual Studio](#tab/visual-studio)

1. Inside Visual Studio, navigate to **File -> New -> Project**.
1. On the **Create a new project** screen, search for **AI Chat with Custom Data**. Select the matching result and then choose **Next**.
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
    dotnet new chat --framework "net9.0" --AiServiceProvider "azureopenai" --VectorStore "local"
    ```

    The .NET CLI creates a new .NET 9.0 app configured to use Azure OpenAI with a local in-memory vector store for prototyping.

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

---

### Explore the sample app

The sample app you created is a Blazor Interactive Server web app preconfigured with common AI and data services. The app handles the following concerns for you:

- Includes essential `Microsoft.Extensions.AI` packages and other dependencies in the `csproj` file to help you get started working with AI.
- Creates various AI services and registers them for dependency injection in the `Program.cs` file:
  - An `IChatClient` service to chat back and forth with the generative AI model.
  - An `IEmbeddingGenerator` service that is used to generate embeddings, which are essential for vector search functionality.
  - A `JsonVectorStore` to act as an in-memory vector store.
- Registers a SQLite database context service to handle ingesting documents. The app is preconfigured to ingest whatever documents you add to the `Data` folder of the project, including the provided `Example.pdf` file.
- Provides a complete chat UI using Blazor components. The UI handles rich formatting for the AI responses and provides features such as citations for response data.

## Configure and run the app

The **AI Chat with Custom Data** app is almost ready to go as soon as it's created. However, you'll need to provide the endpoint for your Azure OpenAI service for the app to connect to. By default, the app template searches for this value in the project's local .NET user secrets.

1. Create a local .NET user secret to store the Azure OpenAI service endpoint:

    ```dotnetcli
    dotnet user-secrets set AzureOpenAi:Endpoint <your-azure-openai-endpoint>
    ```

1. By default, the app template assumes your Azure OpenAI deployment names are the same as the underlying models. If necessary, update the deployment name parameters to match your `gpt-4o-mini` and `text-embedding-3-small` deployment names:

    ```csharp
    // Update these parameter values to match your Azure OpenAI model deployment names
    var chatClient = azureOpenAi.AsChatClient("gpt-4o-mini");
    var embeddingGenerator = azureOpenAi.AsEmbeddingGenerator("text-embedding-3-small");
    ```

1. Select the run button at the top of Visual Studio to launch the app. After a moment, you should see the following UI load in the browser:

    > [!NOTE]
    > To avoid authentication errors, make sure you are signed-in to Visual Studio or the Azure CLI with a user that is assigned the **Azure AI Developer** role on your Azure OpenAI resource.

    :::image type="content" source="../media/ai-templates/app-ui.png" alt-text="A screenshot showing the UI of the .NET AI app template.":::

1. Enter a prompt into the input box such as *"What are some essential tools in the survival kit?"* to ask your AI model a question about the ingested data from the `Example.pdf` file.

    :::image type="content" source="../media/ai-templates/app-ui-question.png" alt-text="A screenshot showing the conversational UI of the .NET AI app template.":::

    The app responds with an answer to the question and provides citations of where it found the data. You can click on one of the citations to be directed to the relevant section of the `Example.pdf` file.

## Next steps

- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
