---
title: "What&#39;s New in Windows Communication Foundation 4.5"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WCF [WCF], what's new"
  - "Windows Communication Foundation [WCF], what's new"
ms.assetid: 7e93fe73-af93-46b5-9f63-32f761ee40cf
caps.latest.revision: 35
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# What&#39;s New in Windows Communication Foundation 4.5
This topic discusses features new to [!INCLUDE[indigo1](../../../includes/indigo1-md.md)].  
  
## WCF Simplification Features  
 Much work has been done to make WCF 4.5 applications easier to develop and maintain. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [WCF Simplification Features](../../../docs/framework/wcf/wcf-simplification-features.md).  
  
### Task-based Async Support  
 By default, Add Service Reference generates Task-returning async service operation methods. This is done for both synchronous and asynchronous methods. This allows you to call the service operations asynchronously using the new Task based async programming model. When you call the generated proxy method, WCF constructs a Task object to represent the asynchronous operation and returns that Task to you. The Task completes when the operation completes.  When implementing an async operation you can implement it as a task-based async operation. For more information see, [Synchronous and Asynchronous Operations](../../../docs/framework/wcf/synchronous-and-asynchronous-operations.md).  
  
### Simplified Generated Configuration Files  
 When you add a service reference in Visual Studio or use the SvcUtil.exe tool, a client configuration file is generated. In previous versions of WCF these configuration files contained the value of every binding property even if its value is the default value. In WCF 4.5 the generated configuration files contain only those binding properties that are set to a non-default value.  
  
 [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [WCF Simplification Features](../../../docs/framework/wcf/wcf-simplification-features.md)  
  
### Contract-First Development  
 WCF now has support for contract-first development. The svcutl.exe has a /serviceContract switch which allows you to generate service and data contracts from a WSDL document.  
  
### Add Service Reference from a Portable Subset Project  
 Portable subset projects enable .NET assembly programmers to maintain a single source tree and build system while still supporting multiple .NET platforms (desktop, Silverlight, Windows Phone, and XBOX). Portable subset projects only reference .NET portable libraries which are a .NET framework assembly that can be used on any .NET platform. The developer experience is the same as adding a service reference within any other WCF client application. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Add Service Reference in a Portable Subset Project](../../../docs/framework/wcf/add-service-reference-in-a-portable-subset-project.md).  
  
### ASP.NET Compatibility Mode Default Changed  
 WCF provides ASP.NET compatibility mode to grant developers full access to the features in the ASP.NET HTTP pipeline when writing WCF services. To use this mode, you must set the `aspNetCompatibilityEnabled` attribute to true in the [\<serviceHostingEnvironment>](../../../docs/framework/configure-apps/file-schema/wcf/servicehostingenvironment.md) section of web.config. Additionally, any service in this appDomain needs to have the `RequirementsMode` property on its <xref:System.ServiceModel.Activation.AspNetCompatibilityRequirementsAttribute> set to <xref:System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed> or <xref:System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Required>. By default <xref:System.ServiceModel.Activation.AspNetCompatibilityRequirementsAttribute> is now set to <xref:System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed>. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [What's New in Windows Communication Foundation](../../../docs/framework/wcf/whats-new.md) and [WCF Services and ASP.NET](../../../docs/framework/wcf/feature-details/wcf-services-and-aspnet.md).  
  
### New Transport Default Values  
 In order to simplify configuration a number of transport property default values have changed. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [WCF Simplification Features](../../../docs/framework/wcf/wcf-simplification-features.md).  
  
### XmlDictionaryReaderQuotas  
 <xref:System.Xml.XmlDictionaryReaderQuotas> contains configurable quota values for XML dictionary readers which limit the amount of memory utilized by an encoder while creating a message. While these quotas are configurable, the default values have changed to lessen the possibility that a developer will have to set them explicitly. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [WCF Simplification Features](../../../docs/framework/wcf/wcf-simplification-features.md).  
  
### WCF Configuration Validation  
 As part of the build process within Visual Studio, WCF configuration files are now validated for attributes defined within the project. A list of validation errors or warnings is displayed in Visual Studio if the validation fails.  
  
### XML Editor Tooltips  
 In order to help new and existing WCF service developers to configure their services, the Visual Studio XML editor now provides tooltips for every configuration element and its properties that is part of the service configuration file.  
  
## Streaming Improvements  
 Added support for true asynchronous streaming where the send side now does not block threads if the receive side is not reading or slow in reading thereby increasing scalability. Removed the limitation of message buffering when a client sends a streamed message to an IIS hosted WCF service. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [WCF Simplification Features](../../../docs/framework/wcf/wcf-simplification-features.md).  
  
## Simplifying Exposing an Endpoint Over HTTPS with IIS  
 An HTTPS protocol mapping has been added to simplify exposing an endpoint over HTTPS. To enable an HTTPS endpoint, ensure your website has an HTTPS binding and SSL certificate configured, and then simply enable HTTPS for the virtual directory that hosts the service. If metadata is enabled for the service, it will be exposed over HTTPS as well.  
  
## Generating a Single WSDL Document  
 Some third-party WSDL processing stacks are not able to process WSDL documents that have dependencies on other documents through a xsd:import.  WCF now allows you to specify that all WSDL information be returned in a single document. To request a single WSDL document append "?singleWSDL" to the URI when requesting metadata from the service.  
  
## WebSocket Support  
 WebSockets is a technology that provides true bidirectional communication over ports 80 and 443 with performance characteristics similar to TCP. Two new bindings have been added to support communication over a WebSocket transport. <xref:System.ServiceModel.NetHttpBinding> and <xref:System.ServiceModel.NetHttpsBinding>. For more information see: [System-Provided Bindings](../../../docs/framework/wcf/system-provided-bindings.md).  
  
## New Transport Default Values  
 The following table describes the settings that have changed and where to find additional information.  
  
|Property|On|New Default|For more information see|  
|--------------|--------|-----------------|------------------------------|  
|channelInitializationTimeout|<xref:System.ServiceModel.NetTcpBinding>|30 seconds|<xref:System.ServiceModel.Channels.ConnectionOrientedTransportBindingElement.ChannelInitializationTimeout%2A>|  
|listenBacklog|<xref:System.ServiceModel.NetTcpBinding>|12 * number of processors|<xref:System.ServiceModel.NetTcpBinding.ListenBacklog%2A>|  
|maxPendingAccepts|ConnectionOrientedTransportBindingElement<br /><br /> SMSvcHost.exe|2 * number of processors for transport<br /><br /> 4 \* number of processors for SMSvcHost.exe|<xref:System.ServiceModel.Channels.ConnectionOrientedTransportBindingElement.MaxPendingAccepts%2A> [Configuring the Net.TCP Port Sharing Service](http://msdn.microsoft.com/library/b6dd81fa-68b7-4e1b-868e-88e5901b7ea0)|  
|maxPendingConnections|ConnectionOrientedTransportBindingElement|12 * number of processors|<xref:System.ServiceModel.Channels.ConnectionOrientedTransportBindingElement.MaxPendingConnections%2A>|  
|receiveTimeout|SMSvcHost.exe|30 seconds|[Configuring the Net.TCP Port Sharing Service](http://msdn.microsoft.com/library/b6dd81fa-68b7-4e1b-868e-88e5901b7ea0)|  
  
## XML Editor Tooltips  
 In order to help new and existing WCF service developers to configure their services, the Visual Studio XML editor now provides tooltips for every configuration element and its properties that is part of the service configuration file.  
  
## Configuring WCF Services in Code  
 [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] allows developers to configure services using configuration files or code.  Configuration files are useful when a service needs to be configured after being deployed. When using configuration files, an IT professional only needs to update the configuration file, no recompilation is required. Configuration files, however, can be complex and difficult to maintain. There is no support for debugging configuration files and configuration elements are referenced by names which makes authoring configuration files error-prone and difficult. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] also allows you to configure services in code. In earlier versions of [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] (4.0 and earlier) configuring services in code was easy in self-hosted scenarios, the <xref:System.ServiceModel.ServiceHost> class allowed you to configure endpoints and behaviors prior to calling ServiceHost.Open. In web hosted scenarios, however, you don’t have access to the <xref:System.ServiceModel.ServiceHost> class. To configure a web hosted service you were required to create a `System.ServiceModel.ServiceHostFactory` that created the <xref:System.ServiceModel.Activation.ServiceHostFactory> and performed any needed configuration. Starting with .NET 4.5, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] provides an easier way to configure both self-hosted and web hosted services in code. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Configuring WCF Services in Code](../../../docs/framework/wcf/configuring-wcf-services-in-code.md).  
  
## ChannelFactory Caching  
 WCF client applications use the <xref:System.ServiceModel.ChannelFactory%601> class to create a communication channel with a WCF service.  Creating <xref:System.ServiceModel.ChannelFactory%601> instances incurs some overhead because it involves the following operations:  
  
1.  Constructing the <xref:System.ServiceModel.Description.ContractDescription> tree  
  
2.  Reflecting all of the required CLR types  
  
3.  Constructing the channel stack  
  
4.  Disposing of resources  
  
 To help minimize this overhead, WCF can cache channel factories when you are using a WCF client proxy. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Channel Factory and Caching](../../../docs/framework/wcf/feature-details/channel-factory-and-caching.md).  
  
## Compression and the Binary Encoder  
 Beginning with WCF 4.5 the WCF binary encoder adds support for compression. The type of compression is configured with the <xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement.CompressionFormat%2A> property. Both the client and the service must configure the <xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement.CompressionFormat%2A> property. Compression will work for HTTP, HTTPS, and TCP protocols. If a client specifies to use compression but the service does not support it a protocol exception is thrown indicating a protocol mismatch. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Choosing a Message Encoder](../../../docs/framework/wcf/feature-details/choosing-a-message-encoder.md)  
  
## UDP  
 Support has been added for a UDP transport which allows developers to write services that use "fire and forget" messaging. A client sends a message to a service and expects no response from the service.  
  
## Multiple Authentication Support  
 Support has been added to support multiple authentication modes, as supported by IIS, on a single WCF endpoint when using the HTTP transport and transport security. IIS allows you to enable multiple authentication modes on a virtual directory, this feature allows a single WCF endpoint to support the multiple authentication modes enabled for the virtual directory where the WCF service is hosted.  
  
## IDN Support  
 Support has been added to allow for WCF services with Internationalized Domain Names. For more information see [WCF and Internationalized Domain Names](../../../docs/framework/wcf/feature-details/wcf-and-internationalized-domain-names.md).  
  
## HttpClient  
 A new class called <xref:System.Net.Http.HttpClient> has been added to make working with HTTP requests much easier. For more info, see [Making apps social and connected with HTTP services](http://go.microsoft.com/fwlink/?LinkId=231886) and the [HTTP Client Sample](http://code.msdn.microsoft.com/windowsapps/HttpClient-sample-55700664).  
  
## Configuration Intellisense  
 Attribute values in configuration files for custom attributes defined in the project now support intellisense to facilitate working with configurations quickly and accurately.  
  
## Configuration tooltips  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] elements and attributes now have tooltips in the XML editor, to more easily and accurately identify the purpose of the element or attribute.  
  
## Paste Data as Classes  
 In a WCF project, data types defined in XML (such as are exposed in a service) can be pasted directly into a code page. The XML type will be pasted as a CLR type. See [Generating Data Type Classes from XML](../../../docs/framework/wcf/generating-data-type-classes-from-xml.md) for more details.  
  
## WebServiceHost and default endpoints  
 In Visual Studio 2010, WebServiceHost automatically created a default endpoint whether you explicitly specified an endpoint or not. In Visual Studio 2012 WebServiceHost will only create a default endpoint if no endpoints are explicitly added. If your client is expecting the default endpoint you can explicity add an endpoint and point the client to it. Alternatively, you can tell WCF to revert back to the previous behavior by adding the following setting to you application’s configuration file  
  
```xml  
<appSettings>  
    <add key="wcf:webservicehost:enableautomaticendpointscompatability" value="true"/>  
  </appSettings>  
```  
  
## IHttpCookieContainerManager  
 This interface, exposed by <xref:System.ServiceModel.Channels.IChannelFactory%601>, makes working with cookies on the client side much easier. When AllowCookies is set to true on the binding, you can access cookies by using the following code:  
  
```csharp  
IHttpCookieContainerManager cookieManager = factory.GetProperty<IHttpCookieContainerManager>();   
System.Net.CookieContainer container = cookieManager.CookieContainer;  
```  
  
 You can then retrieve or set the cookies from the <xref:System.Net.CookieContainer>. When AllowCookies is set to false, you can manually retrieve the cookies using <xref:System.ServiceModel.OperationContext> and send it in other requests using another <xref:System.ServiceModel.OperationContext> or message inspector. The IHttpCookieContainerManager interface allows you to authenticate a user with a service and use the authentication cookie returned by that service to authenticate with other services.
