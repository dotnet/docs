---
title: 'Credential chains in the Azure Identity library for .NET'
description: 'This article describes the DefaultAzureCredential and ChainedTokenCredential classes in the Azure Identity library.'
ms.topic: conceptual
ms.date: 02/13/2025
---

# Credential chains in the Azure Identity library for .NET

The Azure Identity library provides *credentials*&mdash;public classes derived from the Azure Core library's [TokenCredential](/dotnet/api/azure.core.tokencredential?view=azure-dotnet&preserve-view=true) class. A credential represents a distinct authentication flow for acquiring an access token from Microsoft Entra ID. These credentials can be chained together to form an ordered sequence of authentication mechanisms to be attempted.

## How a chained credential works

At runtime, a credential chain attempts to authenticate using the sequence's first credential. If that credential fails to acquire an access token, the next credential in the sequence is attempted, and so on, until an access token is successfully obtained. The following sequence diagram illustrates this behavior:

:::image type="content" source="../media/mermaidjs/ChainSequence.svg" alt-text="Credential chain sequence diagram":::

## Why use credential chains

A chained credential can offer the following benefits:

- **Environment awareness**: Automatically selects the most appropriate credential based on the environment in which the app is running. Without it, you'd have to write code like this:

    :::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_NoChain":::

- **Seamless transitions**: Your app can move from local development to your staging or production environment without changing authentication code.
- **Improved resiliency**: Includes a fallback mechanism that moves to the next credential when the prior fails to acquire an access token.

## How to choose a chained credential

There are two disparate philosophies to credential chaining:

- **"Tear down" a chain**: Start with a preconfigured chain and exclude what you don't need. For this approach, see the [DefaultAzureCredential overview](#defaultazurecredential-overview) section.
- **"Build up" a chain**: Start with an empty chain and include only what you need. For this approach, see the [ChainedTokenCredential overview](#chainedtokencredential-overview) section.

## DefaultAzureCredential overview

[DefaultAzureCredential](/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet&preserve-view=true) is an opinionated, preconfigured chain of credentials. It's designed to support many environments, along with the most common authentication flows and developer tools. In graphical form, the underlying chain looks like this:

:::image type="content" source="../media/mermaidjs/DefaultAzureCredentialAuthFlow.svg" alt-text="DefaultAzureCredential auth flowchart":::

The order in which `DefaultAzureCredential` attempts credentials follows.

| Order | Credential          | Description | Enabled by default? |
|-------|---------------------|-------------|---------------------|
| 1     | [Environment][env-cred]         |Reads a collection of [environment variables][env-vars] to determine if an application service principal (application user) is configured for the app. If so, `DefaultAzureCredential` uses these values to authenticate the app to Azure. This method is most often used in server environments but can also be used when developing locally.             | Yes                 |
| 2     | [Workload Identity][wi-cred]   |If the app is deployed to an Azure host with Workload Identity enabled, authenticate that account.             | Yes                 |
| 3     | [Managed Identity][mi-cred]    |If the app is deployed to an Azure host with Managed Identity enabled, authenticate the app to Azure using that Managed Identity.             | Yes                 |
| 4     | [Visual Studio][vs-cred]       |If the developer authenticated to Azure by logging into Visual Studio, authenticate the app to Azure using that same account.             | Yes                 |
| 5     | [Azure CLI][az-cred]           |If the developer authenticated to Azure using Azure CLI's `az login` command, authenticate the app to Azure using that same account.             | Yes                 |
| 6     | [Azure PowerShell][pwsh-cred]    |If the developer authenticated to Azure using Azure PowerShell's `Connect-AzAccount` cmdlet, authenticate the app to Azure using that same account.             | Yes                 |
| 7     | [Azure Developer CLI][azd-cred] |If the developer authenticated to Azure using Azure Developer CLI's `azd auth login` command, authenticate with that account.             | Yes                 |
| 8     | [Interactive browser][int-cred]         |If enabled, interactively authenticate the developer via the current system's default browser.             | No                  |

[env-cred]: /dotnet/api/azure.identity.environmentcredential?view=azure-dotnet&preserve-view=true
[wi-cred]: /dotnet/api/azure.identity.workloadidentitycredential?view=azure-dotnet&preserve-view=true
[mi-cred]: /dotnet/api/azure.identity.managedidentitycredential?view=azure-dotnet&preserve-view=true
[vs-cred]: /dotnet/api/azure.identity.visualstudiocredential?view=azure-dotnet&preserve-view=true
[az-cred]: /dotnet/api/azure.identity.azureclicredential?view=azure-dotnet&preserve-view=true
[pwsh-cred]: /dotnet/api/azure.identity.azurepowershellcredential?view=azure-dotnet&preserve-view=true
[azd-cred]: /dotnet/api/azure.identity.azuredeveloperclicredential?view=azure-dotnet&preserve-view=true
[int-cred]: /dotnet/api/azure.identity.interactivebrowsercredential?view=azure-dotnet&preserve-view=true

In its simplest form, you can use the parameterless version of `DefaultAzureCredential` as follows:

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_Dac" highlight="8":::

> [!TIP]
> The `UseCredential` method in the preceding code snippet is recommended for use in ASP.NET Core apps. For more information, see [Use the Azure SDK for .NET in ASP.NET Core apps](../aspnetcore-guidance.md#authenticate-using-microsoft-entra-id).

### How to customize DefaultAzureCredential

To remove a credential from `DefaultAzureCredential`, use the corresponding `Exclude`-prefixed property in [DefaultAzureCredentialOptions](/dotnet/api/azure.identity.defaultazurecredentialoptions?view=azure-dotnet&preserve-view=true#properties). For example:

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_DacExcludes" highlight="11-13":::

In the preceding code sample, `EnvironmentCredential`, `ManagedIdentityCredential`, and `WorkloadIdentityCredential` are removed from the credential chain. As a result, the first credential to be attempted is `VisualStudioCredential`. The modified chain contains only development-time credentials and looks like this:

:::image type="content" source="../media/mermaidjs/DefaultAzureCredentialExcludes.svg" alt-text="DefaultAzureCredential using Excludes properties":::

> [!NOTE]
> `InteractiveBrowserCredential` is excluded by default and therefore isn't shown in the preceding diagram. To include `InteractiveBrowserCredential`, either pass `true` to constructor <xref:Azure.Identity.DefaultAzureCredential.%23ctor%28System.Boolean%29> or set property <xref:Azure.Identity.DefaultAzureCredentialOptions.ExcludeInteractiveBrowserCredential%2A?displayProperty=nameWithType> to `false`.

As more `Exclude`-prefixed properties are set to `true` (credential exclusions are configured), the advantages of using `DefaultAzureCredential` diminish. In such cases, `ChainedTokenCredential` is a better choice and requires less code. To illustrate, these two code samples behave the same way:

### [DefaultAzureCredential](#tab/dac)

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_DacEquivalents":::

### [ChainedTokenCredential](#tab/ctc)

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_CtcEquivalents":::

---

## ChainedTokenCredential overview

[ChainedTokenCredential](/dotnet/api/azure.identity.chainedtokencredential?view=azure-dotnet&preserve-view=true) is an empty chain to which you add credentials to suit your app's needs. For example:

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_Ctc" highlight="8-10" :::

The preceding code sample creates a tailored credential chain comprised of two development-time credentials. `AzurePowerShellCredential` is attempted first, followed by `VisualStudioCredential`, if necessary. In graphical form, the chain looks like this:

:::image type="content" source="../media/mermaidjs/ChainedTokenCredentialAuthFlow.svg" alt-text="ChainedTokenCredential":::

> [!TIP]
> For improved performance, optimize credential ordering in `ChainedTokenCredential` from most to least used credential.

## Usage guidance for DefaultAzureCredential

`DefaultAzureCredential` is undoubtedly the easiest way to get started with the Azure Identity library, but with that convenience comes tradeoffs. Once you deploy your app to Azure, you should understand the app's authentication requirements. For that reason, replace `DefaultAzureCredential` with a specific `TokenCredential` implementation, such as `ManagedIdentityCredential`. See the [**Derived** list](/dotnet/api/azure.core.tokencredential?view=azure-dotnet&preserve-view=true#definition) for options.

Here's why:

- **Debugging challenges**: When authentication fails, it can be challenging to debug and identify the offending credential. You must enable logging to see the progression from one credential to the next and the success/failure status of each. For more information, see [Debug a chained credential](#debug-a-chained-credential).
- **Performance overhead**: The process of sequentially trying multiple credentials can introduce performance overhead. For example, when running on a local development machine, managed identity is unavailable. Consequently, `ManagedIdentityCredential` always fails in the local development environment, unless explicitly disabled via its corresponding `Exclude`-prefixed property.
- **Unpredictable behavior**: `DefaultAzureCredential` checks for the presence of certain [environment variables][env-vars]. It's possible that someone could add or modify these environment variables at the system level on the host machine. Those changes apply globally and therefore alter the behavior of `DefaultAzureCredential` at runtime in any app running on that machine. For more information on unpredictability, see [Use deterministic credentials in production environments](best-practices.md#use-deterministic-credentials-in-production-environments).

## Debug a chained credential

To diagnose an unexpected issue or to understand what a chained credential is doing, [enable logging](../logging.md) in your app. Optionally, filter the logs to only those events emitted from the Azure Identity library. For example:

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_FilteredLogging":::

For illustration purposes, assume the parameterless form of `DefaultAzureCredential` was used to authenticate a request to a Log Analytics workspace. The app ran in the local development environment, and Visual Studio was authenticated to an Azure account. The next time the app ran, the following pertinent entries appeared in the output:

:::code language="output" source="../snippets/authentication/credential-chains/dac-logs.txt":::

In the preceding output, notice that:

- `EnvironmentCredential`, `WorkloadIdentityCredential`, and `ManagedIdentityCredential` each failed to acquire a Microsoft Entra access token, in that order.
- The `DefaultAzureCredential credential selected:`-prefixed entry indicates the credential that was selected&mdash;`VisualStudioCredential` in this case. Since `VisualStudioCredential` succeeded, no credentials beyond it were used.

<!-- LINKS -->
[env-vars]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#environment-variables
