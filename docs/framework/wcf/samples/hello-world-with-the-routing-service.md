---
title: "Hello World with the Routing Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0f4b0d5b-6522-4ad5-9f3a-baa78316d7d1
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Hello World with the Routing Service
This sample demonstrates the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] Routing Service. The Routing Service is a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] component that makes it easy to include a content-based router in your application. This sample adapts the standard [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Calculator Sample to communicate using the Routing Service. In this sample, the Calculator client is configured to send messages to an endpoint exposed by the router. The Routing Service is configured to accept all messages sent to it and to forward them to an endpoint that corresponds to the Calculator service. Thus messages sent from the client are received by the router and re-routed to the actual Calculator service. Messages from the Calculator service are sent back to the router, which in turn passes them back to the Calculator client.  
  
### To use this sample  
  
1.  Using [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], open HelloRoutingService.sln.  
  
2.  Press F5 or CTRL+SHIFT+B.  
  
    > [!NOTE]
    >  If you press F5, the Calculator Client automatically starts. If you press CTRL+SHIFT+B (build), you must start following applications yourself.  
    >   
    >  1.  Calculator client (./CalculatorClient/bin/client.exe  
    > 2.  Calculator service (./CalculatorService/bin/service.exe)  
    > 3.  Routing service (./RoutingService/bin/RoutingService.exe)  
  
3.  Press ENTER to start the client.  
  
     You should see the following output:  
  
     Add(100,15.99) = 115.99  
  
     Subtract(145,76.54) = 68.46  
  
     Multiply(9,81.25) = 731.25  
  
     Divide(22,7) = 3.14285714285714  
  
## Configurable via Code or App.Config  
 The sample ships configured to use an App.config file to define the router’s behavior. You can also change the name of the App.config file to something else so that it is not recognized and uncomment the method call to ConfigureRouterViaCode(). Either method results in the same behavior from the router.  
  
### Scenario  
 This sample demonstrates the router acting as a basic message pump. The routing service acts as a transparent proxy node configured to pass messages directly to a preconfigured set of destination endpoints.  
  
### Real World Scenario  
 Contoso wants to increase the flexibility it has in the naming, addressing, configuration, and security of its services. To do this, they place a basic message pump in front of their services to act as a public facing endpoint. This allows them to place additional security in front of their actual services and make it easier to implement scaled out solutions or service versioning at a later date.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\RoutingServices\HelloRoutingService`  
  
## See Also  
 [AppFabric Hosting and Persistence Samples](http://go.microsoft.com/fwlink/?LinkId=193961)
