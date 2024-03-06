---
title: Scale Azure OpenAI for .NET chat sample using RAG
description: Learn how to add load balancing to your application to extend the chat app beyond the Azure OpenAI token and model quota limits.
ms.date: 03/06/2024
ms.topic: get-started
ms.custom: devx-track-java, devx-track-java-ai
# CustomerIntent: As a .NET developer new to Azure OpenAI, I want to scale my OpenAI capacity to avoid rate limit errors.
---

# Scale Azure OpenAI for .NET chat using RAG with Azure Container Apps

[!INCLUDE [aca-load-balancer-intro](~/azure-dev-docs-pr/articles/intro/includes//scaling-load-balancer-introduction-azure-container-apps.md)]

## Prerequisites

* Azure subscription.  [Create one for free](https://azure.microsoft.com/free/ai-services?azure-portal=true)
* Access granted to Azure OpenAI in the desired Azure subscription.

    Currently, access to this service is granted only by application. You should [apply for access](https://aka.ms/oai/access) to Azure OpenAI.

* [Dev containers](https://containers.dev/) are available for both samples, with all dependencies required to complete this article. You can run the dev containers in GitHub Codespaces (in a browser) or locally using Visual Studio Code.

#### [Codespaces (recommended)](#tab/github-codespaces)

* GitHub account

#### [Visual Studio Code](#tab/visual-studio-code)

* [Azure Developer CLI](/azure/developer/azure-developer-cli/install-azd)
* [Docker Desktop](https://www.docker.com/products/docker-desktop/) - start Docker Desktop if it's not already running
* [Visual Studio Code](https://code.visualstudio.com/) with [Dev Container Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers)

---

[!INCLUDE [scaling-load-balancer-aca-procedure.md](~/azure-dev-docs-pr/articles/intro/includes//scaling-load-balancer-procedure-azure-container-apps.md)]

[!INCLUDE [redeployment-procedure](~/azure-dev-docs-pr/articles/intro/includes//redeploy-procedure-chat.md)]

[!INCLUDE [logs](~/azure-dev-docs-pr/articles/intro/includes//scaling-load-balancer-logs-azure-container-apps.md)]

[!INCLUDE [capacity.md](~/azure-dev-docs-pr/articles/intro/includes//scaling-load-balancer-capacity.md)]

[!INCLUDE [aca-cleanup](~/azure-dev-docs-pr/articles/intro/includes//scaling-load-balancer-cleanup-azure-container-apps.md)]

## Sample code

Samples used in this article include:

* [.NET chat app with RAG](https://github.com/Azure-Samples/azure-search-openai-demo-csharp)
* [Load Balancer with Azure Container Apps](https://github.com/Azure-Samples/openai-aca-lb)

## Next step

* Use [Azure Load Testing](/azure/load-testing/) to load test your chat app
