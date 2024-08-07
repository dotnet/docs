---
title: Credential chains in the Azure Identity library
description: 'This article describes the Azure Identity library's DefaultAzureCredential and ChainedTokenCredential classes.'
ms.topic: conceptual
ms.date: 08/06/2024
---

# Credential chains in the Azure Identity library for .NET

The Azure Identity library provides *credentials*&mdash;public classes derived from the [TokenCredential](/dotnet/api/azure.core.tokencredential?view=azure-dotnet&preserve-view=true) class. A credential represents a distinct authentication flow for acquiring an access token from Microsoft Entra ID. These credentials can be chained together to form an ordered sequence of mechanisms for attempting to authenticate.

## Why to use a chained credential

At runtime, the credential chain attempts to authenticate using the first credential. If that credential fails to acquire an access token, the next credential in the sequence is attempted, and so on, until an access token is successfully obtained. In this way, your app can use different credentials in different environments without writing environment-specific code like this:

:::code language="csharp" source="../snippets/authentication/Program.cs" id="snippet_NoChain":::

## How to choose a chained credential

There are two different philosophies to credential chaining:

- **"Tear down" a chain** - Start with a preconfigured chain and exclude what you don't need. For this approach, see the [DefaultAzureCredential overview](#defaultazurecredential-overview) section.
- **"Build up" a chain** - Start with an empty chain and include only what you need. For this approach, see the [ChainedTokenCredential overview](#chainedtokencredential-overview) section.

## DefaultAzureCredential overview

[DefaultAzureCredential](/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet&preserve-view=true) is an opinionated, preconfigured chain of credentials. In graphical form, it looks like this:

:::image type="content" source="../media/mermaidjs/DefaultAzureCredentialAuthFlow.svg" alt-text="DefaultAzureCredential" lightbox="../media/mermaidjs/DefaultAzureCredentialAuthFlow.svg":::

The order in which `DefaultAzureCredential` attempts credentials follows.

| Order | Credential          | Description | Enabled by default? |
|-------|---------------------|-------------|---------------------|
| 1     | Environment         |Reads a collection of environment variables to determine if an application service principal (application user) is configured for the app. If so, `DefaultAzureCredential` uses these values to authenticate the app to Azure. This method is most often used in server environments but can also be used when developing locally.             | Yes                 |
| 2     | Workload Identity   |If the app is deployed to an Azure host with Workload Identity enabled, authenticate that account.             | Yes                 |
| 3     | Managed Identity    |If the app is deployed to an Azure host with Managed Identity enabled, authenticate the app to Azure using that Managed Identity.             | Yes                 |
| 4     | Visual Studio       |If the developer authenticated to Azure by logging into Visual Studio, authenticate the app to Azure using that same account.             | Yes                 |
| 5     | Azure CLI           |If the developer authenticated to Azure using Azure CLI's `az login` command, authenticate the app to Azure using that same account.             | Yes                 |
| 6     | Azure PowerShell    |If the developer authenticated to Azure using Azure PowerShell's `Connect-AzAccount` cmdlet, authenticate the app to Azure using that same account.             | Yes                 |
| 7     | Azure Developer CLI |If the developer authenticated to Azure using Azure Developer CLI's `azd auth login` command, authenticate with that account.             | Yes                 |
| 8     | Interactive         |If enabled, interactively authenticate the developer via the current system's default browser. By default, this credential is disabled.             | No                  |

In its simplest form, you can use the parameterless version of `DefaultAzureCredential` as follows:

:::code language="csharp" source="../snippets/authentication/Program.cs" id="snippet_Dac":::

### How to customize DefaultAzureCredential

To remove a credential from `DefaultAzureCredential`, use the corresponding `Exclude`-prefixed property in [DefaultAzureCredentialOptions](/dotnet/api/azure.identity.defaultazurecredentialoptions?view=azure-dotnet&preserve-view=true#properties). For example:

:::code language="csharp" source="../snippets/authentication/Program.cs" id="snippet_DacExcludes":::

In the preceding code sample, `EnvironmentCredential` and `WorkloadIdentityCredential` are removed from the credential chain. As a result, the first credential to be attempted is `ManagedIdentityCredential`. The modified chain looks like this:

:::image type="content" source="../media/mermaidjs/DefaultAzureCredentialExcludes.svg" alt-text="DefaultAzureCredential using Excludes properties":::

## ChainedTokenCredential overview

[ChainedTokenCredential](/dotnet/api/azure.identity.chainedtokencredential?view=azure-dotnet&preserve-view=true) is an empty chain to which you add credentials to suit your app's needs. For example:

:::code language="csharp" source="../snippets/authentication/Program.cs" id="snippet_Ctc":::

The preceding code sample creates a tailored credential chain comprised of two credentials. `ManagedIdentityCredential` is attempted first, followed by `VisualStudioCredential`, if necessary. In graphical form, the chain looks like this:

:::image type="content" source="../media/mermaidjs/ChainedTokenCredentialAuthFlow.svg" alt-text="ChainedTokenCredential":::

> [!TIP]
> For improved performance, optimize credential ordering in `ChainedTokenCredential` for your production environment.

## Usage guidance for DefaultAzureCredential

`DefaultAzureCredential` is undoubtedly the easiest way to get started with the Azure Identity library, but with that convenience comes tradeoffs. Once you deploy your app to Azure, you should understand your app's authentication requirements. For that reason, strongly consider moving from `DefaultAzureCredential` to one of the following solutions:

- A specific `TokenCredential` implementation, such as `ManagedIdentityCredential`. See the [**Derived** list](/dotnet/api/azure.core.tokencredential?view=azure-dotnet&preserve-view=true#definition) for options.
- A pared-down `ChainedTokenCredential` implementation optimized for the Azure environment in which your app runs.

Here's why:

- **Debugging challenges** - When authentication fails, it can be challenging to debug and identify the offending credential. You need to [enable logging](../logging.md) to see the list of credentials attempted and the success/failure status of each.
- **Performance overhead** - The process of sequentially trying multiple credentials can introduce performance overhead. For example, when running on a local development machine, Managed Identity is unavailable. Consequently, `ManagedIdentityCredential` always fails in the local development environment, unless explicitly disabled via its corresponding `Exclude`-prefixed property.
- **Unpredictable behavior** - `DefaultAzureCredential` checks for the presence of certain environment variables. It's possible that someone could change these environment variables on the host machine and therefore alter the behavior of `DefaultAzureCredential` at runtime.
