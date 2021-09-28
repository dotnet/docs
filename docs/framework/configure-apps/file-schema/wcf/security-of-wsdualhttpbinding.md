---
description: "Learn more about: <security> of <wsDualHttpBinding>"
title: "<security> of <wsDualHttpBinding>"
ms.date: "03/30/2017"
ms.assetid: 869c05e7-4ebe-467d-95ab-c8f8de4e6b9e
---
# \<security> of \<wsDualHttpBinding>

Defines the security capabilities of the [\<wsDualHttpBinding>](wsdualhttpbinding.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<wsDualHttpBinding>**](wsdualhttpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<security>**  
  
## Syntax  
  
```xml  
<security mode="Message/None">
  <message algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"
           clientCredentialType="Certificate/IssuedToken/None/UserName/Windows"
           negotiateServiceCredential="Boolean"/>
</security>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|mode|-   Optional. Specifies the type of security that is applied. The default value is `Message`. This attribute is of type <xref:System.ServiceModel.WSDualHttpSecurityMode>.|  
  
## Mode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|Security is disabled.|  
|Message|Security is provided using SOAP message security.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<message>](message-of-wsdualhttpbinding.md)|Defines the settings for the message-level security. This element is of type <xref:System.ServiceModel.MessageSecurityOverHttp>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](bindings.md)|Defines all binding capabilities of the [\<wsDualHttpBinding>](wsdualhttpbinding.md).|  
  
## Remarks  

 A dual binding exposes the IP address of the client to the service. The client should use security to ensure that it only connects to services it trusts.  
  
## See also

- <xref:System.ServiceModel.WSDualHttpSecurity>
- <xref:System.ServiceModel.BasicHttpSecurity>
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](bindings.md)
