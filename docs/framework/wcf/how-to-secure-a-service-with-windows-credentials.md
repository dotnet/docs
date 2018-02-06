---
title: "How to: Secure a Service with Windows Credentials"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "WCF, security"
ms.assetid: d171b5ca-96ef-47ff-800c-c138023cf76e
caps.latest.revision: 26
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How to: Secure a Service with Windows Credentials
This topic shows how to enable transport security on a [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] service that resides in a Windows domain and is called by clients in the same domain. [!INCLUDE[crabout](../../../includes/crabout-md.md)] this scenario, see [Transport Security with Windows Authentication](../../../docs/framework/wcf/feature-details/transport-security-with-windows-authentication.md). For a sample application, see the [WSHttpBinding](../../../docs/framework/wcf/samples/wshttpbinding.md) sample.  
  
 This topic assumes you have an existing contract interface and implementation already defined, and adds on to that. You can also modify an existing service and client.  
  
 You can secure a service with Windows credentials completely in code. Alternatively, you can omit some of the code by using a configuration file. This topic shows both ways. Be sure you only use one of the ways, not both.  
  
 The first three procedures show how to secure the service using code. The fourth and fifth procedure shows how to do it with a configuration file.  
  
## Using Code  
 The complete code for the service and the client is in the Example section at the end of this topic.  
  
 The first procedure walks through creating and configuring a <xref:System.ServiceModel.WSHttpBinding> class in code. The binding uses the HTTP transport. The same binding is used on the client.  
  
#### To create a WSHttpBinding that uses Windows credentials and message security  
  
1.  This procedure's code is inserted at the beginning of the `Run` method of the `Test` class in the service code in the Example section.  
  
2.  Create an instance of the <xref:System.ServiceModel.WSHttpBinding> class.  
  
3.  Set the <xref:System.ServiceModel.WSHttpSecurity.Mode%2A> property of the <xref:System.ServiceModel.WSHttpSecurity> class to <xref:System.ServiceModel.SecurityMode.Message>.  
  
4.  Set the <xref:System.ServiceModel.MessageSecurityOverHttp.ClientCredentialType%2A> property of the <xref:System.ServiceModel.MessageSecurityOverHttp> class to <xref:System.ServiceModel.MessageCredentialType.Windows>.  
  
5.  The code for this procedure is as follows:  
  
     [!code-csharp[c_SecureWindowsService#1](../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewindowsservice/cs/secureservice.cs#1)]
     [!code-vb[c_SecureWindowsService#1](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securewindowsservice/vb/secureservice.vb#1)]  
  
### Using the Binding in a Service  
 This is the second procedure, which shows how to use the binding in a self-hosted service. [!INCLUDE[crabout](../../../includes/crabout-md.md)] hosting services see [Hosting Services](../../../docs/framework/wcf/hosting-services.md).  
  
##### To use a binding in a service  
  
1.  Insert this procedure's code after the code from the preceding procedure.  
  
2.  Create a <xref:System.Type> variable named `contractType` and assign it the type of the interface (`ICalculator`). When using [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)], use the `GetType` operator; when using C#, use the `typeof` keyword.  
  
3.  Create a second `Type` variable named `serviceType` and assign it the type of the implemented contract (`Calculator`).  
  
4.  Create an instance of the <xref:System.Uri> class named `baseAddress` with the base address of the service. The base address must have a scheme that matches the transport. In this case, the transport scheme is HTTP, and the address includes the special Uniform Resource Identifier (URI) "localhost" and a port number (8036) as well as a base endpoint address ("serviceModelSamples/): http://localhost:8036/serviceModelSamples/.  
  
5.  Create an instance of the <xref:System.ServiceModel.ServiceHost> class with the `serviceType` and `baseAddress` variables.  
  
6.  Add an endpoint to the service using the `contractType`, binding, and an endpoint name (secureCalculator). A client must concatenate the base address and the endpoint name when initiating a call to the service.  
  
7.  Call the <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A> method to start the service. The code for this procedure is shown here:  
  
     [!code-csharp[c_SecureWindowsService#2](../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewindowsservice/cs/secureservice.cs#2)]
     [!code-vb[c_SecureWindowsService#2](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securewindowsservice/vb/secureservice.vb#2)]  
  
### Using the Binding in a Client  
 This procedure shows how to generate a proxy that communicates with the service. The proxy is generated with the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) which uses the service metadata to create the proxy.  
  
 This procedure also creates an instance of the <xref:System.ServiceModel.WSHttpBinding> class to communicate with the service, and then calls the service.  
  
 This example uses only code to create the client. As an alternative, you can use a configuration file, which is shown in the section following this procedure.  
  
##### To use a binding in a client with code  
  
1.  Use the SvcUtil.exe tool to generate the proxy code from the service's metadata. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [How to: Create a Client](../../../docs/framework/wcf/how-to-create-a-wcf-client.md). The generated proxy code inherits from the <xref:System.ServiceModel.ClientBase%601> class, which ensures that every client has the necessary constructors, methods, and properties to communicate with a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service. In this example, the generated code includes the `CalculatorClient` class, which implements the `ICalculator` interface, enabling compatibility with the service code.  
  
2.  This procedure's code is inserted at the beginning of the `Main` method of the client program.  
  
3.  Create an instance of the <xref:System.ServiceModel.WSHttpBinding> class and set its security mode to `Message` and its client credential type to `Windows`. The example names the variable `clientBinding`.  
  
4.  Create an instance of the <xref:System.ServiceModel.EndpointAddress> class named `serviceAddress`. Initialize the instance with the base address concatenated with the endpoint name.  
  
5.  Create an instance of the generated client class with the `serviceAddress` and the `clientBinding` variables.  
  
6.  Call the <xref:System.ServiceModel.ClientBase%601.Open%2A> method, as shown in the following code.  
  
7.  Call the service and display the results.  
  
     [!code-csharp[c_secureWindowsClient#1](../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewindowsclient/cs/secureclient.cs#1)]
     [!code-vb[c_secureWindowsClient#1](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securewindowsclient/vb/secureclient.vb#1)]  
  
## Using the Configuration File  
 Instead of creating the binding with procedural code, you can use the following code shown for the bindings section of the configuration file.  
  
 If you do not already have a service defined, see [Designing and Implementing Services](../../../docs/framework/wcf/designing-and-implementing-services.md), and [Configuring Services](../../../docs/framework/wcf/configuring-services.md).  
  
 **Note** This configuration code is used in both the service and client configuration files.  
  
#### To enable transfer security on a service in a Windows domain using configuration  
  
1.  Add a [\<wsHttpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md) element to the [\<bindings>](../../../docs/framework/configure-apps/file-schema/wcf/bindings.md) element section of the configuration file.  
  
2.  Add a <`binding`> element to the <`WSHttpBinding`> element and set the `configurationName` attribute to a value appropriate to your application.  
  
3.  Add a <`security`> element and set the `mode` attribute to Message.  
  
4.  Add a <`message`> element and set the `clientCredentialType` attribute to Windows.  
  
5.  In the service's configuration file, replace the `<bindings>` section with the following code. If you do not already have a service configuration file, see [Using Bindings to Configure Services and Clients](../../../docs/framework/wcf/using-bindings-to-configure-services-and-clients.md).  
  
    ```xml  
    <bindings>  
      <wsHttpBinding>  
       <binding name = "wsHttpBinding_Calculator">  
         <security mode="Message">  
           <message clientCredentialType="Windows"/>  
         </security>  
        </binding>  
      </wsHttpBinding>  
    </bindings>  
    ```  
  
### Using the Binding in a Client  
 This procedure shows how to generate two files: a proxy that communicates with the service and a configuration file. It also describes changes to the client program, which is the third file used on the client.  
  
##### To use a binding in a client with configuration  
  
1.  Use the SvcUtil.exe tool to generate the proxy code and configuration file from the service's metadata. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [How to: Create a Client](../../../docs/framework/wcf/how-to-create-a-wcf-client.md).  
  
2.  Replace the [\<bindings>](../../../docs/framework/configure-apps/file-schema/wcf/bindings.md) section of the generated configuration file with the configuration code from the preceding section.  
  
3.  Procedural code is inserted at the beginning of the `Main` method of the client program.  
  
4.  Create an instance of the generated client class passing the name of the binding in the configuration file as an input parameter.  
  
5.  Call the <xref:System.ServiceModel.ClientBase%601.Open%2A> method, as shown in the following code.  
  
6.  Call the service and display the results.  
  
     [!code-csharp[c_secureWindowsClient#2](../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewindowsclient/cs/secureclient.cs#2)]  
  
## Example  
 [!code-csharp[c_SecureWindowsService#0](../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewindowsservice/cs/secureservice.cs#0)]  
  
 [!code-csharp[c_SecureWindowsClient#0](../../../samples/snippets/csharp/VS_Snippets_CFX/c_securewindowsclient/cs/secureclient.cs#0)] 
 [!code-vb[c_SecureWindowsClient#0](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securewindowsclient/vb/secureclient.vb#0)]      
  
## See Also  
 <xref:System.ServiceModel.WSHttpBinding>  
 [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md)  
 [How to: Create a Client](../../../docs/framework/wcf/how-to-create-a-wcf-client.md)  
 [Securing Services](../../../docs/framework/wcf/securing-services.md)  
 [Security Overview](../../../docs/framework/wcf/feature-details/security-overview.md)
