---
title: Scale Azure OpenAI for .NET with Azure API Management
description: Learn how to add load balancing to your .NET application to extend the chat app beyond the Azure OpenAI token and model quota limits with Azure API Management.
ms.date: 03/28/2024
ms.topic: get-started
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
# CustomerIntent: As a .NET developer new to Azure OpenAI, I want to scale my Azure OpenAI capacity to avoid rate limit errors with Azure API Management.
---

# Scale Azure OpenAI for .NET chat using RAG with Azure API Management

[!INCLUDE [aca-load-balancer-intro](~/azure-dev-docs-pr/articles/intro/includes/scaling-load-balancer-introduction-azure-api-management.md)]

## Prerequisites

* Azure subscription.  [Create one for free](https://azure.microsoft.com/free/ai-services?azure-portal=true) 
* Access granted to Azure OpenAI in the desired Azure subscription.

    Currently, access to this service is granted only by application. You can apply for access to Azure OpenAI by completing the form at https://aka.ms/oai/access.

* [Dev containers](https://containers.dev/) are available for both samples, with all dependencies required to complete this article. You can run the dev containers in GitHub Codespaces (in a browser) or locally using Visual Studio Code.

    #### [Codespaces (recommended)](#tab/github-codespaces)
    
    * Only a [GitHub account](https://www.github.com/login) is required to use Codespaces
    
    #### [Visual Studio Code](#tab/visual-studio-code)
    * [Azure Developer CLI](~/azure-dev-docs-pr/articles/azure-developer-cli/install-azd.md?tabs=winget-windows%2Cbrew-mac%2Cscript-linux&pivots=os-windows)
    * [Docker Desktop](https://www.docker.com/products/docker-desktop/) - start Docker Desktop if it's not already running
    * [Visual Studio Code](https://code.visualstudio.com/) with [Dev Container Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers)
    
    ---

[!INCLUDE [scaling-load-balancer-aca-procedure.md](~/azure-dev-docs-pr/articles/intro/includes/scaling-load-balancer-procedure-azure-api-management.md)]

[!INCLUDE [deployment-procedure](~/azure-dev-docs-pr/articles/intro/includes/redeploy-procedure-chat-azure-api-management.md)]

[!INCLUDE [capacity.md](~/azure-dev-docs-pr/articles/intro/includes/scaling-load-balancer-capacity.md)]

[!INCLUDE [py-apim-cleanup](~/azure-dev-docs-pr/articles/intro/includes/scaling-load-balancer-cleanup-azure-api-management.md)]

## Sample code

Samples used in this article include: 

* [.NET chat app with RAG](https://github.com/Azure-Samples/azure-search-openai-demo-csharp)
* [Load Balancer with Azure API Management](https://github.com/Azure-Samples/openai-apim-lb)

## Next step

* [View Azure API Management diagnostic data in Azure Monitor](/azure/api-management/api-management-howto-use-azure-monitor#view-diagnostic-data-in-azure-monitor)
* Use [Azure Load Testing](/azure/load-testing/) to load test your chat app with 
