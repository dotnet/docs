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

:::zone target="docs" pivot="microsoft-extensions-ai"

In this quickstart, learn how to create a .NET console chat app to connect to and prompt an OpenAI or Azure OpenAI model. The app uses the [`Microsoft.Extensions.AI`](https://www.nuget.org/packages/Microsoft.Extensions.AI) library so you can write code using AI abstractions rather than a specific SDK. AI abstractions enable you to change the underlying AI model with minimal code changes.

:::zone-end

:::zone target="docs" pivot="semantic-kernel"

In this quickstart, learn how to create a .NET console chat app to connect to and prompt an OpenAI or Azure OpenAI model using [`Semantic Kernel`](/semantic-kernel/overview). Semantic Kernel is a lightweight, open-source development kit that lets you easily build AI agents and integrate the latest AI models into your C#, Python, or Java codebase. It serves as an efficient middleware that enables rapid delivery of enterprise-grade solutions.

:::zone-end

## Prerequisites

# [Azure OpenAI](#tab/azure-openai)

[!INCLUDE [azure-openai-prereqs](includes/prerequisites-azure-openai.md)]

# [OpenAI](#tab/openai)

[!INCLUDE [openai-prereqs](includes/prerequisites-openai.md)]

---

## Clone the sample repository

[!INCLUDE [clone-sample-repo](includes/clone-sample-repo.md)]

:::zone target="docs" pivot="microsoft-extensions-ai"

[!INCLUDE [extensions-ai](includes/connect-prompt/extensions-ai.md)]

:::zone-end

:::zone target="docs" pivot="semantic-kernel"

[!INCLUDE [semantic-kernel](includes/connect-prompt/semantic-kernel.md)]

:::zone-end

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

## Next steps

- [Quickstart - Build an AI chat app with .NET](get-started-openai.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
