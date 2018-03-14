---
title: "WCF Data Services Protocol Implementation Details"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-oob"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 712d689b-fada-4cbb-bcdb-d65a3ef83b4c
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Data Services Protocol Implementation Details
## OData Protocol Implementation Details  
 The [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] requires that a data service that implements the protocol provide a certain minimum set of functionalities. These functionalities are described in the protocol documents in terms of "should" and "must." Other optional functionality is described in terms of "may." This topic describes these optional functionalities that are not currently implemented by [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)]. For more information, see [OData Protocol Documentation](http://go.microsoft.com/fwlink/?LinkID=184554).  
  
### Support for the $format Query Option  
 The [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] protocol supports both JavaScript Notation (JSON) and Atom feeds, and [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] provides the `$format` system query option to allow a client to request the format of the response feed. This system query option, if supported by the data service, must override the value of the Accept header of the request. [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] supports returning both JSON and Atom feeds. However, the default implementation does not support the `$format` query option and uses only the value of the Accept header to determine the format of the response. There are cases when your data service may need to support the `$format` query option, such as when clients cannot set the Accept header. To support these scenarios, you must extend your data service to handle this option in the URI. You can add this functionality to your data service by downloading the [JSONP and URL-controlled format support for ADO.NET Data Services](http://go.microsoft.com/fwlink/?LinkId=208228) sample project from the MSDN Code Gallery web site and adding it to your data service project. This sample removes the `$format` query option and changes the Accept header to `application/json`. When you include the sample project and adding the `JSONPSupportBehaviorAttribute` to your data service class enables the service to handle the `$format` query option `$format=json`. Further customization of this sample project is required to also handle `$format=atom` or other custom formats.  
  
## WCF Data Services Behaviors  
 The following [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] behaviors are not explicitly defined by the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] protocol:  
  
### Default Sorting Behavior  
 When a query request that is sent to the data service includes a `$top` or `$skip` system query option and does not include the `$orderby` system query option, the returned feed is sorted by the key properties, in ascending order. This is because ordering is required to ensure the correct paging of results. To do this, the data service adds an ordering expression to the query. This behavior also occurs when server-driven paging is enabled in the data service. For more information, see [Configuring the Data Service](../../../../docs/framework/data/wcf/configuring-the-data-service-wcf-data-services.md).To control the ordering of the returned feed, you should include `$orderby` in the query URI.  
  
## See Also  
 [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md)  
 [WCF Data Services Client Library](../../../../docs/framework/data/wcf/wcf-data-services-client-library.md)
