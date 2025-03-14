---
title: Authenticate .NET apps to Azure using developer accounts
description: Learn how to authenticate your application to Azure services when using the Azure SDK for .NET during local development using developer accounts.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 07/31/2024
---

# Authenticate .NET apps to Azure services during local development using developer accounts

During local development, applications need to authenticate to Azure to access various Azure services. Two common approaches for local authentication are to [use a service principal](local-development-service-principal.md) or to use a developer account. This article explains how to use a developer account. In the sections ahead, you learn:

- How to use Microsoft Entra groups to efficiently manage permissions for multiple developer accounts
- How to assign roles to developer accounts to scope permissions
- How to sign-in to supported local development tools
- How to authenticate using a developer account from your app code

:::image type="content" source="../media/local-dev-dev-accounts-overview.png" alt-text="A diagram showing an app running in local development using a developer tool identity to connect to Azure resources.":::

For an app to authenticate to Azure during local development using the developer's Azure credentials, the developer must be signed-in to Azure from one of the following developer tools:

- Azure CLI
- Azure Developer CLI
- Azure PowerShell
- Visual Studio

The Azure Identity library can detect that the developer is signed-in from one of these tools. The library can then obtain the Microsoft Entra access token via the tool to authenticate the app to Azure as the signed-in user.

This approach takes advantage of the developer's existing Azure accounts to streamline the authentication process. However, a developer's account likely has more permissions than required by the app, therefore exceeding the permissions the app runs with in production. As an alternative, you can [create application service principals to use during local development](./local-development-service-principal.md), which can be scoped to have only the access needed by the app.

[!INCLUDE [auth-create-entra-group](../includes/auth-create-entra-group.md)]

[!INCLUDE [auth-assign-group-roles](../includes/auth-assign-group-roles.md)]

## Sign-in to Azure using developer tooling

Next, sign-in to Azure using one of several developer tools that can be used to perform authentication in your development environment. The account you authenticate should also exist in the Microsoft Entra group you created and configured earlier.

### [Visual Studio](#tab/sign-in-visual-studio)

Developers using Visual Studio 2017 or later can authenticate using their developer account through the IDE. Apps using `DefaultAzureCredential` or `VisualStudioCredential` can discover and use this account to authenticate app requests when running locally.

1. Inside Visual Studio, navigate to **Tools** > **Options** to open the options dialog.
1. In the **Search Options** box at the top, type *Azure* to filter the available options.
1. Under **Azure Service Authentication**, choose **Account Selection**.
1. Select the drop-down menu under **Choose an account** and choose to add a Microsoft Account.
1. In the window that opens, enter the credentials for your desired Azure account, and then confirm your inputs.

    :::image type="content" source="../media/visual-studio-sign-in.png" alt-text="A screenshot showing how to sign-in to Azure using Visual Studio.":::

1. Select **OK** to close the options dialog.

### [Azure CLI](#tab/sign-in-azure-cli)

Developers coding outside of an IDE can also use the [Azure CLI](/cli/azure/what-is-azure-cli) to authenticate. Apps using `DefaultAzureCredential` or `AzureCliCredential` can then use this account to authenticate app requests when running locally.

To authenticate with the Azure CLI, run the `az login` command. On a system with a default web browser, the Azure CLI launches the browser to authenticate the user.

```azurecli
az login
```

For systems without a default web browser, the `az login` command uses the device code authentication flow. The user can also force the Azure CLI to use the device code flow rather than launching a browser by specifying the `--use-device-code` argument.

```azurecli
az login --use-device-code
```

### [Azure Developer CLI](#tab/sign-in-azure-developer-cli)

Developers coding outside of an IDE can also use the [Azure Developer CLI](/azure/developer/azure-developer-cli/overview) to authenticate. Apps using `DefaultAzureCredential` or `AzureDeveloperCliCredential` can then use this account to authenticate app requests when running locally.

To authenticate with the Azure Developer CLI, run the `azd auth login` command. On a system with a default web browser, the Azure Developer CLI launches the browser to authenticate the user.

```azdeveloper
azd auth login
```

For systems without a default web browser, the `azd auth login --use-device-code` uses the device code authentication flow. The user can also force the the Azure Developer CLI to use the device code flow rather than launching a browser by specifying the `--use-device-code` argument.

```bash
azd auth login --use-device-code
```

### [Azure PowerShell](#tab/sign-in-azure-powershell)

Developers coding outside of an IDE can also use [Azure PowerShell](/powershell/azure/what-is-azure-powershell) to authenticate. Apps using `DefaultAzureCredential` or `AzurePowerShellCredential` can then use this account to authenticate app requests when running locally.

To authenticate with Azure PowerShell, run the command `Connect-AzAccount`. On a system with a default web browser and version 5.0.0 or later of Azure PowerShell, it launches the browser to authenticate the user.

```azurepowershell
Connect-AzAccount
```

For systems without a default web browser, the `Connect-AzAccount` command uses the device code authentication flow. The user can also force Azure PowerShell to use the device code flow rather than launching a browser by specifying the `UseDeviceAuthentication` argument.

```azurepowershell
Connect-AzAccount -UseDeviceAuthentication
```

---

[!INCLUDE [Implement DefaultAzureCredential](<../includes/implement-defaultazurecredential.md>)]
