---
title: "Dynamic Reconfiguration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b20786ae-cce6-4f91-b6cb-9cae116faf8b
caps.latest.revision: 20
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Dynamic Reconfiguration
This sample demonstrates the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] routing service. The routing service is a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] component that makes it easy to include a content-based router in your application. This sample adapts the standard [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Calculator Sample to communicate using the routing service. This sample shows how the routing service can be dynamically reconfigured during runtime.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\RoutingServices\DynamicReconfiguration`  
  
## Sample Details  
 To dynamically reconfigure the routing service during runtime, this sample fires a timer every five seconds that creates a new <xref:System.ServiceModel.Routing.RoutingConfiguration> object and applies it. This configuration references either the regular Calculator endpoint or the Rounding Calculator endpoint. The Calculator Client application has its messages returned from one service or the other, depending on which one the routing service is configured to route to at that time.  
  
 The routing service’s capabilitiy for dynamic reconfiguration through a custom behavior is used. This custom behavior attaches a service extension, which contains a simple thread timer that fires every five seconds, which results in a callback to the `UpdateRules` method. This callback creates and applies the new routing configuration. In an actual deployment, this callback would likely be accomplished as a result of some other type of event, such as a SQL-Event notification, or a WS-Discovery announcement.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], open DynamicReconfiguration.sln.  
  
2.  To open **Solution Explorer**, select **Solution Explorer** from the **View** menu.  
  
3.  Press **F5** or **CTRL+SHIFT+B** in [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)].  
  
    1.  If you would like to auto-launch the necessary projects when you press **F5**, right-click the solution and select **Properties**. Select the **Startup Project** node under **Common Properties** in the left pane. Select the **Multiple Startup Projects**  radio button and set all of the projects to have the **Start** action.  
  
    2.  If you build the project with **CTRL+SHIFT+B**, you must start the following applications:  
  
        1.  Calculator Client (./CalculatorClient/bin/client.exe)  
  
        2.  Calculator Service (./CalculatorService/bin/service.exe)  
  
        3.  Routing Calculator Service (./RoundingCalcService/bin/service.exe)  
  
        4.  RoutingService (./RoutingService/bin/RoutingService.exe)  
  
4.  In the console window of the Calculator Client, press ENTER to start the client and to call the Calculator service operations.  
  
     The routing service routes messages to the Rounding Calculator and to the regular Calculator alternately as the routing configuration changes dynamically every five seconds. Depending on which endpoint the routing service is configured to send messages to there are different outputs in the client console window.  
  
5.  Continue pressing ENTER repeatedly over more than five seconds and observe the change in the results from the service.  
  
    1.  The following is the output returned if the Router Service is configured to route messages to the Rounding Calculator service.  
  
        ```Output  
        Add(100,15.99) = 116  
        Subtract(145,76.54) = 68.5  
        Multiply(9,81.25) = 731.2  
        Divide(22,7) = 3.1  
        ```  
  
    2.  The following is the output returned if the routing service is configured to route messages to the regular Calculator service.  
  
        ```Output  
        Add(100,15.99) = 115.99  
        Subtract(145,76.54) = 68.46  
        Multiply(9,81.25) = 731.25  
        Divide(22,7) = 3.14285714285714  
        ```  
  
6.  The Calculator Service and the Rounding Calculator Service also print out a log of the operations invoked to their respective console windows.  
  
7.  In the client console window, type "quit" and press ENTER to exit.  
  
8.  Press ENTER in the services console windows to terminate the services.  
  
## Scenario  
 This sample demonstrates the router acting as a content-based router allowing multiple types or implementation of services to be exposed through one endpoint.  
  
### Real World Scenario  
 Contoso wants to virtualize all of their services to expose only one endpoint publicly through which they offer access to multiple different types of services. In this case they utilize the routing service’s content-based routing capabilities to determine where the incoming requests should be sent.  
  
## See Also  
 [AppFabric Hosting and Persistence Samples](http://go.microsoft.com/fwlink/?LinkId=193961)
