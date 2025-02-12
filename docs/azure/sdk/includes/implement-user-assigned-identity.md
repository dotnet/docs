---
ms.topic: include
ms.date: 02/12/2025
---

## Authenticate to Azure services from your app

To authenticate to Azure services from your app code using Microsoft Entra ID and a user-assigned managed identity, you'll need to use an implementation of the [`TokenCredential`](/dotnet/api/overview/azure/identity-readme?view=azure-dotnet#credentials) class. The [Azure.Identity](/dotnet/api/azure.identity) library provides various implementations of `TokenCredential` for different scenarios and credential types. These classes allow apps to seamlessly authenticate to Azure resources whether the app is running locally, deployed to Azure, or on an on-premises server.

The steps ahead demonstrate how to use a `TokenCredential` across two different environments:

- **Local dev environment**: During **local development only**, you can use a class called `DefaultAzureCredential` for an opinionated, preconfigured chain of credentials. `DefaultAzureCredential` can discover user credentials from your local tooling or IDE, such as the Azure CLI or Visual Studio. It also provides flexibility and convenience for local development through the right balance of retries, wait time for response, and support for multiple authentication options. Visit the [Authenticate to Azure services during local development](/dotnet/azure/sdk/authentication/local-development-dev-accounts) article to learn more.
- **Azure-hosted apps**: When your app is running in Azure, use a `ManagedIdentityCredential` to safely discover the managed identity configured for your app. You can configure the `ManagedIdentityCredential` to locate a user-assigned managed identity using the client ID, the resource ID, or the object ID.

### Implement the code

Add the [Azure.Identity](/dotnet/api/azure.identity) and optionally the [Microsoft.Extensions.Azure](/dotnet/api/microsoft.extensions.azure) packages to your application:

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

- Use `DefaultAzureCredential` when your app is running locally
- Use `ManagedIdentityCredential` when your app is running in Azure and configure either the client ID, resource ID, or object ID.

## [Client ID](#tab/client-id)

:::code language="csharp" source="../snippets/authentication/user-assigned-managed-identity/Program.cs" id="snippet_MIC_ClientId_UseCredential":::

An alternative to the `UseCredential` method is to provide the credential to the service client directly:

:::code language="csharp" source="../snippets/authentication/user-assigned-managed-identity/Program.cs" id="snippet_MIC_ClientId":::

## [Resource ID](#tab/resource-id)

:::code language="csharp" source="../snippets/authentication/user-assigned-managed-identity/Program.cs" id="snippet_MIC_ResourceId_UseCredential":::

An alternative to the `UseCredential` method is to provide the credential to the service client directly:

:::code language="csharp" source="../snippets/authentication/user-assigned-managed-identity/Program.cs" id="snippet_MIC_ResourceId":::

## [Object ID](#tab/object-id)

:::code language="csharp" source="../snippets/authentication/user-assigned-managed-identity/Program.cs" id="snippet_MIC_ObjectId_UseCredential":::

An alternative to the `UseCredential` method is to provide the credential to the service client directly:

:::code language="csharp" source="../snippets/authentication/user-assigned-managed-identity/Program.cs" id="snippet_MIC_ObjectId":::

---

When the preceding code runs on your local development workstation, `DefaultAzureCredential` looks in the environment variables for an application service principal or at locally installed developer tools, such as Visual Studio, for a set of developer credentials. When deployed to Azure, the `ManagedIdentityCredential` discovers your managed identity configurations to authenticate to other services automatically.
