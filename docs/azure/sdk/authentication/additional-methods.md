---
title: Additional methods to authenticate to Azure from .NET apps
description: This article describes additional, less common methods you can use to authenticate your .NET app to Azure resources. 
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 07/31/2024
---

# Additional methods to authenticate to Azure resources from .NET apps

This article lists additional methods apps may use to authenticate to Azure resources. The methods on this page are less commonly used; when possible, use one of the methods outlined in [authenticating .NET apps to Azure using the Azure SDK overview](./index.md).

## Interactive browser authentication

This method interactively authenticates an application through [`InteractiveBrowserCredential`](/dotnet/api/azure.identity.interactivebrowsercredential) by collecting user credentials in the default system.

Interactive browser authentication enables the application for all operations allowed by the interactive login credentials. As a result, if you're the owner or administrator of your subscription, your code has inherent access to most resources in that subscription without having to assign any specific permissions. For this reason, the use of interactive browser authentication is discouraged for anything but experimentation.

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

### Authenticate the default system account via WAM

Many people always sign in to Windows with the same user account and, therefore, only ever want to authenticate using that account. Web Account Manager (WAM) is a broker service that allows apps to request OAuth tokens from identity providers, such as Microsoft Entra ID, in a seamless fashion. With it, identity providers can natively plug into the OS and provide the service to other apps to streamline the login process. WAM also supports a silent login process that automatically uses a default account so the user does not have to repeatedly select it.

To enable sign-in using WAM and the default system account:

1. Install the following NuGet packages:

    ```dotnetcli
    dotnet add package Azure.Identity
    dotnet add package Azure.Identity.Broker
    ```

2. Get the handle of the parent window to which the WAM account picker window should be docked:

    ### [WinForms](#tab/winforms)

    ```csharp
    private async void testBrokeredAuth_Click(object sender, EventArgs e)
    {
        IntPtr windowHandle = this.Handle;
    
        // code omitted for brevity
    }
    ```

    ### [WPF](#tab/wpf)

    ```csharp
    // MainWindow.xaml.cs
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var wih = new System.Windows.Interop.WindowInteropHelper(this);
        var windowHandle = wih.Handle;
    }
    ```

    ### [WinUI 3](#tab/winui3)

    ```csharp
    // MainWindow.xaml.cs
    private async void myButton_Click(object sender, RoutedEventArgs e)
    {
        // Retrieve the window handle (HWND) of the current WinUI 3 window.
        var windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(this);
    }
    ```

    ### [Console](#tab/console)

    ```csharp
    [DllImport("user32.dll", ExactSpelling = true)]
    static extern IntPtr GetAncestor(IntPtr hwnd, GetAncestorFlags flags);
    
    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();
    
    // This is your window handle!
    IntPtr GetConsoleOrTerminalWindow()
    {
        IntPtr consoleHandle = GetConsoleWindow();
        IntPtr handle = GetAncestor(consoleHandle, GetAncestorFlags.GetRootOwner );
        
        return handle;
    }

    enum GetAncestorFlags
    {   
        GetParent = 1,
        GetRoot = 2,
        /// <summary>
        /// Retrieves the owned root window by walking the chain of parent and owner windows returned by GetParent.
        /// </summary>
        GetRootOwner = 3
    }
    ```

    ---

    > [!NOTE]
    > Visit the [Parent window handles](/entra/msal/dotnet/acquiring-tokens/desktop-mobile/wam#parent-window-handles) and [Retrieve a window handle](/windows/apps/develop/ui-input/retrieve-hwnd) articles for more information about retrieving the parent window handle.

3. Create a broker-enabled instance of `InteractiveBrowserCredential` in your app. The credential requires the handle of the parent window that's requesting the authentication flow. On Windows, the handle is an integer value that uniquely identifies the window.

    The following example shows how to enable sign-in with the default system account:

    ```csharp
    using Azure.Identity;
    using Azure.Identity.Broker;
    
    // code omitted for brevity
    
    // Get the window handle using the selected approach in step 2
    IntPtr windowHandle = GetForegroundWindow(); 
    InteractiveBrowserCredential credential = new(
        new InteractiveBrowserCredentialBrokerOptions(windowHandle)
    );
    ```

4. Use the broker-enabled `InteractiveBrowserCredential` instance.

Once you opt into this behavior, the credential type attempts to sign in by asking the underlying Microsoft Authentication Library (MSAL) to perform the sign-in for the default system account. If the sign-in fails, the credential type falls back to displaying the account picker dialog, from which the user can select the appropriate account.

## Device code authentication

This method interactively authenticates a user on devices with limited UI (typically devices without a keyboard):

1. When the application attempts to authenticate, the credential prompts the user with a URL and an authentication code.
1. The user visits the URL on a separate browser-enabled device (a computer, smartphone, etc.) and enters the code.
1. The user follows a normal authentication process in the browser.
1. Upon successful authentication, the application is authenticated on the device.

For more information, see [Microsoft identity platform and the OAuth 2.0 device authorization grant flow](/entra/identity-platform/v2-oauth2-device-code).

Device code authentication in a development environment enables the application for all operations allowed by the interactive login credentials. As a result, if you're the owner or administrator of your subscription, your code has inherent access to most resources in that subscription without having to assign any specific permissions. However, you can use this method with a specific client ID, rather than the default, for which you can assign specific permissions.

## Authentication with a username and password

This method authenticates an application using previously collected credentials and the [UsernamePasswordCredential](/dotnet/api/azure.identity.usernamepasswordcredential) object.

> [!IMPORTANT]
> This method of authentication is discouraged because it's less secure than other flows. Also, this method isn't interactive and is therefore **incompatible with any form of multi-factor authentication or consent prompting.** The application must already have consent from the user or a directory administrator.
>
> Furthermore, this method authenticates only work and school accounts; Microsoft accounts aren't supported. For more information, see [Sign up your organization to use Microsoft Entra ID](/entra/fundamentals/sign-up-organization).

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
