---
title: "WCF Data Services Client Library"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "WCF Data Services, client library"
  - "DataServiceQuery class, about DataServiceQuery class"
  - "DataServiceContext class, about DataServiceContext class"
ms.assetid: 21075e50-8917-413e-a8ea-35a0f6e65aa5
---
# WCF Data Services Client Library
Any application can interact with an Open Data Protocol (OData)-based data service if it can send an HTTP request and process the OData feed that a data service returns. This interoperability enables you to access OData-based services from a broad range of Web-enabled applications. WCF Data Services includes client libraries that provide a richer programming experience when you consume OData feeds from .NET Framework or Silverlight-based applications.  
  
 The two main classes of the client library are the <xref:System.Data.Services.Client.DataServiceContext> class and the <xref:System.Data.Services.Client.DataServiceQuery%601> class. The <xref:System.Data.Services.Client.DataServiceContext> class encapsulates operations that are supported against a specified data service. Although OData services are stateless, the context is not. Therefore, you can use the <xref:System.Data.Services.Client.DataServiceContext> class to maintain state on the client between interactions with the data service in order to support features such as change management. This class also manages identities and tracks changes. The <xref:System.Data.Services.Client.DataServiceQuery%601> class represents a query against a specific entity set.  
  
 This section describes how to use client libraries to access and change data from a .NET Framework client application. For more information about how to use the WCF Data Services client library with a Silverlight-based application, see [WCF Data Services (Silverlight)](https://go.microsoft.com/fwlink/?LinkId=186016). Other client libraries are available that enable you to consume an OData feed in other kinds of applications. For more information, see the [OData SDK](https://go.microsoft.com/fwlink/?LinkID=185796).  
  
## In This Section  
 [Generating the Data Service Client Library](generating-the-data-service-client-library-wcf-data-services.md)  
 Describes how to generate a client library and client data service classes that are based on OData feeds.  
  
 [Querying the Data Service](querying-the-data-service-wcf-data-services.md)  
 Describes how to query a data service from a .NET Framework-based application by using client libraries.  
  
 [Loading Deferred Content](loading-deferred-content-wcf-data-services.md)  
 Describes how to load additional content not included in the initial query response.  
  
 [Updating the Data Service](updating-the-data-service-wcf-data-services.md)  
 Describes how to create, modify, and delete entities and relationships by using the client libraries.  
  
 [Asynchronous Operations](asynchronous-operations-wcf-data-services.md)  
 Describes the facilities provided by the client libraries for working with a data service in an asynchronous manner.  
  
 [Batching Operations](batching-operations-wcf-data-services.md)  
 Describes how to send multiple requests to the data service in a single batch by using the client libraries.  
  
 [Binding Data to Controls](binding-data-to-controls-wcf-data-services.md)  
 Describes how to bind controls to a OData feed returned by a data service.  
  
 [Calling Service Operations](calling-service-operations-wcf-data-services.md)  
 Describes how to use the client library to call service operations.  
  
 [Managing the Data Service Context](managing-the-data-service-context-wcf-data-services.md)  
 Describes options for managing the behavior of the client library.  
  
 [Working with Binary Data](working-with-binary-data-wcf-data-services.md)  
 Describes how to access and change binary data returned by the data service as a data stream.  
  
## See also

- [Defining WCF Data Services](defining-wcf-data-services.md)
- [Getting Started](getting-started-with-wcf-data-services.md)
