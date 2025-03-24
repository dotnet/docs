---
title: 'Credential chains in the Azure Identity library for .NET'
description: 'This article describes the DefaultAzureCredential and ChainedTokenCredential classes in the Azure Identity library.'
ms.topic: conceptual
ms.date: 02/13/2025
---

# Credential chains in the Azure Identity library for .NET

The Azure Identity library provides *credentials*&mdash;public classes derived from the Azure Core library's [TokenCredential](/dotnet/api/azure.core.tokencredential?view=azure-dotnet&preserve-view=true) class. A credential represents a distinct authentication flow for acquiring an access token from Microsoft Entra ID. These credentials can be chained together to form an ordered sequence of authentication mechanisms to be attempted.

[!INCLUDE [credential-chains-how-why](../includes/credential-chains-how-why.md)]

[!INCLUDE [defaultazurecredential-overview](../includes/defaultazurecredential-overview.md)]

## Implement DefaultAzureCredential

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

[!INCLUDE [defaultazurecredential-usage-guidance](../includes/defaultazurecredential-usage-guidance.md)]

## Debug a chained credential

To diagnose an unexpected issue or to understand what a chained credential is doing, [enable logging](../logging.md) in your app. Optionally, filter the logs to only those events emitted from the Azure Identity library. For example:

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_FilteredLogging":::

For illustration purposes, assume the parameterless form of `DefaultAzureCredential` was used to authenticate a request to a Log Analytics workspace. The app ran in the local development environment, and Visual Studio was authenticated to an Azure account. The next time the app ran, the following pertinent entries appeared in the output:

:::code language="output" source="../snippets/authentication/credential-chains/dac-logs.txt":::

In the preceding output, notice that:

- `EnvironmentCredential`, `WorkloadIdentityCredential`, and `ManagedIdentityCredential` each failed to acquire a Microsoft Entra access token, in that order.
- The `DefaultAzureCredential credential selected:`-prefixed entry indicates the credential that was selected&mdash;`VisualStudioCredential` in this case. Since `VisualStudioCredential` succeeded, no credentials beyond it were used.
