---
title: Choose the right .NET AI tool
description: Learn which .NET AI technology to use for your scenario, including Microsoft.Extensions.AI, Microsoft Agent Framework, vector stores, data ingestion, MCP, evaluations, Azure AI Foundry, Foundry Local, and Aspire.
ms.date: 04/15/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Choose the right .NET AI tool

The .NET AI ecosystem includes many powerful tools and libraries for different purposes. Picking the right one—or the right combination—makes your application easier to build, test, and maintain. This article helps you understand which tool fits your scenario.

## Quick reference

The following table summarizes when to reach for each component:

| Component | Use it when... | Don't lead with it when... |
|-----------|---------------|---------------------------|
| **Microsoft.Extensions.AI (MEAI)** | You need to add AI behavior to an app: chat, summarization, structured outputs, tool calling, embeddings, or streaming. | The hardest problem is ingestion, retrieval, orchestration, or infrastructure. |
| **Evaluations** | You need repeatable quality checks for prompts, models, agents, or AI features—including regressions and side-by-side comparisons. | You haven't yet built the AI behavior you want to measure. |
| **Microsoft.Extensions.DataIngestion (MEDI)** | Your challenge is getting source content into shape for AI: reading, chunking, enriching, and preparing data for grounding or RAG. | You only need a direct model call and no serious data preparation pipeline. |
| **Microsoft.Extensions.VectorData (MEVD)** | You need semantic search, retrieval, embeddings-backed lookup, or RAG over your own data. | You don't need vector retrieval or grounding. |
| **MCP Server** | You want to expose tools, resources, or prompts so external assistants, IDEs, or agents can discover and use them. | The capability is local to one app and ordinary in-process function calling is enough. |
| **MCP Client** | Your app or agent needs to connect to existing MCP servers and consume external tools or resources. | You don't need interoperability beyond your own process boundary. |
| **Microsoft Agent Framework (MAF)** | The system must pursue goals across multiple steps with routing, planning, handoffs, or multiple collaborating agents. | A single LLM call or straightforward tool-calling loop is sufficient. |
| **AI Toolkit** | You want a better developer workflow for trying models, prompts, and evaluations during development. | You need the runtime abstraction or production architecture itself. |
| **Copilot SDK** | You want a pre-built agent harness with tools, context, and automatic tool calling out of the box. | You want a blank-slate app stack or full low-level control from MEAI or MAF. |
| **Azure AI Foundry** | You need managed model hosting, safety, governance, enterprise controls, and a cloud deployment target. | You're only deciding how app code should call a model. |
| **Foundry Local** | You need local or local-first AI for privacy or compliance reasons, or you want some alignment with Azure AI Foundry without requiring a perfect cloud transition. | Any local runtime works, or you expect local-to-cloud to be a drop-in identical move. |
| **Aspire** | The solution spans multiple services and you need orchestration, service discovery, and observability. | The app is still a single service or proof of concept. |

## How to decide

Start by identifying your primary challenge:

- **Adding AI behavior to an app** → Start with [MEAI](#microsoftextensionsai-meai). Add [Evaluations](#evaluations) once you have something worth measuring.
- **Working with your own data** → If you need to read, chunk, or enrich content first, start with [MEDI](#microsoftextensionsdataingestion-medi). Then use [MEVD](#microsoftextensionsvectordata-mevd) for vector storage and retrieval.
- **Sharing or consuming capabilities across AI clients** → Build an [MCP Server](#mcp-server) to publish capabilities, or use an [MCP Client](#mcp-client) to consume them.
- **Building a truly agentic system** → If you want a ready-made harness, use the [Copilot SDK](#copilot-sdk). For multi-step goal pursuit, routing, or handoffs, use [MAF](#microsoft-agent-framework-maf).
- **Choosing a hosting or execution model** → Use [Azure AI Foundry](#azure-ai-foundry) for managed cloud, [Foundry Local](#foundry-local) for local-first or privacy-sensitive execution, and [Aspire](#aspire) when the solution is a distributed multi-service system.
- **Improving the developer workflow** → Use [AI Toolkit](#ai-toolkit).

## Component guidance

### Microsoft.Extensions.AI (MEAI)

`Microsoft.Extensions.AI` is the app-facing foundation for adding model-powered behavior to a .NET application.

**Use MEAI when you want to:**

- Build chat or conversational UX.
- Stream responses.
- Summarize, extract, or classify content.
- Produce structured outputs.
- Generate or work with embeddings.
- Call tools or functions.

MEAI gives .NET developers a clean abstraction for model interaction. It fits naturally into dependency injection, configuration, and existing app architectures and is the usual first layer of an AI-enabled .NET application.

**Important boundary:** MEAI alone isn't an agent framework. A one-shot call, chat feature, or tool-call loop can be built with MEAI without becoming "agentic." When the system needs goal-directed, multi-step orchestration, use [MAF](#microsoft-agent-framework-maf) instead.

**Don't lead with MEAI alone when:**

- The hard problem is preparing enterprise content for AI—add [MEDI](#microsoftextensionsdataingestion-medi).
- The hard problem is retrieval or RAG—add [MEVD](#microsoftextensionsvectordata-mevd).
- Tools must be discoverable across assistants or apps—add [MCP Server](#mcp-server).
- The app needs to consume external MCP capabilities—add [MCP Client](#mcp-client).
- The challenge is multi-step autonomous workflows—add [MAF](#microsoft-agent-framework-maf).
- The main concern is hosting, governance, and enterprise controls—add [Azure AI Foundry](#azure-ai-foundry).

For more information, see [Microsoft.Extensions.AI overview](../microsoft-extensions-ai.md).

### Evaluations

`Microsoft.Extensions.AI.Evaluations` is the quality and regression layer for AI features built with the .NET AI stack.

**Use Evaluations when you need to answer questions like:**

- "Is this prompt change actually better?"
- "Did switching models hurt quality or safety?"
- "Did the agent regress on key scenarios?"
- "Can you measure behavior before shipping?"

AI behavior changes easily as prompts, models, and tools evolve. Intuition doesn't scale—Evaluations give teams a repeatable way to compare outputs and catch regressions.

**Important boundary:** Evaluations aren't the runtime feature itself. They're most valuable once you already have a feature, workflow, or agent worth measuring.

For more information, see [Microsoft.Extensions.AI.Evaluation libraries](../evaluation/libraries.md).

### Microsoft.Extensions.DataIngestion (MEDI)

`Microsoft.Extensions.DataIngestion` is the ingestion and preparation layer for AI-ready data in .NET.

**Use MEDI when:**

- You need to read content from files, stores, or enterprise sources.
- You need to chunk documents for retrieval and grounding.
- You need to normalize and enrich content with metadata.
- You're preparing data to feed a vector index or downstream RAG pipeline.

Many AI apps fail before retrieval because data is messy, oversized, or poorly structured. Ingestion quality strongly affects downstream answer quality.

**Important boundary:** MEDI isn't the retrieval layer—it comes *before* retrieval. It prepares and shapes the data that MEVD or another store later queries.

**Don't lead with MEDI when:**

- The app just needs chat, extraction, summarization, or tool calling over immediate input—start with [MEAI](#microsoftextensionsai-meai).
- Your content is already prepared and the need is semantic lookup—lead with [MEVD](#microsoftextensionsvectordata-mevd).

For more information, see [Data ingestion for AI apps](data-ingestion.md).

### Microsoft.Extensions.VectorData (MEVD)

`Microsoft.Extensions.VectorData` is the vector data storage and retrieval layer for semantic search, similarity lookup, and grounding in .NET AI apps.

**Use MEVD when:**

- You need semantic search.
- You need embeddings-backed retrieval.
- You're implementing RAG.
- You need similarity search or hybrid retrieval patterns.

MEVD gives .NET applications a consistent way to work with vector stores and helps separate vector storage and retrieval concerns from model invocation concerns.

**Important boundary:** MEVD isn't the model layer or the ingestion layer. MEDI prepares the data. MEVD stores and retrieves the data. MEAI uses that retrieved context with the model.

For more information, see [Vector stores overview](../vector-stores/overview.md).

### MCP Server

An MCP Server exposes capabilities—tools, resources, or prompts—over the Model Context Protocol so other assistants, IDEs, and agents can discover and use them through a standard protocol.

**Use an MCP Server when:**

- You want to make internal APIs or business actions available to multiple AI clients.
- You want interoperability instead of custom one-off integrations.
- The same capability should be reusable across tools, products, or agent systems.

An MCP Server turns app capabilities into reusable AI-facing endpoints. It reduces duplicated tool integration work across assistants and creates a cleaner boundary between capability providers and capability consumers.

**Important boundary:** An MCP Server is about *publishing* capabilities. If the capability is used only inside one app, ordinary in-process function calling is simpler.

### MCP Client

An MCP Client is the consumer side of the protocol: it connects to MCP servers and brings their exposed capabilities into an app, assistant, or agent runtime.

**Use an MCP Client when:**

- Your app needs to call tools that are already exposed elsewhere through MCP.
- You want an agent or assistant to consume capabilities without custom per-tool plumbing.
- You're composing with an external ecosystem of AI-facing tools.

**Important boundary:** An MCP Client is about *consuming* capabilities, not publishing them. If everything the app needs is local and in-process, ordinary function or tool calling is still simpler.

For more information, see [Get started with MCP](../get-started-mcp.md).

### Microsoft Agent Framework (MAF)

Microsoft Agent Framework is the orchestration layer for systems that are truly agentic: they pursue a goal across multiple steps, make decisions along the way, use tools, and might coordinate multiple agents.

**Use MAF when the system needs:**

- Planning or stepwise execution.
- Routing across tools or specialist agents.
- Handoffs between agents or humans.
- Stateful, multi-step workflows that adapt as results come back.

**Important boundary:** Not every AI feature needs MAF. If a direct MEAI call or a simple tool-calling loop solves the problem, use a simpler approach. MAF matters when orchestration complexity is the real challenge, not just model access.

For more information, see [Microsoft Agent Framework overview](/agent-framework/overview/agent-framework-overview).

### AI Toolkit

AI Toolkit is a VS Code extension pack for AI development that speeds up experimentation with models, prompts, agents, and evaluations.

**Use AI Toolkit when teams want:**

- A model catalog and playground inside VS Code.
- A faster loop for testing prompts and models.
- An agent builder and agent inspector for creating, debugging, and visualizing agents.
- A friendlier workflow for experimenting during development.
- Bulk runs, tracing, or fine-tuning as part of the development loop.

**Important boundary:** AI Toolkit isn't the core runtime architecture for the production app. It complements MEAI, Evaluations, and Foundry Local.

### Copilot SDK

Copilot SDK is a pre-built agent harness and runtime that brings tools, context, and automatic tool calling out of the box.

**Use Copilot SDK when:**

- You want more built-in runtime behavior than a blank-slate MEAI app provides.
- You want tools and context wired in quickly.
- Automatic tool calling and agent-harness behavior are more valuable than assembling everything manually.
- You want a faster path to a working assistant or agent runtime.

**Important boundary:** Copilot SDK is more opinionated and pre-wired than MEAI. If the goal is a fully custom app architecture, direct MEAI or MAF composition can be a better fit.

### Azure AI Foundry

Azure AI Foundry is the managed cloud platform layer for enterprise AI solutions, with two primary functions: model management and hosted agents.

**Use Azure AI Foundry when priorities include:**

- Managed model hosting.
- Hosted agent capabilities with persistent memory and built-in tools.
- Code-free RAG through file upload or grounding services.
- Out-of-the-box evaluations, comparisons, and safety checks.
- Safety filtering and governance controls.
- Enterprise compliance and operational consistency.
- Centralized access to models and cloud deployment infrastructure.

**Important boundary:** Azure AI Foundry isn't the app-facing programming abstraction—MEAI still plays that role in .NET code. Azure AI Foundry becomes the right lead when the real question is *where* the model runs and under what controls.

For more information, see the [Azure AI Foundry documentation](/azure/ai-foundry/).

### Foundry Local

Foundry Local is a local development and local-first deployment option for teams that need to keep AI workloads close to the machine or environment.

**Use Foundry Local when:**

- Local development needs better production parity.
- The organization is local-first or all-local because of privacy, compliance, or data residency requirements.
- You want the local experience to align somewhat with Azure AI Foundry.
- Teams need to experiment locally without sending sensitive data to the cloud.

**Important boundary:** Foundry Local is about the development and deployment path, not the higher-level app architecture itself. Local-to-cloud isn't a clean one-to-one move—expect differences in features, hosting model, and operations.

### Aspire

.NET Aspire is the orchestration, service-wiring, and observability layer for distributed .NET applications, including AI systems that span multiple services.

**Use Aspire when the solution includes:**

- Separate API, agent, retrieval, and model-facing services.
- Service discovery and distributed configuration.
- Tracing, telemetry, and end-to-end visibility across the system.

AI systems often stop being "just one app" once retrieval, tools, gateways, and worker services are involved. Aspire helps teams keep those parts understandable and observable, and its visuals make it easier to trace AI flows across services.

**Important boundary:** Aspire isn't specifically the AI runtime; it's the multi-service application layer around it. It doesn't replace MEAI, MAF, or Azure AI Foundry.

For more information, see the [.NET Aspire documentation](/dotnet/aspire/).

## Common combinations

Most production AI applications combine several components:

- **Chat or summarization app**: MEAI + Evaluations
- **RAG application**: MEDI + MEVD + MEAI
- **Multi-agent system**: MEAI + MAF + Aspire
- **Tool interoperability**: MEAI + MCP Server + MCP Client
- **Enterprise cloud app**: MEAI + Azure AI Foundry + Aspire
- **Local-first app**: MEAI + Foundry Local + AI Toolkit (development)

## Next steps

- [.NET + AI ecosystem tools and SDKs](../dotnet-ai-ecosystem.md)
- [Microsoft.Extensions.AI overview](../microsoft-extensions-ai.md)
- [Microsoft Agent Framework overview](/agent-framework/overview/agent-framework-overview)
- [Get started with MCP](../get-started-mcp.md)
- [Vector stores overview](../vector-stores/overview.md)
- [Data ingestion for AI apps](data-ingestion.md)
- [Evaluations overview](../evaluation/libraries.md)
