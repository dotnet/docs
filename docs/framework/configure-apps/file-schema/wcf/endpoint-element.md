---
title: "&lt;endpoint&gt; element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2fc8fedc-78d0-4e87-8142-fbfd26c15a4e
caps.latest.revision: 23
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;endpoint&gt; element
Specifies binding, contract, and address properties for a service endpoint, which is used to expose services.  
  
 \<system.ServiceModel>  
\<service>  
\<endpoint>  
  
## Syntax  
  
```xml  
<endpoint address="String"  
   behaviorConfiguration="String"  
   binding="String"  
   bindingConfiguration="String"  
   bindingName="String"  
   bindingNamespace="String"  
   contract="String"  
   endpointConfiguration="String"   isSystemEndpoint="Boolean"   kind="String"   listenUriMode="Explicit/Unique"  
   listenUri="Uri"  
</endpoint>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|address|A string that contains the address of the endpoint. The address can be specified as an absolute or relative address. If a relative address is provided, the host is expected to provide a base address appropriate for the transport scheme used in the binding. If an address is not configured, the base address is assumed to be the address for that endpoint.<br /><br /> The default is an empty string.|  
|behaviorConfiguration|A string that contains the name of the behavior to be used in the endpoint.|  
|binding|Required string attribute that specifies the type of binding to use. The type must have a registered configuration section in order to be referenced. The type is the registered by section name, rather than by the type name of the binding.|  
|bindingConfiguration|A string that specifies the binding name of the binding to use when the endpoint is instantiated. The binding name must be in scope at the point the endpoint is defined. The default is an empty string.<br /><br /> This attribute is used in conjunction with `binding` to reference a specific binding configuration in the configuration file. Set this attribute if you are attempting to use a custom binding. Otherwise, an exception may be thrown.|  
|bindingName|A string that specifies the unique qualified name of the binding for definition export through WSDL. The default is an empty string.|  
|bindingNamespace|A string that specifies the qualified name of the namespace of the binding for definition export through WSDL. The default is an empty string.|  
|contract|A string that indicates which contract this endpoint is exposing. The assembly must implement the contract type. If a service implementation implements a single contract type, then this property can be omitted. The default is an empty string.|  
|endpointConfiguration|A string that specifies the name of the standard endpoint that is set by the `kind` attribute, which references to the additional configuration information of this standard endpoint. The same name must be defined in the `<standardEndpoints>` section.|  
|isSystemEndpoint|A Boolean value that specifies whether an endpoint is an infrastructure endpoint.|  
|kind|A string that specifies the type of standard endpoint applied. The type must be registered in the `<extensions>` section or in machine.config. If nothing is specified, a common service endpoint is created.|  
|listenUriMode|Specifies how the transport treats the `ListenUri` provided for the service to listen on. Valid values are<br /><br /> -   Explicit<br />-   Unique<br /><br /> The default value is Explicit.|  
|listenUri|A string that specifies the URI at which the service endpoint listens. The default is an empty string.|  
|name|Optional attribute. A string that specifies the name the service endpoint. The default value is the concatenation of the binding name and the contract description name. Services may have multiple endpoints, so the endpoint’s `name` attribute is distinct from the name of the service.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<headers>](../../../../../docs/framework/configure-apps/file-schema/wcf/headers.md)|A collection of address headers.|  
|[\<identity>](../../../../../docs/framework/configure-apps/file-schema/wcf/identity.md)|An identity that enables the authentication of an endpoint by other endpoints exchanging messages with it.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<service>](../../../../../docs/framework/configure-apps/file-schema/wcf/service.md)|A configuration section that defines a list of endpoints that a client can connect to.|  
  
## Example  
 This is an example of a service endpoint configuration.  
  
```xml  
<endpoint   
    address="/HelloWorld/"  
    bindingConfiguration="usingDefaults"  
    bindingName="MyBinding"  
    binding="customBinding"  
    contract="HelloWorld">  
    <Headers>  
       <Region xmlns="http://tempuri.org/">EastCoast</Region>  
       <Member xmlns="http://tempuri.org/">Gold</Member>  
    </Headers>  
</endpoint>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ServiceEndpointElement>  
 <xref:System.ServiceModel.EndpointAddress>  
 <xref:System.ServiceModel.Description.ServiceEndpoint>  
 [Endpoints: Addresses, Bindings, and Contracts](../../../../../docs/framework/wcf/feature-details/endpoints-addresses-bindings-and-contracts.md)  
 [How to: Create a Service Endpoint in Configuration](../../../../../docs/framework/wcf/feature-details/how-to-create-a-service-endpoint-in-configuration.md)
