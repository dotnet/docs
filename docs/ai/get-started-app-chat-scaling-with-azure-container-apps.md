---
title: Scale Azure OpenAI for .NET chat sample using RAG
description: Learn how to add load balancing to your application to extend the chat app beyond the Azure OpenAI token and model quota limits.
ms.date: 05/29/2025
ms.topic: get-started
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
# CustomerIntent: As a .NET developer new to Azure OpenAI, I want to scale my Azure OpenAI capacity to avoid rate limit errors with Azure Container Apps.
---

# Scale Azure OpenAI for .NET chat using RAG with Azure Container Apps

[!INCLUDE [aca-load-balancer-intro](~/azure-dev-docs-pr/articles/ai/includes//scaling-load-balancer-introduction-azure-container-apps.md)]

## Prerequisites

* Azure subscription. [Create one for free](https://azure.microsoft.com/free/ai-services?azure-portal=true).

[Dev containers](https://containers.dev/) are available for both samples, with all dependencies required to complete this article. You can run the dev containers in GitHub Codespaces (in a browser) or locally using Visual Studio Code.

#### [Codespaces (recommended)](#tab/github-codespaces)

* Only a [GitHub account](https://www.github.com/login) is required to use CodeSpaces

#### [Visual Studio Code](#tab/visual-studio-code)

* [Docker Desktop](https://www.docker.com/products/docker-desktop/) - Start Docker Desktop if it's not already running
* [Visual Studio Code](https://code.visualstudio.com/)
* [Dev Container Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers)

---

[!INCLUDE [scaling-load-balancer-aca-procedure.md](~/azure-dev-docs-pr/articles/ai/includes//scaling-load-balancer-procedure-azure-container-apps.md)]

[!INCLUDE [redeployment-procedure](~/azure-dev-docs-pr/articles/ai/includes//redeploy-procedure-chat.md)]

[!INCLUDE [logs](~/azure-dev-docs-pr/articles/ai/includes//scaling-load-balancer-logs-azure-container-apps.md)]

[!INCLUDE [capacity.md](~/azure-dev-docs-pr/articles/ai/includes//scaling-load-balancer-capacity.md)]

[!INCLUDE [aca-cleanup](~/azure-dev-docs-pr/articles/ai/includes//scaling-load-balancer-cleanup-azure-container-apps.md)]

## Sample code

Samples used in this article include:

* [.NET chat app with RAG](https://github.com/Azure-Samples/azure-search-openai-demo-csharp)
* [Load Balancer with Azure Container Apps](https://github.com/Azure-Samples/openai-aca-lb)

## Next step

* Use [Azure Load Testing](/azure/load-testing/) to load test your chat app
