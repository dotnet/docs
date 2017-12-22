---
title: "WCF Client Overview"
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
  - "clients [WCF], architecture"
ms.assetid: f60d9bc5-8ade-4471-8ecf-5a07a936c82d
caps.latest.revision: 17
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Client Overview
This section describes what client applications do, how to configure, create, and use a [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] client, and how to secure client applications.  
  
## Using WCF Client Objects  
 A client application is a managed application that uses a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client to communicate with another application. To create a client application for a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service requires the following steps:  
  
1.  Obtain the service contract, bindings, and address information for a service endpoint.  
  
2.  Create a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client using that information.  
  
3.  Call operations.  
  
4.  Close the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object.  
  
 The following sections discuss these steps and provide brief introductions to the following issues:  
  
-   Handling errors.  
  
-   Configuring and securing clients.  
  
-   Creating callback objects for duplex services.  
  
-   Calling services asynchronously.  
  
-   Calling services using client channels.  
  
## Obtain the Service Contract, Bindings, and Addresses  
 In [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], services and clients model contracts using managed attributes, interfaces, and methods. To connect to a service in a client application, you need to obtain the type information for the service contract. Typically, you do this by using the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md), which downloads metadata from the service, converts it to a managed source code file in the language of your choice, and creates a client application configuration file that you can use to configure your [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object. For example, if you are going to create an [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object to invoke a `MyCalculatorService`, and you know that the metadata for that service is published at `http://computerName/MyCalculatorService/Service.svc?wsdl`, then the following code example shows how to use Svcutil.exe to obtain a `ClientCode.vb` file that contains the service contract in managed code.  
  
```  
svcutil /language:vb /out:ClientCode.vb /config:app.config http://computerName/MyCalculatorService/Service.svc?wsdl  
```  
  
 You can either compile this contract code into the client application or into another assembly that the client application can then use to create an [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object. You can use the configuration file to configure the client object to properly connect to the service .  
  
 For an example of this process, see [How to: Create a Client](../../../docs/framework/wcf/how-to-create-a-wcf-client.md). For more complete information about contracts, see [Contracts](../../../docs/framework/wcf/feature-details/contracts.md).  
  
## Create a WCF Client Object  
 A [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client is a local object that represents a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service in a form that the client can use to communicate with the remote service. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client types implement the target service contract, so when you create one and configure it, you can then use the client object directly to invoke service operations. The [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] run time converts the method calls into messages, sends them to the service, listens for the reply, and returns those values to the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object as return values or `out` or `ref` parameters.  
  
 You can also use [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client channel objects to connect with and use services. For details, see [WCF Client Architecture](../../../docs/framework/wcf/feature-details/client-architecture.md).  
  
#### Creating a New WCF Object  
 To illustrate the use of a <xref:System.ServiceModel.ClientBase%601> class, assume the following simple service contract has been generated from a service application.  
  
> [!NOTE]
>  If you are using [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] to create your [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client, objects are loaded automatically into the object browser when you add a service reference to your project.  
  
 [!code-csharp[C_GeneratedCodeFiles#12](../../../samples/snippets/csharp/VS_Snippets_CFX/c_generatedcodefiles/cs/proxycode.cs#12)]  
  
 If you are not using [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], examine the generated contract code to find the type that extends <xref:System.ServiceModel.ClientBase%601> and the service contract interface `ISampleService`. In this case, that type looks like the following code:  
  
 [!code-csharp[C_GeneratedCodeFiles#14](../../../samples/snippets/csharp/VS_Snippets_CFX/c_generatedcodefiles/cs/proxycode.cs#14)]  
  
 This class can be created as a local object using one of the constructors, configured, and then used to connect to a service of the type `ISampleService`.  
  
 It is recommended that you create your [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object first, and then use it and close it inside a single try/catch block. You should not use the `using` statement (`Using` in [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]) because it may mask exceptions in certain failure modes. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] the following sections as well as [Avoiding Problems with the Using Statement](../../../docs/framework/wcf/samples/avoiding-problems-with-the-using-statement.md).  
  
### Contracts, Bindings, and Addresses  
 Before you can create a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object, you must configure the client object. Specifically, it must have a service *endpoint* to use. An endpoint is the combination of a service contract, a binding, and an address. ([!INCLUDE[crabout](../../../includes/crabout-md.md)] endpoints, see [Endpoints: Addresses, Bindings, and Contracts](../../../docs/framework/wcf/feature-details/endpoints-addresses-bindings-and-contracts.md).) Typically, this information is located in the [\<endpoint>](../../../docs/framework/configure-apps/file-schema/wcf/endpoint-of-client.md) element in a client application configuration file, such as the one the Svcutil.exe tool generates, and is loaded automatically when you create your client object. Both [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client types also have overloads that enable you to programmatically specify this information.  
  
 For example, a generated configuration file for an `ISampleService` used in the preceding examples contains the following endpoint information.  
  
 [!code-xml[C_GeneratedCodeFiles#19](../../../samples/snippets/csharp/VS_Snippets_CFX/c_generatedcodefiles/common/client.exe.config#19)]  
  
 This configuration file specifies a target endpoint in the `<client>` element. [!INCLUDE[crabout](../../../includes/crabout-md.md)] using multiple target endpoints, see the <xref:System.ServiceModel.ClientBase%601.%23ctor%2A?displayProperty=nameWithType> or the <xref:System.ServiceModel.ChannelFactory%601.%23ctor%2A?displayProperty=nameWithType> constructors.  
  
## Calling Operations  
 Once you have a client object created and configured, create a try/catch block, call operations in the same way that you would if the object were local, and close the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object. When the client application calls the first operation, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] automatically opens the underlying channel, and the underlying channel is closed when the object is recycled. (Alternatively, you can also explicitly open and close the channel prior to or subsequent to calling other operations.)  
  
 For example, if you have the following service contract:  
  
```csharp  
namespace Microsoft.ServiceModel.Samples  
{  
    using System;  
    using System.ServiceModel;  
  
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]  
    public interface ICalculator  
   {  
        [OperationContract]  
        double Add(double n1, double n2);  
        [OperationContract]  
        double Subtract(double n1, double n2);  
        [OperationContract]  
        double Multiply(double n1, double n2);  
        [OperationContract]  
        double Divide(double n1, double n2);  
    }  
}  
```  
  
```vb  
Namespace Microsoft.ServiceModel.Samples  
  
    Imports System  
    Imports System.ServiceModel  
  
    <ServiceContract(Namespace:= _  
    "http://Microsoft.ServiceModel.Samples")> _   
   Public Interface ICalculator  
        <OperationContract> _   
        Function Add(n1 As Double, n2 As Double) As Double  
        <OperationContract> _   
        Function Subtract(n1 As Double, n2 As Double) As Double  
        <OperationContract> _   
        Function Multiply(n1 As Double, n2 As Double) As Double  
        <OperationContract> _   
     Function Divide(n1 As Double, n2 As Double) As Double  
End Interface  
```  
  
 You can call operations by creating a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object and calling its methods, as the following code example demonstrates. Note that the opening, calling, and closing of the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object occurs within a single try/catch block. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Accessing Services Using a WCF Client](../../../docs/framework/wcf/feature-details/accessing-services-using-a-client.md) and [Avoiding Problems with the Using Statement](../../../docs/framework/wcf/samples/avoiding-problems-with-the-using-statement.md).  
  
 [!code-csharp[C_GeneratedCodeFiles#20](../../../samples/snippets/csharp/VS_Snippets_CFX/c_generatedcodefiles/cs/proxycode.cs#20)]  
  
## Handling Errors  
 Exceptions can occur in a client application when opening the underlying client channel (whether explicitly or automatically by calling an operation), using the client or channel object to call operations, or when closing the underlying client channel. It is recommended at a minimum that applications expect to handle possible <xref:System.TimeoutException?displayProperty=nameWithType> and <xref:System.ServiceModel.CommunicationException?displayProperty=nameWithType> exceptions in addition to any <xref:System.ServiceModel.FaultException?displayProperty=nameWithType> objects thrown as a result of SOAP faults returned by operations. SOAP faults specified in the operation contract are raised to client applications as a <xref:System.ServiceModel.FaultException%601?displayProperty=nameWithType> where the type parameter is the detail type of the SOAP fault. [!INCLUDE[crabout](../../../includes/crabout-md.md)] handling error conditions in a client application, see [Sending and Receiving Faults](../../../docs/framework/wcf/sending-and-receiving-faults.md). For a complete sample the shows how to handle errors in a client, see [Expected Exceptions](../../../docs/framework/wcf/samples/expected-exceptions.md).  
  
## Configuring and Securing Clients  
 Configuring a client starts with the required loading of target endpoint information for the client or channel object, usually from a configuration file, although you can also load this information programmatically using the client constructors and properties. However, additional configuration steps are required to enable certain client behavior and for many security scenarios.  
  
 For example, security requirements for service contracts are declared in the service contract interface, and if Svcutil.exe created a configuration file, that file usually contains a binding that is capable of supporting the security requirements of the service. In some cases, however, more security configuration may be required, such as configuring client credentials. For complete information about the configuration of security for [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] clients, see [Securing Clients](../../../docs/framework/wcf/securing-clients.md).  
  
 In addition, some custom modifications can be enabled in client applications, such as custom run-time behaviors. [!INCLUDE[crabout](../../../includes/crabout-md.md)] how to configure a custom client behavior, see [Configuring Client Behaviors](../../../docs/framework/wcf/configuring-client-behaviors.md).  
  
## Creating Callback Objects for Duplex Services  
 Duplex services specify a callback contract that the client application must implement in order to provide a callback object for the service to call according to the requirements of the contract. Although callback objects are not full services (for example, you cannot initiate a channel with a callback object), for the purposes of implementation and configuration they can be thought of as a kind of service.  
  
 Clients of duplex services must:  
  
-   Implement a callback contract class.  
  
-   Create an instance of the callback contract implementation class and use it to create the <xref:System.ServiceModel.InstanceContext?displayProperty=nameWithType> object that you pass to the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client constructor.  
  
-   Invoke operations and handle operation callbacks.  
  
 Duplex [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client objects function like their nonduplex counterparts, with the exception that they expose the functionality necessary to support callbacks, including the configuration of the callback service.  
  
 For example, you can control various aspects of callback object runtime behavior by using properties of the <xref:System.ServiceModel.CallbackBehaviorAttribute?displayProperty=nameWithType> attribute on the callback class. Another example is the use of the <xref:System.ServiceModel.Description.CallbackDebugBehavior?displayProperty=nameWithType> class to enable the return of exception information to services that call the callback object. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Duplex Services](../../../docs/framework/wcf/feature-details/duplex-services.md). For a complete sample, see [Duplex](../../../docs/framework/wcf/samples/duplex.md).  
  
 On Windows XP computers running Internet Information Services (IIS) 5.1, duplex clients must specify a client base address using the <xref:System.ServiceModel.WSDualHttpBinding?displayProperty=nameWithType> class or an exception is thrown. The following code example shows how to do this in code.  
  
 [!code-csharp[S_DualHttp#8](../../../samples/snippets/csharp/VS_Snippets_CFX/s_dualhttp/cs/program.cs#8)]
 [!code-vb[S_DualHttp#8](../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_dualhttp/vb/module1.vb#8)]  
  
 The following code shows how to do this in a configuration file  
  
 [!code-csharp[S_DualHttp#134](../../../samples/snippets/csharp/VS_Snippets_CFX/s_dualhttp/cs/program.cs#134)]  
  
## Calling Services Asynchronously  
 How operations are called is entirely up to the client developer. This is because the messages that make up an operation can be mapped to either synchronous or asynchronous methods when expressed in managed code. Therefore, if you want to build a client that calls operations asynchronously, you can use Svcutil.exe to generate asynchronous client code using the `/async` option. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [How to: Call Service Operations Asynchronously](../../../docs/framework/wcf/feature-details/how-to-call-wcf-service-operations-asynchronously.md).  
  
## Calling Services Using WCF Client Channels  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client types extend <xref:System.ServiceModel.ClientBase%601>, which itself derives from <xref:System.ServiceModel.IClientChannel?displayProperty=nameWithType> interface to expose the underlying channel system. You can invoke services by using the target service contract with the <xref:System.ServiceModel.ChannelFactory%601?displayProperty=nameWithType> class. For details, see [WCF Client Architecture](../../../docs/framework/wcf/feature-details/client-architecture.md).  
  
## See Also  
 <xref:System.ServiceModel.ClientBase%601?displayProperty=nameWithType>  
 <xref:System.ServiceModel.ChannelFactory%601?displayProperty=nameWithType>
