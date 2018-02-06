---
title: "How to: Host a WCF Service in WAS"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9e3e213e-2dce-4f98-81a3-f62f44caeb54
caps.latest.revision: 25
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Host a WCF Service in WAS
This topic outlines the basic steps required to create a Windows Process Activation Services (also known as WAS) hosted [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service. WAS is the new process activation service that is a generalization of Internet Information Services (IIS) features that work with non-HTTP transport protocols. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the listener adapter interface to communicate activation requests that are received over the non-HTTP protocols supported by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], such as TCP, named pipes, and Message Queuing.  
  
 This hosting option requires that WAS activation components are properly installed and configured, but it does not require any hosting code to be written as part of the application. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] installing and configuring WAS, see [How to: Install and Configure WCF Activation Components](../../../../docs/framework/wcf/feature-details/how-to-install-and-configure-wcf-activation-components.md).  
  
> [!WARNING]
>  WAS activation is not supported if the web server’s request processing pipeline is set to Classic mode. The web server’s request processing pipeline must be set to Integrated mode if WAS activation is to be used.  
  
 When a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service is hosted in WAS, the standard bindings are used in the usual way. However, when using the <xref:System.ServiceModel.NetTcpBinding> and the <xref:System.ServiceModel.NetNamedPipeBinding> to configure a WAS-hosted service, a constraint must be satisfied. When different endpoints use the same transport, the binding settings have to match on the following seven properties:  
  
-   ConnectionBufferSize  
  
-   ChannelInitializationTimeout  
  
-   MaxPendingConnections  
  
-   MaxOutputDelay  
  
-   MaxPendingAccepts  
  
-   ConnectionPoolSettings.IdleTimeout  
  
-   ConnectionPoolSettings.MaxOutboundConnectionsPerEndpoint  
  
 Otherwise, the endpoint that is initialized first always determines the values of these properties, and endpoints added later throw a <xref:System.ServiceModel.ServiceActivationException> if they do not match those settings.  
  
 For the source copy of this example, see [TCP Activation](../../../../docs/framework/wcf/samples/tcp-activation.md).  
  
### To create a basic service hosted by WAS  
  
1.  Define a service contract for the type of service.  
  
     [!code-csharp[C_HowTo_HostInWAS#1121](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_hostinwas/cs/service.cs#1121)]  
  
2.  Implement the service contract in a service class. Note that address or binding information is not specified inside the implementation of the service. Also, code does not have to be written to retrieve that information from the configuration file.  
  
     [!code-csharp[C_HowTo_HostInWAS#1122](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_hostinwas/cs/service.cs#1122)]  
  
3.  Create a Web.config file to define the <xref:System.ServiceModel.NetTcpBinding> binding to be used by the `CalculatorService` endpoints.  
  
    ```xml  
    <?xml version="1.0" encoding="utf-8" ?>  
    <configuration>  
      <system.serviceModel>  
        <bindings>  
          <netTcpBinding>  
            <binding portSharingEnabled="true">  
              <security mode="None" />  
            </binding>  
          </netTcpBinding>  
        </bindings>  
      </system.serviceModel>  
    </configuration>  
    ```  
  
4.  Create a Service.svc file that contains the following code.  
  
    ```  
    <%@ServiceHost language=c# Service="CalculatorService" %>   
    ```  
  
5.  Place the Service.svc file in your IIS virtual directory.  
  
### To create a client to use the service  
  
1.  Use [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) from the command line to generate code from service metadata.  
  
    ```  
    Svcutil.exe <service's Metadata Exchange (MEX) address or HTTP GET address>   
    ```  
  
2.  The client that is generated contains the `ICalculator` interface that defines the service contract that the client implementation must satisfy.  
  
     [!code-csharp[C_HowTo_HostInWAS#1221](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_hostinwas/cs/client.cs#1221)]  
  
3.  The generated client application also contains the implementation of the `ClientCalculator`. Note that the address and binding information is not specified anywhere inside the implementation of the service. Also, code does not have to be written to retrieve that information from the configuration file.  
  
     [!code-csharp[C_HowTo_HostInWAS#1222](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_hostinwas/cs/client.cs#1222)]  
  
4.  The configuration for the client that uses the <xref:System.ServiceModel.NetTcpBinding> is also generated by Svcutil.exe. This file should be named in the App.config file when using Visual Studio.  
  
     [!code-xml[C_HowTo_HostInWAS#2211](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_hostinwas/common/app.config#2211)]   
  
5.  Create an instance of the `ClientCalculator` in an application and then call the service operations.  
  
     [!code-csharp[C_HowTo_HostInWAS#1223](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_hostinwas/cs/client.cs#1223)]  
  
6.  Compile and run the client.  
  
## See Also  
 [TCP Activation](../../../../docs/framework/wcf/samples/tcp-activation.md)  
 [Windows Server App Fabric Hosting Features](http://go.microsoft.com/fwlink/?LinkId=201276)
