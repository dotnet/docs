---
title: Develop .NET apps with AI features
description: Learn how you can build .NET applications that include AI features.
ms.date: 12/10/2025
ms.topic: overview
---

# Develop .NET apps with AI features

With .NET, you can use artificial intelligence (AI) to automate and accomplish complex tasks in your applications using the tools, platforms, and services that are familiar to you.

## Why choose .NET to build AI apps?

Millions of developers use .NET to create applications that run on the web, on mobile and desktop devices, or in the cloud. By using .NET to integrate AI into your applications, you can take advantage of all that .NET has to offer:

* A unified story for building web UIs, APIs, and applications.
* Supported on Windows, macOS, and Linux.
* Is open-source and community-focused.
* Runs on top of the most popular web servers and cloud platforms.
* Provides powerful tooling to edit, debug, test, and deploy.

## Supported AI providers

.NET libraries support a wide range of AI service providers, enabling you to build applications with the AI platform that best fits your needs. The following table lists the major AI providers that integrate with `Microsoft.Extensions.AI`:

| Provider | Description |
|----------|------------------------|---------------------------|-----------------|-------------|
| OpenAI | Direct integration with OpenAI's models including GPT-4, GPT-3.5, and DALL-E |
| Azure OpenAI | Enterprise-grade OpenAI models hosted on Azure with enhanced security and compliance |
| Azure AI Foundry | Microsoft's managed platform for building and deploying AI agents at scale |
| GitHub Models | Access to models available through GitHub's AI model marketplace |
| Ollama | Run open-source models locally, for example, Llama, Mistral, and Phi-3 |
| Google Gemini | Google's multimodal AI models |
| Amazon Bedrock | AWS's managed service for foundation models |

Any AI provider that's usable with `Microsoft.Extensions.AI` is also usable with Agent Framework.

## What can you build with AI and .NET?

The opportunities with AI are near endless. Here are a few examples of solutions you can build using AI in your .NET applications:

* Language processing: Create virtual agents or chatbots to talk with your data and generate content and images.
* Computer vision: Identify objects in an image or video.
* Audio generation: Use synthesized voices to interact with customers.
* Classification: Label the severity of a customer-reported issue.
* Task automation: Automatically perform the next step in a workflow as tasks are completed.

## Recommended learning path

We recommend the following sequence of tutorials and articles for an introduction to developing applications with AI and .NET:

| Scenario                    | Tutorial                                                                |
|-----------------------------|-------------------------------------------------------------------------|
| Create a chat application   | [Build an Azure AI chat app with .NET](./quickstarts/build-chat-app.md) |
| Summarize text              | [Summarize text using Azure AI chat app](./quickstarts/prompt-model.md) |
| Chat with your data         | [Get insight about your data from a .NET Azure AI chat app](./vector-stores/how-to/build-vector-search-app.md) |
| Call .NET functions with AI | [Extend Azure AI using tools and execute a local function with .NET](./quickstarts/use-function-calling.md) |
| Generate images             | [Generate images from text](./quickstarts/text-to-image.md) |
| Train your own model        | [ML.NET tutorial](https://dotnet.microsoft.com/learn/ml-dotnet/get-started-tutorial/intro) |

Browse the table of contents to learn more about the core concepts, starting with [How generative AI and LLMs work](./conceptual/how-genai-and-llms-work.md).

## Next steps

* [Quickstart: Build an Azure AI chat app with .NET](./quickstarts/build-chat-app.md)
* [Video series: Machine Learning and AI with .NET](/shows/machine-learning-and-ai-with-dotnet-for-beginners)
