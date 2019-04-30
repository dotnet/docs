---
title: "<add> of <protocolMapping>"
ms.date: "03/30/2017"
ms.assetid: 08e62249-1641-41d1-91b1-66d7b46244e4
---
# \<add> of \<protocolMapping>
Represents a default protocol mapping between a transport protocol scheme (e.g., http, net.tcp, net.pipe, etc.) and a Windows Communication Foundation (WCF) binding. When creating default endpoints at runtime, WCF looks at the configured mappings and decides on which binding to use for a particular based address.  
  
 \<system.serviceModel>  
\<protocolMapping>  
\<add>  
  
## Syntax  
  
```xml  
<protocolMapping>
  <add binding="String"
       bindingConfiguration="String"
       scheme="http/net.msmq/net.pipe/net.tcp" />
</protocolMapping>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Element|Description|  
|-------------|-----------------|  
|binding|A string that specifies the type of binding to be used for an endpoint during default endpoint creation.|  
|bindingConfiguration|A string that specifies the name of the binding configuration section to be referenced.|  
|scheme|The transport protocol scheme to be used for the default endpoint.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<protocolMapping>](../../../../../docs/framework/configure-apps/file-schema/wcf/protocolmapping.md)|Represents a configuration section for defining default protocol mappings between transport protocol schemes (e.g., http, net.tcp, net.pipe, etc.) and Windows Communication Foundation (WCF) bindings.|  
  
## Example  
 The following configuration example shows the default protocol mapping in the machine.config file. You can override this default mapping at the machine level by modifying the machine.config file. Or if you would only like to override it within the scope of an application, you can override this section within your application configuration file and change the mapping for individual protocol schemes.  
  
```xml  
<protocolMapping>
  <add scheme="http"
       binding="basicHttpBinding" />
  <add scheme="net.tcp"
       binding="netTcpBinding" />
  <add scheme="net.pipe"
       binding="netNamedPipeBinding" />
  <add scheme="net.msmq"
       binding="netMsmqBinding" />
</protocolMapping>
```  
  
## See also

- <xref:System.ServiceModel.Configuration.ProtocolMappingSection?displayProperty=nameWithType>
- <xref:System.ServiceModel.Configuration.ProtocolMappingElement?displayProperty=nameWithType>
