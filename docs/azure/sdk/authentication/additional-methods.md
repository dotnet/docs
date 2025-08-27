---
title: Additional methods to authenticate to Azure from .NET apps
description: This article describes additional, less common methods you can use to authenticate your .NET app to Azure resources.
ms.topic: how-to
ms.date: 03/14/2025
ms.custom:
  - devx-track-dotnet
  - engagement-fy23
  - sfi-ropc-nochange
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

## Device code authentication

This method interactively authenticates a user on devices with limited UI (typically devices without a keyboard):

1. When the application attempts to authenticate, the credential prompts the user with a URL and an authentication code.
1. The user visits the URL on a separate browser-enabled device (a computer, smartphone, etc.) and enters the code.
1. The user follows a normal authentication process in the browser.
1. Upon successful authentication, the application is authenticated on the device.

For more information, see [Microsoft identity platform and the OAuth 2.0 device authorization grant flow](/entra/identity-platform/v2-oauth2-device-code).

Device code authentication in a development environment enables the application for all operations allowed by the interactive login credentials. As a result, if you're the owner or administrator of your subscription, your code has inherent access to most resources in that subscription without having to assign any specific permissions. However, you can use this method with a specific client ID, rather than the default, for which you can assign specific permissions.
