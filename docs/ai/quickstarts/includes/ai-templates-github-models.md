---
ms.date: 2/21/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
---

## Prerequisites

* .NET 9.0 SDK - [Install the .NET 9.0 SDK](https://dotnet.microsoft.com/download)
* Visual Studio 2022 - [Install Visual Studio 2022](https://visualstudio.microsoft.com/) (optional), or
* Visual Studio Code - [Install Visual Studio Code](https://code.visualstudio.com) (optional)
  * With the C# DevKit - [Install C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

## Install the .NET AI app template

The **AI Chat Web App** template is available as a template package through NuGet. Use the [`dotnet new`](../../../core/tools/dotnet-new-install.md) command to install the package:

```dotnetcli
dotnet new install Microsoft.Extensions.AI.Templates
```

## Create the .NET AI app

After you install the AI app templates, you can use them to create starter apps through Visual Studio UI, Visual Studio Code, or the .NET CLI.

# [Visual Studio](#tab/visual-studio)

1. Inside Visual Studio, navigate to **File > New > Project**.
1. On the **Create a new project** screen, search for **AI Chat Web App**. Select the matching result and then choose **Next**.
1. On the **Configure your new project** screen, enter the desired name and location for your project and then choose **Next**.
1. On the **Additional information** screen:
    - For the **Framework** option, select **.NET 9.0**.
    - For the **AI service provider** option, select **GitHub Models**.
    - Make sure the **Use managed identity** checkbox is checked.
    - For the **Vector store** option, select **Local on-disc (for prototyping)**.
1. Select **Create** to complete the process.

# [Visual Studio Code](#tab/visual-studio-code)

1. Open the command pallete in Visual Studio Code.
1. Search for *New project* and select the matching result **.NET: New Project**.
1. Filter the project templates list by searching for *AI*.
1. Select **AI Chat Web App** and press enter.

> [!NOTE]
> The command palette experience currently only supports the default settings. To configure your AI platform and vectore store during template creation, use the Visual Studio or .NET CLI workflows.

# [.NET CLI](#tab/dotnet-cli)

1. In a terminal window, navigate to an empty directory on your device.
1. Create a new app with the `dotnet new` command and the following parameters:

    ```dotnetcli
    dotnet new aichatweb --framework net9.0 --AiServiceProvider githubmodels --VectorStore local
    ```

    The .NET CLI creates a new .NET 9.0 app with the configurations you specified.

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

---

### Explore the sample app

The sample app you created is a Blazor Interactive Server web app preconfigured with common AI and data services. The app handles the following concerns for you:

- Includes essential `Microsoft.Extensions.AI` packages and other dependencies in the `csproj` file to help you get started working with AI.
- Creates various AI services and registers them for dependency injection in the `Program.cs` file:
  - An `IChatClient` service to chat back and forth with the generative AI model
  - An `IEmbeddingGenerator` service that's used to generate embeddings, which are essential for vector search functionality
  - A `JsonVectorStore` to act as an in-memory vector store
- Registers a SQLite database context service to handle ingesting documents. The app is preconfigured to ingest whatever documents you add to the `Data` folder of the project, including the provided example files.
- Provides a complete chat UI using Blazor components. The UI handles rich formatting for the AI responses and provides features such as citations for response data.

## Configure access to GitHub Models

To authenticate to GitHub models from your code, you'll need to create a GitHub personal access token:

1. Navigate to the **Personal access tokens** page of your GitHub account settings.
1. Select **Generate new token**.
1. Enter a **Token name** and then select **Generate token** at the bottom of the page.
1. Copy the token for use in the steps ahead.

## Configure the app

The **AI Chat Web App** app is almost ready to go as soon as it's created. However, you'll need to provide the endpoint for your Azure OpenAI service for the app to connect to. By default, the app template searches for this value in the project's local .NET user secrets. You can manage user secrets using either the Visual Studio UI or the .NET CLI.

# [Visual Studio](#tab/configure-visual-studio)

1. In Visual Studio, right-click on your project in the Solution Explorer and select "Manage User Secrets". This opens a `secrets.json` file where you can store your API keys without them being tracked in source control.

2. Add the following key and value:

    ```json
    {
        "GitHubModels:Token": "<your-personal-access-token>"
    }
    ```

# [.NET CLI](#tab/configure-dotnet-cli)

```dotnetcli
dotnet user-secrets set AzureOpenAi:Endpoint <your-personal-access-token>
```

---

By default, the app template uses the `gpt-4o-mini` and `text-embedding-3-small` models. To try other models, update the name parameters in `Program.cs`:

  ```csharp
  var chatClient = ghModelsClient.AsChatClient("gpt-4o-mini");
  var embeddingGenerator = ghModelsClient.AsEmbeddingGenerator("text-embedding-3-small");
  ```
