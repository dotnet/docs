---
title: "<client>"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.ServiceModel/client"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#client"
ms.assetid: bf0f7031-76c8-4e7e-a6c6-9ad9119134be
---
# \<client>
The `client` element defines a list of endpoints that a client can connect to.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<client>**  
  
## Syntax  
  
```xml  
<system.serviceModel>
  <client>
    <endpoint>
    </endpoint>
    <metadata>
    </metadata>
  </client>
</system.serviceModel>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<endpoint>](endpoint-of-client.md)|Contains a collection of endpoint elements, that specify the endpoints that this client can connect to.|  
|[\<metadata>](metadata.md)|Contains settings for processing metadata.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.serviceModel>](system-servicemodel.md)|The root element of all Windows Communication Foundation (WCF) configuration elements.|  
  
## Remarks  
 The `client` section defines a list of endpoints that a client can connect to. Each endpoint listed in the client section defines its own binding, behavior, and contract. It is uniquely identified by the combination of the `name` and `contract` attributes. The client code specifies the `name` to connect to an endpoint for the service that the client implements. If the `name` attribute is omitted, the endpoint acts as the default endpoint for the contract it implements.  
  
 In addition, this section also specifies settings for processing metadata.  
  
## Example  
  
```xml  
<client>
  <endpoint address="/HelloWorld/"
            bindingConfiguration="usingDefaults"
            name="MyBinding"
            binding="customBinding"
            contract="HelloWorld">
    <addressProperties actingAs="http://www.microsoft.com/TestActor"
                       identityData="BasicReadWrite"
                       identityType="Spn"
                       isAddressPrivate="false">
  </endpoint>
</client>
```  
  
## See also

- <xref:System.ServiceModel.Configuration.ClientSection>
- <xref:System.ServiceModel.Configuration.MetadataElement>
- [WCF Client Configuration](../../../wcf/feature-details/client-configuration.md)
- [Clients](../../../wcf/feature-details/clients.md)
