---
ms.topic: include
ms.date: 03/11/2025
---

Developers using Visual Studio 2017 or later can authenticate using their developer account through the IDE. Apps using `DefaultAzureCredential` or <xref:Azure.Identity.VisualStudioCredential> can discover and use this account to authenticate app requests when running locally. This account is also used when you publish apps directly from Visual Studio to Azure.

> [!NOTE]
> You'll need to [install the **Azure development** workload](/dotnet/azure/configure-visual-studio#install-azure-workloads) to enable additional Visual Studio tooling that helps with the development and deployment of applications on Azure.

1. Inside Visual Studio, navigate to **Tools** > **Options** to open the options dialog.
1. In the **Search Options** box at the top, type *Azure* to filter the available options.
1. Under **Azure Service Authentication**, choose **Account Selection**.
1. Select the drop-down menu under **Choose an account** and choose to add a Microsoft Account.
1. In the window that opens, enter the credentials for your desired Azure account, and then confirm your inputs.

    :::image type="content" source="../media/visual-studio-sign-in.png" alt-text="A screenshot showing how to sign-in to Azure using Visual Studio.":::

1. Select **OK** to close the options dialog.
