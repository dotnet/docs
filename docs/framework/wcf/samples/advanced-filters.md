---
title: "Advanced Filters"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8d81590f-e036-4f96-824a-4a187f462764
caps.latest.revision: 23
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Advanced Filters
This sample demonstrates a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] routing service. The routing service is a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] component that makes it easy to include a content-based router in your application. This sample adapts the standard [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Calculator sample to communicate using the routing service. This sample shows how to define content-based routing logic through the use of message filters and message filter tables.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\RoutingServices\AdvancedFilters`  
  
## Sample Details  
 The following table shows the message filters that are added to the message filter table of the routing service.  
  
|Filter|Rule|Priority|  
|------------|----------|--------------|  
|If (has header)|Rounding|2|  
|If (showed up on Ep2)|Regular|1|  
|If (showed up with Address2)|Rounding|1|  
|If (RoundRobin1)|Regular|0|  
|If (RoundRobin2)|Rounding|0|  
  
 The message filters and message filter tables can be created and configured either through code or in the application configuration file. For this sample, you can find the message filters and message filter tables defined through code in the RoutingService\routing.cs file, or defined in the application configuration file in the RoutingService\App.config file. The following paragraphs describe how the message filters and message filter tables are created for this sample through code.  
  
 First, an <xref:System.ServiceModel.Dispatcher.XPathMessageFilter> looks for the custom header. Note that <xref:System.ServiceModel.WSHttpBinding> results in an envelope version using SOAP 1.2, so the XPath statement is defined to use the SOAP 1.2 namespace. The default namespace manager for <xref:System.ServiceModel.Dispatcher.XPathMessageFilter>s already defines a prefix for the SOAP 1.2 namespace, /s12, which can be used. However, the default namespace manager does not have the custom namespace that the client uses to define the actual header value, so that prefix must be defined. Any message that shows up with this header matches this filter.  
  
```  
XPathMessageContext namespaceManager = new XPathMessageContext();  
namespaceManager.AddNamespace("custom", "http://my.custom.namespace/");  
  
XPathMessageFilter xpathFilter = new XPathMessageFilter("/s12:Envelope/s12:Header/custom:RoundingCalculator = 1", namespaceManager);  
```  
  
 The second filter is an <xref:System.ServiceModel.Dispatcher.EndpointNameMessageFilter>, which matches any message that was received on the `calculatorEndpoint`. The endpoint name is defined when a service endpoint object is created.  
  
```  
EndpointNameMessageFilter endpointNameFilter = new EndpointNameMessageFilter("calculatorEndpoint");  
```  
  
 The third filter is a <xref:System.ServiceModel.Dispatcher.PrefixEndpointAddressMessageFilter>. This matches any message that showed up on an endpoint with an address that matches the address prefix (or the front portion) provided. In this example the address prefix is defined as "http://localhost/routingservice/router/rounding/". This means that any incoming messages that are addressed to "http://localhost/routingservice/router/rounding/*" are matched by this filter. In this case, it is messages that show up on the Rounding Calculator endpoint, which has the address of "http://localhost/routingservice/router/rounding/calculator".  
  
```  
PrefixEndpointAddressMessageFilter prefixAddressFilter = new PrefixEndpointAddressMessageFilter(new EndpointAddress("http://localhost/routingservice/router/rounding/"));  
```  
  
 The last two message filters are custom <xref:System.ServiceModel.Dispatcher.MessageFilter>s. In this example, a "RoundRobin" message filter is used. This message filter is created in the provided RoutingService\RoundRobinMessageFilter.cs file. These filters, when set to the same group, alternate between reporting that they match the message and that they do not, such that only one of them responds `true` at a time.  
  
```  
RoundRobinMessageFilter roundRobinFilter1 = new RoundRobinMessageFilter("group1");  
  
RoundRobinMessageFilter roundRobinFilter2 = new RoundRobinMessageFilter("group1");  
```  
  
 Next, all of those messages are added to a <xref:System.ServiceModel.Dispatcher.MessageFilterTable%601>. In doing so, priorities are specified to influence the order in which the message filter table executes the filters. The higher the priority, the sooner the filter is executed; the lower the priority, the later a filter is executed. Thus a filter at priority 2 runs before a filter at priority 1. The default priority level if none is specified is 0. A message filter table executes all of the filters at a given priority level before moving to the next lowest priority level. If a match is found at a particular priority, then the message filter table does not continue trying to find matches at the next lower priority.  
  
> [!NOTE]
>  While this example shows how to use message filter priorities, in general it is more performant and better design to design and configure your filters such that they do not require prioritization to function correctly.  
  
 The first filter to be added is the XPath filter and its priority is set to 2. This is the first message filter that executes. If it finds the custom header, regardless of what the results of the other filters would be, the message is routed to the Rounding Calculator endpoint.  
  
 At priority 1, two filters are added. Again, these only run if the XPath filter at priority 2 does not match the message. These two filters show two different ways to determine where the message was addressed when it showed up. Because the two filters effectively check to see whether the message arrived at one of the two endpoints, they can be run at the same priority level because they do not both return `true` at the same time.  
  
 Finally, at Priority 0 (the lowest priority) run the RoundRobin message filters. Because the filters are configured with the same group name, only one of them matches at a time. Because all messages with the custom header have been routed and all those addressed to the specific virtualized endpoints, messages handled by the RoundRobin message filters are only messages that were addressed to the default router endpoint without the custom header. Because these messages switch on a message for each call, half of the operations go to the Regular Calculator endpoint and the other half go to the Rounding Calculator endpoint.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], open AdvancedFilters.sln.  
  
2.  To open **Solution Explorer**, select **Solution Explorer** from the **View** menu.  
  
3.  Press F5 or CTRL+SHIFT+B in [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)].  
  
    1.  If you would like to auto-launch the necessary projects when you press F5, right-click the solution and select **Properties**. Select the **Startup Project** node under **Common Properties** in the left pane. Select the **Multiple Startup Projects**  radio button and set all of the projects to have the **Start** action.  
  
    2.  If you build the project with CTRL+SHIFT+B, you must start the following applications:  
  
        1.  Calculator Client (./CalculatorClient/bin/client.exe)  
  
        2.  Calculator Service (./CalculatorService/bin/service.exe)  
  
        3.  Routing Calculator Service (./RoundingCalcService/bin/service.exe)  
  
        4.  RoutingService (./RoutingService/bin/RoutingService.exe)  
  
4.  In the console window of the Calculator client, press ENTER to start the client. The client returns a list of destination endpoints to choose from.  
  
5.  Choose a destination endpoint by typing its corresponding letter and press ENTER.  
  
6.  Next, the client asks you if you want to add a custom header. Press Y for Yes or N for No, then press ENTER.  
  
7.  Depending on the selections you made, you should see different outputs.  
  
    1.  The following is the output returned if you added a custom header to the messages.  
  
        ```Output  
        Add(100,15.99) = 116  
        Subtract(145,76.54) = 68.5  
        Multiply(9,81.25) = 731.3  
        Divide(22,7) = 3.1  
        ```  
  
    2.  The following is the output returned if you chose the Rounding Calculator endpoint without a custom header.  
  
        ```Output  
        Add(100,15.99) = 116  
        Subtract(145,76.54) = 68.5  
        Multiply(9,81.25) = 731.3  
        Divide(22,7) = 3.1  
        ```  
  
    3.  The following is the output returned if you chose the Regular Calculator endpoint without a custom header.  
  
        ```Output  
        Add(100,15.99) = 115.99  
        Subtract(145,76.54) = 68. 46  
        Multiply(9,81.25) = 731.25  
        Divide(22,7) = 3.14285714285714  
        ```  
  
    4.  The following is the output returned if you chose the Default Router endpoint without a custom header.  
  
        ```Output  
        Add(100,15.99) = 116  
        Subtract(145,76.54) = 68.46  
        Multiply(9,81.25) = 731.3  
        Divide(22,7) = 3.14285714285714  
        ```  
  
8.  The Calculator Service and the Rounding Calculator Service also prints out a log of the operations invoked to their respective console windows.  
  
9. In the client console window, type `quit` and press ENTER to exit.  
  
10. Press ENTER in the services console windows to terminate the services.  
  
## Configurable Via Code or App.config  
 The sample ships configured to use an App.config file to define the router’s behavior. You can also change the name of the RoutingService\App.config file to something else so that it is not recognized and uncomment the method call to `ConfigureRouterViaCode()` in RoutingService\routing.cs. Either method results in the same behavior from the router.  
  
### Scenario  
 This sample demonstrates the router acting as a content-based router allowing multiple types or implementation of services to be exposed through one endpoint.  
  
### Real World Scenario  
 Contoso wants to virtualize all of their services to expose only one endpoint publicly through which they offer access to multiple different types of services. In this case they utilize the routing service’s content-based routing capabilities to determine where the incoming requests should be sent.  
  
## See Also  
 [AppFabric Hosting and Persistence Samples](http://go.microsoft.com/fwlink/?LinkId=193961)
