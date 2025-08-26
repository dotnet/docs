---
title: Authenticate .NET apps to Azure using brokered authentication.
description: Learn how to authenticate your app to Azure services when using the Azure SDK for .NET during local development using brokered authentication.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 08/20/2025
zone_pivot_groups: operating-systems-set-one
---

# Authenticate .NET apps to Azure services during local development using interactive brokered authentication

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

macOS does not include a built-in authentication broker. Brokered authentication is supported via the Azure.Identity.Broker library, which uses platform-specific mechanisms and may integrate with apps like Microsoft Company Portal when devices are managed. For more information, see [Microsoft Enterprise SSO plug-in for Apple devices](/entra/identity-platform/apple-sso-plugin).

:::zone-end

:::zone target="docs" pivot="os-linux"

Linux uses [Microsoft single sign-on for Linux](/entra/identity/devices/sso-linux) as its authentication broker.

> [!NOTE]
> Microsoft SSO for Linux authentication broker support is available starting with `Azure.Identity.Broker` version 1.3.0.

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
        | Windows 10+ | `ms-appx-web://Microsoft.AAD.BrokerPlugin/your_client_id`                                                             |
        | macOS       | `msauth.com.msauth.unsignedapp://auth` for unsigned apps `msauth.BUNDLE_ID://auth` for signed apps                    |
        | WSL         | `ms-appx-web://Microsoft.AAD.BrokerPlugin/your_client_id`                                                             |
        | Linux       | `https://login.microsoftonline.com/common/oauth2/nativeclient`                                                        |

         Replace `{your_client_id}` or `{BUNDLE_ID}` with the **Application (client) ID** from the app registration's **Overview** pane.

    1. Select **Configure**.

    To learn more, see [Add a redirect URI to an app registration](/entra/identity-platform/quickstart-register-app#add-a-redirect-uri).

1. Back on the **Authentication** pane, under **Advanced settings**, select **Yes** for **Allow public client flows**.
1. Select **Save** to apply the changes.
1. To authorize the application for specific resources, navigate to the resource in question, select **API Permissions**, and enable **Microsoft Graph** and other resources you want to access.

    > [!IMPORTANT]
    > You must also be the admin of your tenant to grant consent to your application when you sign in for the first time.

### Assign roles

To run your app code successfully with brokered authentication, grant your user account permissions using [Azure role-based access control (RBAC)](/azure/role-based-access-control/overview). Assign an appropriate role to your user account for the relevant Azure service. For example:

- **Azure Blob Storage**: Assign the **Storage Account Data Contributor** role.
- **Azure Key Vault**: Assign the **Key Vault Secrets Officer** role.

If an app is specified, it must have API permissions set for **user_impersonation Access Azure Storage** (step 6 in the previous section). This API permission allows the app to access Azure storage on behalf of the signed-in user after consent is granted during sign-in.

## Implement the code

.NET and the `Azure.Identity` libraries provide interactive brokered authentication using <xref:Azure.Identity.InteractiveBrowserCredential>. For example, to use `InteractiveBrowserCredential` in a MAUI app to authenticate to Azure Key Vault with the [`SecretClient`](/dotnet/api/azure.security.keyvault.secrets.secretclient), follow these steps:

1. Install the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) and [Azure.Identity.Broker](https://www.nuget.org/packages/Azure.Identity.Broker) packages.

    > [!NOTE]
    > macOS and Linux support exists in `Azure.Identity.Broker` versions 1.3.0 and later.

1. Get a reference to the parent window on top of which the account picker dialog should appear.
1. Create an instance of <xref:Azure.Identity.InteractiveBrowserCredential> using <xref:Azure.Identity.Broker.InteractiveBrowserCredentialBrokerOptions>.

:::zone target="docs" pivot="os-windows"

:::code language="csharp" source="../snippets/authentication/brokered/maui-app/MainPage.xaml.cs" highlight="37-49" :::

The following screenshot shows the user sign-in experience:

:::image type="content" source="../media/web-account-manager-sign-in-account-picker.png" alt-text="A screenshot that shows the sign-in experience when using a broker-enabled InteractiveBrowserCredential instance to authenticate a user." :::

:::zone-end

:::zone target="docs" pivot="os-macos"

:::code language="csharp" source="../snippets/authentication/brokered/maui-app/MainPage.xaml.cs" highlight="53-65" :::

:::zone-end

:::zone target="docs" pivot="os-linux"

:::code language="csharp" source="../snippets/authentication/brokered/console-app/Program.cs" highlight="22-28" :::

:::zone-end

### Authenticate the default system account

`InteractiveBrowserCredential` also supports a silent sign-in process that automatically uses a default account, so the user doesn't have to repeatedly select it. When you opt in to this behavior, the credential attempts to sign in by asking the underlying Microsoft Authentication Library (MSAL) to perform the sign-in for the default system account. If sign-in fails, the credential falls back to displaying the account picker dialog, allowing the user to select the appropriate account.

The previous example shows how to enable sign-in with the default system account:

:::code language="csharp" source="../snippets/authentication/brokered/console-app/Program.cs" range="22-28" highlight="3" :::
