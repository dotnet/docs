---
title: "WCF Data Services 4.5"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-oob"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Astoria"
  - "WCF Data Services, getting started"
ms.assetid: 73d2bec3-7c92-4110-b905-11bb0462357a
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Data Services 4.5
[!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] (formerly known as "ADO.NET Data Services") is a component of the .NET Framework that enables you to create services that use the [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] to expose and consume data over the Web or intranet by using the semantics of [representational state transfer (REST)](http://go.microsoft.com/fwlink/?LinkId=113919). [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] exposes data as resources that are addressable by URIs. Data is accessed and changed by using standard HTTP verbs of GET, PUT, POST, and DELETE. [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] uses the entity-relationship conventions of the [Entity Data Model](../../../../docs/framework/data/adonet/entity-data-model.md) to expose resources as sets of entities that are related by associations.  
  
 [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] uses the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] protocol for addressing and updating resources. In this way, you can access these services from any client that supports [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)]. [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] enables you to request and write data to resources by using well-known transfer formats: Atom, a set of standards for exchanging and updating data as XML, and JavaScript Object Notation (JSON), a text-based data exchange format used extensively in AJAX application.  
  
 [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] can expose data that originates from various sources as [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feeds. Visual Studio tools make it easier for you to create an [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)]-based service by using an ADO.NET Entity Framework data model. You can also create [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feeds based on common language runtime (CLR) classes and even late-bound or un-typed data.  
  
 [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] also includes a set of client libraries, one for general .NET Framework client applications and another specifically for Silverlight-based applications. These client libraries provide an object-based programming model when you access an [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feed from environments such as the .NET Framework and Silverlight.  
  
## Where Should I Start?  
 Depending on your interests, consider getting started with [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] in one of the following topics.  
  
 I want to jump right in…  
 -   [Quickstart](../../../../docs/framework/data/wcf/quickstart-wcf-data-services.md)  
  
-   [Getting Started](../../../../docs/framework/data/wcf/getting-started-with-wcf-data-services.md)  
  
-   [Silverlight Quickstart](http://go.microsoft.com/fwlink/?LinkID=192782)  
  
-   [Silverlight Quickstart for Windows Phone Development](http://go.microsoft.com/fwlink/?LinkID=214535)  
  
 Just show me some code…  
 -   [Quickstart](../../../../docs/framework/data/wcf/quickstart-wcf-data-services.md)  
  
-   [How to: Execute Data Service Queries](../../../../docs/framework/data/wcf/how-to-execute-data-service-queries-wcf-data-services.md)  
  
-   [How to: Bind Data to Windows Presentation Foundation Elements](../../../../docs/framework/data/wcf/bind-data-to-wpf-elements-wcf-data-services.md)  
  
 I want to know more about [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)]…  
 -   [Whitepaper: Introducing OData](http://go.microsoft.com/fwlink/?LinkId=220867)  
  
-   [Open Data Protocol Web site](http://go.microsoft.com/fwlink/?LinkID=184554)  
  
-   [OData: SDK](http://go.microsoft.com/fwlink/?LinkID=185248)  
  
-   [OData: Frequently Asked Questions](http://go.microsoft.com/fwlink/?LinkId=185867)  
  
 I want to watch some videos…  
 -   [Beginner's Guide to WCF Data Services](http://go.microsoft.com/fwlink/?LinkId=220864)  
  
-   [WCF Data Services Developer Videos](http://go.microsoft.com/fwlink/?LinkId=220861)  
  
-   [OData: Developers Web site](http://go.microsoft.com/fwlink/?LinkId=185866)  
  
 I want to see end-to-end samples  
 -   [WCF Data Services Documentation Samples on MSDN Samples Gallery](http://go.microsoft.com/fwlink/?LinkID=220865)  
  
-   [Other WCF Data Services Samples on MSDN Samples Gallery](http://go.microsoft.com/fwlink/?LinkId=220866)  
  
-   [OData: SDK](http://go.microsoft.com/fwlink/?LinkID=185248)  
  
 How does it integrate with Visual Studio?  
 -   [Generating the Data Service Client Library](../../../../docs/framework/data/wcf/generating-the-data-service-client-library-wcf-data-services.md)  
  
-   [Creating the Data Service](../../../../docs/framework/data/wcf/creating-the-data-service.md)  
  
-   [Entity Framework Provider](../../../../docs/framework/data/wcf/entity-framework-provider-wcf-data-services.md)  
  
 What can I do with it?  
 -   [Overview](../../../../docs/framework/data/wcf/wcf-data-services-overview.md)  
  
-   [Whitepaper: Introducing OData](http://go.microsoft.com/fwlink/?LinkId=220867)  
  
-   [Application Scenarios](../../../../docs/framework/data/wcf/application-scenarios-wcf-data-services.md)  
  
 I want to use Silverlight…  
 -   [Silverlight Quickstart](http://go.microsoft.com/fwlink/?LinkID=192782)  
  
-   [WCF Data Services (Silverlight)](http://go.microsoft.com/fwlink/?LinkID=143149)  
  
-   [Getting Started with Silverlight](http://go.microsoft.com/fwlink/?LinkId=148366)  
  
 I want to create a Windows Phone application…  
 -   [Silverlight Quickstart for Windows Phone Development](http://go.microsoft.com/fwlink/?LinkID=214535)  
  
-   [Open Data Protocol (OData) Client for Windows Phone](http://go.microsoft.com/fwlink/?LinkID=208749)  
  
 I want to use LINQ…  
 -   [Querying the Data Service](../../../../docs/framework/data/wcf/querying-the-data-service-wcf-data-services.md)  
  
-   [LINQ Considerations](../../../../docs/framework/data/wcf/linq-considerations-wcf-data-services.md)  
  
-   [How to: Execute Data Service Queries](../../../../docs/framework/data/wcf/how-to-execute-data-service-queries-wcf-data-services.md)  
  
 I still need some more information…  
 -   [WCF Data Services Team Blog](http://go.microsoft.com/fwlink/?LinkID=150511)  
  
-   [Resources](../../../../docs/framework/data/wcf/wcf-data-services-resources.md)  
  
-   [WCF Data Services Developer Center](http://go.microsoft.com/fwlink/?LinkId=220868)  
  
-   [Open Data Protocol Web site](http://go.microsoft.com/fwlink/?LinkID=184554)  
  
## In This Section  
 [Overview](../../../../docs/framework/data/wcf/wcf-data-services-overview.md)  
 Provides an overview of the features and functionality available in [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)].  
  
 [What's New in WCF Data Services](http://msdn.microsoft.com/library/cf22cad5-b8d9-472b-8d7c-b863b64eaae8)  
 Describes new functionality in [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] and support for new [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] features.  
  
 [Getting Started](../../../../docs/framework/data/wcf/getting-started-with-wcf-data-services.md)  
 Describes how to expose and consume [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feeds by using [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)].  
  
 [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md)  
 Describes how to create and configure a data service that exposes [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feeds.  
  
 [WCF Data Services Client Library](../../../../docs/framework/data/wcf/wcf-data-services-client-library.md)  
 Describes how to use client libraries to consume [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feeds from a .NET Framework client application.  
  
## See Also  
 [Representational State Transfer (REST)](http://go.microsoft.com/fwlink/?LinkId=113919)
