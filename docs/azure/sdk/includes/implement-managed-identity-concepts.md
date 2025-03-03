---
ms.topic: include
ms.date: 02/12/2025
---

## Authenticate to Azure services from your app

The [Azure Identity library](/dotnet/api/azure.identity?view=azure-dotnet&preserve-view=true) provides various *credentials*&mdash;implementations of `TokenCredential` adapted to supporting different scenarios and Microsoft Entra authentication flows. Since managed identity is unavailable when running locally, the steps ahead demonstrate which credential to use in which scenario:

- **Local dev environment**: During **local development only**, use a class called [DefaultAzureCredential](../authentication/credential-chains.md#defaultazurecredential-overview) for an opinionated, preconfigured chain of credentials. `DefaultAzureCredential` discovers user credentials from your local tooling or IDE, such as the Azure CLI or Visual Studio. It also provides flexibility and convenience for retries, wait times for responses, and support for multiple authentication options. Visit the [Authenticate to Azure services during local development](../authentication/local-development-dev-accounts.md) article to learn more.
- **Azure-hosted apps**: When your app is running in Azure, use [ManagedIdentityCredential](/dotnet/api/azure.identity.managedidentitycredential?view=azure-dotnet&preserve-view=true) to safely discover the managed identity configured for your app. Specifying this exact type of credential prevents other available credentials from being picked up unexpectedly.
