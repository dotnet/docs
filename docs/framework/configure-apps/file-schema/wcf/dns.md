---
description: "Learn more about: <dns>"
title: "<dns>"
ms.date: "03/30/2017"
ms.assetid: 81819dae-4825-43b7-bccd-f16d2d3d2f06
---
# \<dns>

Specifies the expected identity of the server. This identity is valid for X509 Certificate authentication mode if the server’s certificate contains a DNS with the same value. It is also valid for Windows authentication mode if the SPN has the same value.  
  
For more information about setting the element value, see [Service Identity and Authentication](../../../wcf/feature-details/service-identity-and-authentication.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<client>**](client.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpoint>**](endpoint-of-client.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<identity>**](identity.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<dns>**  
  
## Syntax  
  
```xml  
<dns value = "String" />
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|value|The DNS of the certificate. DNS is an industry-standard protocol used to locate computers on an IP-based network. Users can remember display names, such as `https://go.microsoft.com/fwlink/?prd=10929` or `https://go.microsoft.com/fwlink/?LinkID=96165`, easier than number-based addresses, such as 207.46.131.137.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<identity>](identity.md)|Specifies the identity of the service to be authenticated by the client.|  
  
## Example  

 The following configuration code specifies the DNS of an X.509 certificate that is used to authenticate a server.  
  
```xml  
<identity>
  <dns value = "www.cohowinery.com" />
</identity>
```  
  
## See also

- <xref:System.ServiceModel.Configuration.IdentityElement>
- <xref:System.ServiceModel.EndpointAddress>
- <xref:System.ServiceModel.EndpointAddress.Identity%2A>
- <xref:System.ServiceModel.DnsEndpointIdentity>
- [Service Identity and Authentication](../../../wcf/feature-details/service-identity-and-authentication.md)
- [\<identity>](identity.md)
