---
ms.topic: include
ms.date: 02/12/2025
---

## Authenticate to Azure services from your app

The [Azure Identity library](/dotnet/api/azure.identity?view=azure-dotnet&preserve-view=true) provides various *credentials*&mdash;implementations of `TokenCredential` adapted to supporting different scenarios and Microsoft Entra authentication flows. The steps ahead demonstrate which credential to use when working with service principals locally and in production:

- **Local dev environment**: During **local development only**, use a class called [DefaultAzureCredential](../authentication/credential-chains.md#defaultazurecredential-overview) for an opinionated, preconfigured chain of credentials. `DefaultAzureCredential` discovers user credentials from your local tooling or IDE, such as the Azure CLI or Visual Studio. It also provides flexibility and convenience for retries, wait times for responses, and support for multiple authentication options.
- **Hosted apps**: In production environments, use [ClientSecretCredential](/dotnet/api/azure.identity.ClientSecretCredential?view=azure-dotnet&preserve-view=true) to discover the environment variables for your service principal. Specifying this deterministic credential prevents other available credentials from being picked up unexpectedly.
