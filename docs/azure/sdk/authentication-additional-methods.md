---
title: Additional methods to authenticate to Azure resources from .NET apps
description: This article describes additional, less common methods you can use to authenticate your .NET app to Azure resources. 
ms.date: 05/05/2022
ms.topic: how-to
ms.custom: devx-track-dotnet
---

# Additional methods to authenticate to Azure resources from .NET apps

This article lists additional methods apps may use to authenticate to Azure resources. The methods on this page are less commonly used and when possible, it is encouraged to use one of the methods outlined in the [authenticating .NET apps to Azure using the Azure SDK overview](./authentication.md) article.

## Interactive browser authentication

This method interactively authenticates an application through [`InteractiveBrowserCredential`](/dotnet/api/azure.identity.interactivebrowsercredential) by collecting user credentials in the default system.

Interactive browser authentication enables the application for all operations allowed by the interactive login credentials. As a result, if you are the owner or administrator of your subscription, your code has inherent access to most resources in that subscription without having to assign any specific permissions. For this reason, the use of interactive browser authentication is discouraged for anything but experimentation.

### Example using InteractiveBrowserCredential

The following example demonstrates using an [`InteractiveBrowserCredential`](/dotnet/api/azure.identity.interactivebrowsercredential) to authenticate with the [`BlobServiceClient`](/dotnet/api/azure.storage.blobs.blobserviceclient):

```csharp
using Azure.Identity;
using Azure.Storage.Blobs;

var client = new BlobServiceClient(
        new Uri("https://<storage-account-name>.blob.core.windows.net"),
        new InteractiveBrowserCredential());

foreach (var blobItem in client.GetBlobContainers())
{
    Console.WriteLine(blobItem.Name);
}
```

For more exact control, such as setting redirect URIs, you can supply specific arguments to `InteractiveBrowserCredential` such as `redirect_uri`.

## Device code authentication

This method interactively authenticates a user on devices with limited UI (typically devices without a keyboard):

1. When the application attempts to authenticate, the credential prompts the user with a URL and an authentication code.
1. The user visits the URL on a separate browser-enabled device (a computer, smartphone, etc.) and enters the code.
1. The user follows a normal authentication process in the browser.
1. Upon successful authentication, the application is authenticated on the device.

For more information, see [Microsoft identity platform and the OAuth 2.0 device authorization grant flow](/azure/active-directory/develop/v2-oauth2-device-code).

Device code authentication in a development environment enables the application for all operations allowed by the interactive login credentials. As a result, if you are the owner or administrator of your subscription, your code has inherent access to most resources in that subscription without having to assign any specific permissions. However, you can use this method with a specific client ID, rather than the default, for which you can assign specific permissions.

## Authentication with a username and password

This method authenticates an application using previous-collected credentials and the [`UsernamePasswordCredential`](/dotnet/api/azure.identity.usernamepasswordcredential) object.

This method of authentication is discouraged because it's less secure than other flows. Also, this method is not interactive and is therefore **not compatible with any form of multi-factor authentication or consent prompting.** The application must already have consent from the user or a directory administrator.

Furthermore, this method authenticates only work and school accounts; Microsoft accounts are not supported. For more information, see [Sign up your organization to use Azure Active Directory](/azure/active-directory/fundamentals/sign-up-organization).

```csharp
using Azure.Identity;
using Azure.Storage.Blobs;

var clientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
var tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
var username = Environment.GetEnvironmentVariable("AZURE_USERNAME");
var password = Environment.GetEnvironmentVariable("AZURE_PASSWORD");

var client = new BlobServiceClient(
        new Uri("https://<storage-account-name>.blob.core.windows.net"),
        new UsernamePasswordCredential(username, password, tenantId, clientId));

foreach (var blobItem in client.GetBlobContainers())
{
    Console.WriteLine(blobItem.Name);
}

```
