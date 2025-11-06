---
ms.topic: include
ms.date: 03/19/2025
---

Developers can use [Azure PowerShell](/powershell/azure/what-is-azure-powershell) to authenticate. Apps using <xref:Azure.Identity.DefaultAzureCredential> or <xref:Azure.Identity.AzurePowerShellCredential> can then use this account to authenticate app requests.

To authenticate with Azure PowerShell, run the command `Connect-AzAccount`. On a system with a default web browser and version 5.0.0 or later of Azure PowerShell, it launches the browser to authenticate the user.

```azurepowershell
Connect-AzAccount
```

For systems without a default web browser, the `Connect-AzAccount` command uses the device code authentication flow. The user can also force Azure PowerShell to use the device code flow rather than launching a browser by specifying the `UseDeviceAuthentication` argument.

```azurepowershell
Connect-AzAccount -UseDeviceAuthentication
```
