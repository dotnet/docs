---
title: "Bridging and Error Handling"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4ae87d1a-b615-4014-a494-a53f63ff0137
caps.latest.revision: 21
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Bridging and Error Handling
This sample demonstrates how the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] routing service is used for bridging communication between a client and a service that use different bindings. This sample also shows how to use a back-up service for failover scenarios. The routing service is a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] component that makes it easy to include a content-based router in your application. This sample adapts the standard [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Calculator Sample to communicate using the routing service.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\RoutingServices\ErrorHandlingAndBridging`  
  
## Sample Details  
 In this sample, the Calculator client is configured to send messages to an endpoint exposed by the router. The routing service is configured to accept all messages sent to it and to forward them to an endpoint that corresponds to the Calculator service. The following points describe the configuration of the primary Calculator service, the back-up Calculator service, and the Calculator client and how the communication between the client and the service happens using the routing service:  
  
-   The Calculator client is configured to use BasicHttpBinding while the Calculator service is configured to use NetTcpBinding. The routing service automatically converts the messages as necessary before sending them to the Calculator service and it also converts the responses so that the Calculator client can access them.  
  
-   The routing service knows about two Calculator services: the primary Calculator service and the back-up Calculator service. The routing service first attempts to communicate with the primary Calculator service endpoint. If this attempt fails due to the endpoint being down, the routing service then tries to communicate with the back-up Calculator service endpoint.  
  
 Thus messages sent from the client are received by the router and are rerouted to the actual Calculator service. If the Calculator service endpoint is down, the routing service routes the message to the back-up Calculator service endpoint. Messages from the back-up Calculator service are sent back to the service router, which in turn passes them back to the Calculator client.  
  
> [!NOTE]
>  A back-up list can have more than one endpoint defined. In this case if the back-up service endpoint is down, the routing service attempts to connect to the next back-up endpoint in the list until a successful connection occurs.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], open RouterBridgingAndErrorHandling.sln.  
  
2.  Press F5 or CTRL+SHIFT+B in Visual Studio  
  
    1.  If you would like to auto-launch the necessary projects when you press F5, right-click the solution, select **Properties**, and in the **Startup Project** node under **Common Properties**, select **Multiple Startup Projects**, and set all projects to **Start**.  
  
    2.  If you build the project with CTRL+SHIFT+B, start the following applications:  
  
        1.  Calculator client (./CalculatorClient/bin/client.exe)  
  
        2.  Calculator service (./CalculatorService/bin/service.exe)  
  
        3.  Routing Service (./RoutingService/bin/RoutingService.exe)  
  
3.  In the Calculator Client, press ENTER to start the client.  
  
     You should see the following output:  
  
    ```Output  
    Add(100,15.99) = 115.99  
    Subtract(145,76.54) = 68.46  
    Multiply(9,81.25) = 731.25  
    Divide(22,7) = 3.14285714285714  
    ```  
  
## Configurable Via Code or App.config  
 The sample ships configured to use an App.config file to define the router’s behavior. You can also change the name of the App.config file to something else so that it is not recognized and uncomment the method call to `ConfigureRouterViaCode()`. Either method results in the same behavior from the router.  
  
### Scenario  
 This sample demonstrates the service router acting as a protocol bridge and error handler. In this scenario, no content-based routing occurs; the routing service acts as a transparent proxy node configured to pass messages directly to a preconfigured set of destination endpoints. The routing service also performs the additional steps of transparently handling errors that occur when it tries to send to the endpoints that it is configured to communicate with. By acting as a protocol bridge, the routing service enables the user to define one protocol for external communication and another for internal communication.  
  
### Real World Scenario  
 Contoso wants to provide an interoperable service endpoint to the world, while optimizing performance internally. Thus it exposes its services to the world through an endpoint using the BasicHttpBinding, while internally using the routing service to bridge that connection to the endpoint using NetTcpBinding, which its services use. Furthermore, Contoso wants its service offering to be tolerant of temporary outages in any one of their production services and thus virtualizes multiple endpoints behind the router service using the ’s error handling capabilities to automatically failover to back-up endpoints when necessary.  
  
## See Also  
 [AppFabric Hosting and Persistence Samples](http://go.microsoft.com/fwlink/?LinkId=193961)
