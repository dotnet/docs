---
title: "Endpoint Addresses"
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
  - "addresses [WCF]"
  - "Windows Communication Foundation [WCF], addresses"
  - "WCF [WCF], addresses"
ms.assetid: 13f269e3-ebb1-433c-86cf-54fbd866a627
caps.latest.revision: 18
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Endpoint Addresses
Every endpoint has an address associated with it, which is used to locate and identify the endpoint. This address consists primarily of a Uniform Resource Identifier (URI), which specifies the location of the endpoint. The endpoint address is represented in the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] programming model by the <xref:System.ServiceModel.EndpointAddress> class, which contains an optional <xref:System.ServiceModel.EndpointAddress.Identity%2A> property that enables the authentication of the endpoint by other endpoints that exchange messages with it, and a set of optional <xref:System.ServiceModel.EndpointAddress.Headers%2A> properties, which define any other SOAP headers required to reach the service. The optional headers provide additional and more detailed addressing information to identify or interact with the service endpoint. The address of an endpoint is represented on the wire as a WS-Addressing endpoint reference (EPR).  
  
## URI Structure of an Address  
 The address URI for most transports has four parts. For example, the four parts of the URI http://www.fabrikam.com:322/mathservice.svc/secureEndpoint can be itemized as follows:  
  
-   Scheme: http:  
  
-   Machine: www.fabrikam.com  
  
-   (optional) Port: 322  
  
-   Path: /mathservice.svc/secureEndpoint  
  
## Defining an Address for a Service  
 The endpoint address for a service can be specified either imperatively using code or declaratively through configuration. Defining endpoints in code is usually not practical because the bindings and addresses for a deployed service are typically different from those used while the service is being developed. Generally, it is more practical to define service endpoints using configuration rather than code. Keeping the binding and addressing information out of the code allows them to change without having to recompile or redeploy the application.  
  
### Defining an Address in Configuration  
 To define an endpoint in a configuration file, use the [\<endpoint>](../../../../docs/framework/configure-apps/file-schema/wcf/endpoint-element.md) element. For details and an example, see [Specifying an Endpoint Address](../../../../docs/framework/wcf/specifying-an-endpoint-address.md).  
  
### Defining an Address in Code  
 An endpoint address can be created in code with the <xref:System.ServiceModel.EndpointAddress> class. For details and an example, see [Specifying an Endpoint Address](../../../../docs/framework/wcf/specifying-an-endpoint-address.md).  
  
### Endpoints in WSDL  
 An endpoint address can also be represented in WSDL as a WS-Addressing EPR element inside the corresponding endpoint's `wsdl:port` element. The EPR contains the endpoint's address as well as any address properties. For details and an example, see [Specifying an Endpoint Address](../../../../docs/framework/wcf/specifying-an-endpoint-address.md).  
  
## Multiple IIS Binding Support in .NET Framework 3.5  
 Internet service providers often host many applications on the same server and site to increase the site density and lower total cost of ownership. These applications are typically bound to different base addresses. An Internet Information Services (IIS) Web site can contain multiple applications. The applications in a site can be accessed through one or more IIS bindings.  
  
 IIS bindings provide two pieces of information: a binding protocol, and binding information. The binding protocol defines the scheme over which communication occurs, and binding information is the information used to access the site.  
  
 The following example shows the components that can be present in an IIS binding:  
  
-   Binding protocol: HTTP  
  
-   Binding Information: IP Address, Port, Host header  
  
 IIS can specify multiple bindings for each site, which results in multiple base addresses for each scheme. Prior to [!INCLUDE[netfx35_short](../../../../includes/netfx35-short-md.md)], [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] did not support multiple addresses for a schema and, if they were specified, threw a <xref:System.ArgumentException> during activation.  
  
 The [!INCLUDE[netfx35_short](../../../../includes/netfx35-short-md.md)] enables Internet service providers to host multiple applications with different base addresses for the same scheme on the same site.  
  
 For example, a site could contain the following base addresses:  
  
-   http://payroll.myorg.com/Service.svc  
  
-   http://shipping.myorg.com/Service.svc  
  
 With [!INCLUDE[netfx35_short](../../../../includes/netfx35-short-md.md)], you specify a prefix filter at the AppDomain level in the configuration file. You do this with the [\<baseAddressPrefixFilters>](../../../../docs/framework/configure-apps/file-schema/wcf/baseaddressprefixfilters.md) element, which contains a list of prefixes. The incoming base addresses, supplied by IIS, are filtered based on the optional prefix list. By default, when a prefix is not specified, all addresses are passed through. Specifying the prefix results in only the matching base address for that scheme to be passed through.  
  
 The following is an example of configuration code that uses the prefix filters.  
  
```xml  
<system.serviceModel>  
  <serviceHostingEnvironment>  
     <baseAddressPrefixFilters>  
        <add prefix="net.tcp://payroll.myorg.com:8000"/>  
        <add prefix="http://shipping.myorg.com:8000"/>  
    </baseAddressPrefixFilters>  
  </serviceHostingEnvironment>  
</system.serviceModel>  
```  
  
 In the preceding example, net.tcp://payroll.myorg.com:8000 and http://shipping.myorg.com:8000 are the only base addresses, for their respective schemes, which are passed through.  
  
 The `baseAddressPrefixFilter` does not support wildcards.  
  
 The base addresses supplied by IIS may have addresses bound to other schemes not present in `baseAddressPrefixFilters` list. These addresses are not filtered out.  
  
## Multiple IIS Binding Support in .NET Framework 4 and later  
 Starting in .NET 4, you can enable support for multiple bindings in IIS without having to pick a single base address, by setting <xref:System.ServiceModel.ServiceHostingEnvironment>’s <xref:System.ServiceModel.ServiceHostingEnvironment.MultipleSiteBindingsEnabled%2A> setting to true. This support is limited to HTTP protocol schemes.  
  
 The following is an example of configuration code that uses multipleSiteBindingsEnabled on [\<serviceHostingEnvironment>](../../../../docs/framework/configure-apps/file-schema/wcf/servicehostingenvironment.md).  
  
```xml  
<system.serviceModel>  
  <serviceHostingEnvironment multipleSiteBindingsEnabled="true" >  
  </serviceHostingEnvironment>  
</system.serviceModel>  
```  
  
 Any baseAddressPrefixFilters settings are ignored, for both HTTP and non-HTTP protocols, when multiple site bindings are enabled using this setting.  
  
 For details and examples, see [Supporting Multiple IIS Site Bindings](../../../../docs/framework/wcf/feature-details/supporting-multiple-iis-site-bindings.md) and <xref:System.ServiceModel.ServiceHostingEnvironment.MultipleSiteBindingsEnabled%2A>.  
  
## Extending Addressing in WCF Services  
 The default addressing model of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services uses the endpoint address URI for the following purposes:  
  
-   To specify the service listening address, the location at which the endpoint listens for messages,  
  
-   To specify the SOAP address filter, the address an endpoint expects as a SOAP header.  
  
 The values for each of these purposes can be specified separately, allowing several extensions of addressing that cover useful scenarios:  
  
-   SOAP intermediaries: a message sent by a client traverses one or more additional services that process the message before it reaches its final destination. SOAP intermediaries can perform various tasks, such as caching, routing, load-balancing, or schema validation on the messages. This scenario is accomplished by sending messages to a separate physical address (`via`) that targets the intermediary rather than just to a logical address (`wsa:To`) that targets the ultimate destination.  
  
-   The listening address of the endpoint is a private URI and is set to a different value than its `listenURI` property.  
  
 The transport address that the `via` specifies is the location to which a message should initially be sent on its way to some other remote address specified by the `to` parameter at which the service is located. In most Internet scenarios, the `via` URI is the same as the <xref:System.ServiceModel.EndpointAddress.Uri%2A> property of the final `to` address of the service. You only distinguish between these two addresses when you must do manual routing.  
  
### Addressing Headers  
 An endpoint can be addressed by one or more SOAP headers in addition to its basic URI. One set of scenarios where this is useful is a set of SOAP intermediary scenarios where an endpoint requires clients of that endpoint to include SOAP headers targeted at intermediaries.  
  
 You can define custom address headers in two ways—by using either code or configuration:  
  
-   In code, create custom address headers by using the <xref:System.ServiceModel.Channels.AddressHeader> class, and then used in the construction of an <xref:System.ServiceModel.EndpointAddress>.  
  
-   In configuration, custom [\<headers>](../../../../docs/framework/configure-apps/file-schema/wcf/headers.md) are specified as children of the [\<endpoint>](http://msdn.microsoft.com/library/13aa23b7-2f08-4add-8dbf-a99f8127c017) element.  
  
 Configuration is generally preferable to code, as it allows you to change the headers after deployment.  
  
### Custom Listening Addresses  
 You can set the listening address to a different value than the endpoint’s URI. This is useful in intermediary scenarios where the SOAP address to be exposed is that of a public SOAP intermediary, whereas the address where the endpoint actually listens is a private network address.  
  
 You can specify a custom listening address by using either code or configuration:  
  
-   In code, specify a custom listening address by adding a <xref:System.ServiceModel.Description.ClientViaBehavior> class to the endpoint’s behavior collection.  
  
-   In configuration, specify a custom listening address with the `ListenUri` attribute of the service [\<endpoint>](http://msdn.microsoft.com/library/13aa23b7-2f08-4add-8dbf-a99f8127c017) element.  
  
### Custom SOAP Address Filter  
 The <xref:System.ServiceModel.EndpointAddress.Uri%2A> is used in conjunction with any <xref:System.ServiceModel.EndpointAddress.Headers%2A> property to define an endpoint’s SOAP address filter (<xref:System.ServiceModel.Dispatcher.EndpointDispatcher.AddressFilter%2A>). By default, this filter verifies that an incoming message has a `To` message header that matches the endpoint’s URI and that all of the required endpoint headers are present in the message.  
  
 In some scenarios, an endpoint receives all messages that arrive on the underlying transport, and not just those with the appropriate `To` header. To enable this, the user can use the <xref:System.ServiceModel.Dispatcher.MatchAllMessageFilter> class.  
  
## See Also  
 [Specifying an Endpoint Address](../../../../docs/framework/wcf/specifying-an-endpoint-address.md)  
 [Service Identity and Authentication](../../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md)
