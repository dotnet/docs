---
title: "Batching Operations (WCF Data Services)"
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
ms.assetid: 962a49d1-cc11-4b96-bc7d-071dd6607d6c
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Batching Operations (WCF Data Services)
The [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] supports batch processing of requests to an [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)]-based service. For more information, see [OData: Batch Processing](http://go.microsoft.com/fwlink/?LinkId=186075). In [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], each operation that uses the <xref:System.Data.Services.Client.DataServiceContext>, such as executing a query or saving changes, results in a separate request being sent to the data service. In order to maintain a logical scope for sets of operations, you can explicitly define operational batches. This ensures that all operations in the batch are sent to the data service in a single HTTP request, enables the server to process the operations atomically, and reduces the number of round trips to the data service.  
  
## Batching Query Operations  
 To execute multiple queries in a single batch, you must create each query in the batch as a separate instance of the <xref:System.Data.Services.Client.DataServiceRequest%601> class. When you create a query request in this manner, the query itself is defined as a URI, and it follows the rules for addressing resources. For more information, see [Accessing Data Service Resources](../../../../docs/framework/data/wcf/accessing-data-service-resources-wcf-data-services.md). The batched query requests are sent to the data service when the <xref:System.Data.Services.Client.DataServiceContext.ExecuteBatch%2A> method is called that contains the query request objects. This method returns a <xref:System.Data.Services.Client.DataServiceResponse> object, which is a collection of <xref:System.Data.Services.Client.QueryOperationResponse%601> objects that represent responses to individual queries in the batch, each of which contains either a collection of objects returned by the query or error information. When any single query operation in the batch fails, error information is returned in the <xref:System.Data.Services.Client.QueryOperationResponse%601> object for the operation that failed and the remaining operations are still executed. For more information, see [How to: Execute Queries in a Batch](../../../../docs/framework/data/wcf/how-to-execute-queries-in-a-batch-wcf-data-services.md).  
  
 Batched queries can also be executed asynchronously. For more information, see [Asynchronous Operations](../../../../docs/framework/data/wcf/asynchronous-operations-wcf-data-services.md).  
  
## Batching the SaveChanges Operation  
 When you call the <xref:System.Data.Services.Client.DataServiceContext.SaveChanges%2A> method, all changes that the context tracks are translated into REST-based operations that are sent as requests to the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] service. By default, these changes are not sent in a single request message. To require that all changes be sent in a single request, you must call the <xref:System.Data.Services.Client.DataServiceContext.SaveChanges%28System.Data.Services.Client.SaveChangesOptions%29> method and include a value of <xref:System.Data.Services.Client.SaveChangesOptions.Batch> in the <xref:System.Data.Services.Client.SaveChangesOptions> enumeration that you supply to the method.  
  
 You can also asynchronously save batched changes. For more information, see [Asynchronous Operations](../../../../docs/framework/data/wcf/asynchronous-operations-wcf-data-services.md).  
  
## See Also  
 [WCF Data Services Client Library](../../../../docs/framework/data/wcf/wcf-data-services-client-library.md)
