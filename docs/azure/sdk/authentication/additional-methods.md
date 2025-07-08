---
title: Additional methods to authenticate to Azure from .NET apps
description: This article describes additional, less common methods you can use to authenticate your .NET app to Azure resources.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 03/14/2025
---

# Additional methods to authenticate to Azure resources from .NET apps

This article lists additional methods apps may use to authenticate to Azure resources. The methods on this page are less commonly used; when possible, use one of the methods outlined in [authenticating .NET apps to Azure using the Azure SDK overview](./index.md).

## Interactive browser authentication

This method interactively authenticates an application through [`InteractiveBrowserCredential`](/dotnet/api/azure.identity.interactivebrowsercredential) by collecting user credentials in the default system.

Interactive browser authentication enables the application for all operations allowed by the interactive login credentials. As a result, if you're the owner or administrator of your subscription, your code has inherent access to most resources in that subscription without having to assign any specific permissions. For this reason, the use of interactive browser authentication is discouraged for anything but experimentation.

### Enable applications for interactive browser authentication

Perform the following steps to enable the application to authenticate through the interactive browser flow. These steps also work for the [device code authentication](#device-code-authentication) flow described later. This process is only necessary if you are using `InteractiveBrowserCredential` in your code.

1. In the [Azure portal](https://portal.azure.com), navigate to **Microsoft Entra ID** and select **App registrations** on the left navigation.
1. Select the registration for your app, then select **Authentication**.
1. Under **Advanced settings**, select **Yes** for **Allow public client flows**.
1. Select **Save** to apply the changes.
1. To authorize the application for specific resources, navigate to the resource in question, select **API Permissions**, and enable **Microsoft Graph** and other resources you want to access. Microsoft Graph is usually enabled by default.

    > [!IMPORTANT]
    > You must also be the admin of your tenant to grant consent to your application when you sign in for the first time.

### Example using InteractiveBrowserCredential

The following example demonstrates using an [`InteractiveBrowserCredential`](/dotnet/api/azure.identity.interactivebrowsercredential) to authenticate with the [`BlobServiceClient`](/dotnet/api/azure.storage.blobs.blobserviceclient):

:::code language="csharp" source="../snippets/authentication/additional-auth/interactive/InteractiveBrowserAuth.cs" highlight="15-17":::

For more exact control, such as setting redirect URIs, you can supply specific arguments to `InteractiveBrowserCredential` such as `redirect_uri`.

## Interactive brokered authentication

This method interactively authenticates an application through <xref:Azure.Identity.InteractiveBrowserCredential> by collecting user credentials using the system authentication broker. A system authentication broker is an app running on a user's machine that manages the authentication handshakes and token maintenance for all connected accounts. Currently, only the Windows authentication broker, Web Account Manager (WAM), is supported. Users on macOS and Linux will be authenticated through the non-brokered interactive browser flow.

WAM enables identity providers such as Microsoft Entra ID to natively plug into the OS and provide the service to other apps to provide a more secure login process. WAM offers the following benefits:

- **Feature support**: Apps can access OS-level and service-level capabilities, including Windows Hello, conditional access policies, and FIDO keys.
- **Streamlined single sign-on**: Apps can use the built-in account picker, allowing the user to select an existing account instead of repeatedly entering the same credentials.
- **Enhanced security**: Bug fixes and enhancements ship with Windows.
- **Token protection**: Refresh tokens are device-bound, and apps can acquire device-bound access tokens.

Interactive brokered authentication enables the application for all operations allowed by the interactive login credentials. Personal Microsoft accounts and work or school accounts are supported. If a supported version of Windows is used, the default browser-based UI is replaced with a smoother authentication experience, similar to Windows built-in apps.

### Enable applications for interactive brokered authentication

Perform the following steps to enable the application to authenticate through the interactive broker flow.

1. On the [Azure portal](https://portal.azure.com), navigate to **Microsoft Entra ID** and select **App registrations** on the left-hand menu.
1. Select the registration for your app, then select **Authentication**.
1. Add the WAM redirect URI to your app registration via a platform configuration:
    1. Under **Platform configurations**, select **+ Add a platform**.
    1. Under **Configure platforms**, select the tile for your application type (platform) to configure its settings, such as **mobile and desktop applications**.
    1. In **Custom redirect URIs**, enter the following WAM redirect URI:

        ```text
        ms-appx-web://microsoft.aad.brokerplugin/{client_id}
        ```

         The `{client_id}` placeholder must be replaced with the **Application (client) ID** listed on the **Overview** pane of the app registration.

    1. Select **Configure**.

    To learn more, see [Add a redirect URI to an app registration](/entra/identity-platform/quickstart-register-app#add-a-redirect-uri).

1. Back on the **Authentication** pane, under **Advanced settings**, select **Yes** for **Allow public client flows**.
1. Select **Save** to apply the changes.
1. To authorize the application for specific resources, navigate to the resource in question, select **API Permissions**, and enable **Microsoft Graph** and other resources you want to access. Microsoft Graph is usually enabled by default.

    > [!IMPORTANT]
    > You must also be the admin of your tenant to grant consent to your application when you sign in for the first time.

### Example using InteractiveBrowserCredential

The following example demonstrates using an <xref:Azure.Identity.InteractiveBrowserCredential> in a Windows Forms app to authenticate with the [`BlobServiceClient`](/dotnet/api/azure.storage.blobs.blobserviceclient):

:::code language="csharp" source="../snippets/authentication/additional-auth/interactive/InteractiveBrokeredAuth.cs" highlight="16-20":::

> [!NOTE]
> Visit the [Parent window handles](/entra/msal/dotnet/acquiring-tokens/desktop-mobile/wam#parent-window-handles) and [Retrieve a window handle](/windows/apps/develop/ui-input/retrieve-hwnd) articles for more information about retrieving window handles.

For the code to run successfully, your user account must be assigned an Azure role on the storage account that allows access to blob containers such as **Storage Account Data Contributor**. If an app is specified, it must have API permissions set for **user_impersonation Access Azure Storage** (step 6 in the previous section). This API permission allows the app to access Azure storage on behalf of the signed-in user after consent is granted during sign-in.

The following screenshot shows the user sign-in experience:

:::image type="content" source="../media/web-account-manager-sign-in-account-picker.png" alt-text="A screenshot that shows the sign-in experience when using the interactive browser broker credential to authenticate a user." :::

### Authenticate the default system account via WAM

Many people always sign in to Windows with the same user account and, therefore, only ever want to authenticate using that account. WAM and `InteractiveBrowserCredential` also support a silent login process that automatically uses a default account so the user doesn't have to repeatedly select it.

The following example shows how to enable sign-in with the default system account:

:::code language="csharp" source="../snippets/authentication/additional-auth/interactive/SilentBrokeredAuth.cs" highlight="16-24":::

Once you opt in to this behavior, the credential attempts to sign in by asking the underlying Microsoft Authentication Library (MSAL) to perform the sign-in for the default system account. If the sign-in fails, the credential falls back to displaying the account picker dialog, from which the user can select the appropriate account.

## Device code authentication

This method interactively authenticates a user on devices with limited UI (typically devices without a keyboard):

1. When the application attempts to authenticate, the credential prompts the user with a URL and an authentication code.
1. The user visits the URL on a separate browser-enabled device (a computer, smartphone, etc.) and enters the code.
1. The user follows a normal authentication process in the browser.
1. Upon successful authentication, the application is authenticated on the device.

For more information, see [Microsoft identity platform and the OAuth 2.0 device authorization grant flow](/entra/identity-platform/v2-oauth2-device-code).

Device code authentication in a development environment enables the application for all operations allowed by the interactive login credentials. As a result, if you're the owner or administrator of your subscription, your code has inherent access to most resources in that subscription without having to assign any specific permissions. However, you can use this method with a specific client ID, rather than the default, for which you can assign specific permissions.
