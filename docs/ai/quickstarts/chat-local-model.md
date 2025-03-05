---
title: Quickstart - Connect to and chat with a local AI using .NET
description: Set up a local AI model and chat with it using a .NET console app and the Microsoft.Extensions.AI libraries
ms.date: 12/19/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
---

# Chat with a local AI model using .NET

In this quickstart, you learn how to create a conversational .NET console chat app using an OpenAI or Azure OpenAI model. The app uses the <xref:Microsoft.Extensions.AI> library so you can write code using AI abstractions rather than a specific SDK. AI abstractions enable you to change the underlying AI model with minimal code changes.

## Prerequisites

* [Install .NET 8.0](https://dotnet.microsoft.com/download) or higher
* [Install Ollama](https://ollama.com/) locally on your device
* [Visual Studio Code](https://code.visualstudio.com/) (optional)

## Run the local AI model

Complete the following steps to configure and run a local AI model on your device. Many different AI models are available to run locally and are trained for different tasks, such as generating code, analyzing images, generative chat, or creating embeddings. For this quickstart, you'll use the general purpose `phi4-mini` model, which is a small but capable generative AI created by Microsoft.

1. Open a terminal window and verify that Ollama is available on your device:

    ```bash
    ollama
    ```

    If Ollama is available, it displays a list of available commands.

1. Start Ollama:

    ```bash
    ollama serve
    ```

    If Ollama is running, it displays a list of available commands.

1. Pull the `phi4-mini` model from the Ollama registry and wait for it to download:

    ```bash
    ollama pull phi4-mini
    ```

1. After the download completes, run the model:

    ```bash
    ollama run phi4-mini
    ```

    Ollama starts the `phi4-mini` model and provides a prompt for you to interact with it.

## Create the .NET app

Complete the following steps to create a .NET console app that connects to your local `phi4-mini` AI model.

1. In a terminal window, navigate to an empty directory on your device and create a new app with the `dotnet new` command:

    ```dotnetcli
    dotnet new console -o LocalAI
    ```

1. Add the [Microsoft.Extensions.AI.Ollama](https://aka.ms/meai-ollama-nuget) packages to your app:

    ```dotnetcli
    dotnet add package Microsoft.Extensions.AI.Ollama --prerelease
    ```

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

## Connect to and chat with the AI model

The Semantic Kernel SDK provides many services and features to connect to AI models and manage interactions. In the steps ahead, you'll create a simple app that connects to the local AI and stores conversation history to improve the chat experience.

1. Open the _Program.cs_ file and replace the contents of the file with the following code:

    :::code language="csharp" source="snippets/local-ai/program.cs" :::

    The preceding code accomplishes the following:

    - Creates an `OllamaChatClient` that implements the `IChatClient` interface.
        - This interface provides a loosely coupled abstraction you can use to chat with AI Models.
        - You can later change the underlying chat client implementation to another model, such as Azure OpenAI, without changing any other code.
    - Creates a `ChatHistory` object to store the messages between the user and the AI model.
    - Retrieves a prompt from the user and stores it in the `ChatHistory`.
    - Sends the chat data to the AI model to generate a response.

    > [!NOTE]
    > Ollama runs on port 11434 by default, which is why the AI model endpoint is set to `http://localhost:11434`.

1. Run the app and enter a prompt into the console to receive a response from the AI, such as the following:

    ```output
    Your prompt:
    Tell me three facts about .NET.

    AI response:
    1. **Cross-Platform Development:** One of the significant strengths of .NET,
    particularly its newer iterations (.NET Core and .NET 5+), is cross-platform support.
    It allows developers to build applications that run on Windows, Linux, macOS,
    and various other operating systems seamlessly, enhancing flexibility and
    reducing barriers for a wider range of users.

    2. **Rich Ecosystem and Library Support:** .NET has a rich ecosystem,
    comprising an extensive collection of libraries (such as those provided by the
    official NuGet Package Manager), tools, and services. This allows developers
    to work on web applications (.NET for desktop apps and ASP.NET Core
    for modern web applications), mobile applications (.NET MAUI),
    IoT solutions, AI/ML projects, and much more with a vast array of prebuilt
    components available at their disposal.

    3. **Type Safety:** .NET operates under the Common Language Infrastructure (CLI)
    model and employs managed code for executing applications. This approach inherently
    offers strong type safety checks which help in preventing many runtime errors that
    are common in languages like C/C++. It also enables features such as garbage collection,
    thus relieving developers from manual memory management. These characteristics enhance
    the reliability of .NET-developed software and improve productivity by catching
    issues early during development.
    ```

1. The response from the AI is accurate, but also verbose. The stored chat history enables the AI to modify its response. Instruct the AI to shorten the list it provided:

    ```output
    Your prompt:
    Shorten the length of each item in the previous response.

    AI Response:
     **Cross-platform Capabilities:** .NET allows building for various operating systems
    through platforms like .NET Core, promoting accessibility (Windows, Linux, macOS).

    **Extensive Ecosystem:** Offers a vast library selection via NuGet and tools for web
    (.NET Framework), mobile development (.NET MAUI), IoT, AI, providing rich
    capabilities to developers.

    **Type Safety & Reliability:** .NET's CLI model enforces strong typing and automatic
    garbage collection, mitigating runtime errors, thus enhancing application stability.
    ```

    The updated response from the AI is much shorter the second time. Due to the available chat history, the AI was able to assess the previous result and provide shorter summaries.

## Next steps

- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
