---
title: "&lt;endpoint&gt; of &lt;client&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: de6238ae-bbf8-48e9-a1b5-e24c0bea8afa
caps.latest.revision: 22
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;endpoint&gt; of &lt;client&gt;
Specifies contract, binding, and address properties of the channel endpoint, which is used by clients to connect to service endpoints on the server.  
  
 \<system.ServiceModel>  
\<client>  
\<endpoint>  
  
## Syntax  
  
```xml  
<endpoint address="String"  
   behaviorConfiguration="String"  
   binding="String"  
   bindingConfiguration="String"  
   contract="String"   endpointConfiguration="String"   kind="String"  
   name="String"  
</endpoint>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|address|Required string attribute.<br /><br /> Specifies the address of the endpoint. The default is an empty string. The address must be an absolute URI.|  
|behaviorConfiguration|A string that contains the behavior name of the behavior to be used to instantiate the endpoint. The behavior name must be in scope at the point the service is defined. The default is an empty string.|  
|binding|Required string attribute.<br /><br /> A string that indicates the type of binding to use. The type must have a registered configuration section in order to be referenced. The type is registered by section name, instead of by the type name of the binding.|  
|bindingConfiguration|Optional. A string that contains the name of the binding configuration to be used when the endpoint is instantiated. The binding configuration must be in scope at the point the endpoint is defined. The default is an empty string.<br /><br /> This attribute is used in conjunction with `binding` to reference a specific binding configuration in the configuration file. Set this attribute if you are attempting to use a custom binding. Otherwise, an exception may be thrown.|  
|contract|Required string attribute.<br /><br /> A string that indicates which contract this endpoint is exposing. The assembly must implement the contract type.|  
|endpointConfiguration|A string that specifies the name of the standard endpoint that is set by the `kind` attribute, which references to the additional configuration information of this standard endpoint. The same name must be defined in the `<standardEndpoints>` section.|  
|kind|A string that specifies the type of standard endpoint applied. The type must be registered in the `<extensions>` section or in machine.config. If nothing is specified, a common channel endpoint is created.|  
|name|Optional string attribute. This attribute uniquely identifies an endpoint for a given contract. You can define multiple clients for a given Contract type. Each definition must be differentiated by a unique configuration name. If this attribute is omitted, the corresponding endpoint is used as the default endpoint associated with the specified Contract type. The default is an empty string.<br /><br /> The `name` attribute of a binding is used for definition export through WSDL.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<headers>](../../../../../docs/framework/configure-apps/file-schema/wcf/headers.md)|A collection of address headers.|  
|[\<identity>](../../../../../docs/framework/configure-apps/file-schema/wcf/identity.md)|An identity that enables the authentication of an endpoint by other endpoints exchanging messages with it.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<client>](../../../../../docs/framework/configure-apps/file-schema/wcf/client.md)|A configuration section that defines a list of endpoints that a client can connect to.|  
  
## Example  
 This is an example of a channel endpoint configuration.  
  
```xml  
<endpoint address="/HelloWorld/"  
    bindingConfiguration="usingDefaults"  
    name="MyBinding"  
    binding="customBinding"  
    contract="HelloWorld">  
</endpoint>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ChannelEndpointElement>  
 <xref:System.ServiceModel.Configuration.ClientSection>  
 <xref:System.ServiceModel.Configuration.ChannelEndpointElementCollection>  
 <xref:System.ServiceModel.Configuration.ClientSection.Endpoints%2A>  
 <xref:System.ServiceModel.Configuration.ChannelEndpointElement>  
 [WCF Client Configuration](../../../../../docs/framework/wcf/feature-details/client-configuration.md)  
 [Clients](../../../../../docs/framework/wcf/feature-details/clients.md)
