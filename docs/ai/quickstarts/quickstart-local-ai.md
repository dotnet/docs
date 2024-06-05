---
title: Quickstart - Connect to and chat with a local AI using .NET and Semantic Kernel
description: Set up a local AI model and chat with it using a .NET consle app and the Semantic Kernel SDK
ms.date: 06/04/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
---

# Chat with a local AI model using .NET and Semantic Kernel

Local AI models provide powerful and flexible options for building AI solutions. In this quickstart, you'll explore how to set up and connect to a local AI model using .NET and the Semantic Kernel SDK. For this example, you'll run the local AI model using Ollama.

## Prerequisites

* [Install .NET 8.0](https://dotnet.microsoft.com/download) or higher
* [Install Ollama](https://ollama.com/) locally on your device

## Run the local AI model

Complete the following steps to configure and run a local AI Model on your device. Many different AI models are available to run locally and are trained for different tasks, such as generating code, analyzing images, generative chat, or creating embeddings. For this quickstart, you'll use the general purpose `phi3:mini` model, which is a small but capable generative AI created by Microsoft.

1. Open a terminal window and verify that Ollama is available on your device:

    ```bash
    ollama
    ```

    If Ollama is running, it displays a list of available commands.

1. Pull the `phi3:mini` model from the Ollama registry and wait for it to download:

    ```bash
    ollama pull phi3:mini
    ```

1. After the download completes, run the model:

    ```bash
    ollama run phi3:mini
    ```

    Ollama starts the `phi3:mini` model and provides a prompt for you to interact with it.

## Create the .NET app

Complete the following steps to create a .NET console app that will connect to your local `phi3:mini` AI model:

1. In a terminal window, navigate to an empty directory on your device and create a new app with the `dotnet new` command:

    ```dotnetcli
    dotnet new console
    ```

1. Add the Semantic Kernel SDK package to your app:

    ```dotnetcli
    dotnet add package Microsoft.SemanticKernel
    ```

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

## Connect to and chat with the AI model

The Semantic Kernel SDK provides many services and features to connect to AI models and manage interactions. In the steps ahead, you'll create a simple app that connects to the local AI and stores conversation history to improve the chat experience.

1. Open the _Program.cs_ file and replace the contents of the file with the following code:

    ```csharp
    using Microsoft.SemanticKernel;
    using Microsoft.SemanticKernel.ChatCompletion;
    
    // Create a kernel with OpenAI chat completion
    #pragma warning disable SKEXP0010
    Kernel kernel = Kernel.CreateBuilder()
                        .AddOpenAIChatCompletion(
                            modelId: "phi3:mini",
                            endpoint: new Uri("http://localhost:11434"),
                            apiKey: String.Empty)
                        .Build();
    
    var aiChatService = kernel.GetRequiredService<IChatCompletionService>();
    var chatHistory = new ChatHistory();
    
    while(true)
    {
        // Get user prompt and add to chat history
        Console.WriteLine("Your prompt:");
        var userPrompt = Console.ReadLine();
        chatHistory.Add(new ChatMessageContent(AuthorRole.User, userPrompt));
    
        // Stream the AI response and add to chat history
        Console.WriteLine("AI Response:");
        var response = String.Empty;
        await foreach(var item in aiChatService.GetStreamingChatMessageContentsAsync(chatHistory))
        {
            Console.Write(item.Content);
            response += item.Content;
        }
        chatHistory.Add(new ChatMessageContent(AuthorRole.Assistant, response));
    }
    ```

    The preceding code accomplishes the following tasks:
    - Creates a `Kernel` object and uses it to retrieve a chat completion service.
    - Creates a `ChatHistory` object to store the messages between the user and the AI model.
    - Retrieves a prompt from the user and stores it in the `ChatHistory`.
    - Sends the chat data to the AI model to generate a response.

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

    2. **Rich Ecosystem and Library Support:** .NET has an incredibly rich ecosystem,
    comprising an extensive collection of libraries (such as those provided by the 
    official NuGet Package Manager), tools, and services. This allows developers 
    to work on web applications (.NET Framework for desktop apps and ASP.NET Core 
    for modern web applications), mobile applications (.NET MAUI or Xamarin.Forms),
    IoT solutions, AI/ML projects, and much more with a vast array of pre-built
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
    (.NET Framework), mobile development (Maui/Xamarin.Forms), IoT, AI, providing rich
    capabilities to developers.
    
    **Type Safety & Reliability:** .NET's CLI model enforces strong typing and automatic
    garbage collection, mitigating runtime errors, thus enhancing application stability.
    ```

    The updated response from the AI is much shorter the second time. Due to the available chat history, the AI was able to assess the previous result and provide shorter summaries.

## Next steps

- [Quickstart - Get insight about your data from an .NET Azure AI chat app](../how-to/work-with-local-models.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
