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

![Components of an agent](../media/agents/agent-components.png)

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

### Agents + Workflows

Workflows don’t require agents, but agents can supercharge them.

When agents are equipped with reasoning, tools, and context, they can optimize workflows.

This is the foundation of multi-agent systems, where agents collaborate within workflows to achieve complex goals.

### Workflow orchestration

Agentic workflows can be orchestrated in a variety of ways. The following are a few of the most common.

#### Sequential

Agents process tasks one after another, passing results forward.

```mermaid
graph TD
    A[Agent A] --> B[Agent B]
    B --> C[Agent C]
    C --> D[Final Output]
```

#### Concurrent

Agents work in parallel, each handling different aspects of the task.

```mermaid
graph TD
    A[Task Input] --> B1[Agent A]
    A --> B2[Agent B]
    A --> B3[Agent C]
    B1 --> C[Aggregate Results]
    B2 --> C
    B3 --> C
    C --> D[Final Output]
```

#### Handoff

Responsibility shifts from one agent to another based on conditions or outcomes.

```mermaid
graph TD
    A[Start Task] --> B{Agent A Decision}
    B -- Success --> C[Agent A Continues]
    B -- Needs Help --> D[Agent B Takes Over]
    D --> E{Agent B Decision}
    E -- Escalate --> F[Agent C Takes Over]
    E -- Complete --> G[Agent B Completes Task]
    C --> H[Final Output]
    F --> H
    G --> H
```

#### Group Chat

Agents collaborate in a shared conversation, exchanging insights in real-time.

```mermaid
sequenceDiagram
    participant User
    participant AgentA
    participant AgentB
    participant AgentC

    User->>GroupChat: Start Task Discussion
    AgentA->>GroupChat: Shares initial analysis
    AgentB->>GroupChat: Adds additional context
    AgentC->>GroupChat: Suggests strategy
    GroupChat->>User: Final Collaborative Output
```

## How can I get started building agents in .NET?

The building blocks in Microsoft.Extensions.AI as well as Microsoft.Extensions.VectorData provide you with the foundations for agents by providing modular components for AI models, tools, and data.

Using those same foundations, you can leverage SDKs such as:

### Agent SDKs

- [Semantic Kernel Agent Framework](https://learn.microsoft.com/semantic-kernel/frameworks/agent/?pivots=programming-language-csharp)

### Workflow SDKs

- [Semantic Kernel Process Framework](https://learn.microsoft.com/semantic-kernel/frameworks/process/process-framework)
