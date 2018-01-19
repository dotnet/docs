---
title: "WCF Data Services Overview"
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
  - "WCF Data Services"
  - "WCF Data Services, about"
ms.assetid: 7924cf94-c9a6-4015-afc9-f5d22b1743bb
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Data Services Overview
[!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] enables creation and consumption of data services for the Web or an intranet by using the [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)]. [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] enables you to expose your data as resources that are addressable by URIs. This enables you to access and change data by using the semantics of representational state transfer (REST), specifically the standard HTTP verbs of GET, PUT, POST, and DELETE. This topic provides an overview of both the patterns and practices defined by [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] and also the facilities provided by [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] to take advantage of [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] in .NET Framework-based applications.  
  
## Address Data as Resources  
 [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] exposes data as resources that are addressable by URIs. The resource paths are constructed based on the entity-relationship conventions of the Entity Data Model. In this model, entities represent operational units of data in an application domain, such as customers, orders, items, and products. For more information, see [Entity Data Model](../../../../docs/framework/data/adonet/entity-data-model.md).  
  
 In [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)], you address entity resources as an entity set that contains instances of entity types. For example, the URI `http://services.odata.org/Northwind/Northwind.svc/Customers('ALFKI')/Orders` returns all of the orders from the `Northwind` data service that are related to the customer with a `CustomerID` value of `ALFKI.`  
  
 Query expressions enable you to perform traditional query operations against resources, such as filtering, sorting, and paging. For example, the URI `http://services.odata.org/Northwind/Northwind.svc/Customers('ALFKI')/Orders?$filter=Freight gt 50` filters the resources to return only the orders with a freight cost of more than $50. For more information, see [Accessing Data Service Resources](../../../../docs/framework/data/wcf/accessing-data-service-resources-wcf-data-services.md).  
  
## Interoperable Data Access  
 [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] builds on standard Internet protocols to make data services interoperable with applications that do not use the .NET Framework. Because you can use standard URIs to address data, your application can access and change data by using the semantics of representational state transfer (REST), specifically the standard HTTP verbs of GET, PUT, POST, and DELETE. This enables you to access these services from any client that can parse and access data that is transmitted over standard HTTP protocols.  
  
 [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] defines a set of extensions to the Atom Publishing Protocol (AtomPub). It supports HTTP requests and responses in more than one data format to accommodate various client applications and platforms. An [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feed can represent data in Atom, JavaScript Object Notation (JSON), and as plain XML. While Atom is the default format, the format of the feed is specified in the header of the HTTP request. For more information, see [OData: Atom Format](http://go.microsoft.com/fwlink/?LinkID=185794) and [OData: JSON Format](http://go.microsoft.com/fwlink/?LinkID=185795).  
  
 When publishing data as an [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feed, [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] relies on other existing Internet facilities for such operations as caching and authentication. To accomplish this, [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] integrates with existing hosting applications and services, such as ASP.NET, Windows Communication Foundation (WCF), and Internet Information Services (IIS).  
  
## Storage Independence  
 Although resources are addressed based on an entity-relationship model, [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] expose [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feeds regardless of the underlying data source. After [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] accepts an HTTP request for a resource that a URI identifies, the request is deserialized and a representation of that request is passed to an [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] provider. This provider translates the request into a data source-specific format and executes the request on the underlying data source. [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] achieves storage independence by separating the conceptual model that addresses resources prescribed by [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] from the specific schema of the underlying data source.  
  
 [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] integrates with the ADO.NET Entity Framework to enable you to create data services that expose relational data. You can use the Entity Data Model tools to create a data model that contains addressable resources as entities and at the same time define the mapping between this model and the tables in the underlying database. For more information, see [Entity Framework Provider](../../../../docs/framework/data/wcf/entity-framework-provider-wcf-data-services.md).  
  
 [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] also enables you to create data services that expose any data structures that return an implementation of the <xref:System.Linq.IQueryable%601> interface. This enables you to create data services that expose data from .NET Framework types. Create, update, and delete operations are supported when you also implement the <xref:System.Data.Services.IUpdatable> interface. For more information, see [Reflection Provider](../../../../docs/framework/data/wcf/reflection-provider-wcf-data-services.md).  
  
 For an illustration of how [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] integrates with these data providers, see the architectural diagram later in this topic.  
  
## Custom Business Logic  
 [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] makes it easy to add custom business logic to a data service through service operations and interceptors. Service operations are methods defined on the server that are addressable by URIs in the same form as data resources. Service operations can also use query expression syntax to filter, order, and page data returned by an operation. For example, the URI `http://localhost:12345/Northwind.svc/GetOrdersByCity?city='London'&$orderby=OrderDate&$top=10&$skip=10` represents a call to a service operation named `GetOrdersByCity` on the Northwind data service that returns orders for customers from London, with paged results sorted by `OrderDate`. For more information, see [Service Operations](../../../../docs/framework/data/wcf/service-operations-wcf-data-services.md).  
  
 Interceptors enable custom application logic to be integrated in the processing of request or response messages by a data service. Interceptors are called when a query, insert, update, or delete action occurs on the specified entity set. An interceptor then may alter the data, enforce authorization policy, or even terminate the operation. Interceptor methods must be explicitly registered for a given entity set that is exposed by a data service. For more information, see [Interceptors](../../../../docs/framework/data/wcf/interceptors-wcf-data-services.md).  
  
## Client Libraries  
 [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] defines a set of uniform patterns for interacting with data services. This provides an opportunity to create reusable components that are based on these services, such as client-side libraries that make it easier to consume data services.  
  
 [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] includes client libraries for both .NET Framework-based and Silverlight-based client applications. These client libraries enable you to interact with data services by using .NET Framework objects. They also support object-based queries and LINQ queries, loading related objects, change tracking, and identity resolution. For more information, see [WCF Data Services Client Library](../../../../docs/framework/data/wcf/wcf-data-services-client-library.md).  
  
 In addition to the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] client libraries included with the .NET Framework and with Silverlight, there are other client libraries that enable you to consume an [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feed in client applications, such as PHP, AJAX, and Java applications. For more information, see the [OData SDK](http://go.microsoft.com/fwlink/?LinkID=185796).  
  
## Architecture Overview  
 The following diagram illustrates the [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] architecture for exposing [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feeds and using these feeds in [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)]-enabled client libraries:  
  
 ![WCF Data Services architecture diagram](../../../../docs/framework/data/wcf/media/astoriaservicearch.gif "AstoriaServiceArch")  
  
## See Also  
 [WCF Data Services 4.5](../../../../docs/framework/data/wcf/index.md)  
 [Getting Started](../../../../docs/framework/data/wcf/getting-started-with-wcf-data-services.md)  
 [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md)  
 [Accessing a Data Service (WCF Data Services)](http://msdn.microsoft.com/library/1e54a2b9-2ec6-4002-b8f8-c1d8df37c350)  
 [WCF Data Services Client Library](../../../../docs/framework/data/wcf/wcf-data-services-client-library.md)  
 [Representational State Transfer (REST)](http://go.microsoft.com/fwlink/?LinkId=113919)
