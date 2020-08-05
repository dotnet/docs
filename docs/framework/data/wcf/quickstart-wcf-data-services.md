---
title: "Quickstart (WCF Data Services)"
ms.date: 08/24/2018
helpviewer_keywords:
  - "WCF Data Services, quick-start example"
  - "WCF Data Services, Entity Data Model (EDM) service"
ms.assetid: 7b18ca1e-d4d6-4c7a-afb9-ce3cebb98a8d
---
# Quickstart (WCF Data Services)

This quickstart helps you become familiar with WCF Data Services and the Open Data Protocol (OData) through a series of tasks that support the topics in [Getting Started](getting-started-with-wcf-data-services.md).

## What you'll learn

The first task in this quickstart shows how to create a data service to expose an OData feed from the Northwind sample database. In later topics, you will access the OData feed by using a Web browser, and also create a Windows Presentation Foundation (WPF) client application that consumes the OData feed by using client libraries.

## Prerequisites

To complete this quickstart, install the following components:

- Visual Studio

- An instance of SQL Server. This includes SQL Server Express, which is included in a default installation of Visual Studio 2015, or as part of the **Data storage and processing** workload in Visual Studio 2017 or later.

- The Northwind sample database. To install the database, run the Transact-SQL script from [Northwind and pubs sample databases for Microsoft SQL Server](https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs).

## WCF data services quickstart tasks

 [Create the Data Service](creating-the-data-service.md)

 Define the ASP.NET application, define the data model, create the data service, and enable access to resources.

 [Access the Service from a Web Browser](accessing-the-service-from-a-web-browser-wcf-data-services-quickstart.md)

 Start the service from Visual Studio and access the service by submitting HTTP GET requests through a Web browser to the exposed feed.

 [Create the .NET Framework Client Application](creating-the-dotnet-client-application-wcf-data-services-quickstart.md)

 Create a WPF app to consume the OData feed, bind data to Windows controls, change data in the bound controls, and then send the changes back to the data service.

> [!NOTE]
> Project files from a completed version of the quickstart can be downloaded from [GitHub](https://github.com/microsoftarchive/msdn-code-gallery-community-s-z/tree/master/WCF%20Data%20Services%20Quickstart%20(OData%20Service%20and%20WPF%20Client)).

## Next steps

> [!div class="nextstepaction"]
> [Start the quickstart](creating-the-data-service.md)

## See also

- [ADO.NET Entity Framework](../adonet/ef/index.md)
