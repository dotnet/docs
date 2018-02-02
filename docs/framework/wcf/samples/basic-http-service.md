---
title: "Basic HTTP Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 27048b43-8a54-4f2a-9952-594bbfab10ad
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Basic HTTP Service
This sample demonstrates how to implement an HTTP-based, RPC-based service - popularly referred to as "POX" (Plain Old XML) service – using the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] REST Programming model. This sample consists of two components: a self-hosted [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] HTTP service (Service.cs) and a console application (Program.cs) that creates the service and makes calls to it.  
  
## Sample Details  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service exposes 2 operations, `EchoWithGet` and `EchoWithPost`, which returns the string that was passed as input.  
  
 The `EchoWithGet` operation is annotated with <xref:System.ServiceModel.Web.WebGetAttribute>, which indicates that the operation processes HTTP `GET` requests. Because the <xref:System.ServiceModel.Web.WebGetAttribute> does not explicitly specify a <xref:System.UriTemplate>, the operation expects the input string to be passed in using a query string parameter with name `s`. Note that the format of the URI that the service expects can be customized using the <xref:System.ServiceModel.Web.WebGetAttribute.UriTemplate%2A> property.  
  
 The `EchoWithPost` operation is annotated with <xref:System.ServiceModel.Web.WebInvokeAttribute>, which indicates it is not a `GET` operation (it has side effects). Because the <xref:System.ServiceModel.Web.WebInvokeAttribute> does not explicitly specify a `Method`, the operation processes HTTP `POST` requests that have the string in the request body (in the XML format, for instance). Note that the HTTP method and the format of the URI for the request can be customized using the <xref:System.ServiceModel.Web.WebInvokeAttribute.Method%2A> and <xref:System.ServiceModel.Web.WebInvokeAttribute.UriTemplate> properties respectively.  
  
 The App.config file configures the WCF service with a default <xref:System.ServiceModel.Description.WebHttpEndpoint> that has the <xref:System.ServiceModel.Description.WebHttpEndpoint.HelpEnabled%2A> property set to `true`. As a result, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure creates an automatic HTML based help page at `http://localhost:8000/Customers/help` that provides information about how to construct HTTP requests to the service and how to consume the service’s HTTP response.  
  
 Program.cs demonstrates how a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel factory can be used to make calls to the service and process responses. Note that this is just one way to access a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service. It is also possible to access the service using other .NET Framework classes like <xref:System.Net.HttpWebRequest> and <xref:System.Net.WebClient>. Other samples in the SDK (such as the [Automatic Format Selection](../../../../docs/framework/wcf/samples/automatic-format-selection.md) sample and [Basic Resource Service](../../../../docs/framework/wcf/samples/basic-resource-service.md) sample) show how to use these classes to communicate with a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
 The sample consists a self-hosted service and a client that both run within a console application. As the console application runs, the client makes requests to the service and writes the pertinent information from the responses to the console window.  
  
#### To use this sample  
  
1.  Open the solution for the Basic Http Service Sample. When launching [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], you must run as an administrator for the sample to execute successfully. Do this by right-clicking the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] icon and selecting **Run as Administrator** from the context menu.  
  
2.  Press CTRL+SHIFT+B to build the solution and then press Ctrl+F5 to run the console application without debugging. The console window appears and provides the URI of the running service and the URI of the HTML help page for the running service. At any point in time you can view the HTML help page by typing the URI of the help page in a browser. As the sample runs, the client writes the status of the current activity.  
  
3.  Press any key to terminate the sample.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Web\BasicHttpService`  
  
## See Also  
 [Automatic Format Selection](../../../../docs/framework/wcf/samples/automatic-format-selection.md)  
 [Basic Resource Service](../../../../docs/framework/wcf/samples/basic-resource-service.md)
