---
title: "<headers>"
ms.date: "03/30/2017"
ms.assetid: c79b897d-8ea3-40b5-a8b6-2471941f7ed3
---
# \<headers>
An endpoint can be addressed by one or more SOAP headers in addition to its basic URI. One set of scenarios where this is useful is a set of SOAP intermediary scenarios where an endpoint requires clients of that endpoint to include SOAP headers targeted at intermediaries. This configuration element can be used to define such custom address headers. Entries in the endpoint header collection are user-defined XML elements. Each element has to be well-formed XML.  
  
 \<system.ServiceModel>  
\<client>  
\<endpoint>  
  
## Syntax  
  
```xml  
<headers>
  <region xmlns="Uri">"String"</region>
  <member xmlns="Uri">"String"</member>
</headers>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
 User-defined XML elements.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<endpoint>](endpoint-of-client.md)|Configures different types of endpoints.|  
  
## Remarks  
 The optional headers provide more detailed addressing information to identify or interact with the endpoint. For example, headers can indicate how to process an incoming message, where the endpoint should send a reply message, or which instance of a service to use to process an incoming message from a particular user when multiple instances are available.  
  
## See also

- <xref:System.ServiceModel.Configuration.IdentityElement>
- <xref:System.ServiceModel.EndpointAddress>
- <xref:System.ServiceModel.EndpointAddress.Headers%2A>
- <xref:System.ServiceModel.Channels.AddressHeaderCollection>
- [Endpoints: Addresses, Bindings, and Contracts](../../../wcf/feature-details/endpoints-addresses-bindings-and-contracts.md)
