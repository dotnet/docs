---
title: Quickstart - Create a minimal AI assistant using .NET
description: Learn to create a minimal AI assistant with tooling capabilities using .NET and the Azure OpenAI SDK libraries
ms.date: 01/25/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
zone_pivot_groups: openai-library
---

# Create a minimal AI assistant using .NET

In this quickstart, you'll learn how to create a minimal AI assistant using the OpenAI or Azure OpenAI SDK libraries. AI assistants provide agentic functionality to help users complete tasks using AI tools and models. In the sections ahead, you'll learn the following:

- Core components and concepts of AI assistants
- How to create an assistant using the Azure OpenAI SDK
- How to enhance and customize the capabilities of an assistant

## Prerequisites

::: zone pivot="openai"

* [Install .NET 8.0](https://dotnet.microsoft.com/download) or higher
* [Visual Studio Code](https://code.visualstudio.com/) (optional)
* [Visual Studio](https://visualstudio.com/) (optional)
* An access key for an OpenAI model

:::zone-end

::: zone pivot="azure-openai"

* [Install .NET 8.0](https://dotnet.microsoft.com/download) or higher
* [Visual Studio Code](https://code.visualstudio.com/) (optional)
* [Visual Studio](https://visualstudio.com/) (optional)
* Access to an Azure OpenAI instance via Azure Identity or an access key

:::zone-end

## Core components of AI assistants

AI assistants are based around conversational threads with a user. The user sends prompts to the assistant on a conversation thread, which direct the assistant to complete tasks using the tools it has available. Assistants can process and analyze data, make decisions, and interact with users or other systems to achieve specific goals. Most assistants include the following components:

| **Component** | **Description** |
|---------------|-----------------|
| **Assistant** | The core AI client and logic that uses Azure OpenAI models, manages conversation threads, and utilizes configured tools. |
| **Thread**    | A conversation session between an assistant and a user. Threads store messages and automatically handle truncation to fit content into a model's context. |
| **Message**   | A message created by an assistant or a user. Messages can include text, images, and other files. Messages are stored as a list on the thread. |
| **Run**       | Activation of an assistant to begin running based on the contents of the thread. The assistant uses its configuration and the thread's messages to perform tasks by calling models and tools. As part of a run, the assistant appends messages to the thread. |
| **Run steps** | A detailed list of steps the assistant took as part of a run. An assistant can call tools or create messages during its run. Examining run steps allows you to understand how the assistant is getting to its final results. |

Assistants can also be configured to use multiple tools in parallel to complete tasks, including the following:

- **Code interpreter tool**: Writes and runs code in a sandboxed execution environment.
- **Function calling**: Runs local custom functions you define in your code.
- **File search capabilities**: Augments the assistant with knowledge from outside its model.

By understanding these core components and how they interact, you can build and customize powerful AI assistants to meet your specific needs.

## Create the .NET app

Complete the following steps to create a .NET console app and add the package needed to work with assistants:

::: zone pivot="openai"

1. In a terminal window, navigate to an empty directory on your device and create a new app with the `dotnet new` command:

    ```dotnetcli
    dotnet new console -o AIAssistant
    ```

1. Add the [OpenAI](https://www.nuget.org/packages/OpenAI) package to your app:

    ```dotnetcli
    dotnet package add OpenAI --prerelease
    ```

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

::: zone-end

::: zone pivot="azure-openai"

1. In a terminal window, navigate to an empty directory on your device and create a new app with the `dotnet new` command:

    ```dotnetcli
    dotnet new console -o AIAssistant
    ```

1. Add the [Azure.AI.OpenAI](https://www.nuget.org/packages/Azure.AI.OpenAI) package to your app:

    ```dotnetcli
    dotnet package add Azure.AI.OpenAI --prerelease
    ```

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

::: zone-end

## Create the AI assistant client

1. Open the _Program.cs_ file and replace the contents of the file with the following code to create the required clients:

    :::code language="csharp" source="snippets/assistants/program.cs" range="0-17" :::

1. Create an in-memory sample document and upload it to the `OpenAIFileClient`:

    :::code language="csharp" source="snippets/assistants/program.cs" range="19-53" :::

1. Enable file search and code interpreter tooling capabilities via the `AssistantCreationOptions`:

    :::code language="csharp" source="snippets/assistants/program.cs" range="55-78" :::

1. Create the `Assistant` and a thread to manage interactions between the user and the assistant:

    :::code language="csharp" source="snippets/assistants/program.cs" range="80-105" :::

1. Print the messages and save the generated image from the conversation with the assistant:

    :::code language="csharp" source="snippets/assistants/program.cs" range="107-147" :::

    Locate and open the saved image in the app *bin* directory, which should resemble the following:

    :::image type="content" source="../media/assistants/generated-sales-graph.png" alt-text="A graph showing the visualization generated by the AI model.":::

## Next steps

- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
