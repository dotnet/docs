---
title: Credential chains in the Azure Identity library
description: This article describes the Azure Identity library's DefaultAzureCredential and ChainedTokenCredential classes.
ms.topic: conceptual
ms.date: 08/06/2024
---

The Azure Identity library provides *credentials*&mdash;public classes derived from the [TokenCredential](/dotnet/api/azure.core.tokencredential?view=azure-dotnet&preserve-view=true) class. A credential represents a distinct authentication flow for acquiring an access token from Microsoft Entra ID. These credentials can be chained together to form an ordered sequence of mechanisms for attempting to authenticate.

At runtime, the credential chain attempts to authenticate using the first credential. If that credential fails to acquire an access token, the next credential in the sequence is attempted, and so on, until an access token is successfully obtained. In this way, your app can use different credentials in different environments without writing environment-specific code.

There are two different philosophies to credential chaining:

- **Tear down a chain** - Start with a preconfigured chain and exclude what you don't need. For this approach, see the [DefaultAzureCredential](#defaultazurecredential) section.
- **Build up a chain** - Start with an empty chain and include only what you need. For this approach, see the [ChainedTokenCredential](#chainedtokencredential) section.

## DefaultAzureCredential

[DefaultAzureCredential](/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet&preserve-view=true) is an opinionated, preconfigured chain of credentials. In graphical form, it looks like this:

:::image type="content" source="../media/credential-chains/DefaultAzureCredentialAuthFlow.svg" alt-text="DefaultAzureCredential" lightbox="../media/credential-chains/DefaultAzureCredentialAuthFlow.svg":::

The order and locations in which `DefaultAzureCredential` looks for credentials is found at [DefaultAzureCredential](/dotnet/api/overview/azure/identity-readme?view=azure-dotnet&preserve-view=true#defaultazurecredential).

1. **Environment** - Reads a collection of environment variables to determine if an application service principal (application user) is configured for the app. If so, `DefaultAzureCredential` uses these values to authenticate the app to Azure.<br><br>This method is most often used in server environments but can also be used when developing locally.
1. **Workload Identity** - If the app is deployed to an Azure host with Workload Identity enabled, authenticate that account.
1. **Managed Identity** - If the app is deployed to an Azure host with Managed Identity enabled, authenticate the app to Azure using that Managed Identity.
1. **Visual Studio** - If the developer authenticated to Azure by logging into Visual Studio, authenticate the app to Azure using that same account.
1. **Azure CLI** - If the developer authenticated to Azure using Azure CLI's `az login` command, authenticate the app to Azure using that same account.
1. **Azure PowerShell** - If the developer authenticated to Azure using Azure PowerShell's `Connect-AzAccount` cmdlet, authenticate the app to Azure using that same account.
1. **Azure Developer CLI** - If the developer authenticated to Azure using Azure Developer CLI's `azd auth login` command, authenticate with that account.
1. **Interactive** - If enabled, interactively authenticate the developer via the current system's default browser. By default, this credential is disabled.

### Customize DefaultAzureCredential

To remove a credential from `DefaultAzureCredential`, use the corresponding `Exclude`-prefixed property in [DefaultAzureCredentialOptions](/dotnet/api/azure.identity.defaultazurecredentialoptions?view=azure-dotnet&preserve-view=true#properties). For example:

:::code language="csharp" source="snippets/authentication/Program.cs" id="snippet_DacExcludes":::

In the preceding code sample, `EnvironmentCredential` and `WorkloadIdentityCredential` are removed from the credential chain. As a result, the first credential to be attempted is `ManagedIdentityCredential`. The modified chain looks like this:

:::image type="content" source="../media/credential-chains/DefaultAzureCredentialExcludes.svg" alt-text="DefaultAzureCredential using Excludes properties" lightbox="../media/credential-chains/DefaultAzureCredentialExcludes.svg":::

## ChainedTokenCredential

[ChainedTokenCredential](/dotnet/api/azure.identity.chainedtokencredential?view=azure-dotnet&preserve-view=true) is an empty chain to which you add credentials to suit your app's needs. For example:

:::code language="csharp" source="snippets/authentication/Program.cs" id="snippet_Ctc":::

The preceding code sample creates a custom credential chain. `ManagedIdentityCredential` is attempted first, followed by `VisualStudioCredential`, if necessary. In graphical form, the chain looks like this:

:::image type="content" source="../media/credential-chains/ChainedTokenCredentialAuthFlow.svg" alt-text="ChainedTokenCredential" lightbox="../media/credential-chains/ChainedTokenCredentialAuthFlow.svg":::

> [!TIP]
> As a recommendation, optimize credential ordering in `ChainedTokenCredential` for your production environment.
