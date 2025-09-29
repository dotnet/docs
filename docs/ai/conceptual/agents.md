---
title: Agents
description: Introduction to agents
author: luisquintanilla
ms.author: luquinta
ms.date: 09/29/2025
---

# Agents

## What are agents?

**Agents are systems that accomplish objectives.**

Agents become more capable when equipped with the following:

- **Reasoning and decision-making**: Powered by LLMs, search algorithms, or planning and decision-making systems.
- **Tool usage**: Access to Model Context Protocol (MCP) servers, code execution, and external APIs.
- **Context awareness**: Informed by chat history, threads, vector stores, enterprise data, or knowledge graphs.

These capabilities allow agents to operate more autonomously, adaptively, and intelligently.

## What are workflows?

As objectives grow in complexity, they need to be broken down into manageable steps. That’s where workflows come in.

**Workflows define the sequence of steps required to achieve an objective.**

Imagine you're launching a new feature on your business website. If it's a simple update, you might go from idea to production in a few hours. But for more complex initiatives, the process might include:

- Requirement gathering
- Design and architecture
- Implementation
- Testing
- Deployment

## Agents + Workflows

Workflows don’t require agents, but agents can supercharge them.

When agents are equipped with reasoning, tools, and context, they can optimize workflows.

This is the foundation of multi-agent systems, where agents collaborate within workflows to achieve complex goals.

## How can I get started building agents in .NET?

The building blocks in Microsoft.Extensions.AI as well as Microsoft.Extensions.VectorData provide you with the foundations for agents by providing modular components for AI models, tools, and data.

Using those same foundations, you can leverage SDKs such as:

### Agent SDKs

- [Semantic Kernel Agent Framework](https://learn.microsoft.com/semantic-kernel/frameworks/agent/?pivots=programming-language-csharp)

### Workflow SDKs

- [Semantic Kernel Process Framework](https://learn.microsoft.com/semantic-kernel/frameworks/process/process-framework)
