---
title: Authenticate .NET apps to Azure using developer accounts
description: Learn how to authenticate your application to Azure services when using the Azure SDK for .NET during local development using user accounts.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 07/31/2024
---

# Authenticate .NET apps to Azure services during local development using developer accounts

During local development, applications need to authenticate to Azure to access various Azure services. Two common approaches for local authentication are to [use a service principal](local-development-service-principal.md) or to use a developer's user account. This article explains how to use a user account. In the sections ahead, you learn:

- How to use Microsoft Entra groups to efficiently manage permissions for multiple user accounts
- How to assign roles to user accounts to scope permissions
- How to sign-in to supported local development tools
- How to authenticate using a user account from your app code

:::image type="content" source="../media/local-dev-dev-accounts-overview.png" alt-text="A diagram showing an app running in local development using a developer tool identity to connect to Azure resources.":::

For an app to authenticate to Azure during local development using the developer's Azure credentials, the developer must be signed in to Azure from one of the following developer tools:

- Visual Studio
- Azure CLI
- Azure Developer CLI
- Azure PowerShell

The Azure Identity library can detect that the developer is signed in from one of these tools. The library can then obtain the Microsoft Entra access token via the tool to authenticate the app to Azure as the signed-in user.

This approach takes advantage of the developer's existing Azure accounts to streamline the authentication process. However, a developer's account likely has more permissions than required by the app, therefore exceeding the permissions the app runs with in production. As an alternative, you can [create application service principals to use during local development](./local-development-service-principal.md), which can be scoped to have only the access needed by the app.

[!INCLUDE [auth-create-entra-group](../includes/auth-create-entra-group.md)]

[!INCLUDE [auth-assign-group-roles](../includes/auth-assign-group-roles.md)]

## Sign in to Azure using developer tooling

Next, sign in to Azure using one of several developer tools. The account you authenticate should also exist in the Microsoft Entra group you created and configured earlier.

### [Visual Studio](#tab/sign-in-visual-studio)

1. Navigate to **Tools** > **Options** to open the options dialog.
1. In the **Search Options** box at the top, type *Azure* to filter the available options.
1. Under **Azure Service Authentication**, choose **Account Selection**.
1. Select the drop-down menu under **Choose an account** and choose to add a Microsoft Account. A window opens, prompting you to pick an account. Enter the credentials for your desired Azure account, and then select the confirmation.

    :::image type="content" source="../media/visual-studio-sign-in.png" alt-text="A screenshot showing how to sign in to Azure using Visual Studio.":::

1. Select **OK** to close the options dialog.

### [Azure CLI](#tab/sign-in-azure-cli)

Open a terminal on your developer workstation and sign in to Azure from the [Azure CLI](/cli/azure/what-is-azure-cli):

```azurecli
az login
```

### [Azure Developer CLI](#tab/sign-in-azure-developer-cli)

Open a terminal on your developer workstation and sign in to Azure from the [Azure Developer CLI](/azure/developer/azure-developer-cli/overview):

```azdeveloper
azd auth login
```

### [Azure PowerShell](#tab/sign-in-azure-powershell)

Open a terminal on your developer workstation and sign in to Azure from [Azure PowerShell](/powershell/azure/what-is-azure-powershell):

```azurepowershell
Connect-AzAccount
```

---

[!INCLUDE [Implement DefaultAzureCredential](<../includes/implement-defaultazurecredential.md>)]
