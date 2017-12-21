---
title: "How to: Specify a Client Binding in Configuration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4a7c79aa-50ee-4991-891e-adc0599323a7
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Specify a Client Binding in Configuration
In this example, a client console application is created to use a calculator service, and the binding for that client is specified declaratively in configuration. The client accesses the `CalculatorService`, which implements the `ICalculator` interface, and both the service and the client use the <xref:System.ServiceModel.BasicHttpBinding> class.  
  
 The procedure outlined assumes that the calculator service is running. For information about how to build the service, see [How to: Specify a Service Binding in Configuration](../../../docs/framework/wcf/how-to-specify-a-service-binding-in-configuration.md). It also uses the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) that [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] provides to automatically generate the client components. The tool generates the client code and configuration for accessing the service.  
  
 The client is built in two parts. Svcutil.exe generates the `ClientCalculator` that implements the `ICalculator` interface. This client application is then constructed by constructing an instance of `ClientCalculator`.  
  
 It is usually the best practice to specify the binding and address information declaratively in configuration rather than imperatively in code. Defining endpoints in code is usually not practical because the bindings and addresses for a deployed service are typically different from those used while the service is being developed. More generally, keeping the binding and addressing information out of the code allows them to change without having to recompile or redeploy the application.  
  
 You can perform all of the following configuration steps by using the [Configuration Editor Tool (SvcConfigEditor.exe)](../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md).  
  
 For the source copy of this example, see the [BasicBinding](../../../docs/framework/wcf/samples/basicbinding.md) sample.  
  
### Specifying a client binding in configuration  
  
1.  Use Svcutil.exe from the command line to generate code from service metadata.  
  
    ```  
    Svcutil.exe <service's Metadata Exchange (MEX) address or HTTP GET address>   
    ```  
  
2.  The client that is generated contains the `ICalculator` interface that defines the service contract that the client implementation must satisfy.  
  
     [!code-csharp[C_HowTo_ConfigureClientBinding#1](../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_configureclientbinding/cs/generatedclient.cs#1)]
     [!code-csharp[C_HowTo_ConfigureClientBinding#1](../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_configureclientbinding/cs/source.cs#1)]  
  
3.  The generated client also contains the implementation of the `ClientCalculator`.  
  
     [!code-csharp[C_HowTo_ConfigureClientBinding#2](../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_configureclientbinding/cs/generatedclient.cs#2)]
     [!code-csharp[C_HowTo_ConfigureClientBinding#2](../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_configureclientbinding/cs/source.cs#2)]  
  
4.  Svcutil.exe also generates the configuration for the client that uses the <xref:System.ServiceModel.BasicHttpBinding> class. When using [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], name this file App.config. Note that the address and binding information are not specified anywhere inside the implementation of the service. Also, code does not have to be written to retrieve that information from the configuration file.  
  
     [!code-xml[C_HowTo_ConfigureClientBinding#100](../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_configureclientbinding/common/client.exe.config#100)]   
            
5.  Create an instance of the `ClientCalculator` in an application, and then call the service operations.  
  
     [!code-csharp[C_HowTo_ConfigureClientBinding#3](../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_configureclientbinding/cs/client.cs#3)]  
  
6.  Compile and run the client.  
  
## See Also  
 [Using Bindings to Configure Services and Clients](../../../docs/framework/wcf/using-bindings-to-configure-services-and-clients.md)
