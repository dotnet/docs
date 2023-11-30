---
title: How to authenticate .NET applications with Azure services
description: How to acquire the necessary credential objects to authenticate a .NET application with Azure services by using the Azure .NET SDK
ms.topic: conceptual
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 2/28/2023
---

# How to authenticate .NET apps to Azure services using the .NET Azure SDK

When an application needs to access an Azure resource such as storage, key vault, or cognitive services, the application must be authenticated to Azure.  This is true for all applications, whether deployed to Azure, deployed on-premises, or under development on a local developer workstation. This article describes the recommended approaches to authenticate an app to Azure when using the Azure SDK for .NET.

## Recommended app authentication approach

It is recommended that apps use token-based authentication rather than connection strings when authenticating to Azure resources.  The Azure SDK for .NET provides classes that support token-based authentication and allow apps to seamlessly authenticate to Azure resources whether the app is in local development, deployed to Azure, or deployed to an on-premises server.

The specific type of token-based authentication an app should use to authenticate to Azure resources depends on where the app is being run and is shown in the following diagram.

:::image type="content" source="../media/dotnet-sdk-auth-strategy.png" alt-text="A diagram showing the recommended token-based authentication strategies for an app depending on where it's running." :::

- **When a developer is running an app during local development -** The app can authenticate to Azure using either an application service principal for local development or by using the developer's Azure credentials.  Each of these options is discussed in more detail in the section [authentication during local development](#authentication-during-local-development).
- **When an app is hosted on Azure -** The app should authenticate to Azure resources using a managed identity. This option is discussed in more detail below in the section [authentication in server environments](#authentication-in-server-environments).
- **When an app is hosted and deployed on-premises -** The app should authenticate to Azure resources using an application service principal. This option is discussed in more detail below in the section [authentication in server environments](#authentication-in-server-environments).

### DefaultAzureCredential

The [`DefaultAzureCredential`](#use-defaultazurecredential-in-an-application) class provided by the Azure SDK allows apps to use different authentication methods depending on the environment they're run in. This allows apps to be promoted from local development to test environments to production without code changes.  You configure the appropriate authentication method for each environment and `DefaultAzureCredential` will automatically detect and use that authentication method. The use of `DefaultAzureCredential` should be preferred over manually coding conditional logic or feature flags to use different authentication methods in different environments.

Details about using the `DefaultAzureCredential` class are covered later in this article in the section [Use `DefaultAzureCredential` in an application](#use-defaultazurecredential-in-an-application).

### Advantages of token-based authentication

Token-based authentication is strongly recommended over using connection strings when building apps for Azure. Token-based authentication offers the following advantages over authenticating with connection strings.

- The token-based authentication methods described below allows you to establish the specific permissions needed by the app on the Azure resource. This follows the [principle of least privilege](https://en.wikipedia.org/wiki/Principle_of_least_privilege).  In contrast, a connection string grants full rights to the Azure resource.
- Whereas anyone or any app with a connection string can connect to an Azure resource, token-based authentication methods scope access to the resource to only the app(s) intended to access the resource.  
- In the case of a managed identity, there is no application secret to store.  This makes the app more secure because there's no connection string or application secret than can be compromised.
- The [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) package in the Azure SDK manages tokens for you behind the scenes. This makes using token based authentication as easy to use as a connection string.

Use of connection strings should be limited to initial proof of concept apps or development prototypes that don't access production or sensitive data.  Otherwise, the token-based authentication classes available in the Azure SDK should always be preferred when authenticating to Azure resources.

## Authentication in server environments

When hosting in a server environment, each application should be assigned a unique *application identity* per environment the application is run in. In Azure, an app identity is represented by a **service principal**, a special type of *security principal* intended to identify and authenticate apps to Azure. The type of service principal to use for your app depends on where your app is running.

| Authentication method | Description |
|-----------------------|-------------|
| Apps hosted in Azure  | [!INCLUDE [sdk-auth-overview-managed-identity](../includes/sdk-auth-overview-managed-identity.md)]            |
| Apps hosted outside of Azure<br>(for example on-premises apps) | [!INCLUDE [sdk-auth-overview-service-principal](../includes/sdk-auth-overview-service-principal.md)] |

## Authentication during local development

When an application is run on a developer's workstation during local development, it still must authenticate to any Azure services used by the app.  The two main strategies for authenticating apps to Azure during local development are:

| Authentication method | Description |
|-----------------------|-------------|
| Create dedicated application service principal objects to be used during local development | [!INCLUDE [sdk-auth-overview-dev-service-principals](../includes/sdk-auth-overview-dev-service-principals.md)] |
| Authenticate the app to Azure using the developer's credentials during local development | [!INCLUDE [sdk-auth-overview-dev-accounts](../includes/sdk-auth-overview-dev-accounts.md)] |

## Use DefaultAzureCredential in an application

[!INCLUDE [Implement Default Azure Credentials](<../includes/implement-defaultazurecredential.md>)]

### Exploring the sequence of DefaultAzureCredential authentication methods

Internally, `DefaultAzureCredential` implements a chain of credential providers for authenticating applications to Azure resources.  Each credential provider is able to detect if credentials of that type are configured for the app.  `DefaultAzureCredential` sequentially checks each provider in order and uses the credentials from the first provider that has credentials configured.

The order and locations in which `DefaultAzureCredential` looks for credentials is found at [DefaultAzureCredential](/dotnet/api/overview/azure/identity-readme?view=azure-dotnet&preserve-view=true#defaultazurecredential).

| Credential type               | Description |
|-------------------------------|-------------|
| Application service principal | `DefaultAzureCredential` reads a set of environment variables to determine if an application service principal (application user) has been set for the app. If so, `DefaultAzureCredential` uses these values to authenticate the app to Azure.<br><br>This method is most often used in server environments but can also be used when developing locally.             |
| Managed Identity              | If the application is deployed to an Azure host with Managed Identity enabled, `DefaultAzureCredential` will authenticate the app to Azure using that Managed Identity. Authentication using a Managed Identity is discussed in the [Authentication in server environments](#authentication-in-server-environments) section of this document.<br><br>This method is only available when an application is hosted in Azure using a service like Azure App Service, Azure Functions, or Azure Virtual Machines. |
| Visual Studio            | If the developer has authenticated to Azure by logging into Visual Studio, `DefaultAzureCredential` will authenticate the app to Azure using that same account. |
| Visual Studio Code            | If the developer has authenticated to Azure using the Visual Studio Code Azure Account plugin, `DefaultAzureCredential` will authenticate the app to Azure using that same account. |
| Azure CLI                     | If a developer has authenticated to Azure using the `az login` command in the Azure CLI, `DefaultAzureCredential` will authenticate the app to Azure using that same account. |
| Azure PowerShell              | If a developer has authenticated to Azure using the `Connect-AzAccount` cmdlet from Azure PowerShell, `DefaultAzureCredential` will authenticate the app to Azure using that same account.            |
| Interactive                   | If enabled, `DefaultAzureCredential` will interactively authenticate the developer via the current system's default browser. By default, this option is disabled. |
