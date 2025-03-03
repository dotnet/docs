---
title: Quickstart - Create a .NET AI app using the AI app template
description: Create a .NET AI app to chat with custom data using the AI app template extensions and the Microsoft.Extensions.AI libraries
ms.date: 2/21/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
zone_pivot_groups: meai-targets
---

# Create a .NET AI app to chat with custom data using the AI app template extensions

In this quickstart, you learn how to create a .NET AI app to chat with custom data using the .NET AI app template extensions. These extensions provide additional starter app templates for Visual Studio and the .NET CLI. The templates are designed to streamline the  getting started experience for building AI apps with .NET by handling common setup tasks and configurations for you.

:::zone target="docs" pivot="github-models"

[!INCLUDE [ai-templates-github-models](includes/ai-templates-github-models.md)]

:::zone-end

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [ai-templates-azure-openai](includes/ai-templates-azure-openai.md)]

:::zone-end

:::zone target="docs" pivot="openai"

[!INCLUDE [ai-templates-openai](includes/ai-templates-openai.md)]

:::zone-end

:::zone target="docs" pivot="ollama"

[!INCLUDE [ai-templates-ollama](includes/ai-templates-ollama.md)]

:::zone-end

## Run and test the app

1. Select the run button at the top of Visual Studio to launch the app. After a moment, you should see the following UI load in the browser:

    :::image type="content" source="../media/ai-templates/app-ui.png" alt-text="A screenshot showing the UI of the .NET AI app template.":::

1. Enter a prompt into the input box such as *"What are some essential tools in the survival kit?"* to ask your AI model a question about the ingested data from the example files.

    :::image type="content" source="../media/ai-templates/app-ui-question.png" alt-text="A screenshot showing the conversational UI of the .NET AI app template.":::

    The app responds with an answer to the question and provides citations of where it found the data. You can click on one of the citations to be directed to the relevant section of the example files.

## Next steps

- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
