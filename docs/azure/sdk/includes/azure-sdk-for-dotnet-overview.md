---
ms.topic: include
ms.date: 03/11/2025
---

The Azure SDK for .NET enables you to access and consume Azure services from your .NET applications. The SDK provides a consistent and approachable interface to perform various tasks, including:

- **Data storage and management**: Upload, download, and manage files in Azure Blob Storage, or utilize scalable database solutions such as Azure Cosmos DB and Azure SQL.
- **Application hosting**: Deploy and manage web applications, APIs, and serverless functions using Azure App Service, Azure Container Apps, and Azure Functions.
- **Authentication and security**: Securely authenticate users and manage access to Azure resources using Microsoft Entra ID, or manage secrets using services like Azure Key Vault.
- **Event and message processing**: Build event-driven applications with Azure Event Hubs, Azure Service Bus, and Azure Event Grid for real-time data processing and messaging.
- **Provision and manage resources**: Automate the creation, configuration, and management of Azure resources using Azure Resource Manager (ARM) APIs.

The Azure SDK for .NET is a collection of NuGet packages that can be used in applications targeting .NET variants that implement [.NET Standard 2.0](/dotnet/standard/net-standard?tabs=net-standard-2-0#select-net-standard-version).

:::image type="content" source="./media/azure-sdk-for-dotnet-overview.png" alt-text="Diagram showing how .NET applications use the Azure SDK to access Azure services.":::

## Use the Azure SDK for .NET in your app

To use an Azure SDK package in one of your .NET app:

1. **Locate the appropriate SDK package**: Use the [package list](packages.md) to find the appropriate package for the Azure service you are working with. Be aware that most services have a client package for working with the service and a management package for creating and managing instances of the service. In most cases, you will want the client package. Install this package in your application using NuGet.

2. **Set up authentication for your application**: To access Azure resources, your application will need the appropriate credentials and access rights assigned in Azure. Learn how to configure authentication in the [Authenticating .NET applications to Azure](authentication/index.md) and the [Authentication best practices](dotnet/azure/sdk/authentication/best-practices) articles.

3. **Write code using the SDK in your application**: When working with Azure services, your code will first create a client object to work with the service and then call methods on that client object to interact with the service. Both synchronous and asynchronous methods are provided. Examples of using each individual SDK package are available throughout the Azure documentation.

4. **Configure logging for the SDK (optional)**: If you need to diagnose issues between your application and Azure, you can [enable logging in the Azure SDK for .NET](logging.md).
