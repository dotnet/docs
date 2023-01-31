---
title: Configure Visual Studio Code for Azure development with .NET
description: This article helps you configure Visual Studio Code for Azure development including getting the right plugins installed and configured in VS Code
ms.topic: conceptual
ms.custom: devx-track-dotnet, vscode-azure-extension-update-completed, engagement-fy23
ms.date: 1/26/2023
author: alexwolfmsft
ms.author: alexwolf
recommendations: false
---

# Configure Visual Studio Code for Azure development

If you're using Visual Studio Code, whether for .NET development, for building single page applications using frameworks like Angular, React or Vue, or for writing applications in another language like Python, you'll want to configure Visual Studio Code for Azure development.

### Download Visual Studio Code

If you already have Visual Studio Code installed, you can skip this step

> [!div class="nextstepaction"]
> [Download Visual Studio Code](https://code.visualstudio.com/download)

### Install the Azure Tools Extension Pack

The [Azure Tools Extension Pack](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-node-azure-pack) contains extensions for working with Azure App Service, Azure Functions, Azure Storage, Cosmos DB, and Azure Virtual Machines all in one convenient package.

To install the extension from Visual Studio Code:

1. Press <kbd>Ctrl+Shift+X</kbd> to open the **Extensions** window.
1. Search for the *Azure Tools* extension.
1. Select the **Install** button.

:::image type="content" source="media/visual-studio-code-azure-tools.png" lightbox="media/visual-studio-code-azure-tools.png" alt-text="A screenshot of Visual Studio Code showing the extensions panel searching for the Azure Tools extension pack.":::

To learn more about installing extensions in Visual Studio Code, refer to the [Extension Marketplace](https://code.visualstudio.com/docs/editor/extension-gallery) document on the Visual Studio Code website.

### Sign in to your Azure account with Azure Tools

On the left hand panel, you'll see an Azure icon. Select this icon, and a control panel for Azure services will appear. Choose **Sign in to Azure...** to complete the authentication process for the Azure tools in Visual Studio Code.

:::image type="content" source="media/visual-studio-code-azure-login-small.png" lightbox="media/visual-studio-code-azure-login.png" alt-text="A screenshot of Visual Studio Code showing how to sign-in to the Azure tools.":::

After you've signed-in, you'll see all of your existing resources in the **Resources** view. You can create and manage these services directly from Visual Studio Code. You'll also see a **Workspace** view that includes local tasks specific to your workspace and files on your machine, such as attaching to a Database or deploying your current workspace to Azure.

:::image type="content" source="media/visual-studio-code-extension-resources.png" lightbox="media/visual-studio-code-azure-login.png" alt-text="A screenshot of Visual Studio Code showing the extension resources view.":::

### Next steps

Next, you'll want to install the Azure CLI on your workstation.

> [!div class="nextstepaction"]
> [Install the Azure CLI](./install-azure-cli.md)
