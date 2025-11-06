---
title: Authenticate .NET apps to Azure using brokered authentication.
description: Learn how to authenticate your app to Azure services when using the Azure SDK for .NET during local development using brokered authentication.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 08/20/2025
zone_pivot_groups: operating-systems-set-one
---

# Authenticate .NET apps to Azure services during local development using brokered authentication

Brokered authentication collects user credentials using the system authentication broker to authenticate an app with <xref:Azure.Identity.InteractiveBrowserCredential>. A system authentication broker is an app running on a user's machine that manages the authentication handshakes and token maintenance for all connected accounts.

Brokered authentication offers the following benefits:

- **Enables Single Sign-On (SSO):** Enables apps to simplify how users authenticate with Microsoft Entra ID and protects Microsoft Entra ID refresh tokens from exfiltration and misuse.
- **Enhanced security:** Many security enhancements are delivered with the broker, without needing to update the app logic.
- **Enhanced feature support:** With the help of the broker, developers can access rich OS and service capabilities.
- **System integration:** Applications that use the broker plug-and-play with the built-in account picker, allowing the user to quickly pick an existing account instead of reentering the same credentials over and over.
- **Token Protection:** Ensures that the refresh tokens are device bound and enables apps to acquire device bound access tokens. See [Token Protection](/azure/active-directory/conditional-access/concept-token-protection).

:::zone target="docs" pivot="os-windows"

Windows provides an authentication broker called [Web Account Manager (WAM)](/entra/msal/dotnet/acquiring-tokens/desktop-mobile/wam). WAM enables identity providers such as Microsoft Entra ID to natively plug into the OS and provide secure login services to apps. Brokered authentication enables the app for all operations allowed by the interactive login credentials.

Personal Microsoft accounts and work or school accounts are supported. On supported Windows versions, the default browser-based UI is replaced with a smoother authentication experience, similar to built-in Windows apps.

:::zone-end

:::zone target="docs" pivot="os-macos"

macOS doesn't natively include a built-in authentication broker. Brokered authentication is supported via the `Azure.Identity.Broker` library, which uses platform-specific mechanisms and may integrate with apps like Microsoft Company Portal when devices are managed. For more information, see [Microsoft Enterprise SSO plug-in for Apple devices](/entra/identity-platform/apple-sso-plugin).

:::zone-end

:::zone target="docs" pivot="os-linux"

Linux uses [Microsoft single sign-on for Linux](/entra/identity/devices/sso-linux) as its authentication broker.

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
