---
title: "Conditional Get and Put"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3d22067f-57b8-4e0f-a571-a694512187ae
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Conditional Get and Put
This sample demonstrates how to use the new conditional retrieve and update APIs for the WCF REST programming model. Because conditional retrieve and update are most appropriate for resource-oriented and REST services, this sample extends the [Basic Resource Service](../../../../docs/framework/wcf/samples/basic-resource-service.md) sample. This sample focuses on adding support for conditional retrieve and update to the [Basic Resource Service](../../../../docs/framework/wcf/samples/basic-resource-service.md) sample using the new APIs introduced in [!INCLUDE[netfx40_long](../../../../includes/netfx40-long-md.md)].  
  
## Demonstrates  
 Conditional Retrieve and Update  
  
## Discussion  
 The WCF service in this sample exposes a collection of customers in a resource-oriented and REST manner. For a detailed description of the service implementation, please see the [Basic Resource Service](../../../../docs/framework/wcf/samples/basic-resource-service.md) sample.  
  
 This sample adds conditional retrieve and update capabilities to the [Basic Resource Service](../../../../docs/framework/wcf/samples/basic-resource-service.md) sample. Conditional retrieve and update use HTTP entity tags and the HTTP If-None-Match and If-Match headers to validate that clients either have or do not have the most current entity for a given resource. However, implementing the code to correctly parse the HTTP If-None-Match and If-Match headers can be tedious and error-prone. Therefore, the <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalRetrieve%2A> and <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalUpdate%2A> methods have been added to the <xref:System.ServiceModel.Web.IncomingWebRequestContext>, which can be accessed using the current instance of the <xref:System.ServiceModel.Web.WebOperationContext>. In addition, the `SetETag` method has been added to the <xref:System.ServiceModel.Web.OutgoingWebRequestContext>, making it easier to return valid entity tags.  
  
 The <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalRetrieve%2A> method is intended to be used with [WebGet] operations. It takes the current entity tag for the given resource as the `entityTag` parameter, which can be a `string`, `int`, `long` or `Guid`. The <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalRetrieve%2A> method checks the entity tag against the HTTP If-None-Match header of the request. If the entity tag is present in the HTTP If-None-Match header, then a <xref:System.ServiceModel.Web.WebFaultException> with a status code of Not Modified (304) is thrown; otherwise the method returns. The conditional retrieve mechanism allows the client to tell the server that it has this entity and to only send the current entity if the client does not already have it. Example usage of the <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalRetrieve%2A> method can be seen in the `GetCustomer` and `GetCustomers` operations of the service. It is important to note that calls to <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalRetrieve%2A> may not return. Developers should implement the operation so that the request is already known to be successful before the call to <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalRetrieve%2A> is executed, such that if the call to <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalRetrieve%2A> was not present, the service would send a response with a successful status code.  
  
 The <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalUpdate%2A> method is similar to the <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalRetrieve%2A> method. It also takes the current entity tag for the given resource. However, it is intended to be used with [WebInvoke] operations in which the method is set to "PUT" or "DELETE". The <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalUpdate%2A> method checks the entity tag against the HTTP If-Match header of the request. If the entity tag is not present in the HTTP If-Match header, then a <xref:System.ServiceModel.Web.WebFaultException> with a status code of Precondition Failed (412) is thrown. The conditional update mechanism allows the client to tell the server that it has this entity for the resource and to only allow the client to alter the resource; if the entity it has is current. Example usage of the <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalUpdate%2A> method can be seen in the `UpdateCustomer` and `DeleteCustomer` operations of the service. Just as with <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalRetrieve%2A>, it is important to note that calls to <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalUpdate%2A> may not return. Developers should implement the operation such that the request is already known to be successful before the call to <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalUpdate%2A> is executed, such that if the call to <xref:System.ServiceModel.Web.IncomingWebRequestContext.CheckConditionalUpdate%2A> was not present, the service would respond with a successful status code.  
  
 The sample consists of a self-hosted service and a client that runs within a console application. As the console application runs, the client makes requests to the service and writes the pertinent information from the responses to the console window.  
  
#### To run the sample  
  
1.  Open the solution for the Conditional Get and Put sample. When launching [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], you must run as an administrator to execute the sample successfully. Do this by right-clicking the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] icon and choosing **Run as Administrator** from the context menu.  
  
2.  Press CTRL+SHIFT+B to build the solution and then press CTRL+F5 to run the console application project. If running this project with debugging enabled (by pressing F5 instead of CTRL+F5), the debugger stops when an exception is thrown by the conditional GET and PUT checking. When this happens, press F5 to continue executing the sample.  
  
3.  The console window appear sand provides the URI of the running service and the URI of the HTML help page for the running service.  
  
4.  As the sample runs, the client sends requests to the service and writes the responses to the console window.  
  
5.  Press any key to terminate the sample.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Web\ConditionalGetAndPut`
