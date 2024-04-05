---
author: fboucher
ms.author: frbouche
ms.date: 03/04/2024
ms.topic: include
---

## Prerequisites

- .NET 8.0 SDK - [Install the .NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- An Azure subscription - [Create one for free](https://azure.microsoft.com/free)
- Azure Developer CLI - [Install or update the Azure Developer CLI](/azure/developer/azure-developer-cli/install-azd)
- Access to [Azure OpenAI service](/azure/ai-services/openai/overview#how-do-i-get-access-to-azure-openai).

## Deploy the Azure resources

Ensure that you follow the [Prerequisites](#prerequisites) to have access to Azure OpenAI Service as well as the Azure Developer CLI, and then follow the following guide to set started with the sample application.

1. Clone the repository: [dotnet/ai-samples](https://github.com/dotnet/ai-samples)
1. From a terminal or command prompt, navigate to the _quickstarts_ directory.
1. This provisions the Azure OpenAI resources. It may take several minutes to create the Azure OpenAI service and deploy the model.

   ```azdeveloper
   azd up
   ```

> [!NOTE]
> If you already have an Azure OpenAI service available, you can skip the deployment and use that value in the _Program.cs_, preferably from an `IConfiguration`.

## Troubleshoot

On Windows, you might get the following error message after running `azd up`:
> *postprovision.ps1 is not digitally signed. The script will not execute on the system*

The script **postprovision.ps1** is executed to set the .NET user secrets used in the application. To avoid this error, run the following PowerShell command:

```powershell
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
```

Then re-run the `azd up` command.
