---
ms.topic: include
ms.date: 08/01/2025
---

## Authenticate to Azure services from your app

The [Azure Identity library](/dotnet/api/azure.identity?view=azure-dotnet&preserve-view=true) provides various *credentials*&mdash;implementations of `TokenCredential` adapted to supporting different scenarios and Microsoft Entra authentication flows. The steps ahead demonstrate how to use <xref:Azure.Identity.DefaultAzureCredential> when working with user accounts locally.

### Implement the code

[DefaultAzureCredential](../authentication/credential-chains.md#defaultazurecredential-overview) is an opinionated, ordered sequence of mechanisms for authenticating to Microsoft Entra ID. Each authentication mechanism is a class derived from the [TokenCredential](/dotnet/api/azure.core.tokencredential?view=azure-dotnet&preserve-view=true) class and is known as a *credential*. At runtime, `DefaultAzureCredential` attempts to authenticate using the first credential. If that credential fails to acquire an access token, the next credential in the sequence is attempted, and so on, until an access token is successfully obtained. In this way, your app can use different credentials in different environments without writing environment-specific code.

To use `DefaultAzureCredential`:

1. Add the [Microsoft.Extensions.Azure](/dotnet/api/microsoft.extensions.azure) package to your application:

    ```dotnetcli
    dotnet add package Microsoft.Extensions.Azure
    ```

1. Azure services are accessed using specialized client classes from the various Azure SDK client libraries. These classes and your own custom services should be registered so they can be accessed via dependency injection throughout your app. In `Program.cs`, complete the following steps to register a client class and `DefaultAzureCredential`:

    1. Include the `Microsoft.Extensions.Azure` namespace via a `using` directive.
    1. Register the Azure service client using the corresponding `Add`-prefixed extension method.

    :::code language="csharp" source="../snippets/authentication/local-dev-account/Program.cs" id="snippet_DefaultAzureCredential":::

By default, the client builder creates a `DefaultAzureCredential` instance on your behalf. For production usage, register a [deterministic credential](../authentication/best-practices.md#use-deterministic-credentials-in-production-environments) instance with the builder instead of using `DefaultAzureCredential`. To use a different credential for Azure SDK clients:

1. Add the [Azure.Identity](/dotnet/api/azure.identity) package to your application:

    ```dotnetcli
    dotnet add package Azure.Identity
    ```

1. Include the `Azure.Identity` namespace via a `using` directive.
1. Register a custom credential instance with the builder. For example:

    :::code language="csharp" source="../snippets/authentication/local-dev-account/Program.cs" id="snippet_DefaultAzureCredential_UseCredential" highlight="6":::
