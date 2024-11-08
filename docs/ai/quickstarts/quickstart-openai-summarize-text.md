---
title: Quickstart - Summarize text using an AI chat app with .NET
description: Create a simple chat app using Microsoft.Extensions.AI and the Semantic Kernel SDK to summarize a text.
ms.date: 07/17/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: dotnet-ai-library
# CustomerIntent: As a .NET developer new to OpenAI, I want deploy and use sample code to interact to learn from the sample code to summarize text.
---

# Connect to and prompt an AI model using .NET

In this quickstart, get started with AI by creating a .NET console chat app to connect to and prompt an OpenAI or Azure OpenAI model. The app uses abstractions from the [`Microsoft.Extensions.AI`](https://www.nuget.org/packages/Microsoft.Extensions.AI) library that allow you to easily update the underlying AI model without requiring changes to your app logic.

## Prerequisites

# [Azure OpenAI](#tab/azure-openai)

[!INCLUDE [azure-openai-prereqs](includes/prerequisites-azure-openai.md)]

# [OpenAI](#tab/openai)

[!INCLUDE [openai-prereqs](includes/prerequisites-openai.md)]

---

## Clone the sample repository

[!INCLUDE [clone-sample-repo](includes/clone-sample-repo.md)]

## Create the AI service

# [Azure OpenAI](#tab/azd)

Choose of the options below to create an Azure OpenAI service.

### Use the Azure Developer CLI

[!INCLUDE [deploy-azd](includes/deploy-azd.md)]

### Use the Azure portal or Azure CLI

1. To provision an Azure OpenAI service using another tool such as the Azure portal or Azure CLI, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=cli) article.

1. Assign the `Azure AI Developer` role to the account you used to sign-in to Visual Studio or the Azure CLI. The sample app uses a secretless approach to connect to the Azure OpenAI service using Microsoft Entra ID.

# [OpenAI](#tab/openai)

If you plan to use an OpenAI Model, this quickstart assumes you already have a service setup and available. You'll need the access key and AI service endpoint  to connect your code.

---

:::zone target="docs" pivot="microsoft-extensions-ai"

[!INCLUDE [extensions-ai](includes/connect-prompt/extensions-ai.md)]

:::zone-end

:::zone target="docs" pivot="semantic-kernel"

[!INCLUDE [extensions-ai](includes/connect-prompt/semantic-kernel.md)]

:::zone-end

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```


## Next steps

- [Quickstart - Build an AI chat app with .NET](get-started-openai.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
