---
title: Authentication best practices with the Azure Identity library for .NET
description: This article describes authentication best practices to follow when using the Azure Identity library for .NET.
ms.topic: concept-article
ms.date: 02/14/2025
---

# Authentication best practices with the Azure Identity library for .NET

This article offers guidelines to help you maximize the performance and reliability of your .NET apps when authenticating to Azure services. To make the most of the Azure Identity library for .NET, it's important to understand potential issues and mitigation techniques.

## Use deterministic credentials in production environments

[`DefaultAzureCredential`](/dotnet/azure/sdk/authentication/credential-chains?tabs=dac#defaultazurecredential-overview) is the most approachable way to get started with the Azure Identity library, but that convenience also introduces certain tradeoffs. Most notably, the specific credential in the chain that will succeed and be used for request authentication can't be guaranteed ahead of time. In a production environment, this unpredictability can introduce significant and sometimes subtle problems.

For example, consider the following hypothetical sequence of events:

1. An organization's security team mandates all apps use managed identity to authenticate to Azure resources.
1. For months, a .NET app hosted on an Azure Virtual Machine (VM) successfully uses `DefaultAzureCredential` to authenticate via managed identity.
1. Without telling the support team, a developer installs the Azure CLI on that VM and runs the `az login` command to authenticate to Azure.
1. Due to a separate configuration change in the Azure environment, authentication via the original managed identity unexpectedly begins to fail silently.
1. `DefaultAzureCredential` skips the failed `ManagedIdentityCredential` and searches for the next available credential, which is `AzureCliCredential`.
1. The application starts utilizing the Azure CLI credentials rather than the managed identity, which may fail or result in unexpected elevation or reduction of privileges.

To prevent these types of subtle issues or silent failures in production apps, replace `DefaultAzureCredential` with a specific `TokenCredential` implementation, such as `ManagedIdentityCredential`. See the [**Derived** list](/dotnet/api/azure.core.tokencredential?view=azure-dotnet&preserve-view=true#definition) for options.

For example, consider the following `DefaultAzureCredential` configuration in an ASP.NET Core project:

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_Dac" highlight="8-9":::

Modify the preceding code to select a credential based on the environment in which the app is running:

:::code language="csharp" source="../snippets/authentication/best-practices/CCA/Program.cs" id="snippet_credential_reuse_AspNetCore" highlight="8-25":::

In this example, only `ManagedIdentityCredential` is used in production. The local development environment's authentication needs are then serviced by the sequence of credentials defined in the `else` clause.

## Reuse credential instances

Reuse credential instances when possible to improve app resilience and reduce the number of access token requests issued to Microsoft Entra ID. When a credential is reused, an attempt is made to fetch a token from the app token cache managed by the underlying MSAL dependency. For more information, see [Token caching in the Azure Identity client library](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/samples/TokenCache.md).

> [!IMPORTANT]
> A high-volume app that doesn't reuse credentials may encounter HTTP 429 throttling responses from Microsoft Entra ID, which can lead to app outages.

The recommended credential reuse strategy differs by .NET application type.

# [ASP.NET Core](#tab/aspdotnet)

To implement credential reuse, use the <xref:Microsoft.Extensions.Azure.AzureClientFactoryBuilder.UseCredential%2A> method from `Microsoft.Extensions.Azure`. Consider an ASP.NET Core app hosted on Azure App Service in both production and staging environments. Environment variable `ASPNETCORE_ENVIRONMENT` is set to either `Production` or `Staging` to differentiate between these two non-development environments. In both production and staging, the user-assigned variant of `ManagedIdentityCredential` is used to authenticate the Key Vault Secrets and Blob Storage clients.

When the app runs on a local development machine, where `ASPNETCORE_ENVIRONMENT` is set to `Development`, a chained sequence of developer tool credentials is used instead. This approach ensures environment-appropriate credentials are used, enhancing security and simplifying credential management.

:::code language="csharp" source="../snippets/authentication/best-practices/CCA/Program.cs" id="snippet_credential_reuse_AspNetCore" highlight="25":::

For information on this approach in an ASP.NET Core app, see [Authenticate using Microsoft Entra ID](/dotnet/azure/sdk/aspnetcore-guidance?tabs=api#authenticate-using-microsoft-entra-id).

# [Other](#tab/other)

In non-ASP.NET Core apps, credential reuse is accomplished by passing the same credential instance to each client constructor. For example, imagine a WPF app using the authentication broker on Windows.

:::code language="csharp" source="../snippets/authentication/best-practices/PCA/MainWindow.xaml.cs" id="snippet_credential_reuse_nonAspNetCore" highlight="12, 16":::

---

## Understand when token lifetime and caching logic is needed

If you use an Azure Identity library credential outside the context of [an Azure SDK client library that depends on Azure Core](../packages.md#libraries-using-azurecore), it becomes your responsibility to manage [token lifetime](/entra/identity-platform/access-tokens#token-lifetime) and caching behavior in your app.

The <xref:Azure.Core.AccessToken.RefreshOn%2A> property on `AccessToken`, which provides a hint to consumers as to when token refresh can be attempted, will be automatically used by Azure SDK client libraries that depend on the Azure Core library to refresh the token. For direct usage of Azure Identity library [credentials that support token caching](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/samples/TokenCache.md#credentials-supporting-token-caching), the underlying MSAL cache automatically refreshes proactively when the `RefreshOn` time occurs. This design allows the client code to call `GetToken` each time a token is needed and delegate the refresh to the library.

To only call `GetToken` when necessary, observe the `RefreshOn` date and proactively attempt to refresh the token after that time. The specific implementation is up to the customer.

## Understand the managed identity retry strategy

The Azure Identity library for .NET allows you to authenticate via managed identity with `ManagedIdentityCredential`. The way in which you use `ManagedIdentityCredential` impacts the applied retry strategy. When used via:

- `DefaultAzureCredential`, no retries are attempted when the initial token acquisition attempt fails or times out after a short duration. This is the least resilient option because it's optimized to "fail fast" for an efficient development inner loop.
- Any other approach, such as `ChainedTokenCredential` or `ManagedIdentityCredential` directly:
  - The time interval between retries starts at 0.8 seconds, and a maximum of five retries are attempted, by default. This option is optimized for resilience but introduces potentially unwanted delays in the development inner loop.
  - To change any of the default retry settings, use the `Retry` property on `ManagedIdentityCredentialOptions`. For example, retry a maximum of three times, with a starting interval of 0.5 seconds:

    :::code language="csharp" source="../snippets/authentication/best-practices/CCA/Program.cs" id="snippet_retries" highlight="5-9":::

For more information on customizing retry policies, see [Setting a custom retry policy](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Configuration.md#setting-a-custom-retry-policy).
