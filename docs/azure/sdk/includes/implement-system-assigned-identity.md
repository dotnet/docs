---
ms.topic: include
ms.date: 02/12/2025
---

[!INCLUDE [implement-managed-identity-concepts](implement-managed-identity-concepts.md)]

### Implement the code

Add the [Azure.Identity](/dotnet/api/azure.identity) package. In an ASP.NET Core project, also install the [Microsoft.Extensions.Azure](/dotnet/api/microsoft.extensions.azure) package:

### [Command Line](#tab/command-line)

In a terminal of your choice, navigate to the application project directory and run the following commands:

```dotnetcli
dotnet add package Azure.Identity
dotnet add package Microsoft.Extensions.Azure
```

### [NuGet Package Manager](#tab/nuget-package)

Right-click your project in the Visual Studio **Solution Explorer** window and select **Manage NuGet Packages**. Search for **Azure.Identity**, and install the matching package. Repeat this process for the **Microsoft.Extensions.Azure** package.

:::image type="content" source="../media/nuget-azure-identity.png" alt-text="Install a package using the package manager.":::

---

Azure services are accessed using specialized client classes from the various Azure SDK client libraries. These classes and your own custom services should be registered for dependency injection so they can be used throughout your app. In `Program.cs`, complete the following steps to configure a client class for dependency injection and token-based authentication:

1. Include the `Azure.Identity` and `Microsoft.Extensions.Azure` namespaces via `using` directives.
1. Register the Azure service client using the corresponding `Add`-prefixed extension method.
1. Pass an appropriate `TokenCredential` instance to the `UseCredential` method:
    - Use `DefaultAzureCredential` when your app is running locally.
    - Use `ManagedIdentityCredential` when your app is running in Azure.

:::code language="csharp" source="../snippets/authentication/system-assigned-managed-identity/Program.cs" id="snippet_MIC_UseCredential":::

An alternative to the `UseCredential` method is to provide the credential to the service client directly:

:::code language="csharp" source="../snippets/authentication/system-assigned-managed-identity/Program.cs" id="snippet_MIC":::

---

The preceding code behaves differently depending on the environment where it's running:

- On your local development workstation, `DefaultAzureCredential` looks in the environment variables for an application service principal or at locally installed developer tools, such as Visual Studio, for a set of developer credentials.
- When deployed to Azure, `ManagedIdentityCredential` discovers your managed identity configurations to authenticate to other services automatically.
