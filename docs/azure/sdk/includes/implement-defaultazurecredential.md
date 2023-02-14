`DefaultAzureCredential` supports multiple authentication methods and determines the authentication method being used at runtime.  In this way, your app can use different authentication methods in different environments without implementing environment specific code.

The order and locations in which `DefaultAzureCredential` looks for credentials is found at [DefaultAzureCredential](/dotnet/api/overview/azure/identity-readme?view=azure-dotnet#defaultazurecredential).

To implement `DefaultAzureCredential`, first add the [`Azure.Identity`](/dotnet/api/azure.identity) and optionally the [`Microsoft.Extensions.Azure`](/dotnet/api/microsoft.extensions.azure) packages to your application. You can do this using either the command line or the NuGet Package Manager.

### [Command Line](#tab/command-line)

Open a terminal environment of your choice in the application project directory and enter the command below.

```terminal
dotnet add package Azure.Identity
dotnet add package Microsoft.Extensions.Azure
```

### [NuGet Package Manager](#tab/nuget-package)

Right click on your project node in Visual Studio and select **Manage NuGet Packages**. Search for **Azure.Identity** in the search field, and install the matching package.  Repeat this process for the **Microsoft.Extensions.Azure** package as well.

:::image type="content" source="../media/nuget-azure-identity.png" alt-text="Install a package using the package manager.":::

---

Azure services are generally accessed using corresponding client classes from the SDK. These classes and your own custom services should be registered in the `Program.cs` file so they can be accessed via dependency injection throughout your app. Inside of `Program.cs`, follow the steps below to correctly setup your service and `DefaultAzureCredential`.

1. Include the `Azure.Identity` and `Microsoft.Extensions.Azure` namespaces with a using statement.
1. Register the Azure service using relevant helper methods.
1. Pass an instance of the `DefaultAzureCredential` object to the `UseCredential` method.

An example of this is shown in the following code segment.

```c#
using Microsoft.Extensions.Azure;
using Azure.Identity;

// Inside of Program.cs
builder.Services.AddAzureClients(x =>
{
    x.AddBlobServiceClient(new Uri("https://<account-name>.blob.core.windows.net"));
    x.UseCredential(new DefaultAzureCredential());
});
```

Alternatively, you can also utilize `DefaultAzureCredential` in your services more directly without the help of additional Azure registration methods, as seen below.

```c#
using Azure.Identity;

// Inside of Program.cs
builder.Services.AddSingleton<BlobServiceClient>(x => 
    new BlobServiceClient(
        new Uri("https://<account-name>.blob.core.windows.net"),
        new DefaultAzureCredential()));
```

When the above code is run on your local workstation during local development, it will look in the environment variables for an application service principal or at Visual Studio, VS Code, the Azure CLI, or Azure PowerShell for a set of developer credentials, either of which can be used to authenticate the app to Azure resources during local development.  

When deployed to Azure this same code can also authenticate your app to other Azure resources. `DefaultAzureCredential` can  retrieve environment settings and managed identity configurations to authenticate to other services automatically.
