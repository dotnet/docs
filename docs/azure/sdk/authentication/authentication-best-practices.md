---
title: Authentication best practices with the Azure Identity library for .NET
description: This article describes authentication best practices to follow when using the Azure Identity library.
ms.topic: conceptual
ms.date: 01/15/2025
---

# Authentication best practices with the Azure Identity library for .NET

This article offers guidelines to help you maximize the performance and reliability of your .NET apps when authenticating to Azure services. To make the most of the Azure Identity library for .NET, it's important to understand potential issues and mitigation techniques.

## Use deterministic credentials in production environments

[!INCLUDE [default-azure-credential-usage](../includes/default-azure-credential-usage.md)]

## Reuse credential instances

Reuse credential instances when possible to improve app resilience and reduce the number of access token requests issued to Microsoft Entra ID. When a credential is reused, an attempt is made to fetch a token from the app token cache managed by the underlying MSAL dependency. For more information, see [Token caching in the Azure Identity client library](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/samples/TokenCache.md).

> [!NOTE]
> A high-volume app that doesn't reuse credentials may encounter HTTP 429 throttling responses from Microsoft Entra ID, which can lead to app outages.

In an ASP.NET Core app, implement credential reuse through the `UseCredential` method of `Microsoft.Extensions.Azure`:

:::code language="csharp" source="../snippets/auth-best-practices/Program.cs" id="snippet_credential_reuse_Dac" highlight="6,7" :::

For information on this approach, see [Authenticate using Microsoft Entra ID](/dotnet/azure/sdk/aspnetcore-guidance?tabs=api#authenticate-using-microsoft-entra-id).

Other types of .NET apps can reuse credential instances as follows:

:::code language="csharp" source="../snippets/auth-best-practices/Program.cs" id="snippet_credential_reuse_noDac" highlight="8, 12" :::

## Understand the managed identity retry strategy

The Azure Identity library for .NET allows you to authenticate via managed identity with `ManagedIdentityCredential`. The way you use `ManagedIdentityCredential` impacts the applied retry strategy:

- When used via `DefaultAzureCredential`:
  - No retries are attempted when token acquisition fails, which makes this the least resilient option.
- When used via any other approach, such as `ChainedTokenCredential` or `ManagedIdentityCredential` directly:
  - The time interval between retries starts at 0.8 seconds, and a maximum of five retries are attempted.
  - If the Azure service to which you're authenticating provides a `Retry-After` response header, the next retry is delayed by the duration specified in that header's value.
  - If the service doesn't provide a `Retry-After` header, the maximum permissible delay between retries is 1 minute.
  - To change any of the default retry settings, use the `Retry` property on `ManagedIdentityCredentialOptions`. For example, retry a maximum of three times, with a starting interval of 0.5 seconds:

:::code language="csharp" source="../snippets/auth-best-practices/Program.cs" id="snippet_retries" highlight="5-9":::
