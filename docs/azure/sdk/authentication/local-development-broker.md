---
title: Authenticate .NET apps to Azure using brokered authentication.
description: Learn how to authenticate your app to Azure services when using the Azure SDK for .NET during local development using brokered authentication.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 08/20/2025
zone_pivot_groups: operating-systems-set-one
---

# Authenticate .NET apps to Azure services during local development using brokered authentication

[!INCLUDE [broker-intro](../includes/broker-intro.md)]

:::zone target="docs" pivot="os-windows"

[!INCLUDE [broker-windows](../includes/broker-windows.md)]

:::zone-end

:::zone target="docs" pivot="os-macos"

[!INCLUDE [broker-mac](../includes/broker-mac.md)]

:::zone-end

:::zone target="docs" pivot="os-linux"

[!INCLUDE [broker-linux](../includes/broker-linux.md)]

:::zone-end

[!INCLUDE [broker-configure-app](../includes/broker-configure-app.md)]

[!INCLUDE [broker-assign-roles](../includes/broker-assign-roles.md)]

## Implement the code

:::zone target="docs" pivot="os-windows, os-macos"

The Azure Identity library supports brokered authentication using <xref:Azure.Identity.InteractiveBrowserCredential>. For example, to use `InteractiveBrowserCredential` in a MAUI app to authenticate to Azure Key Vault with the [`SecretClient`](/dotnet/api/azure.security.keyvault.secrets.secretclient), follow these steps:

:::zone-end

:::zone target="docs" pivot="os-linux"

The Azure Identity library provide interactive brokered authentication using <xref:Azure.Identity.InteractiveBrowserCredential>. For example, to use `InteractiveBrowserCredential` in a console app to authenticate to Azure Key Vault with the [`SecretClient`](/dotnet/api/azure.security.keyvault.secrets.secretclient), follow these steps:

:::zone-end

:::zone target="docs" pivot="os-windows"

1. Install the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) and [Azure.Identity.Broker](https://www.nuget.org/packages/Azure.Identity.Broker) packages.

    ```dotnetcli
    dotnet add package Azure.Identity
    dotnet add package Azure.Identity.Broker
    ```

1. Get a reference to the parent window on top of which the account picker dialog should appear.
1. Create an instance of <xref:Azure.Identity.InteractiveBrowserCredential> using <xref:Azure.Identity.Broker.InteractiveBrowserCredentialBrokerOptions>.

:::code language="csharp" source="../snippets/authentication/brokered/maui-app/MainPage.xaml.cs" id="snippet_brokered_windows" highlight="6-13":::

:::zone-end

:::zone target="docs" pivot="os-macos"

1. Install the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) and [Azure.Identity.Broker](https://www.nuget.org/packages/Azure.Identity.Broker) packages.

    ```dotnetcli
    dotnet add package Azure.Identity
    dotnet add package Azure.Identity.Broker
    ```

    > [!NOTE]
    > macOS support exists in `Azure.Identity.Broker` versions 1.3.0 and later.

2. Get a reference to the parent window on top of which the account picker dialog should appear.
3. Create an instance of <xref:Azure.Identity.InteractiveBrowserCredential> using <xref:Azure.Identity.Broker.InteractiveBrowserCredentialBrokerOptions>.

:::code language="csharp" source="../snippets/authentication/brokered/maui-app/MainPage.xaml.cs" id="snippet_brokered_macos" highlight="6-13":::

:::zone-end

:::zone target="docs" pivot="os-linux"

1. Install the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) and [Azure.Identity.Broker](https://www.nuget.org/packages/Azure.Identity.Broker) packages.

    ```dotnetcli
    dotnet add package Azure.Identity
    dotnet add package Azure.Identity.Broker
    ```

    > [!NOTE]
    > Linux support exists in `Azure.Identity.Broker` versions 1.3.0 and later.

2. Get a reference to the parent window on top of which the account picker dialog should appear.
3. Create an instance of <xref:Azure.Identity.InteractiveBrowserCredential> using <xref:Azure.Identity.Broker.InteractiveBrowserCredentialBrokerOptions>.

:::code language="csharp" source="../snippets/authentication/brokered/console-app/Program.cs" id="snippet_brokered_linux" highlight="15-21":::

:::zone-end

> [!TIP]
> View the [complete sample app code](https://github.com/dotnet/docs/tree/main/docs/azure/sdk/snippets/authentication/brokered) in the .NET docs GitHub repository.

In the preceding example, property <xref:Azure.Identity.Broker.InteractiveBrowserCredentialBrokerOptions.UseDefaultBrokerAccount%2A> is set to `true`, which opts into a silent, brokered authentication flow with the default system account. In this way, the user doesn't have to repeatedly select the same account. If silent, brokered authentication fails, or `UseDefaultBrokerAccount` is set to `false`, `InteractiveBrowserCredential` falls back to interactive, brokered authentication.

:::zone target="docs" pivot="os-windows"

The following screenshot shows the alternative interactive, brokered authentication experience:

:::image type="content" source="../media/broker-web-account-manager-account-picker.png" alt-text="A screenshot that shows the Windows sign-in experience when using a broker-enabled InteractiveBrowserCredential instance to authenticate a user.":::

:::zone-end

:::zone target="docs" pivot="os-macos"

The following screenshot shows the alternative interactive, brokered authentication experience:

:::image type="content" source="../media/broker-macos-account-picker.png" alt-text="A screenshot that shows the macOS sign-in experience when using a broker-enabled InteractiveBrowserCredential instance to authenticate a user.":::

:::zone-end

:::zone target="docs" pivot="os-linux"

The following video shows the alternative interactive, brokered authentication experience:

:::image type="content" source="../media/broker-linux-login.gif" alt-text="An animated gif that shows the Linux sign-in experience when using a broker-enabled InteractiveBrowserCredential instance to authenticate a user.":::

:::zone-end
