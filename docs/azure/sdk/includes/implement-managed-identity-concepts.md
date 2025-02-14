---
ms.topic: include
ms.date: 02/12/2025
---

## Authenticate to Azure services from your app

To authenticate to Azure services from your app code using Microsoft Entra ID and a managed identity, use an implementation of the [`TokenCredential`](/dotnet/api/overview/azure/identity-readme?view=azure-dotnet#credentials) class. The [Azure.Identity](/dotnet/api/azure.identity) library provides various implementations of `TokenCredential` for different scenarios and credential types. These classes allow apps to seamlessly authenticate to Azure resources whether the app is running locally, deployed to Azure, or on an on-premises server.

The steps ahead demonstrate how to use a `TokenCredential` across two different environments:

- **Local dev environment**: During **local development only**, use a class called `DefaultAzureCredential` for an opinionated, preconfigured chain of credentials. `DefaultAzureCredential` discovers user credentials from your local tooling or IDE, such as the Azure CLI or Visual Studio. It also provides flexibility and convenience for retries, wait times for responses, and support for multiple authentication options. Visit the [Authenticate to Azure services during local development](/dotnet/azure/sdk/authentication/local-development-dev-accounts) article to learn more.
- **Azure-hosted apps**: When your app is running in Azure, use a `ManagedIdentityCredential` to safely discover the managed identity configured for your app. Specifying this exact type of credential prevents other available credentials from being picked up unexpectedly.
