---
title: How to authenticate .NET applications with Azure services
description: Learn how to authenticate a .NET app with Azure services by using classes in the Azure Identity library.
ms.topic: conceptual
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 08/02/2024
---

# Authenticate .NET apps to Azure services using the Azure Identity library

Apps can use the Azure Identity library to authenticate to Microsoft Entra ID, which allows the apps to access Azure services and resources. This authentication requirement applies whether the app is deployed to Azure, hosted on-premises, or running locally on a developer workstation. The sections ahead describe the recommended approaches to authenticate an app to Microsoft Entra ID across different environments when using the Azure SDK client libraries.

## Recommended approach for app authentication

Token-based authentication via Microsoft Entra ID is the recommended approach for authenticating apps to Azure, instead of using connection strings or key-based options. The [Azure Identity library](/dotnet/api/overview/azure/identity-readme?view=azure-dotnet&preserve-view=true) provides classes that support token-based authentication and allow apps to authenticate to Azure resources whether the app runs locally, on Azure, or on an on-premises server.

### Advantages of token-based authentication

Token-based authentication offers the following advantages over connection strings:

- Token-based authentication ensures only the specific apps intended to access the Azure resource are able to do so, whereas anyone or any app with a connection string can connect to an Azure resource.
- Token-based authentication allows you to further limit Azure resource access to only the specific permissions needed by the app. This follows the [principle of least privilege](https://wikipedia.org/wiki/Principle_of_least_privilege). In contrast, a connection string grants full rights to the Azure resource.
- When using a [managed identity](/entra/identity/managed-identities-azure-resources/overview) for token-based authentication, Azure handles administrative functions for you, so you don't have to worry about tasks like securing or rotating secrets. This makes the app more secure because there's no connection string or application secret that can be compromised.
- The Azure Identity library acquires and manages Microsoft Entra tokens for you.

Use of connection strings should be limited to scenarios where token-based authentication is not an option, initial proof-of-concept apps, or development prototypes that don't access production or sensitive data. When possible, use the token-based authentication classes available in the Azure Identity library to authenticate to Azure resources.

## Authentication across different environments

The specific type of token-based authentication an app should use to authenticate to Azure resources depends on where the app runs. The following diagram provides guidance for different scenarios and environments:

:::image type="content" source="../media/dotnet-sdk-auth-strategy.png" alt-text="A diagram showing the recommended token-based authentication strategies for an app depending on where it's running." :::

When an app is:

- **Hosted on Azure**: The app should authenticate to Azure resources using a managed identity. This option is discussed in more detail at [authentication in server environments](#authentication-for-azure-hosted-apps).
- **Running locally during development**: The app can authenticate to Azure using either an application service principal for local development or by using the developer's Azure credentials. Each option is discussed in more detail at [authentication during local development](#authentication-during-local-development).
- **Hosted on-premises**: The app should authenticate to Azure resources using an application service principal, or a managed identity in the case of Azure Arc. On-premises workflows are discussed in more detail at [authentication in server environments](#authentication-for-apps-hosted-on-premises).

## Authentication for Azure-hosted apps

When your app is hosted on Azure, it can use managed identities to authenticate to Azure resources without needing to manage any credentials. There are two types of managed identities: user-assigned and system-assigned.

#### Use a user-assigned managed identity

A user-assigned managed identity is created as a standalone Azure resource. It can be assigned to one or more Azure resources, allowing those resources to share the same identity and permissions. To authenticate using a user-assigned managed identity, create the identity, assign it to your Azure resource, and then configure your app to use this identity for authentication by specifying its client ID, resource ID, or object ID.

> [!div class="nextstepaction"]
> [Authenticate using a user-assigned managed identity](user-assigned-managed-identity.md)

#### Use a system-assigned managed identity

A system-assigned managed identity is enabled directly on an Azure resource. The identity is tied to the lifecycle of that resource and is automatically deleted when the resource is deleted. To authenticate using a system-assigned managed identity, enable the identity on your Azure resource and then configure your app to use this identity for authentication.

> [!div class="nextstepaction"]
> [Authenticate using a system-assigned managed identity](system-assigned-managed-identity.md)

## Authentication during local development

During local development, you can authenticate to Azure resources using your developer credentials or a service principal. This allows you to test your app's authentication logic without deploying it to Azure.

#### Use developer credentials

You can use your own Azure credentials to authenticate to Azure resources during local development. This is typically done using a development tool, such as Azure CLI or Visual Studio, which can provide your app with the necessary tokens to access Azure services. This method is convenient but should only be used for development purposes.

> [!div class="nextstepaction"]
> [Authenticate locally using developer credentials](local-development-dev-accounts.md)

#### Use a service principal

A service principal is created in a Microsoft Entra tenant to represent an app and be used to authenticate to Azure resources. You can configure your app to use service principal credentials during local development. This method is more secure than using developer credentials and is closer to how your app will authenticate in production. However, it's still less ideal than using a managed identity due to the need for secrets.

> [!div class="nextstepaction"]
> [Authenticate locally using a service principal](local-development-service-principal.md)

## Authentication for apps hosted on-premises

For apps hosted on-premises, you can use a service principal to authenticate to Azure resources. This involves creating a service principal in Microsoft Entra ID, assigning it the necessary permissions, and configuring your app to use its credentials. This method allows your on-premises app to securely access Azure services.

> [!div class="nextstepaction"]
> [Authenticate your on-prem app using a service principal](local-development-service-principal.md)
