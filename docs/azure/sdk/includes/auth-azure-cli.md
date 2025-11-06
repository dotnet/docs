---
ms.topic: include
ms.date: 03/19/2025
---

Developers can use [Azure CLI](/cli/azure/what-is-azure-cli) to authenticate. Apps using <xref:Azure.Identity.DefaultAzureCredential> or <xref:Azure.Identity.AzureCliCredential> can then use this account to authenticate app requests.

To authenticate with the Azure CLI, run the `az login` command. On a system with a default web browser, the Azure CLI launches the browser to authenticate the user.

```azurecli
az login
```

For systems without a default web browser, the `az login` command uses the device code authentication flow. The user can also force the Azure CLI to use the device code flow rather than launching a browser by specifying the `--use-device-code` argument.

```azurecli
az login --use-device-code
```