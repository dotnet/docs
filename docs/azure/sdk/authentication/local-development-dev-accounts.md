---
title: Authenticate .NET apps to Azure using developer accounts
description: Learn how to authenticate your application to Azure services when using the Azure SDK for .NET during local development using developer accounts.
ms.topic: how-to
ms.date: 11/25/2025
ms.custom:
  - devx-track-dotnet
  - engagement-fy23
  - devx-track-azurecli
  - sfi-image-nochange
---

# Authenticate .NET apps to Azure services during local development using developer accounts

During local development, applications need to authenticate to Azure to use different Azure services. Authenticate locally using one of these approaches:

- Use a developer account with one of the [developer tools supported by the Azure Identity library](#supported-developer-tools-for-authentication).
- Use a [broker](local-development-broker.md) to manage credentials.
- Use a [service principal](local-development-service-principal.md).

This article explains how to authenticate using a developer account with tools supported by the Azure Identity library. In the sections ahead, you learn:

- How to use Microsoft Entra groups to efficiently manage permissions for multiple developer accounts.
- How to assign roles to developer accounts to scope permissions.
- How to sign-in to supported local development tools.
- How to authenticate using a developer account from your app code.

## Supported developer tools for authentication

For an app to authenticate to Azure during local development using the developer's Azure credentials, the developer must be signed-in to Azure from one of the following developer tools:

- Azure CLI
- Azure Developer CLI
- Azure PowerShell
- Visual Studio
- Visual Studio Code

The Azure Identity library can detect that the developer is signed-in from one of these tools. The library can then obtain the Microsoft Entra access token via the tool to authenticate the app to Azure as the signed-in user.

This approach takes advantage of the developer's existing Azure accounts to streamline the authentication process. However, a developer's account likely has more permissions than required by the app, therefore exceeding the permissions the app runs with in production. As an alternative, you can [create application service principals to use during local development](./local-development-service-principal.md), which can be scoped to have only the access needed by the app.

[!INCLUDE [auth-create-entra-group](~/azure-dev-docs-pr/articles/includes/authentication/create-entra-group.md)]

[!INCLUDE [auth-assign-group-roles](~/azure-dev-docs-pr/articles/includes/authentication/assign-group-roles.md)]

## Sign-in to Azure using developer tooling

Next, sign-in to Azure using one of several developer tools that can be used to perform authentication in your development environment. The account you authenticate should also exist in the Microsoft Entra group you created and configured earlier.

### [Visual Studio](#tab/sign-in-visual-studio)

[!INCLUDE [auth-visual-studio](~/azure-dev-docs-pr/articles/includes/authentication/visual-studio.md)]

### [Visual Studio Code](#tab/sign-in-visual-studio-code)

[!INCLUDE [sign-in-visual-studio-code](~/azure-dev-docs-pr/articles/includes/authentication/sign-in-visual-studio-code.md)]

### [Azure CLI](#tab/sign-in-azure-cli)

[!INCLUDE [sign-in-azure-cli](~/azure-dev-docs-pr/articles/includes/authentication/sign-in-azure-cli.md)]

### [Azure Developer CLI](#tab/sign-in-azure-developer-cli)

[!INCLUDE [sign-in-azure-developer-cli](~/azure-dev-docs-pr/articles/includes/authentication/sign-in-azure-developer-cli.md)]

### [Azure PowerShell](#tab/sign-in-azure-powershell)

[!INCLUDE [sign-in-azure-powershell](~/azure-dev-docs-pr/articles/includes/authentication/sign-in-azure-powershell.md)]

---

## Authenticate to Azure services from your app

The [Azure Identity library](/dotnet/api/azure.identity?view=azure-dotnet&preserve-view=true) provides implementations of <xref:Azure.Core.TokenCredential> that support various scenarios and Microsoft Entra authentication flows. The steps ahead demonstrate how to use <xref:Azure.Identity.DefaultAzureCredential> or a specific development tool credential when working with user accounts locally.

### Implement the code

Complete the following steps:

1. Add references to the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) and the [Microsoft.Extensions.Azure](https://www.nuget.org/packages/Microsoft.Extensions.Azure) packages in your project:

    ```dotnetcli
    dotnet add package Azure.Identity
    dotnet add package Microsoft.Extensions.Azure
    ```

1. In `Program.cs`, add `using` directives for the `Azure.Identity` and `Microsoft.Extensions.Azure` namespaces.

1. Register the Azure service client using the corresponding `Add`-prefixed extension method.

    Azure services are accessed using specialized client classes from the Azure SDK client libraries. Register these client types so you can access them through dependency injection across your app.

1. Pass a `TokenCredential` instance to the `UseCredential` method. Common `TokenCredential` examples include:

    - A `DefaultAzureCredential` instance optimized for local development. This example sets environment variable `AZURE_TOKEN_CREDENTIALS` to `dev`. For more information, see [Exclude a credential type category](credential-chains.md#exclude-a-credential-type-category).

      :::code language="csharp" source="../snippets/authentication/local-dev-account/Program.cs" id="snippet_DefaultAzureCredentialDev":::

    - An instance of a credential corresponding to a specific development tool, such as `VisualStudioCredential`.

      :::code language="csharp" source="../snippets/authentication/local-dev-account/Program.cs" id="snippet_VisualStudioCredential":::

    > [!TIP]
    > When your team uses multiple development tools to authenticate with Azure, prefer a local development-optimized instance of `DefaultAzureCredential` over tool-specific credentials.
