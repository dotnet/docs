---
description: "Learn more about: <rsa>"
title: "<rsa>"
ms.date: "03/30/2017"
ms.assetid: ae1f2267-e40d-42ff-8abf-06ab7067bdb9
---
# \<rsa>

A secure WCF client that connects to an endpoint with this identity verifies that the claims presented by the server contain a claim that contains the RSA public key used to construct this identity.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<client>**](client.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpoint>**](endpoint-of-client.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<identity>**](identity.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<rsa>**  
  
## Syntax  
  
```xml  
<rsa value="String" />
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|value|Optional String. The RSA public key value to be compared with on the client.|  
  
### Child Elements  

 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<identity>](identity.md)|Specifies the identity of the service to be authenticated by the client.|  
  
## Remarks  

 A RSA check enables you to specifically restrict authentication to a single certificate based upon its RSA key or generated your own RSA key value. This enables stricter authentication of a specific RSA key at the expense of the service no longer working with existing clients if the RSA key value is changed.  
  
 For more information about using identity to validate a service to a client, see [Service Identity and Authentication](../../../wcf/feature-details/service-identity-and-authentication.md).  
  
## Example  

 The following configuration code specifies the public key value of an X.509 certificate that is used to authenticate a server.  
  
```xml  
<identity>
  <rsa value="0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000" />
</identity>
```  
  
## See also

- <xref:System.ServiceModel.Configuration.IdentityElement>
- <xref:System.ServiceModel.EndpointAddress>
- <xref:System.ServiceModel.EndpointAddress.Identity%2A>
- <xref:System.ServiceModel.RsaEndpointIdentity>
- [Service Identity and Authentication](../../../wcf/feature-details/service-identity-and-authentication.md)
- [\<identity>](identity.md)
