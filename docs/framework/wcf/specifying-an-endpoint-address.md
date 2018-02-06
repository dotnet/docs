---
title: "Specifying an Endpoint Address"
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
  - "endpoints [WCF], addressing"
ms.assetid: ac24f5ad-9558-4298-b168-c473c68e819b
caps.latest.revision: 41
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Specifying an Endpoint Address
All communication with a [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] service occurs through its endpoints. Each <xref:System.ServiceModel.Description.ServiceEndpoint> contains an <xref:System.ServiceModel.Description.ServiceEndpoint.Address%2A>, a <xref:System.ServiceModel.Description.ServiceEndpoint.Binding%2A>, and a <xref:System.ServiceModel.Description.ServiceEndpoint.Contract%2A>. The contract specifies which operations are available. The binding specifies how to communicate with the service, and the address specifies where to find the service. Every endpoint must have a unique address. The endpoint address is represented by the <xref:System.ServiceModel.EndpointAddress> class, which contains a Uniform Resource Identifier (URI) that represents the address of the service, an <xref:System.ServiceModel.EndpointAddress.Identity%2A>, which represents the security identity of the service, and a collection of optional <xref:System.ServiceModel.EndpointAddress.Headers%2A>. The optional headers provide more detailed addressing information to identify or interact with the endpoint. For example, headers can indicate how to process an incoming message, where the endpoint should send a reply message, or which instance of a service to use to process an incoming message from a particular user when multiple instances are available.  
  
## Definition of an Endpoint Address  
 In [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], an <xref:System.ServiceModel.EndpointAddress> models an endpoint reference (EPR) as defined in the WS-Addressing standard.  
  
 The address URI for most transports has four parts. For example, this URI, "http://www.fabrikam.com:322/mathservice.svc/secureEndpoint" has the following four parts:  
  
-   Scheme: http:  
  
-   Machine: www.fabrikam.com  
  
-   (Optional) Port: 322  
  
-   Path: /mathservice.svc/secureEndpoint  
  
 Part of the EPR model is that each endpoint reference can carry some reference parameters that add extra identifying information. In [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], these reference parameters are modeled as instances of the <xref:System.ServiceModel.Channels.AddressHeader> class.  
  
 The endpoint address for a service can be specified either imperatively by using code or declaratively through configuration. Defining endpoints in code is usually not practical because the bindings and addresses for a deployed service are typically different from those used while the service is being developed. Generally, it is more practical to define service endpoints using configuration rather than code. Keeping the binding and addressing information out of the code allows them to change without having to recompile and redeploy the application. If no endpoints are specified in code or in configuration, then the runtime adds one default endpoint on each base address for each contract implemented by the service.  
  
 There are two ways to specify endpoint addresses for a service in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)]. You can specify an absolute address for each endpoint associated with the service or you can provide a base address for the <xref:System.ServiceModel.ServiceHost> of a service and then specify an address for each endpoint associated with this service that is defined relative to this base address. You can use each of these procedures to specify the endpoint addresses for a service in either configuration or code. If you do not specify a relative address, the service uses the base address. You can also have multiple base addresses for a service, but each service is allowed only one base address for each transport. If you have multiple endpoints, each of which is configured with a different binding, their addresses must be unique. Endpoints that use the same binding but different contracts can use the same address.  
  
 When hosting with IIS, you do not manage the <xref:System.ServiceModel.ServiceHost> instance yourself. The base address is always the address specified in the .svc file for the service when hosting in IIS. So you must use relative endpoint addresses for IIS-hosted service endpoints. Supplying a fully-qualified endpoint address can lead to errors in the deployment of the service. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Deploying an Internet Information Services-Hosted WCF Service](../../../docs/framework/wcf/feature-details/deploying-an-internet-information-services-hosted-wcf-service.md).  
  
## Defining Endpoint Addresses in Configuration  
 To define an endpoint in a configuration file, use the [\<endpoint>](http://msdn.microsoft.com/library/13aa23b7-2f08-4add-8dbf-a99f8127c017) element.  
  
 [!code-xml[S_UEHelloWorld#5](../../../samples/snippets/common/VS_Snippets_CFX/s_uehelloworld/common/serviceapp2.config#5)]  
  
 When the <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A> method is called (that is, when the hosting application attempts to start the service), the system looks for a [\<service>](../../../docs/framework/configure-apps/file-schema/wcf/service.md) element with a name attribute that specifies "UE.Samples.HelloService". If the [\<service>](../../../docs/framework/configure-apps/file-schema/wcf/service.md) element is found, the system loads the specified class and creates endpoints using the endpoint definitions provided in the configuration file. This mechanism allows you to load and start a service with two lines of code while keeping binding and addressing information out of your code. The advantage of this approach is that these changes can be made without having to recompile or redeploy the application.  
  
 The optional headers are declared in a [\<headers>](../../../docs/framework/configure-apps/file-schema/wcf/headers-element.md). The following is an example of the elements used to specify endpoints for a service in a configuration file that distinguishes between two headers: "Gold" clients from http://tempuri1.org/ and "Standard" clients from http://tempuri2.org/. The client calling this service must have the appropriate [\<headers>](../../../docs/framework/configure-apps/file-schema/wcf/headers-element.md) in its configuration file.  
  
 [!code-xml[S_UEHelloWorld#1](../../../samples/snippets/common/VS_Snippets_CFX/s_uehelloworld/common/serviceapp.config#1)]  
  
 Headers can also be set on individual messages instead of all messages on an endpoint (as shown previously). This is done by using <xref:System.ServiceModel.OperationContextScope> to create a new context in a client application to add a custom header to the outgoing message, as shown in the following example.  
  
 [!code-csharp[OperationContextScope#4](../../../samples/snippets/csharp/VS_Snippets_CFX/operationcontextscope/cs/client.cs#4)]
 [!code-vb[OperationContextScope#4](../../../samples/snippets/visualbasic/VS_Snippets_CFX/operationcontextscope/vb/client.vb#4)]  
  
## Endpoint Address in Metadata  
 An endpoint address is represented in Web Services Description Language (WSDL) as a WS-Addressing `EndpointReference` (EPR) element inside the corresponding endpoint's `wsdl:port` element. The EPR contains the endpoint's address as well as any address properties. Note that the EPR inside `wsdl:port` replaces `soap:Address` as seen in the following example.  
  
  
  
## Defining Endpoint Addresses in Code  
 An endpoint address can be created in code with the <xref:System.ServiceModel.EndpointAddress> class. The URI specified for the endpoint address can be a fully-qualified path or a path that is relative to the service's base address. The following code illustrates how to create an instance of the <xref:System.ServiceModel.EndpointAddress> class and add it to the <xref:System.ServiceModel.ServiceHost> instance that is hosting the service.  
  
 The following example demonstrates how to specify the full endpoint address in code.  
  
 [!code-csharp[S_UEHelloWorld#2](../../../samples/snippets/csharp/VS_Snippets_CFX/s_uehelloworld/cs/snippet.cs#2)]  
  
 The following example demonstrates how to add a relative address ("MyService") to the base address of the service host.  
  
 [!code-csharp[S_UEHelloWorld#3](../../../samples/snippets/csharp/VS_Snippets_CFX/s_uehelloworld/cs/snippet.cs#3)]  
  
> [!NOTE]
>  Properties of the <xref:System.ServiceModel.Description.ServiceDescription> in the service application must not be modified subsequent to the <xref:System.ServiceModel.Channels.CommunicationObject.OnOpening%2A> method on <xref:System.ServiceModel.ServiceHostBase>. Some members, such as the <xref:System.ServiceModel.ServiceHostBase.Credentials%2A> property and the `AddServiceEndpoint` methods on <xref:System.ServiceModel.ServiceHostBase> and <xref:System.ServiceModel.ServiceHost>, throw an exception if modified after that point. Others permit you to modify them, but the result is undefined.  
>   
>  Similarly, on the client the <xref:System.ServiceModel.Description.ServiceEndpoint> values must not be modified after the call to <xref:System.ServiceModel.Channels.CommunicationObject.OnOpening%2A> on the <xref:System.ServiceModel.ChannelFactory>. The <xref:System.ServiceModel.ChannelFactory.Credentials%2A> property throws an exception if modified after that point. The other client description values can be modified without error, but the result is undefined.  
>   
>  Whether for the service or client, it is recommended that you modify the description prior to calling <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A>.  
  
## Using Default Endpoints  
 If no endpoints are specified in code or in configuration then the runtime provides default endpoints by adding one default endpoint on each base address for each service contract implemented by the service. The base address can be specified in code or in configuration, and the default endpoints are added when <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A> is called on the <xref:System.ServiceModel.ServiceHost>.  
  
 If endpoints are explicitly provided, the default endpoints can still be added by calling <xref:System.ServiceModel.ServiceHostBase.AddDefaultEndpoints%2A> on the <xref:System.ServiceModel.ServiceHost> before calling <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A>. [!INCLUDE[crabout](../../../includes/crabout-md.md)] default endpoints, bindings, and behaviors, see [Simplified Configuration](../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).  
  
## See Also  
 <xref:System.ServiceModel.EndpointAddress>  
 [Service Identity and Authentication](../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md)  
 [Endpoint Creation Overview](../../../docs/framework/wcf/endpoint-creation-overview.md)  
 [Hosting](../../../docs/framework/wcf/feature-details/hosting.md)
