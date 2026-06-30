---
title: .NET + AI ecosystem tools and SDKs
description: This article provides an overview of the ecosystem of SDKs and tools available to .NET developers integrating AI into their applications.
ms.date: 04/15/2026
ms.topic: overview
---

# .NET + AI ecosystem tools and SDKs

The .NET ecosystem provides many powerful tools, libraries, and services to develop AI applications. .NET supports both cloud and local AI model connections, many different SDKs for various AI and vector database services, and other tools to help you build intelligent apps of varying scope and complexity.

## Decide which tool to use

The following table recommends which technology to use based on different objectives.

| Objective                     | Technology to use |
|-------------------------------|-------------------|
| **Add AI behavior to an app** | Use [Microsoft.Extensions.AI library (MEAI)](#microsoftextensionsai-libraries). Add [Evaluations](#evaluation-libraries) once you have something worth measuring. |
| **Work with your own data**   | Use [Microsoft.Extensions.DataIngestion (MEDI)](#microsoftextensionsdataingestion-medi) to read, chunk, or enrich content. Then use [Microsoft.Extensions.VectorData (MEVD)](#microsoftextensionsvectordata-mevd) to store and retrieve vectors. |
| **Share or consume capabilities across AI clients** | Use an [MCP Server](#mcp-server) to publish capabilities, or an [MCP Client](#mcp-client) to consume them. |
| **Build an agentic system**   | Use [Copilot SDK](#copilot-sdk) for a ready-made harness, or [Microsoft Agent Framework](#microsoft-agent-framework-maf) for multi-step goal pursuit, routing, or handoffs. |
| **Choose a hosting or execution model** | Use [Azure AI Foundry](#azure-ai-foundry) for managed cloud, [Foundry Local](#foundry-local) for local-first or privacy-sensitive execution, and [Aspire](#aspire) for distributed multi-service systems. |
| **Improve the developer workflow** | Use [AI Toolkit](#ai-toolkit). |

Most production AI applications combine several components:

- **Chat or summarization app**: MEAI + Evaluations
- **RAG application**: MEDI + MEVD + MEAI
- **Multi-agent system**: MEAI + MAF + Aspire
- **Tool interoperability**: MEAI + MCP Server + MCP Client
- **Enterprise cloud app**: MEAI + Azure AI Foundry + Aspire
- **Local-first app**: MEAI + Foundry Local + AI Toolkit (development)

Use these practical rules to choose quickly:

- Start with `Microsoft.Extensions.AI` for most app-level AI features.
- Add `Microsoft.Extensions.DataIngestion` and `Microsoft.Extensions.VectorData` when grounding responses with your own data.
- Use MCP when capabilities must be shared across process or product boundaries.
- Move to Agent Framework when one-step prompts become multi-step workflows.
- Add evaluations once behavior is useful enough to measure and protect from regressions.

## Microsoft.Extensions.AI libraries

[`Microsoft.Extensions.AI`](microsoft-extensions-ai.md) is a set of core .NET libraries that provide a unified layer of C# abstractions for interacting with AI services, such as small and large language models (SLMs and LLMs), embeddings, and middleware. These APIs were created in collaboration with developers across the .NET ecosystem. The low-level APIs, such as <xref:Microsoft.Extensions.AI.IChatClient> and <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2>, were extracted from Semantic Kernel and moved into the <xref:Microsoft.Extensions.AI> namespace.

`Microsoft.Extensions.AI` provides abstractions that can be implemented by various services, all adhering to the same core concepts. This library is not intended to provide APIs tailored to any specific provider's services. The goal of `Microsoft.Extensions.AI` is to act as a unifying layer within the .NET ecosystem, enabling developers to choose their preferred frameworks and libraries while ensuring seamless integration and collaboration across the ecosystem.

MEAI gives .NET developers a clean abstraction for model interaction. It fits naturally into dependency injection, configuration, and existing app architectures and is the usual first layer of an AI-enabled .NET application.

MEAI alone isn't an agent framework. A one-shot call, chat feature, or tool-call loop can be built with MEAI without becoming "agentic." When the system needs goal-directed, multi-step orchestration, use [MAF](#microsoft-agent-framework-maf) instead.

For more information, see [Microsoft.Extensions.AI overview](microsoft-extensions-ai.md).

## Evaluation libraries

The [Microsoft.Extensions.AI.Evaluation library](evaluation/libraries.md) is the quality and regression layer for AI features built with the .NET AI stack. AI behavior changes readily as prompts, models, and tools evolve. The evaluations library gives teams a repeatable way to compare outputs and catch regressions.

For more information, see [Microsoft.Extensions.AI.Evaluation libraries](evaluation/libraries.md).

## Microsoft.Extensions.DataIngestion (MEDI)

[Microsoft.Extensions.DataIngestion](conceptual/medi-library.md) is the ingestion and preparation layer for AI-ready data in .NET.

Many AI apps fail before retrieval because data is messy, oversized, or poorly structured. Ingestion quality strongly affects downstream answer quality. MEDI prepares and shapes the data that MEVD or another store later queries.

For more information, see [Data ingestion for AI apps](conceptual/data-ingestion.md).

## Microsoft.Extensions.VectorData (MEVD)

[Microsoft.Extensions.VectorData](conceptual/mevd-library.md) is the vector data storage and retrieval layer for semantic search, similarity lookup, and grounding in .NET AI apps.

MEVD gives .NET applications a consistent way to work with vector stores and helps separate vector storage and retrieval concerns from model invocation concerns.

For more information, see [Vector stores overview](vector-stores/overview.md).

## MCP Server

An MCP Server exposes capabilities such as tools, resources, or prompts over the Model Context Protocol so other assistants, IDEs, and agents can discover and use them through a standard protocol.

An MCP Server turns app capabilities into reusable AI-facing endpoints. It reduces duplicated tool integration work across assistants and creates a cleaner boundary between capability providers and capability consumers.

An MCP Server is about *publishing* capabilities. If the capability is used only inside one app, ordinary in-process function calling is simpler.

## MCP Client

An MCP Client is the consumer side of the protocol: it connects to MCP servers and brings their exposed capabilities into an app, assistant, or agent runtime.

An MCP Client is about *consuming* capabilities, not publishing them. If everything the app needs is local and in-process, ordinary function or tool calling is still simpler.

For more information, see [Get started with MCP](get-started-mcp.md).

## Microsoft Agent Framework (MAF)

Microsoft Agent Framework is the orchestration layer for systems that are truly agentic: they pursue a goal across multiple steps, make decisions along the way, use tools, and might coordinate multiple agents.

Not every AI feature needs MAF. If a direct MEAI call or a simple tool-calling loop solves the problem, use a simpler approach. MAF matters when orchestration complexity is the real challenge, not just model access.

For more information, see [Microsoft Agent Framework overview](/agent-framework/overview/agent-framework-overview).

## AI Toolkit

AI Toolkit is a VS Code extension pack for AI development that speeds up experimentation with models, prompts, agents, and evaluations.

AI Toolkit isn't the core runtime architecture for the production app. It complements MEAI, Evaluations, and Foundry Local.

For more information, see [AI Toolkit for Visual Studio Code](https://code.visualstudio.com/docs/intelligentapps/overview).

## Copilot SDK

Copilot SDK is a prebuilt agent harness and runtime that brings tools, context, and automatic tool calling out of the box.

Copilot SDK is more opinionated and prewired than MEAI. If your goal is a fully custom app architecture, direct MEAI or MAF composition can be a better fit.

For more information, see the [Copilot SDK repository](https://github.com/github/copilot-sdk).

## Azure AI Foundry

Azure AI Foundry is the managed cloud platform layer for enterprise AI solutions, with two primary functions: model management and hosted agents.

Azure AI Foundry isn't the app-facing programming abstraction; MEAI still plays that role in .NET code. Azure AI Foundry becomes the right lead when the real question is *where* the model runs and under what controls.

For more information, see the [Azure AI Foundry documentation](/azure/ai-foundry/).

## Foundry Local

Foundry Local is a local development and local-first deployment option for teams that need to keep AI workloads close to the machine or environment.

Foundry Local is about the development and deployment path, not the higher-level app architecture itself. Local-to-cloud isn't a clean one-to-one move, so expect differences in features, hosting model, and operations.

For more information, see the [Foundry Local documentation](/azure/foundry-local/).

## Aspire

Aspire is the orchestration, service-wiring, and observability layer for distributed .NET applications, including AI systems that span multiple services.

AI systems often stop being "just one app" once retrieval, tools, gateways, and worker services are involved. Aspire helps teams keep those parts understandable and observable, and its visuals make it easier to trace AI flows across services.

Aspire isn't specifically the AI runtime; it's the multi-service application layer around it. It doesn't replace MEAI, MAF, or Azure AI Foundry.

For more information, see the [Aspire documentation](https://aspire.dev/).
