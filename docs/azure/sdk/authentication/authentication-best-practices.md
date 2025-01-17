---
title: Authentication best practices with the Azure Identity library for .NET
description: This article describes authentication best practices to follow when using the Azure Identity library for .NET.
ms.topic: conceptual
ms.date: 01/15/2025
---

# Authentication best practices with the Azure Identity library for .NET

This article offers guidelines to help you maximize the performance and reliability of your .NET apps when authenticating to Azure services. To make the most of the Azure Identity library for .NET, it's important to understand potential issues and mitigation techniques.

## Use deterministic credentials in production environments

`DefaultAzureCredential` is the most approachable way to get started with the Azure Identity library, but that convenience also introduces certain tradeoffs. Most notably, the specific credential in the chain that will succeed and be used for request authentication can't be guaranteed ahead of time. In a production environment, this unpredictability can introduce significant and sometimes subtle problems.

For example, consider the following hypothetical sequence of events:

1. An organization's security team mandates all apps use managed identity to authenticate to Azure resources.
1. For months, a .NET app hosted on an Azure Virtual Machine (VM) successfully uses `DefaultAzureCredential` to authenticate via managed identity.
1. Without telling the support team, a developer installs the Azure CLI on that VM and runs the `az login` command to authenticate to Azure.
1. Due to a separate configuration change in the Azure environment, authentication via the original managed identity unexpectedly begins to fail silently.
1. `DefaultAzureCredential` skips the failed `ManagedIdentityCredential` and searches for the next available credential, which is `AzureCliCredential`.
1. The application starts utilizing the Azure CLI credentials rather than the managed identity, which may fail or result in unexpected elevation or reduction of privileges.

To prevent these types of subtle issues or silent failures in production apps, strongly consider moving from `DefaultAzureCredential` to one of the following deterministic solutions:

- A specific `TokenCredential` implementation, such as `ManagedIdentityCredential`. See the [**Derived** list](/dotnet/api/azure.core.tokencredential?view=azure-dotnet&preserve-view=true#definition) for options.
- A pared-down `ChainedTokenCredential` implementation optimized for the Azure environment in which your app runs. `ChainedTokenCredential` essentially creates a specific allow-list of acceptable credential options, such as `ManagedIdentity` for production and `VisualStudioCredential` for development.

For example, consider the following `DefaultAzureCredential` configuration in an ASP.NET Core project:

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_Dac" highlight="6,7":::

Replace the preceding code with a `ChainedTokenCredential` implementation that specifies only the necessary credentials:

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_Ctc" highlight="6-8":::

In this example, `ManagedIdentityCredential` would be automatically discovered in production, while `VisualStudioCredential` would work in local development environments.

## Reuse credential instances

Reuse credential instances when possible to improve app resilience and reduce the number of access token requests issued to Microsoft Entra ID. When a credential is reused, an attempt is made to fetch a token from the app token cache managed by the underlying MSAL dependency. For more information, see [Token caching in the Azure Identity client library](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/samples/TokenCache.md).

> [!IMPORTANT]
> A high-volume app that doesn't reuse credentials may encounter HTTP 429 throttling responses from Microsoft Entra ID, which can lead to app outages.

The recommended credential reuse strategy differs by .NET application type.

# [ASP.NET Core](#tab/aspdotnet)

Implement credential reuse through the `UseCredential` method of `Microsoft.Extensions.Azure`:

:::code language="csharp" source="../snippets/authentication/best-practices/Program.cs" id="snippet_credential_reuse_Dac" highlight="6" :::

For information on this approach, see [Authenticate using Microsoft Entra ID](/dotnet/azure/sdk/aspnetcore-guidance?tabs=api#authenticate-using-microsoft-entra-id).

# [Other](#tab/other)

:::code language="csharp" source="../snippets/authentication/best-practices/Program.cs" id="snippet_credential_reuse_noDac" highlight="8, 12" :::

---

## Understand the managed identity retry strategy

The Azure Identity library for .NET allows you to authenticate via managed identity with `ManagedIdentityCredential`. The way in which you use `ManagedIdentityCredential` impacts the applied retry strategy. When used via:

- `DefaultAzureCredential`, no retries are attempted when the initial token acquisition attempt fails or times out after a short duration, which makes this the least resilient option.
- Any other approach, such as `ChainedTokenCredential` or `ManagedIdentityCredential` directly:
  - The time interval between retries starts at 0.8 seconds, and a maximum of five retries are attempted.
  - To change any of the default retry settings, use the `Retry` property on `ManagedIdentityCredentialOptions`. For example, retry a maximum of three times, with a starting interval of 0.5 seconds:

    :::code language="csharp" source="../snippets/authentication/best-practices/Program.cs" id="snippet_retries" highlight="5-9" :::

For more information on customizing retry policies, see [Setting a custom retry policy](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Configuration.md#setting-a-custom-retry-policy).
