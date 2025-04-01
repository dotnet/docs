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
dotnet package add Azure.Identity
dotnet package add Microsoft.Extensions.Azure
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

The client ID is used to identify a managed identity when configuring applications or services that need to authenticate using that identity.

1. Retrieve the client ID assigned to a user-assigned managed identity using the following command:

    ```azurecli
    az identity show \
        --resource-group <resource-group-name> \
        --name <identity-name> \
        --query 'clientId'
    ```

1. Configure `ManagedIdentityCredential` with the client ID:

    :::code language="csharp" source="../snippets/authentication/user-assigned-managed-identity/Program.cs" id="snippet_MIC_ClientId_UseCredential":::

    An alternative to the `UseCredential` method is to provide the credential to the service client directly:

    :::code language="csharp" source="../snippets/authentication/user-assigned-managed-identity/Program.cs" id="snippet_MIC_ClientId":::

## [Resource ID](#tab/resource-id)

The resource ID uniquely identifies the managed identity resource within your Azure subscription using the following structure:

`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}`

Resource IDs can be built by convention, which makes them more convenient when working with a large number of user-assigned managed identities in your environment.

1. Retrieve the resource ID for a user-assigned managed identity using the following command:

    ```azurecli
    az identity show \
        --resource-group <resource-group-name> \
        --name <identity-name> \
        --query 'id'
    ```

1. Configure `ManagedIdentityCredential` with the resource ID:

    :::code language="csharp" source="../snippets/authentication/user-assigned-managed-identity/Program.cs" id="snippet_MIC_ResourceId_UseCredential":::

    An alternative to the `UseCredential` method is to provide the credential to the service client directly:

    :::code language="csharp" source="../snippets/authentication/user-assigned-managed-identity/Program.cs" id="snippet_MIC_ResourceId":::

## [Object ID](#tab/object-id)

A principal ID is another name for an object ID.

1. Retrieve the object ID for a user-assigned managed identity using the following command:

    ```azurecli
    az identity show \
        --resource-group <resource-group-name> \
        --name <identity-name> \
        --query 'principalId'
    ```

1. Configure `ManagedIdentityCredential` with the object ID:

    :::code language="csharp" source="../snippets/authentication/user-assigned-managed-identity/Program.cs" id="snippet_MIC_ObjectId_UseCredential":::

    An alternative to the `UseCredential` method is to provide the credential to the service client directly:

    :::code language="csharp" source="../snippets/authentication/user-assigned-managed-identity/Program.cs" id="snippet_MIC_ObjectId":::

---

The preceding code behaves differently depending on the environment where it's running:

- On your local development workstation, `DefaultAzureCredential` looks in the environment variables for an application service principal or at locally installed developer tools, such as Visual Studio, for a set of developer credentials.
- When deployed to Azure, `ManagedIdentityCredential` discovers your managed identity configurations to authenticate to other services automatically.
