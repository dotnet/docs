---
title: How to authenticate .NET applications with Azure services
description: Learn how to authenticate a .NET app with Azure services by using classes in the Azure Identity library.
ms.topic: conceptual
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 08/02/2024
---

# Authenticate .NET apps to Azure services using the Azure Identity library overview

When an app needs to access an Azure resource, the app must be authenticated to Azure. This is true for all apps, whether deployed to Azure, deployed on-premises, or under development on a local developer workstation. This article describes the recommended approaches to authenticate an app to Azure when using the Azure SDK client libraries.

## Recommended app authentication approach

It's recommended that apps use token-based authentication rather than connection strings when authenticating to Azure resources. The [Azure Identity library](/dotnet/api/overview/azure/identity-readme?view=azure-dotnet&preserve-view=true) provides classes that support token-based authentication and allow apps to seamlessly authenticate to Azure resources whether the app is in local development, deployed to Azure, or deployed to an on-premises server.

The specific type of token-based authentication an app should use to authenticate to Azure resources depends on where the app runs and is shown in the following diagram:

:::image type="content" source="../media/dotnet-sdk-auth-strategy.png" alt-text="A diagram showing the recommended token-based authentication strategies for an app depending on where it's running." :::

When an app is:

- **Hosted on Azure**, the app should authenticate to Azure resources using a managed identity. This option is discussed in more detail at [authentication in server environments](#authentication-for-azure-hosted-apps).
- **Running locally during development**, the app can authenticate to Azure using either an application service principal for local development or by using the developer's Azure credentials. Each option is discussed in more detail at [authentication during local development](#authentication-during-local-development).
- **Hosted and deployed on-premises**, the app should authenticate to Azure resources using an application service principal. This option is discussed in more detail at [authentication in server environments](#authentication-for-apps-hosted-on-premises).

### Advantages of token-based authentication

Token-based authentication offers the following advantages over authenticating with connection strings:

- The token-based authentication methods described below allows you to establish the specific permissions needed by the app on the Azure resource. This follows the [principle of least privilege](https://en.wikipedia.org/wiki/Principle_of_least_privilege). In contrast, a connection string grants full rights to the Azure resource.
- Whereas anyone or any app with a connection string can connect to an Azure resource, token-based authentication methods scope access to the resource to only the app(s) intended to access the resource.  
- In the case of a managed identity, there's no application secret to store. This makes the app more secure because there's no connection string or application secret that can be compromised.
- The [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) package acquires and manages Microsoft Entra tokens for you. This makes using token-based authentication as easy to use as a connection string.

Use of connection strings should be limited to initial proof-of-concept apps or development prototypes that don't access production or sensitive data. Otherwise, the token-based authentication classes available in the Azure Identity library should always be preferred when authenticating to Azure resources.

## Authentication for Azure-hosted apps

When your app is hosted on Azure, it can leverage Azure's managed identities to authenticate to Azure resources without needing to manage any credentials. There are two types of managed identities: user-assigned and system-assigned. Both types provide a secure way to authenticate to Azure services.

### Use a user-assigned identity

A user-assigned managed identity is created as a standalone Azure resource. It can be assigned to one or more Azure resources, allowing those resources to share the same identity. To authenticate using a user-assigned identity, you need to create the identity, assign it to your Azure resource, and then configure your app to use this identity for authentication.

> [!div class="nextstepaction"]
> [Authenticate Azure-hosted apps using a user-assigned managed-identity](user-assigned-managed-identity.md)

### Use a system-assigned identity

A system-assigned managed identity is enabled directly on an Azure resource. The identity is tied to the lifecycle of that resource and is automatically deleted when the resource is deleted. To authenticate using a system-assigned identity, you need to enable the identity on your Azure resource and then configure your app to use this identity for authentication.

> [!div class="nextstepaction"]
> [Authenticate Azure-hosted apps using a system-assigned managed-identity](system-assigned-managed-identity.md)

## Authentication during local development

During local development, you can authenticate to Azure resources using your developer credentials or a service principal. This allows you to test your app's authentication logic without deploying it to Azure.

### Use developer credentials

You can use your own Azure credentials to authenticate to Azure resources during local development. This is typically done using the Azure CLI or Visual Studio, which can provide your app with the necessary tokens to access Azure services. This method is convenient but should only be used for development purposes.

> [!div class="nextstepaction"]
> [Authenticate to Azure services locally using developer credentials](local-development-dev-accounts.md)

### Use a service principal

A service principal is an Azure Active Directory application that can be used to authenticate to Azure resources. You can create a service principal and configure your app to use its credentials during local development. This method is more secure than using developer credentials and is closer to how your app will authenticate in production.

> [!div class="nextstepaction"]
> [Authenticate to Azure services locally using a service principal](local-development-service-principal.md)

## Authentication for apps hosted on-premises

For apps hosted on-premises, you can use a service principal to authenticate to Azure resources. This involves creating a service principal in Azure Active Directory, assigning it the necessary permissions, and configuring your app to use its credentials. This method allows your on-premises app to securely access Azure services.

> [!div class="nextstepaction"]
> [Authenticate your on-prem app using a service principal](local-development-service-principal.md)
