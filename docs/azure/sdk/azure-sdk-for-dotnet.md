---
title: Azure SDK for .NET Overview
description: Provides an overview of what the Azure SDK for .NET is and the basic steps to use the SDK in a .NET application
ms.date: 09/02/2021
ms.custom: devx-track-dotnet
ms.author: daberry
author: daberry
---

# Azure SDK for .NET overview

## What is the Azure SDK for .NET

The **Azure SDK for .NET** is designed to make it easy to use Azure services from your .NET applications.  Whether it is uploading and downloading files to Blob Storage, retrieving application secrets from Azure Key Vault, or processing notifications from Azure Event Hubs, the Azure SDK for .NET provides a consistent and familiar interface to access Azure services.  

The Azure SDK for .NET is available as series of NuGet packages that can be used in both .NET Core (2.1 and higher) and .NET Framework (4.7.2 and higher) applications.

:::image type="content" source="./media/azure-sdk-for-dotnet-overview.png" alt-text="Diagram showing how .NET applications use the Azure SDK to access Azure services.":::

## Use the Azure SDK for .NET in your applications

To use an Azure SDK package in one of your .NET applications, you want to follow these steps.

1. **Locate the appropriate SDK package -** Use the [package list](packages.md) to find the appropriate package for the Azure service you are working with.  Be advised that most services have a client package for working with the service and a management package for creating and managing instances of the service.  In most cases, you will want the client package.  Install this package in your application using NuGet.

2. **Set up authentication for your application -** To access Azure resources, your application will need to have the appropriate credentials and access rights assigned in Azure.  Learn how to configure authentication in [Authenticating .NET applications to Azure](authentication.md).

3. **Write code using the SDK in your application -** When working with Azure services, your code will first create a client object to work with the service and then call methods on that client object to interact with the service.  Both synchronous and asynchronous methods are provided.  Examples of using each individual SDK package are provided throughout the Azure documentation.

4. **Configure logging for the SDK (optional) -** If you need to diagnose issues between your application and Azure, you can [enable logging in the Azure SDK for .NET](logging.md).
