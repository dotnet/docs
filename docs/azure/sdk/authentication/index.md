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

- **Running locally during development**, the app can authenticate to Azure using either an application service principal for local development or by using the developer's Azure credentials. Each option is discussed in more detail at [authentication during local development](#authentication-during-local-development).
- **Hosted on Azure**, the app should authenticate to Azure resources using a managed identity. This option is discussed in more detail at [authentication in server environments](#authentication-in-server-environments).
- **Hosted and deployed on-premises**, the app should authenticate to Azure resources using an application service principal. This option is discussed in more detail at [authentication in server environments](#authentication-in-server-environments).

### DefaultAzureCredential

The [DefaultAzureCredential](#use-defaultazurecredential-in-an-application) class provided by the Azure Identity library allows apps to use different authentication methods depending on the environment in which they're run. This allows apps to be promoted from local development to test environments to production without code changes. You configure the appropriate authentication method for each environment, and `DefaultAzureCredential` will automatically detect and use that authentication method. The use of `DefaultAzureCredential` should be preferred over manually coding conditional logic or feature flags to use different authentication methods in different environments.

Details about using `DefaultAzureCredential` are covered at [Use `DefaultAzureCredential` in an application](#use-defaultazurecredential-in-an-application).

### Advantages of token-based authentication

Token-based authentication offers the following advantages over authenticating with connection strings:

- The token-based authentication methods described below allows you to establish the specific permissions needed by the app on the Azure resource. This follows the [principle of least privilege](https://en.wikipedia.org/wiki/Principle_of_least_privilege). In contrast, a connection string grants full rights to the Azure resource.
- Whereas anyone or any app with a connection string can connect to an Azure resource, token-based authentication methods scope access to the resource to only the app(s) intended to access the resource.  
- In the case of a managed identity, there's no application secret to store. This makes the app more secure because there's no connection string or application secret that can be compromised.
- The [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) package acquires and manages Microsoft Entra tokens for you. This makes using token-based authentication as easy to use as a connection string.

Use of connection strings should be limited to initial proof-of-concept apps or development prototypes that don't access production or sensitive data. Otherwise, the token-based authentication classes available in the Azure Identity library should always be preferred when authenticating to Azure resources.

## Authentication in server environments

When hosting in a server environment, each app should be assigned a unique *application identity* per environment in which the app is run. In Azure, an application identity is represented by a **service principal**, a special type of *security principal* intended to identify and authenticate apps to Azure. The type of service principal to use for your app depends on where your app is running.

| Authentication method | Description |
|-----------------------|-------------|
| Apps hosted in Azure  | [!INCLUDE [sdk-auth-overview-managed-identity](../includes/sdk-auth-overview-managed-identity.md)]            |
| Apps hosted outside of Azure<br>(for example, on-premises apps) | [!INCLUDE [sdk-auth-overview-service-principal](../includes/sdk-auth-overview-service-principal.md)] |

## Authentication during local development

When an app is run on a developer's workstation during local development, it must still authenticate to any Azure services used by the app. The two main strategies for authenticating apps to Azure during local development are:

| Authentication method | Description |
|-----------------------|-------------|
| Create dedicated application service principal objects to be used during local development | [!INCLUDE [sdk-auth-overview-dev-service-principals](../includes/sdk-auth-overview-dev-service-principals.md)] |
| Authenticate the app to Azure using the developer's credentials during local development | [!INCLUDE [sdk-auth-overview-dev-accounts](../includes/sdk-auth-overview-dev-accounts.md)] |

## Use DefaultAzureCredential in an application

[!INCLUDE [Implement DefaultAzureCredential](<../includes/implement-defaultazurecredential.md>)]
