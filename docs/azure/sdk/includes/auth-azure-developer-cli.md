---
ms.topic: include
ms.date: 03/19/2025
---

Developers can use [Azure Developer CLI](/azure/developer/azure-developer-cli/overview) to authenticate. Apps using <xref:Azure.Identity.DefaultAzureCredential> or <xref:Azure.Identity.AzureDeveloperCliCredential> can then use this account to authenticate app requests.

To authenticate with the Azure Developer CLI, run the `azd auth login` command. On a system with a default web browser, the Azure Developer CLI launches the browser to authenticate the user.

```azdeveloper
azd auth login
```

For systems without a default web browser, the `azd auth login --use-device-code` uses the device code authentication flow. The user can also force the Azure Developer CLI to use the device code flow rather than launching a browser by specifying the `--use-device-code` argument.

```azdeveloper
azd auth login --use-device-code
```
