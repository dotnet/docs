---
title: Quickstart - Create a simple AI assistant using .NET
description: Learn to create a basic AI assistant with tooling capabilities using .NET and the Azure OpenAI SDK libraries
ms.date: 01/25/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
zone_pivot_groups: openai-library
---

# Chat with a Local AI Model Using .NET

In this quickstart, you will learn how to create a basic AI assistant using the Azure OpenAI or OpenAI SDK libraries. AI assistants provide agentic functionality to help users complete tasks using AI tools and models. They can process and analyze data, make decisions, and interact with users or other systems to achieve specific goals. They also understand and respond to user inputs, providing valuable assistance and automating repetitive tasks. In the sections ahead, you'll learn the following:

- Core components and concepts of AI assistants
- How to create an assistant using the Azure OpenAI SDK
- How to enhance and customize the capabilities of an assistant

## Core Components of AI Assistants

AI assistants are based around conversational threads with a user. The user sends prompts to the assistant on a conversation thread, which directs the assistant to complete tasks using the tools it has available. The most basic assistant includes the following components:

| **Component** | **Description** |
|---|---|
| **Assistant** | The core AI client and logic that uses Azure OpenAI models, manages conversation threads, and utilizes configured tools. |
| **Thread** | A conversation session between an assistant and a user. Threads store messages and automatically handle truncation to fit content into a model's context. |
| **Message** | A message created by an assistant or a user. Messages can include text, images, and other files. Messages are stored as a list on the thread. |
| **Run** | Activation of an assistant to begin running based on the contents of the thread. The assistant uses its configuration and the thread's messages to perform tasks by calling models and tools. As part of a run, the assistant appends messages to the thread. |
| **Run Step** | A detailed list of steps the assistant took as part of a run. An assistant can call tools or create messages during its run. Examining run steps allows you to understand how the assistant is getting to its final results. |

Assistants can also be configured to use multiple tools in parallel to complete tasks, including the following:

- **Code Interpreter Tool**: Writes and runs code in a sandboxed execution environment.
- **Function Calling**: Runs local custom functions you define in your code.
- **File Search Capabilities**: Augments the assistant with knowledge from outside its model.

By understanding these core components and how they interact, you can build and customize powerful AI assistants to meet your specific needs.

## Prerequisites

* [Install .NET 8.0](https://dotnet.microsoft.com/download) or higher
* [Visual Studio Code](https://code.visualstudio.com/) (optional)

## Create the .NET app

Complete the following steps to create a .NET console app that will connect to your local `phi3:mini` AI model:

::: zone pivot="openai"

1. In a terminal window, navigate to an empty directory on your device and create a new app with the `dotnet new` command:

    ```dotnetcli
    dotnet new console -o AIAssistant
    ```

1. Add the [OpenAI](https://www.nuget.org/packages/OpenAI) package to your app:

    ```dotnetcli
    dotnet add packageOpenAI --prerelease
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
    dotnet add package Azure.AI.OpenAI --prerelease
    ```

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

::: zone-end

## Create the AI Assistant client

1. Open the _Program.cs_ file and replace the contents of the file with the following code:

    :::code language="csharp" source="snippets/assistants/openai/program.cs" range="6-10" :::

    The preceding code:
      - Creates an `OpenAIClient` to interact with OpenAI models and components
      - Creates an `AssistantClient` to work with AI assistants
      - Creates an `OpenAIFileClient` the assistant will use to work with files

1. Create an in-memory document and upload it to the `OpenAIFileClient`:

    :::code language="csharp" source="snippets/assistants/openai/program.cs" range="12-44" :::

    The preceding code:
    - Creates an in-memory document containing sample data.
    - Uploads the document to the `OpenAIFileClient` for the assistant to access.

1. Enable tooling capabilities via the `AssistantClientOptions`:

    :::code language="csharp" source="snippets/assistants/openai/program.cs" range="46-68" :::

    The preceding code:
    - Configures the `FileSearchToolDefinition` to enable the assistant to search and access files.
    - Configures the `CodeInterpreterToolDefinition` to enable the assistant to run code for data analysis.

1. Create the `AssistantClient` and a thread to manage interactions between the user and the assistant:

    :::code language="csharp" source="snippets/assistants/openai/program.cs" range="70-86" :::

    The preceding code:
    - Initializes the `AssistantClient` with the configured options.
    - Creates a conversation thread to manage interactions.
    - Sends an initial prompt to the assistant to analyze and project sales data.

1. Print and save the results from the conversation with the assistant:

    :::code language="csharp" source="snippets/assistants/openai/program.cs" range="88-126" :::

    The preceding code:
    - Retrieves the results from the assistant's analysis.
    - Prints the results to the console.
    - Saves the generated graph image to the root directory of the app.

    Locate and open the saved image in teh app bin directory, which should resemble the following:

    :::image type="content" source="../media/assistants/generated-sales-graph.png" alt-text="A graph showing the visualization generated by the AI model.":::

## Next steps

- [Quickstart - Get insight about your data from an .NET Azure AI chat app](../how-to/work-with-local-models.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
