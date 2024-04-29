---
title: AI Concepts for .NET Developers
description: This article provides an overview of AI concepts for .NET developers integrating AI into their applications.
ms.date: 04/25/2024
ms.topic: overview
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
---

# AI Concepts for .NET Developers

## AI overview

Fundamentally, AI involves an interaction between a user and a Large Language Model (LLM). The user inputs a commmand or question (a *prompt*), and the model returns what it determines is the most appropriate response (a *completion*). The LLM converts inputs into [*tokens*](/conceptual/) that it can use for semantic analysis, and has a token limit for each input. AI developers can use prompt templates to manage the number of tokens in prompts, influence the LLM's behavior, and integrate other AI models and services&mdash;collectively called [*prompt engineering*](conceptual/prompt-engineering-dotnet.md).

.NET supports access to numerous AI services and includes an OpenAI SDK, Semantic Kernel.

## Prompt Engineering

### Instructions, examples and cues

### Embeddings

### Using your own data

## .NET AI Implementations

### Models

There are two common model types for AI completions: content generation and chat assistant. Content generation is the older pattern, and is supported by GPT-35 models. Chat completion is supported by GPT-35-turbo and GPT-4 models

GPT-35
GPT-35-turbo
GPT-4
Dall-E

### Services

Azure AI services
Azure OpenAI

### SDKs

Semantic Kernel

The Semantic Kernel includes a default prompt template engine which is used to render Semantic Kernel prompts i.e., skprompt.txt files. The prompt template is rendered before being send to the AI to allow the prompt to be generated dynamically e.g., include input parameters or the result of a native or semantic function execution.

:::image type="content" source="{/semantic-kernel/blob/main/docs/decisions/diagrams/skfunctions-preview.png}" alt-text="{SK functions diagram}":::