---
title: "WCF Data Services Client Library"
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
  - "WCF Data Services, client library"
  - "DataServiceQuery class, about DataServiceQuery class"
  - "DataServiceContext class, about DataServiceContext class"
ms.assetid: 21075e50-8917-413e-a8ea-35a0f6e65aa5
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Data Services Client Library
Any application can interact with an [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)]-based data service if it can send an HTTP request and process the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feed that a data service returns. This interoperability enables you to access [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)]-based services from a broad range of Web-enabled applications. [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] includes client libraries that provide a richer programming experience when you consume [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feeds from .NET Framework or Silverlight-based applications.  
  
 The two main classes of the client library are the <xref:System.Data.Services.Client.DataServiceContext> class and the <xref:System.Data.Services.Client.DataServiceQuery%601> class. The <xref:System.Data.Services.Client.DataServiceContext> class encapsulates operations that are supported against a specified data service. Although [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] services are stateless, the context is not. Therefore, you can use the <xref:System.Data.Services.Client.DataServiceContext> class to maintain state on the client between interactions with the data service in order to support features such as change management. This class also manages identities and tracks changes. The <xref:System.Data.Services.Client.DataServiceQuery%601> class represents a query against a specific entity set.  
  
 This section describes how to use client libraries to access and change data from a .NET Framework client application. For more information about how to use the [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client library with a Silverlight-based application, see [WCF Data Services (Silverlight)](http://go.microsoft.com/fwlink/?LinkId=186016). Other client libraries are available that enable you to consume an [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feed in other kinds of applications. For more information, see the [OData SDK](http://go.microsoft.com/fwlink/?LinkID=185796).  
  
## In This Section  
 [Generating the Data Service Client Library](../../../../docs/framework/data/wcf/generating-the-data-service-client-library-wcf-data-services.md)  
 Describes how to generate a client library and client data service classes that are based on [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feeds.  
  
 [Querying the Data Service](../../../../docs/framework/data/wcf/querying-the-data-service-wcf-data-services.md)  
 Describes how to query a data service from a .NET Framework-based application by using client libraries.  
  
 [Loading Deferred Content](../../../../docs/framework/data/wcf/loading-deferred-content-wcf-data-services.md)  
 Describes how to load additional content not included in the initial query response.  
  
 [Updating the Data Service](../../../../docs/framework/data/wcf/updating-the-data-service-wcf-data-services.md)  
 Describes how to create, modify, and delete entities and relationships by using the client libraries.  
  
 [Asynchronous Operations](../../../../docs/framework/data/wcf/asynchronous-operations-wcf-data-services.md)  
 Describes the facilities provided by the client libraries for working with a data service in an asynchronous manner.  
  
 [Batching Operations](../../../../docs/framework/data/wcf/batching-operations-wcf-data-services.md)  
 Describes how to send multiple requests to the data service in a single batch by using the client libraries.  
  
 [Binding Data to Controls](../../../../docs/framework/data/wcf/binding-data-to-controls-wcf-data-services.md)  
 Describes how to bind controls to a [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feed returned by a data service.  
  
 [Calling Service Operations](../../../../docs/framework/data/wcf/calling-service-operations-wcf-data-services.md)  
 Describes how to use the client library to call service operations.  
  
 [Managing the Data Service Context](../../../../docs/framework/data/wcf/managing-the-data-service-context-wcf-data-services.md)  
 Describes options for managing the behavior of the client library.  
  
 [Working with Binary Data](../../../../docs/framework/data/wcf/working-with-binary-data-wcf-data-services.md)  
 Describes how to access and change binary data returned by the data service as a data stream.  
  
## See Also  
 [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md)  
 [Getting Started](../../../../docs/framework/data/wcf/getting-started-with-wcf-data-services.md)
