---
title: "How to: Exchange Messages Within a Reliable Session | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 87cd0e75-dd2c-44c1-8da0-7b494bbdeaea
caps.latest.revision: 9
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# How to: Exchange Messages Within a Reliable Session
This topic outlines the steps required to enable a reliable session using one of the system-provided bindings that support such a session, but not by default. The reliable session can be enabled imperatively using code or declaratively in the configuration file. This procedure uses the client and service configuration filesto enable the reliable session and to stipulate that the messages arrive in the same order in which they were sent.  
  
 The key part of this procedure is that the endpoint configuration element contain a `bindingConfiguration` attribute that references a binding configuration named "Binding1." The [\<binding>](../../../../docs/framework/misc/binding.md) configuration element can then reference this name to enable reliable sessions by setting the `enabled` attribute of the [reliableSession](http://msdn.microsoft.com/en-us/9c93818a-7dfa-43d5-b3a1-1aafccf3a00b) element to `true`. You specify the ordered delivery assurances for the reliable session by setting the `ordered` attribute to `true`.  
  
 For the source copy of this example, see [WS Reliable Session](../../../../docs/framework/wcf/samples/ws-reliable-session.md).  
  
### To configure the service with a WSHttpBinding to use a reliable session  
  
1.  Define a service contract for the type of service.  
  
     [!code-csharp[c_HowTo_UseReliableSession#1121](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_usereliablesession/cs/service.cs#1121)]  
  
2.  Implement the service contract in a service class. Note that address or binding information is not specified inside the implementation of the service. Also, code does not have to be written to retrieve that information from the configuration file.  
  
     [!code-csharp[c_HowTo_UseReliableSession#1122](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_usereliablesession/cs/service.cs#1122)]  
  
3.  Create a Web.config file to configure an endpoint for the `CalculatorService` that uses the <xref:System.ServiceModel.WSHttpBinding> with reliable session enabled and ordered delivery of messages required.  
  
     [!code-xml[c_HowTo_UseReliableSession#2111](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_usereliablesession/common/web.config#2111)]   
  
4.  Create a Service.svc file that contains the line:  
  
    ```  
    <%@ServiceHost language=c# Service="CalculatorService" %>   
    ```  
  
5.  Place the Service.svc file in your Internet Information Services (IIS) virtual directory.  
  
### To configure the client with a WSHttpBinding to use a reliable session  
  
1.  Use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) from the command line to generate code from service metadata:  
  
    ```  
    Svcutil.exe <service's Metadata Exchange (MEX) address or HTTP GET address>   
    ```  
  
2.  The client that is generated contains the `ICalculator` interface that defines the service contract that the client implementation must satisfy.  
  
     [!code-csharp[C_HowTo_UseReliableSession#1221](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_usereliablesession/cs/client.cs#1221)]  
  
3.  The generated client application also contains the implementation of the `ClientCalculator`. Note that the address and binding information is not specified anywhere inside the implementation of the service. Also, code does not have to be written to retrieve that information from the configuration file.  
  
     [!code-csharp[C_HowTo_UseReliableSession#1222](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_usereliablesession/cs/client.cs#1222)]  
  
4.  Svcutil.exe also generates the configuration for the client that uses the <xref:System.ServiceModel.WSHttpBinding> class. This file should be named the App.config file when using [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)].  
  
     [!code-xml[C_HowTo_UseReliableSession#2211](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_usereliablesession/common/app.config#2211)]   
  
5.  Create an instance of the `ClientCalculator` in an application and then call the service operations.  
  
     [!code-csharp[C_HowTo_UseReliableSession#1223](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_usereliablesession/cs/client.cs#1223)]  
  
6.  Compile and run the client.  
  
## Example  
  
 Several of the system-provided bindings support reliable sessions by default. These include:  
  
-   <xref:System.ServiceModel.WSDualHttpBinding>  
  
-   <xref:System.ServiceModel.NetNamedPipeBinding>  
  
-   <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding>  
  
 For an example of how to create a custom binding that supports reliable sessions, see [How to: Create a Custom Reliable Session Binding with HTTPS](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-reliable-session-binding-with-https.md).  
  
## See Also  
 [Reliable Sessions](../../../../docs/framework/wcf/feature-details/reliable-sessions.md)