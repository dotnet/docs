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

## Configure the app for brokered authentication

To enable brokered authentication in your application, follow these steps:

1. In the [Azure portal](https://portal.azure.com), navigate to **Microsoft Entra ID** and select **App registrations** on the left-hand menu.
1. Select the registration for your app, then select **Authentication**.
1. Add the appropriate redirect URI to your app registration via a platform configuration:
    1. Under **Platform configurations**, select **+ Add a platform**.
    1. Under **Configure platforms**, select the tile for your application type (platform) to configure its settings, such as **mobile and desktop applications**.
    1. In **Custom redirect URIs**, enter the following redirect URI for your platform:

        | Platform    | Redirect URI                                                                                                          |
        |-------------|-----------------------------------------------------------------------------------------------------------------------|
        | Windows 10+ or WSL | `ms-appx-web://Microsoft.AAD.BrokerPlugin/{your_client_id}`                                                             |
        | macOS       | `msauth.com.msauth.unsignedapp://auth` for unsigned apps<br>`msauth.{bundle_id}://auth` for signed apps                    |
        | Linux       | `https://login.microsoftonline.com/common/oauth2/nativeclient`                                                        |

        Replace `{your_client_id}` or `{bundle_id}` with the **Application (client) ID** from the app registration's **Overview** pane.

    1. Select **Configure**.

    To learn more, see [Add a redirect URI to an app registration](/entra/identity-platform/quickstart-register-app#add-a-redirect-uri).

1. Back on the **Authentication** pane, under **Advanced settings**, select **Yes** for **Allow public client flows**.
1. Select **Save** to apply the changes.
1. To authorize the application for specific resources, navigate to the resource in question, select **API Permissions**, and enable **Microsoft Graph** and other resources you want to access.

    > [!IMPORTANT]
    > You must also be the admin of your tenant to grant consent to your application when you sign in for the first time.

## Assign roles

To run your app code successfully with brokered authentication, grant your user account permissions using [Azure role-based access control (RBAC)](/azure/role-based-access-control/overview). Assign an appropriate role to your user account for the relevant Azure service. For example:

- **Azure Blob Storage**: Assign the **Storage Account Data Contributor** role.
- **Azure Key Vault**: Assign the **Key Vault Secrets Officer** role.

If an app is specified, it must have API permissions set for **user_impersonation Access Azure Storage** (step 6 in the previous section). This API permission allows the app to access Azure storage on behalf of the signed-in user after consent is granted during sign-in.

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
