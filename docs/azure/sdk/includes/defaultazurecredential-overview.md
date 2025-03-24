---
ms.topic: include
ms.date: 08/15/2024
---

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