---
title: Get started with the chat using your own data sample for .NET 
description: Get started with .NET and search across your own data using a chat app sample implemented using Azure OpenAI Service and Retrieval Augmented Generation (RAG) in Azure AI Search. Easily deploy with Azure Developer CLI. This article uses the Azure AI Reference Template sample.
ms.date: 05/16/2024
ms.topic: get-started
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
# CustomerIntent: As a .NET developer new to Azure OpenAI, I want deploy and use sample code to interact with app infused with my own business data so that learn from the sample code.
---

# Get started with the chat using your own data sample for .NET

This article shows you how to deploy and run the [Chat with your own data sample for .NET](https://github.com/Azure-Samples/azure-search-openai-demo-csharp). This sample implements a chat app using C#, Azure OpenAI Service, and [Retrieval Augmented Generation (RAG)](/azure/search/retrieval-augmented-generation-overview) in Azure AI Search to get answers about employee benefits at a fictitious company. The employee benefits chat app is seeded with PDF files including an employee handbook, a benefits document and a list of company roles and expectations.

* [Demo video](https://aka.ms/azai/net/video)

By following the instructions in this article, you will:

- Deploy a chat app to Azure.
- Get answers about employee benefits.
- Change settings to change behavior of responses.

Once you complete this procedure,you can start modifying the new project with your custom code.

This article is part of a collection of articles that show you how to build a chat app using Azure Open AI Service and Azure AI Search.

Other articles in the collection include:

- [Python](/azure/developer/python/get-started-app-chat-template)
- [JavaScript](/azure/developer/javascript/get-started-app-chat-template)
- [Java](/azure/developer/java/quickstarts/get-started-app-chat-template)

## Architectural overview

In this sample application, a fictitious company called Contoso Electronics provides the chat app experience to its employees to ask questions about the benefits, internal policies, as well as job descriptions and roles.

The architecture of the chat app is shown in the following diagram:

:::image type="content" source="./media/get-started-app-chat-template/simple-architecture-diagram.png" lightbox="./media/get-started-app-chat-template/simple-architecture-diagram.png" alt-text="Diagram showing architecture from client to backend app.":::

- **User interface** - The application's chat interface is a [Blazor WebAssembly](/aspnet/core/blazor/) application. This interface is what accepts user queries, routes request to the application backend, and displays generated responses.
- **Backend** - The application backend is an [ASP.NET Core Minimal API](/aspnet/core/fundamentals/minimal-apis/overview). The backend hosts the Blazor static web application and is what orchestrates the interactions among the different services. Services used in this application include:
  - [**Azure Cognitive Search**](/azure/search/search-what-is-azure-search) – Indexes documents from the data stored in an Azure Storage Account. This makes the documents searchable using [vector search](/azure/search/search-get-started-vector) capabilities.
  - [**Azure OpenAI Service**](/azure/ai-services/openai/overview) – Provides the Large Language Models (LLM) to generate responses. [Semantic Kernel](/semantic-kernel/whatissk) is used in conjunction with the Azure OpenAI Service to orchestrate the more complex AI workflows.

## Cost

Most resources in this architecture use a basic or consumption pricing tier. Consumption pricing is based on usage, which means you only pay for what you use. To complete this article, there will be a charge but it will be minimal. When you are done with the article, you can delete the resources to stop incurring charges.

For more information, see [Azure Samples: Cost in the sample repo](https://github.com/Azure-Samples/azure-search-openai-demo-csharp#cost-estimation).

## Prerequisites

A [development container](https://containers.dev/) environment is available with all dependencies required to complete this article. You can run the development container in GitHub Codespaces (in a browser) or locally using Visual Studio Code.

To follow along with this article, you need the following prerequisites:

#### [Codespaces (recommended)](#tab/github-codespaces)

* An Azure subscription - [Create one for free](https://azure.microsoft.com/free/ai-services?azure-portal=true)
* Azure account permissions - Your Azure Account must have Microsoft.Authorization/roleAssignments/write permissions, such as [User Access Administrator](/azure/role-based-access-control/built-in-roles#user-access-administrator) or [Owner](/azure/role-based-access-control/built-in-roles#owner).
* Access granted to Azure OpenAI in the desired Azure subscription.
    Currently, access to this service is granted only by application. You can apply for access to Azure OpenAI by completing the form at [https://aka.ms/oai/access](https://aka.ms/oai/access). Open an issue on this repo to contact us if you have an issue.
* GitHub account

#### [Visual Studio Code](#tab/visual-studio-code)

* An Azure subscription - [Create one for free](https://azure.microsoft.com/free/ai-services?azure-portal=true)
* Azure account permissions - Your Azure Account must have Microsoft.Authorization/roleAssignments/write permissions, such as [User Access Administrator](/azure/role-based-access-control/built-in-roles#user-access-administrator) or [Owner](/azure/role-based-access-control/built-in-roles#owner).
* Access granted to Azure OpenAI in the desired Azure subscription.
    Currently, access to this service is granted only by application. You can apply for access to Azure OpenAI by completing the form at [https://aka.ms/oai/access](https://aka.ms/oai/access). Open an issue on this repo to contact us if you have an issue.
* [Azure Developer CLI](/azure/developer/azure-developer-cli)
* [Docker Desktop](https://www.docker.com/products/docker-desktop/) - start Docker Desktop if it's not already running
* [Visual Studio Code](https://code.visualstudio.com/)
* [Dev Container Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers)

---

## Open development environment

Begin now with a development environment that has all the dependencies installed to complete this article.

#### [GitHub Codespaces (recommended)](#tab/github-codespaces)

[GitHub Codespaces](https://docs.github.com/codespaces) runs a development container managed by GitHub with [Visual Studio Code for the Web](https://code.visualstudio.com/docs/editor/vscode-web) as the user interface. For the most straightforward development environment, use GitHub Codespaces so that you have the correct developer tools and dependencies preinstalled to complete this article.

> [!IMPORTANT]
> All GitHub accounts can use Codespaces for up to 60 hours free each month with 2 core instances. For more information, see [GitHub Codespaces monthly included storage and core hours](https://docs.github.com/billing/managing-billing-for-github-codespaces/about-billing-for-github-codespaces#monthly-included-storage-and-core-hours-for-personal-accounts).

1. Start the process to create a new GitHub Codespace on the `main` branch of the [`Azure-Samples/azure-search-openai-demo-csharp`](https://github.com/Azure-Samples/azure-search-openai-demo-csharp) GitHub repository.
1. Right-click on the following button, and select _Open link in new windows_ in order to have both the development environment and the documentation available at the same time.

    [![Open this project in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Azure-Samples/azure-search-openai-demo-csharp)

1. On the **Create codespace** page, review the codespace configuration settings and then select **Create new codespace**:

    :::image type="content" source="./media/get-started-app-chat-template/github-create-codespace.png" alt-text="Screenshot of the confirmation screen before creating a new codespace.":::

1. Wait for the codespace to start. This startup process can take a few minutes.

1. In the terminal at the bottom of the screen, sign in to Azure with the Azure Developer CLI.

    ```bash
    azd auth login
    ```

1. Copy the code from the terminal and then paste it into a browser. Follow the instructions to authenticate with your Azure account.

1. The remaining tasks in this article take place in the context of this development container.

#### [Visual Studio Code](#tab/visual-studio-code)

The [Dev Containers extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers) for Visual Studio Code requires [Docker](https://docs.docker.com/) to be installed on your local machine. The extension hosts the development container locally using the Docker host with the correct developer tools and dependencies preinstalled to complete this article.

1. Create a new local directory on your computer for the project.

    ```bash
    mkdir my-intelligent-app && cd my-intelligent-app
    ```

1. Open Visual Studio Code in that directory:

    ```bash
    code .
    ```

1. Open a new terminal in Visual Studio Code.
1. Run the following `azd` command to clone the GitHub repository to your local computer.

    ```bash
    azd init -t azure-search-openai-demo-csharp
    ```

1. Open the Command Palette, and then search for and select **Dev Containers: Open Folder in Container** to open the project in a dev container. Wait until the dev container opens before continuing.
1. Sign in to Azure with the Azure Developer CLI.

    ```bash
    azd auth login
    ```

    Copy the code from the terminal and then paste it into a browser. Follow the instructions to authenticate with your Azure account.

1. The remaining exercises in this project take place in the context of this development container.

---

## Deploy and run

The sample repository contains all the code and configuration files you need to deploy a chat app to Azure. The following steps walk you through the process of deploying the sample to Azure.

### Deploy chat app to Azure

> [!IMPORTANT]
> Azure resources created in this section incur immediate costs, primarily from the Azure AI Search resource. These resources may accrue costs even if you interrupt the command before it is fully executed.

1. Run the following Azure Developer CLI command to provision the Azure resources and deploy the source code:

    ```bash
    azd up
    ```

1. When you're prompted to enter an environment name, keep it short and lowercase. For example, `myenv`. Its used as part of the resource group name.
1. When prompted, select a subscription to create the resources in.
1. When you're prompted to select a location the first time, select a location near you. This location is used for most the resources including hosting.
1. If you're prompted for a location for the OpenAI model, select a location that is near you. If the same location is available as your first location, select that.
1. Wait until app is deployed. It may take up to 20 minutes for the deployment to complete.
1. After the application has been successfully deployed, you see a URL displayed in the terminal.
1. Select that URL labeled `Deploying service web` to open the chat application in a browser.

    :::image type="content" source="./media/get-started-app-chat-template/browser-chat-with-your-data.png" alt-text="Screenshot of chat app in browser showing several suggestions for chat input and the chat text box to enter a question.":::

### Use chat app to get answers from PDF files

The chat app is preloaded with employee benefits information from [PDF files](https://github.com/Azure-Samples/azure-search-openai-demo-csharp/tree/main/data). You can use the chat app to ask questions about the benefits. The following steps walk you through the process of using the chat app.

1. In the browser, navigate to the **Chat** page using the left navigation.
1. Select or enter "What is included in my Northwind Health Plus plan that is not in standard?" in the chat text box. Your response is _similar_ to the following image.

    :::image type="content" source="./media/get-started-app-chat-template/browser-chat-initial-answer.png" lightbox="./media/get-started-app-chat-template/browser-chat-initial-answer.png" alt-text="Screenshot of chat app's first answer.":::

1. From the answer, select a citation. A pop-up window will open displaying the source of the information.

    :::image type="content" source="./media/get-started-app-chat-template/browser-chat-initial-answer-citation-highlighted.png" lightbox="./media/get-started-app-chat-template/browser-chat-initial-answer-citation-highlighted.png" alt-text="Screenshot of chat app's first answer with its citation highlighted in a red box.":::

1. Navigate between the tabs at the top of the answer box to understand how the answer was generated.

    |Tab|Description|
    |---|---|
    |**Thought process**|This is a script of the interactions in chat. You can view the system prompt (`content`) and your user question (`content`).|
    |**Supporting content**|This includes the information to answer your question and the source material. The number of source material citations is noted in the **Developer settings**. The default value is **3**.|
    |**Citation**|This displays the source page that contains the citation.|

1. When you're done, navigate back to the answer tab.

### Use chat app settings to change behavior of responses

The intelligence of the chat is determined by the OpenAI model and the settings that are used to interact with the model.

:::image type="content" source="./media/get-started-app-chat-template/browser-chat-developer-settings-chat-pane.png" alt-text="Screenshot of chat developer settings.":::

|Setting|Description|
|---|---|
|Override prompt template|This is the prompt that is used to generate the answer.|
|Retrieve this many search results|This is the number of search results that are used to generate the answer. You can see these sources returned in the _Thought process_ and _Supporting content_ tabs of the citation. |
|Exclude category|This is the category of documents that are excluded from the search results.|
|Use semantic ranker for retrieval|This is a feature of [Azure AI Search](/azure/search/semantic-search-overview#what-is-semantic-search) that uses machine learning to improve the relevance of search results.|
|Retrieval mode|**Vectors + Text** means that the search results are based on the text of the documents and the embeddings of the documents. **Vectors** means that the search results are based on the embeddings of the documents. **Text** means that the search results are based on the text of the documents.|
|Use query-contextual summaries instead of whole documents|When both `Use semantic ranker` and `Use query-contextual summaries` are checked, the LLM uses captions extracted from key passages, instead of all the passages, in the highest ranked documents.|
|Suggest follow-up questions|Have the chat app suggest follow-up questions based on the answer.|

The following steps walk you through the process of changing the settings.

1. In the browser, select the gear icon in the upper right of the page.
1. If not selected, select the **Suggest follow-up questions** checkbox and ask the same question again.

    ```Text
   What is included in my Northwind Health Plus plan that is not in standard?
    ```

    The chat might return with follow-up question suggestions.

1. In the **Settings** tab, deselect **Use semantic ranker for retrieval**.
1. Ask the same question again.

    ```Text
    What is my deductible?
    ```

1. What is the difference in the answers?

    The response that used the Semantic ranker provided a single answer. The response without semantic ranking returned a less direct answer.

## Clean up resources

### Clean up Azure resources

The Azure resources created in this article are billed to your Azure subscription. If you don't expect to need these resources in the future, delete them to avoid incurring more charges.

Run the following Azure Developer CLI command to delete the Azure resources and remove the source code:

```bash
azd down --purge
```

### Clean up GitHub Codespaces

#### [GitHub Codespaces](#tab/github-codespaces)

Deleting the GitHub Codespaces environment ensures that you can maximize the amount of free per-core hours entitlement you get for your account.

> [!IMPORTANT]
> For more information about your GitHub account's entitlements, see [GitHub Codespaces monthly included storage and core hours](https://docs.github.com/billing/managing-billing-for-github-codespaces/about-billing-for-github-codespaces#monthly-included-storage-and-core-hours-for-personal-accounts).

1. Sign into the GitHub Codespaces dashboard (<https://github.com/codespaces>).

1. Locate your currently running codespaces sourced from the [`Azure-Samples/azure-search-openai-demo-csharp`](https://github.com/Azure-Samples/azure-search-openai-demo-csharp) GitHub repository.

    :::image type="content" source="./media/get-started-app-chat-template/github-codespace-dashboard.png" alt-text="Screenshot of all the running codespaces including their status and templates.":::

1. Open the context menu for the codespace and then select **Delete**.

    :::image type="content" source="./media/get-started-app-chat-template/github-codespace-delete.png" alt-text="Screenshot of the context menu for a single codespace with the delete option highlighted.":::

#### [Visual Studio Code](#tab/visual-studio-code)

You aren't necessarily required to clean up your local environment, but you can stop the running development container and return to running Visual Studio Code in the context of a local workspace.

1. Open the **Command Palette**, search for the **Dev Containers** commands, and then select **Dev Containers: Reopen Folder Locally**.

    :::image type="content" source="./media/get-started-app-chat-template/reopen-local-command-palette.png" alt-text="Screenshot of the Command Palette option to reopen the current folder within your local environment.":::

> [!TIP]
> Visual Studio Code will stop the running development container, but the container still exists in Docker in a stopped state. You always have the option to deleting the container instance, container image, and volumes from Docker to free up more space on your local machine.

---

## Get help

This sample repository offers [troubleshooting information](https://github.com/Azure-Samples/azure-search-openai-demo-csharp/tree/main#troubleshooting).

If your issue isn't addressed, log your issue to the repository's [Issues](https://github.com/Azure-Samples/azure-search-openai-demo-csharp/issues).

## Next steps

- [Get the source code for the sample used in this article](https://github.com/Azure-Samples/azure-search-openai-demo-csharp)
- [Build a chat app with Azure OpenAI](https://aka.ms/azai/chat) best practice solution architecture
- [Access control in Generative AI Apps with Azure AI Search](https://techcommunity.microsoft.com/t5/azure-ai-services-blog/access-control-in-generative-ai-applications-with-azure/ba-p/3956408)
- [Build an Enterprise ready OpenAI solution with Azure API Management](https://techcommunity.microsoft.com/t5/apps-on-azure-blog/build-an-enterprise-ready-azure-openai-solution-with-azure-api/bc-p/3935407)
- [Outperforming vector search with hybrid retrieval and ranking capabilities](https://techcommunity.microsoft.com/t5/azure-ai-services-blog/azure-cognitive-search-outperforming-vector-search-with-hybrid/ba-p/3929167)
