---
title: Authenticate .NET apps to Azure using brokered authentication.
description: Learn how to authenticate your app to Azure services when using the Azure SDK for .NET during local development using brokered authentication.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 08/20/2025
---

# Authenticate .NET apps to Azure services during local development using brokered authentication

Brokered authentication collects user credentials using the system authentication broker to authenticate an application with <xref:Azure.Identity.InteractiveBrowserCredential>. A system authentication broker is an app running on a user's machine that manages the authentication handshakes and token maintenance for all connected accounts.

> [!NOTE]
> Currently, only the Windows authentication broker, Web Account Manager (WAM), is supported. Users on macOS and Linux will be authenticated through the [non-brokered interactive browser flow](additional-methods.md#interactive-browser-authentication).

WAM enables identity providers such as Microsoft Entra ID to natively plug into the OS and provide the service to other apps to provide a more secure login process. WAM offers the following benefits:

- **Feature support**: Apps can access OS-level and service-level capabilities, including Windows Hello, conditional access policies, and FIDO keys.
- **Streamlined single sign-on**: Apps can use the built-in account picker, allowing the user to select an existing account instead of repeatedly entering the same credentials.
- **Enhanced security**: Bug fixes and enhancements ship with Windows.
- **Token protection**: Refresh tokens are device-bound, and apps can acquire device-bound access tokens.

Brokered authentication enables the application for all operations allowed by the interactive login credentials. Personal Microsoft accounts and work or school accounts are supported. If a supported version of Windows is used, the default browser-based UI is replaced with a smoother authentication experience, similar to Windows built-in apps.

## Configure the app for brokered authentication

Complete the following steps to enable the application to authenticate through the broker flow:

1. On the [Azure portal](https://portal.azure.com), navigate to **Microsoft Entra ID** and select **App registrations** on the left-hand menu.
1. Select the registration for your app, then select **Authentication**.
1. Add the WAM redirect URI to your app registration via a platform configuration:
    1. Under **Platform configurations**, select **+ Add a platform**.
    1. Under **Configure platforms**, select the tile for your application type (platform) to configure its settings, such as **mobile and desktop applications**.
    1. In **Custom redirect URIs**, enter the following WAM redirect URI:

        ```text
        ms-appx-web://Microsoft.AAD.BrokerPlugin/{client_id}
        ```

         The `{client_id}` placeholder must be replaced with the **Application (client) ID** listed on the **Overview** pane of the app registration.

    1. Select **Configure**.

    To learn more, see [Add a redirect URI to an app registration](/entra/identity-platform/quickstart-register-app#add-a-redirect-uri).

1. Back on the **Authentication** pane, under **Advanced settings**, select **Yes** for **Allow public client flows**.
1. Select **Save** to apply the changes.
1. To authorize the application for specific resources, navigate to the resource in question, select **API Permissions**, and enable **Microsoft Graph** and other resources you want to access. Microsoft Graph is usually enabled by default.

    > [!IMPORTANT]
    > You must also be the admin of your tenant to grant consent to your application when you sign in for the first time.

## Example using InteractiveBrowserCredential

The following example demonstrates using <xref:Azure.Identity.InteractiveBrowserCredential> in a Windows Forms app to authenticate with the [`BlobServiceClient`](/dotnet/api/azure.storage.blobs.blobserviceclient):

:::code language="csharp" source="../snippets/authentication/additional-auth/interactive/InteractiveBrokeredAuth.cs" highlight="16-20":::

> [!NOTE]
> For more information about retrieving window handles, see [Parent window handles](/entra/msal/dotnet/acquiring-tokens/desktop-mobile/wam#parent-window-handles) and [Retrieve a window handle](/windows/apps/develop/ui-input/retrieve-hwnd).

For the code to run successfully, your user account must be assigned an Azure role on the storage account that allows access to blob containers, such as **Storage Account Data Contributor**. If an app is specified, it must have API permissions set for **user_impersonation Access Azure Storage** (step 6 in the previous section). This API permission allows the app to access Azure storage on behalf of the signed-in user after consent is granted during sign-in.

The following screenshot shows the user sign-in experience:

:::image type="content" source="../media/web-account-manager-sign-in-account-picker.png" alt-text="A screenshot that shows the sign-in experience when using the interactive browser broker credential to authenticate a user." :::

## Authenticate the default system account via WAM

Many people always sign in to Windows with the same user account and, therefore, only ever want to authenticate using that account. WAM and `InteractiveBrowserCredential` also support a silent login process that automatically uses a default account so the user doesn't have to repeatedly select it.

The following example shows how to enable sign-in with the default system account:

:::code language="csharp" source="../snippets/authentication/additional-auth/interactive/SilentBrokeredAuth.cs" highlight="16-24":::

Once you opt in to this behavior, the credential attempts to sign in by asking the underlying Microsoft Authentication Library (MSAL) to perform the sign-in for the default system account. If the sign-in fails, the credential falls back to displaying the account picker dialog, from which the user can select the appropriate account.
