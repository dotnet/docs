---
title: Microsoft.Testing.Platform (MTP) AI integrations
description: Learn how MTP extensions access AI chat clients and configure the Azure AI Foundry provider.
author: Evangelink
ms.author: amauryleve
ms.date: 08/28/2026
ai-usage: ai-assisted
---

# AI integrations

The experimental [Microsoft.Testing.Platform.AI](https://www.nuget.org/packages/Microsoft.Testing.Platform.AI) package defines provider-neutral AI abstractions for test frameworks and MTP extensions. The package integrates with `Microsoft.Extensions.AI`, so an extension can request an <xref:Microsoft.Extensions.AI.IChatClient> without depending on a specific model provider.

> [!IMPORTANT]
> The AI APIs use the `TPEXP` diagnostic ID and can change in a future release. The packages supply infrastructure to extensions; they don't add AI behavior to a test suite by themselves.

## Use AI coding tools for test workflows

The packages in this article let MTP extensions call AI models at test run time. To use an AI coding assistant to create, analyze, or migrate tests in your repository, use the curated [.NET Agent Skills](https://github.com/dotnet/skills) instead.

Choose a workflow based on your goal:

| Goal | Skill or agent |
|---|---|
| Create or extend tests | Use the [`code-testing-agent` skill](https://github.com/dotnet/skills/tree/main/plugins/dotnet-test/skills/code-testing-agent) from the [`dotnet-test` plugin](https://github.com/dotnet/skills/tree/main/plugins/dotnet-test). The skill researches the codebase, plans the work, implements tests, and verifies the changes. |
| Audit test quality | Use the [`test-quality-auditor` agent](https://github.com/dotnet/skills/blob/main/plugins/dotnet-test/agents/test-quality-auditor.agent.md) for a broad assessment, or invoke a focused `dotnet-test` skill for assertions, coverage, test gaps, or test smells. |
| Improve testability | Use the [`testability-migration` agent](https://github.com/dotnet/skills/blob/main/plugins/dotnet-test/agents/testability-migration.agent.md) to find static dependencies and introduce testable abstractions. |
| Migrate a test framework or platform | Use the [`test-migration` agent](https://github.com/dotnet/skills/blob/main/plugins/dotnet-test-migration/agents/test-migration.agent.md) from the [`dotnet-test-migration` plugin](https://github.com/dotnet/skills/tree/main/plugins/dotnet-test-migration). The agent detects the current setup and selects the appropriate migration skill. |

For installation steps and supported coding agents, see the [.NET Agent Skills repository](https://github.com/dotnet/skills#installation). Install `dotnet-test` alongside `dotnet-test-migration` because migration workflows reuse its platform detection and test verification skills.

## Choose the packages

Add the abstractions package when you author an extension that consumes a chat client. Add a provider package to the test application that hosts the extension:

```dotnetcli
dotnet add package Microsoft.Testing.Platform.AI
dotnet add package Microsoft.Testing.Extensions.AzureFoundry
```

`Microsoft.Testing.Extensions.AzureFoundry` is the Microsoft-provided reference provider. It creates an Azure OpenAI chat client through Azure AI Foundry.

## Configure Azure AI Foundry

Set the following environment variables:

| Variable | Required | Description |
|---|---|---|
| `AZURE_OPENAI_ENDPOINT` | Yes | The Azure OpenAI resource endpoint, such as `https://my-resource.openai.azure.com`. |
| `AZURE_OPENAI_DEPLOYMENT_NAME` | Yes | The model deployment name. |
| `AZURE_OPENAI_API_KEY` | Conditional | The resource API key. Set this value unless you register a `TokenCredential` in code. |

To keep credentials out of source control, supply these values through your local environment or a protected CI secret store.

## Register the provider

Disable the generated MTP entry point and register the provider in your custom `Main` method. For API-key authentication, call:

```csharp
#pragma warning disable TPEXP
builder.AddAzureOpenAIChatClientProvider();
#pragma warning restore TPEXP
```

For Microsoft Entra ID or managed identity, reference the `Azure.Identity` package and pass a credential:

```csharp
using Azure.Identity;

#pragma warning disable TPEXP
builder.AddAzureOpenAIChatClientProvider(new DefaultAzureCredential());
#pragma warning restore TPEXP
```

When `AZURE_OPENAI_API_KEY` is set, the provider uses the API key before the supplied credential. Credential resolution and authentication occur when the first chat request runs, so configuration errors might not appear during provider registration.

## Consume a chat client

Implement `IChatClientProvider` to integrate another AI provider. An MTP extension can retrieve the registered chat client from its `IServiceProvider`:

```csharp
IChatClient? client =
    await serviceProvider.GetChatClientAsync(cancellationToken);
```

The call returns `null` when no available provider is registered. Before an extension sends test data to a model, document what data it sends and apply the privacy, security, and retention requirements for that data.

## See also

- [MTP features](microsoft-testing-platform-features.md)
- [Build extensions for MTP](microsoft-testing-platform-architecture-extensions.md)
- [Microsoft.Extensions.AI libraries](/dotnet/ai/microsoft-extensions-ai)
