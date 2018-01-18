---
title: "Basic Resource Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4360063e-cc8c-4648-846e-c05a5af51a7a
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Basic Resource Service
This sample demonstrates how to implement a HTTP-based service using the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] REST Programming model that exposes a collection of customers that supports the retrieve, add, delete and replace operations. This sample consists of 2 components - a self-hosted [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] HTTP service (Service.cs) and a console application (program.cs) that creates the service and makes calls to it.  
  
## Sample Details  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service exposes a collection of customers in a resource-oriented/REST manner. In short, this involves having unique URIs for the collection of customers and every customer in the collection. The service supports sending an HTTP `GET` at the collection URI to retrieve the entire collection and HTTP `POST` at the collection URI to add a new customer to the collection. Also at the URI for an individual customer, it supports HTTP `GET` to get the customer details, HTTP `PUT` to replace the details of the customer and HTTP `DELETE` to remove the customer from the collection. When a new customer is added to the collection, the service assigns it a unique URI and stores the URI as part of the customer’s details. Also, it communicates the URI to the client using the Location HTTP header of the response.  
  
 The App.config file configures the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service with a default <xref:System.ServiceModel.Description.WebHttpEndpoint> that has the <xref:System.ServiceModel.Description.WebHttpEndpoint.HelpEnabled%2A> property set to `true`. As a result, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] creates an automatic HTML-based help page at `http://localhost:8000/Customers/help` that provides information about how to construct HTTP requests to the service and how to access the service’s HTTP response – for instance, an example of how the customer details is represented in XML and JSON.  
  
 Exposing the customer collection (and more generally, any resource) in this manner allows the client to interact with it in a uniform way using URIs and HTTP `GET`, `PUT`, `DELETE` and `POST`. Program.cs demonstrates how such a client can be authored using <xref:System.Net.HttpWebRequest>. Note that this is just one way to access a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] REST service. It is also possible to access the service using other .NET Framework classes like the <xref:System.ServiceModel.ChannelFactory> and <xref:System.Net.WebClient>. Other samples in the SDK (such as the [Basic HTTP Service](../../../../docs/framework/wcf/samples/basic-http-service.md) sample and the [Automatic Format Selection](../../../../docs/framework/wcf/samples/automatic-format-selection.md) sample) show how to use these classes to communicate with a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
 The sample consists a self-hosted service and a client that both run within a console application. As the console application runs, the client makes requests to the service and writes the pertinent information from the responses to the console window.  
  
#### To use this sample  
  
1.  Open the solution for the Basic Resource Service Sample. When launching [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], you must run as an administrator for the sample to execute successfully. Do this by right-clicking the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] icon and selecting **Run as Administrator** from the context menu.  
  
2.  Press CTRL+SHIFT+B to build the solution and then press Ctrl+F5 to run the console application. The console window appears and provides the URI of the running service and the URI of the HTML help page for the running service. At any point in time you can view the HTML help page by typing the URI of the help page in a browser. As the sample runs, the client writes the status of the current activity.  
  
3.  Press any key to terminate the sample.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Web\BasicResourceService`  
  
## See Also  
 [Basic HTTP Service](../../../../docs/framework/wcf/samples/basic-http-service.md)  
 [Automatic Format Selection](../../../../docs/framework/wcf/samples/automatic-format-selection.md)
