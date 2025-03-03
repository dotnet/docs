---
ms.date: 2/21/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
---

## Prerequisites

* .NET 9.0 SDK - [Install the .NET 9.0 SDK](https://dotnet.microsoft.com/download)
* Visual Studio 2022 - [Install Visual Studio 2022](https://code.visualstudio.com/) (optional)
* Access to an [OpenAI service](https://openai.com/api/) and the corresponding API key.

## Install the .NET AI app template

The **AI Chat Web App** template is available as a template package through NuGet. Use the [`dotnet new`](../../../core/tools/dotnet-new-install.md) command to install the package:

```dotnetcli
dotnet new --install Microsoft.Extensions.AI.Templates
```

## Create the .NET AI app

After you install the AI app templates, you can use them to create starter apps through Visual Studio UI, Visual Studio Code, or the .NET CLI.

# [Visual Studio](#tab/visual-studio)

1. Inside Visual Studio, navigate to **File > New > Project**.
1. On the **Create a new project** screen, search for **AI Chat Web App**. Select the matching result and then choose **Next**.
1. On the **Configure your new project** screen, enter the desired name and location for your project and then choose **Next**.
1. On the **Additional information** screen:
    - For the **Framework** option, select **.NET 9.0**.
    - For the **AI service provider** option, select **OpenAI**.
    - For the **Vector store** option, select **Local on-disk (for prototyping)**.
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
    dotnet new aichatweb --framework "net9.0" --AIServiceProvider "openai" --VectorStore "local"
    ```

    The .NET CLI creates a new .NET 9.0 app with the configurations you specified.

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

---

### Explore the sample app

[!INCLUDE [ai-templates-explore-app](ai-templates-explore-app.md)]

## Configure the app

The **AI Chat Web App** app is almost ready to go as soon as it's created. However, you'll need to provide the key for your OpenAI service that the app will use to connect and authenticate. By default, the app template searches for this value in the project's local .NET user secrets. You can manage user secrets using either the Visual Studio UI or the .NET CLI.

# [Visual Studio](#tab/configure-visual-studio)

1. In Visual Studio, right-click on your project in the Solution Explorer and select "Manage User Secrets". This opens a `secrets.json` file where you can store your API keys without them being tracked in source control.

2. Add the following key and value:

    ```json
    {
        "OpenAi:Key": "<your-openai-key>"
    }
    ```

# [.NET CLI](#tab/configure-dotnet-cli)

```dotnetcli
dotnet user-secrets set OpenAi:Key <your-openai-key>
```

---

By default, the app template assumes the use of certain AI models. If necessary, update the model name parameters to match your the models you want to target:

```csharp
// Update these parameter values to match your preferred OpenAI models
var chatClient = openAIClient.AsChatClient("gpt-4o-mini");
var embeddingGenerator = openAIClient.AsEmbeddingGenerator("text-embedding-3-small");
```
