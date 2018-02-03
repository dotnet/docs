---
title: "AspNetRouteIntegration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0638ce0e-d053-47df-a447-688e447a03fb
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# AspNetRouteIntegration
This sample demonstrates how to host a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] REST service using ASP.NET routes. The [Basic Resource Service](../../../../docs/framework/wcf/samples/basic-resource-service.md) sample shows a self-hosted version of this scenario and discusses the service implementation in depth. This topic focuses on the ASP.NET integration feature. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] ASP.NET Routing, see <xref:System.Web.Routing>.  
  
## Sample Details  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service exposes a collection of customers in a resource-oriented/REST manner. Just like a SOAP-based [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service, the service can be hosted in ASP.NET using a .svc file. However, this is often not preferred for HTTP scenarios because it requires having .svc in the URL for the service. In addition, it requires deploying a .svc file along with the service library. These limitations can be avoided by hosting the service using ASP.NET routes, as is demonstrated in this sample.  
  
 The sample hosts the service in ASP.NET by adding a <xref:System.ServiceModel.Activation.ServiceRoute> in a Global.asax file. The <xref:System.ServiceModel.Activation.ServiceRoute> specifies the type of the service (‘Service’ in this case), the type of the service host factory to use for the service (<xref:System.ServiceModel.Activation.WebServiceHostFactory> in this case) and the HTTP base address for the service (‘~/Customers’ in this case).  
  
 In addition to this, the sample includes a Web.config that adds the <xref:System.Web.Routing.UrlRoutingModule> (to turn on ASP.NET routes) and includes the configuration for the service. In particular, the configuration configures the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service with a default <xref:System.ServiceModel.Description.WebHttpEndpoint> that has the <xref:System.ServiceModel.Description.WebHttpEndpoint.HelpEnabled%2A> setting to `true`. As a result, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure creates an automatic HTML based help page at `http://localhost/Customers/help` that provides information about how to construct HTTP requests to the service and how to access the service’s HTTP response – for instance, an example of how the customer details are represented in XML and JSON.  
  
 Exposing the customer collection (and more generally, any resource) in this manner allows a client to interact with a service in a uniform way using URIs and HTTP `GET`, `PUT`, `DELETE` and `POST`.  
  
 Program.cs in the Client project demonstrates how such a client can be authored using <xref:System.Net.HttpWebRequest>. Note that this is just one way to access a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service. It is also possible to access the service using other .NET Framework classes like the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel factory and <xref:System.Net.WebClient>. Other samples in the SDK (such as the [Basic HTTP Service](../../../../docs/framework/wcf/samples/basic-http-service.md) sample and the [Automatic Format Selection](../../../../docs/framework/wcf/samples/automatic-format-selection.md) sample) show how to use these classes to communicate with a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
 This sample consists of 3 projects:  
  
 Service  
 A Web application project that includes a WCF HTTP service hosted in ASP.NET.  
  
 Client  
 A console application project that makes calls to the service.  
  
 Common  
 A shared library that contains the `Customer` type used by the client and service. As the client console application runs, the client makes requests to the service and writes the pertinent information from the responses to the console window.  
  
#### To use this sample  
  
1.  Open the solution for the ASP.NET Routes Integration sample in [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)].  
  
2.  Press CTRL+SHIFT+B to build the solution.  
  
3.  If it is not already open, press "CTRL+W, S" to open the **Solution Explorer** window.  
  
4.  From the **Solution Explorer** windows, right-click the **Service** project and place the cursor over the **Debug** context menu option so that the **Start New Instance** context menu appears and select **Start New Instance**.  This launches the ASP.NET development server, which hosts the service.  
  
5.  From the **Solution Explorer** windows, right-click the **Client** project and place the cursor over the **Debug** context menu option so that the **Start New Instance** context menu appears and select **Start New Instance**.  
  
6.  The client console window appears and provides the URI of the running service and the URI of the HTML help page for the running service. At any point in time you can view the HTML help page by typing the URI of the help page in a browser. As the sample runs, the client writes the status of the current activity.  
  
7.  Press any key to terminate the client console application.  
  
8.  Press Shift+F5 to stop debugging the service and in the Windows Notification Area, right-click the ASP.NET development server icon and select **Stop** from the context menu.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Web\AspNetRouteIntegration`  
  
## See Also
