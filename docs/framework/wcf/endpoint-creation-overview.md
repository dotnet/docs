---
title: "Endpoint Creation Overview"
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
  - "endpoints [WCF], overview"
ms.assetid: f4dce0fb-6f54-47e6-8054-86d7f574b91c
caps.latest.revision: 40
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Endpoint Creation Overview
All communication with a [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] service occurs through the *endpoints* of the service. Endpoints provide the clients access to the functionality that a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service offers. This section describes the structure of an endpoint and outlines how to define an endpoint in configuration and in code.  
  
## The Structure of an Endpoint  
 Each endpoint contains an address that indicates where to find the endpoint, a binding that specifies how a client can communicate with the endpoint, and a contract that identifies the methods available.  
  
-   **Address**. The address uniquely identifies the endpoint and tells potential consumers where the service is located. It is represented in the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] object model by the <xref:System.ServiceModel.EndpointAddress> address, which contains a Uniform Resource Identifier (URI) and address properties that include an identity, some Web Services Description Language (WSDL) elements, and a collection of optional headers. The optional headers provide additional detailed addressing information to identify or interact with the endpoint. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Specifying an Endpoint Address](../../../docs/framework/wcf/specifying-an-endpoint-address.md).  
  
-   **Binding**. The binding specifies how to communicate with the endpoint. The binding specifies how the endpoint communicates with the world, including which transport protocol to use (for example, TCP or HTTP), which encoding to use for the messages (for example, text or binary), and which security requirements are necessary (for example, Secure Sockets Layer [SSL] or SOAP message security). [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Using Bindings to Configure Services and Clients](../../../docs/framework/wcf/using-bindings-to-configure-services-and-clients.md).  
  
-   **Service contract**. The service contract outlines what functionality the endpoint exposes to the client. A contract specifies the operations that a client can call, the form of the message and the type of input parameters or data required to call the operation, and the kind of processing or response message the client can expect. Three basic types of contracts correspond to basic message exchange patterns (MEPs): datagram (one-way), request/reply, and duplex (bidirectional). The service contract can also employ data and message contracts to require specific data types and message formats when being accessed. [!INCLUDE[crabout](../../../includes/crabout-md.md)] how to define a service contract, see [Designing Service Contracts](../../../docs/framework/wcf/designing-service-contracts.md). Note that a client may also be required to implement a service-defined contract, called a callback contract, to receive messages from the service in a duplex MEP. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Duplex Services](../../../docs/framework/wcf/feature-details/duplex-services.md).  
  
 The endpoint for a service can be specified either imperatively by using code or declaratively through configuration. If no endpoints are specified then the runtime provides default endpoints by adding one default endpoint for each base address for each service contract implemented by the service. Defining endpoints in code is usually not practical because the bindings and addresses for a deployed service are typically different from those used while the service is being developed. Generally, it is more practical to define service endpoints using configuration rather than code. Keeping the binding and addressing information out of the code allows them to change without having to recompile and redeploy the application.  
  
> [!NOTE]
>  When adding a service endpoint that performs impersonation, you must either use one of the <xref:System.ServiceModel.ServiceHost.AddServiceEndpoint%2A> methods or the <xref:System.ServiceModel.Description.ContractDescription.GetContract%28System.Type%2CSystem.Type%29> method to properly load the contract into a new <xref:System.ServiceModel.Description.ServiceDescription> object.  
  
## Defining Endpoints in Code  
 The following example illustrates how to specify an endpoint in code with the following:  
  
-   Define a contract for an `IEcho` type of service that accepts someone's name and echo with the response "Hello \<name>!".  
  
-   Implement an `Echo` service of the type defined by the `IEcho` contract.  
  
-   Specify an endpoint address of http://localhost:8000/Echo for the service.  
  
-   Configure the `Echo` service using a <xref:System.ServiceModel.WSHttpBinding> binding.  
  
```csharp  
Namespace Echo  
{  
   // Define the contract for the IEcho service   
   [ServiceContract]  
   public interface IEcho  
   {  
       [OperationContract]  
       String Hello(string name)  
   }  
  
   // Create an Echo service that implements IEcho contract  
   class Echo : IEcho  
   {  
      public string Hello(string name)  
      {  
         return "Hello" + name + "!";  
      }  
      public static void Main ()  
      {  
          //Specify the base address for Echo service.  
          Uri echoUri = new Uri("http://localhost:8000/");  
  
          //Create a ServiceHost for the Echo service.  
          ServiceHost serviceHost = new ServiceHost(typeof(Echo),echoUri);  
  
          // Use a predefined WSHttpBinding to configure the service.  
          WSHttpBinding binding = new WSHttpBinding();  
  
          // Add the endpoint for this service to the service host.  
          serviceHost.AddServiceEndpoint(  
             typeof(IEcho),   
             binding,   
             echoUri  
           );  
  
          // Open the service host to run it.  
          serviceHost.Open();  
     }  
  }  
}  
```  
  
```vb  
' Define the contract for the IEcho service  
    <ServiceContract()> _  
    Public Interface IEcho  
        <OperationContract()> _  
        Function Hello(ByVal name As String) As String  
    End Interface  
  
' Create an Echo service that implements IEcho contract  
    Public Class Echo   
        Implements IEcho  
        Public Function Hello(ByVal name As String) As String _  
 Implements ICalculator.Hello  
            Dim result As String = "Hello" + name + "!"  
            Return result  
        End Function  
  
' Specify the base address for Echo service.  
Dim echoUri As Uri = New Uri("http://localhost:8000/")  
  
' Create a ServiceHost for the Echo service.  
Dim svcHost As ServiceHost = New ServiceHost(GetType(HelloWorld), echoUri)  
  
' Use a predefined WSHttpBinding to configure the service.  
Dim binding As New WSHttpBinding()  
  
' Add the endpoint for this service to the service host.  
serviceHost.AddServiceEndpoint(GetType(IEcho), binding, echoUri)  
  
' Open the service host to run it.  
serviceHost.Open()  
```  
  
> [!NOTE]
>  The service host is created with a base address and then the rest of the address, relative to the base address, is specified as part of an endpoint. This partitioning of the address allows multiple endpoints to be defined more conveniently for services at a host.  
  
> [!NOTE]
>  Properties of <xref:System.ServiceModel.Description.ServiceDescription> in the service application must not be modified subsequent to the <xref:System.ServiceModel.Channels.CommunicationObject.OnOpening%2A> method on <xref:System.ServiceModel.ServiceHostBase>. Some members, such as the <xref:System.ServiceModel.ServiceHostBase.Credentials%2A> property and the `AddServiceEndpoint` methods on <xref:System.ServiceModel.ServiceHostBase> and <xref:System.ServiceModel.ServiceHost>, throw an exception if modified past that point. Others permit you to modify them, but the result is undefined.  
>   
>  Similarly, on the client the <xref:System.ServiceModel.Description.ServiceEndpoint> values must not be modified after the call to <xref:System.ServiceModel.Channels.CommunicationObject.OnOpening%2A> on the <xref:System.ServiceModel.ChannelFactory>. The <xref:System.ServiceModel.ChannelFactory.Credentials%2A> property throws an exception if modified past that point. The other client description values can be modified without error, but the result is undefined.  
>   
>  Whether for the service or client, it is recommended that you modify the description prior to calling <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A>.  
  
## Defining Endpoints in Configuration  
 When creating an application, you often want to defer decisions to the administrator who is deploying the application. For example, there is often no way of knowing in advance what a service address (a URI) will be. Instead of hard-coding an address, it is preferable to allow an administrator to do so after creating a service. This flexibility is accomplished through configuration. For details, see [Configuring Services](../../../docs/framework/wcf/configuring-services.md).  
  
> [!NOTE]
>  Use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) with the `/config:`*filename*`[,`*filename*`]` switch to quickly create configuration files.  
  
## Using Default Endpoints  
 If no endpoints are specified in code or in configuration then the runtime provides default endpoints by adding one default endpoint for each base address for each service contract implemented by the service. The base address can be specified in code or in configuration, and the default endpoints are added when <xref:System.ServiceModel.ICommunicationObject.Open> is called on the <xref:System.ServiceModel.ServiceHost>. This example is the same example from the previous section, but since no endpoints are specified, the default endpoints are added.  
  
```csharp  
Namespace Echo  
{  
   // Define the contract for the IEcho service   
   [ServiceContract]  
   Interface IEcho  
   {  
       [OperationContract]  
       String Hello(string name)  
   }  
  
   // Create an Echo service that implements IEcho contract  
   Class Echo : IEcho  
   {  
      Public string Hello(string name)  
      {  
         return "Hello" + name + "!";  
      }  
      static void Main ()  
      {  
          //Specify the base address for Echo service.  
          Uri echoUri = new Uri("http://localhost:8000/");  
  
          //Create a ServiceHost for the Echo service.  
          ServiceHost serviceHost = new ServiceHost(typeof(Echo),echoUri);  
  
          // Open the service host to run it. Default endpoints  
          // are added when the service is opened.  
          serviceHost.Open();  
     }  
  }  
}  
```  
  
```vb  
' Define the contract for the IEcho service  
    <ServiceContract()> _  
    Public Interface IEcho  
        <OperationContract()> _  
        Function Hello(ByVal name As String) As String  
    End Interface  
  
' Create an Echo service that implements IEcho contract  
    Public Class Echo   
        Implements IEcho  
        Public Function Hello(ByVal name As String) As String _  
 Implements ICalculator.Hello  
            Dim result As String = "Hello" + name + "!"  
            Return result  
        End Function  
  
' Specify the base address for Echo service.  
Dim echoUri As Uri = New Uri("http://localhost:8000/")  
  
' Open the service host to run it. Default endpoints  
' are added when the service is opened.  
serviceHost.Open()  
```  
  
 If endpoints are explicitly provided, the default endpoints can still be added by calling <xref:System.ServiceModel.ServiceHostBase.AddDefaultEndpoints%2A> on the <xref:System.ServiceModel.ServiceHost> before calling <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A>. [!INCLUDE[crabout](../../../includes/crabout-md.md)] default endpoints, see [Simplified Configuration](../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).  
  
## See Also  
 [Implementing Service Contracts](../../../docs/framework/wcf/implementing-service-contracts.md)
