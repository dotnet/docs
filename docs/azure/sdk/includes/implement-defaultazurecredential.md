---
ms.topic: include
ms.date: 08/15/2024
---
[DefaultAzureCredential](../authentication/credential-chains.md#defaultazurecredential-overview) is an opinionated, ordered sequence of mechanisms for authenticating to Microsoft Entra ID. Each authentication mechanism is a class derived from the [TokenCredential](/dotnet/api/azure.core.tokencredential?view=azure-dotnet&preserve-view=true) class and is known as a *credential*. At runtime, `DefaultAzureCredential` attempts to authenticate using the first credential. If that credential fails to acquire an access token, the next credential in the sequence is attempted, and so on, until an access token is successfully obtained. In this way, your app can use different credentials in different environments without writing environment-specific code.

To use `DefaultAzureCredential`, add the [Azure.Identity](/dotnet/api/azure.identity) and optionally the [Microsoft.Extensions.Azure](/dotnet/api/microsoft.extensions.azure) packages to your application:

### [Command Line](#tab/command-line)

In a terminal of your choice, navigate to the application project directory and run the following commands:

```dotnetcli
dotnet add package Azure.Identity
dotnet add package Microsoft.Extensions.Azure
```

### [NuGet Package Manager](#tab/nuget-package)

Right-click your project in Visual Studio's **Solution Explorer** window and select **Manage NuGet Packages**. Search for **Azure.Identity**, and install the matching package. Repeat this process for the **Microsoft.Extensions.Azure** package.

:::image type="content" source="../media/nuget-azure-identity.png" alt-text="Install a package using the package manager.":::

---

Azure services are accessed using specialized client classes from the various Azure SDK client libraries. These classes and your own custom services should be registered so they can be accessed via dependency injection throughout your app. In `Program.cs`, complete the following steps to register a client class and `DefaultAzureCredential`:

1. Include the `Azure.Identity` and `Microsoft.Extensions.Azure` namespaces via `using` directives.
1. Register the Azure service client using the corresponding `Add`-prefixed extension method.
1. Pass an instance of `DefaultAzureCredential` to the `UseCredential` method.

For example:

```c#
using Microsoft.Extensions.Azure;
using Azure.Identity;

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(
        new Uri("https://<account-name>.blob.core.windows.net"));
    clientBuilder.UseCredential(new DefaultAzureCredential());
});
```

An alternative to `UseCredential` is to instantiate `DefaultAzureCredential` directly:

```c#
using Azure.Identity;

builder.Services.AddSingleton<BlobServiceClient>(_ =>
    new BlobServiceClient(
        new Uri("https://<account-name>.blob.core.windows.net"),
        new DefaultAzureCredential()));
```

When the preceding code runs on your local development workstation, it looks in the environment variables for an application service principal or at locally installed developer tools, such as Visual Studio, for a set of developer credentials. Either approach can be used to authenticate the app to Azure resources during local development.

When deployed to Azure, this same code can also authenticate your app to other Azure resources. `DefaultAzureCredential` can retrieve environment settings and managed identity configurations to authenticate to other services automatically.
