---
title: Authenticate .NET apps to Azure using developer accounts
description: Learn how to authenticate your application to Azure services when using the Azure SDK for .NET during local development using developer accounts.
ms.topic: how-to
ms.date: 03/14/2025
ms.custom:
  - devx-track-dotnet
  - engagement-fy23
  - devx-track-azurecli
  - sfi-image-nochange
---

# Authenticate .NET apps to Azure services during local development using developer accounts

During local development, applications need to authenticate to Azure to access various Azure services. You can authenticate locally using a developer account, a [broker](local-development-broker.md), or a [service principal](local-development-service-principal.md). This article explains how to use a developer account. In the sections ahead, you learn:

- How to use Microsoft Entra groups to efficiently manage permissions for multiple developer accounts
- How to assign roles to developer accounts to scope permissions
- How to sign-in to supported local development tools
- How to authenticate using a developer account from your app code

For an app to authenticate to Azure during local development using the developer's Azure credentials, the developer must be signed-in to Azure from one of the following developer tools:

- Azure CLI
- Azure Developer CLI
- Azure PowerShell
- Visual Studio
- Visual Studio Code

The Azure Identity library can detect that the developer is signed-in from one of these tools. The library can then obtain the Microsoft Entra access token via the tool to authenticate the app to Azure as the signed-in user.

This approach takes advantage of the developer's existing Azure accounts to streamline the authentication process. However, a developer's account likely has more permissions than required by the app, therefore exceeding the permissions the app runs with in production. As an alternative, you can [create application service principals to use during local development](./local-development-service-principal.md), which can be scoped to have only the access needed by the app.

[!INCLUDE [auth-create-entra-group](../includes/auth-create-entra-group.md)]

[!INCLUDE [auth-assign-group-roles](../includes/auth-assign-group-roles.md)]

## Sign-in to Azure using developer tooling

Next, sign-in to Azure using one of several developer tools that can be used to perform authentication in your development environment. The account you authenticate should also exist in the Microsoft Entra group you created and configured earlier.

### [Visual Studio](#tab/sign-in-visual-studio)

[!INCLUDE [auth-visual-studio](../includes/auth-visual-studio.md)]

### [Visual Studio Code](#tab/sign-in-visual-studio-code)

Developers using Visual Studio Code can authenticate with their developer account directly through the editor via the broker. Apps that use <xref:Azure.Identity.DefaultAzureCredential> or <xref:Azure.Identity.VisualStudioCodeCredential> can then use this account to authenticate app requests through a seamless single-sign-on experience.

1. In Visual Studio Code, go to the **Extensions** panel and install the [Azure Resources](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azureresourcegroups) extension. This extension lets you view and manage Azure resources directly from Visual Studio Code. It also uses the built-in Visual Studio Code Microsoft authentication provider to authenticate with Azure.

    :::image type="content" source="../media/azure-resources-extension.png" alt-text="Screenshot showing the Azure Resources extension.":::

1. Open the Command Palette in Visual Studio Code, then search for and select **Azure: Sign in**.

    :::image type="content" source="../media/visual-studio-code-sign-in.png" alt-text="Screenshot showing how to sign in to Azure in Visual Studio Code.":::

    > [!TIP]
    > Open the Command Palette using `Ctrl+Shift+P` on Windows/Linux or `Cmd+Shift+P` on macOS.

1. Add the [Azure.Identity.Broker](https://www.nuget.org/packages/Azure.Identity.Broker) NuGet package to your app:

    ```dotnetcli
    dotnet add package Azure.Identity.Broker
    ```

### [Azure CLI](#tab/sign-in-azure-cli)

Developers can use [Azure CLI](/cli/azure/what-is-azure-cli) to authenticate. Apps using <xref:Azure.Identity.DefaultAzureCredential> or <xref:Azure.Identity.AzureCliCredential> can then use this account to authenticate app requests.

To authenticate with the Azure CLI, run the `az login` command. On a system with a default web browser, the Azure CLI launches the browser to authenticate the user.

```azurecli
az login
```

For systems without a default web browser, the `az login` command uses the device code authentication flow. The user can also force the Azure CLI to use the device code flow rather than launching a browser by specifying the `--use-device-code` argument.

```azurecli
az login --use-device-code
```

### [Azure Developer CLI](#tab/sign-in-azure-developer-cli)

Developers can use [Azure Developer CLI](/azure/developer/azure-developer-cli/overview) to authenticate. Apps using <xref:Azure.Identity.DefaultAzureCredential> or <xref:Azure.Identity.AzureDeveloperCliCredential> can then use this account to authenticate app requests when running locally.

To authenticate with the Azure Developer CLI, run the `azd auth login` command. On a system with a default web browser, the Azure Developer CLI launches the browser to authenticate the user.

```azdeveloper
azd auth login
```

For systems without a default web browser, the `azd auth login --use-device-code` uses the device code authentication flow. The user can also force the the Azure Developer CLI to use the device code flow rather than launching a browser by specifying the `--use-device-code` argument.

```azdeveloper
azd auth login --use-device-code
```

### [Azure PowerShell](#tab/sign-in-azure-powershell)

Developers can use [Azure PowerShell](/powershell/azure/what-is-azure-powershell) to authenticate. Apps using <xref:Azure.Identity.DefaultAzureCredential> or <xref:Azure.Identity.AzurePowerShellCredential> can then use this account to authenticate app requests when running locally.

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
