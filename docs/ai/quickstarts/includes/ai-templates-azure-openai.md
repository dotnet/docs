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

The **AI Chat Web App** template is available as a template package through NuGet. Use the [`dotnet new install`](../../../core/tools/dotnet-new-install.md) command to install the package:

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
    - For the **AI service provider** option, select **Azure OpenAI**.
    - Make sure the **Use keyless authentication for Azure services** checkbox is checked.
    - For the **Vector store** option, select **Local on-disc (for prototyping)**.
1. Select **Create** to complete the process.

# [Visual Studio Code](#tab/visual-studio-code)

1. Open the command palette in Visual Studio Code.
1. Search for *New project* and select the result called **.NET: New Project**.
1. Filter the project templates list by searching for *AI*.
1. Select **AI Chat Web App** and press <kbd>Enter</kbd>.

> [!NOTE]
> The command palette experience currently only supports the default settings. To configure your AI platform and vector store during template creation, use the Visual Studio or .NET CLI workflows.

# [.NET CLI](#tab/dotnet-cli)

1. In a terminal window, navigate to an empty directory on your device.
1. Create a new app with the `dotnet new` command and the following parameters:

    ```dotnetcli
    dotnet new aichatweb --framework "net9.0" --AiServiceProvider "azureopenai" --VectorStore "local"
    ```

    The .NET CLI creates a new .NET 9.0 app with the configurations you specified.

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

---

### Explore the sample app

[!INCLUDE [ai-templates-explore-app](ai-templates-explore-app.md)]

## Create and authenticate to the Azure OpenAI service

To use the .NET AI templates with Azure OpenAI, you'll need to create and authenticate to an Azure OpenAI service.

### Create the Azure OpenAI service

1. [Create an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=web-portal) if you don't already have one available.

1. Deploy the `gpt-4o-mini` and `text-embedding-3-small` models to your Azure OpenAI Service resource. When creating those deployments, give them the same names as the models (`gpt-4o-mini` and `text-embedding-3-small`). To learn how to deploy a model, see [Create a resource](/azure/ai-services/openai/how-to/create-resource?pivots=web-portal#deploy-a-model) in the Azure OpenAI docs.

### Authenticate to the Azure OpenAI service

The AI template uses Microsoft Entra ID for seamless, keyless authentication. It leverages [`DefaultAzureCredential`](/dotnet/api/azure.identity.defaultazurecredential) to automatically detect and utilize credentials from your development tools when running locally. To connect to the service, ensure your developer account has the appropriate roles assigned and is signed in to your local development tools.

1. Assign a role to your developer account to access the Azure OpenAI resource:

    - In the Azure Portal, navigate to the overview page of your Azure OpenAI resource.
    - Select **Access control (IAM)** from the left navigation.
    - [Add a role assignment](/dotnet/azure/sdk/authentication/local-development-dev-accounts#assign-roles-to-the-group) for the `Azure AI Developer` role to your Azure account.

1. [Sign-in to a local development tool](/dotnet/azure/sdk/authentication/local-development-dev-accounts#sign-in-to-azure-using-developer-tooling) such as Visual Studio or the Azure CLI using the Azure account you assigned the `Azure AI Developer` role to.

## Configure the app

The **AI Chat Web App** app is almost ready to go as soon as it's created. However, you'll need to provide the endpoint for your Azure OpenAI service for the app to connect to. By default, the app template searches for this value in the project's local .NET user secrets. You can manage user secrets using either the Visual Studio UI or the .NET CLI.

> [!NOTE]
> To avoid authentication errors, make sure you're signed in to Visual Studio or the Azure CLI with a user that's assigned the **Azure AI Developer** role on your Azure OpenAI resource.

# [Visual Studio](#tab/configure-visual-studio)

1. In Visual Studio, right-click on your project in the Solution Explorer and select "Manage User Secrets". This opens a `secrets.json` file where you can store your API keys without them being tracked in source control.

2. Add the following key and value:

    ```json
    {
        "AzureOpenAi:Endpoint": "<your-endpoint>"
    }
    ```

# [.NET CLI](#tab/configure-dotnet-cli)

```dotnetcli
dotnet user-secrets set AzureOpenAi:Endpoint <your-azure-openai-endpoint>
```

---

By default, the app template assumes your AI model deployment names are the same as the underlying models. If necessary, update the deployment name parameters to match your `gpt-4o-mini` and `text-embedding-3-small` deployment names:

```csharp
// Update these parameter values to match your Azure OpenAI model deployment names
var chatClient = azureOpenAi.AsChatClient("gpt-4o-mini");
var embeddingGenerator = azureOpenAi.AsEmbeddingGenerator("text-embedding-3-small");
```
