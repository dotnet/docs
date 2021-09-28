---
description: "Learn more about: <windows> of <clientCredentials> Element"
title: "<windows> of <clientCredentials> Element"
ms.date: "03/30/2017"
ms.assetid: 793e41c2-31ea-4159-abbc-2123bf097233
---
# \<windows> of \<clientCredentials> Element

Specifies the settings for a Windows credential to be used to represent the client.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpointBehaviors>**](endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<clientCredentials>**](clientcredentials.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<windows>**  
  
## Syntax  
  
```xml  
<windows allowedImpersonationLevel="Identification/Impersonation/Delegation/Anonymous/None"
         allowNtlm="Boolean" />
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`allowedImpersonationLevel`|Sets the impersonation preference that the client communicates to the server. The impersonation mode that the client selects is not enforced on the server. Valid values include the following:<br /><br /> -   Identification: The server can get the identity and privileges of the client, but cannot impersonate the client.<br />-   Impersonation: The server can impersonate the client's security context on the local system.<br />-   Delegation: The server can impersonate the client's security context on remote systems.<br />-   Anonymous: The server cannot impersonate or identify the client.<br />-   None: An impersonation level is not assigned.<br /><br /> The default is Identification. This attribute is of type <xref:System.Security.Principal.TokenImpersonationLevel>.|  
|`allowNtlm`|Setting this property to `true` allows authentication to downgrade to NTLM if Kerberos is not available.<br /><br /> Setting this property to `false` causes Windows Communication Foundation (WCF) to make a best-effort to throw an exception if NTLM is used. Note that setting this property to `false` may not prevent NTLM credentials from being sent over the wire.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<clientCredentials>](clientcredentials.md)|Specifies the credentials used to authenticate the client to the service.|  
  
## See also

- <xref:System.ServiceModel.Configuration.WindowsClientElement>
- <xref:System.ServiceModel.Configuration.ClientCredentialsElement>
- <xref:System.ServiceModel.Description.ClientCredentials>
- <xref:System.ServiceModel.Configuration.ClientCredentialsElement.Windows%2A>
- <xref:System.ServiceModel.Description.ClientCredentials>
- <xref:System.ServiceModel.Description.ClientCredentials.Windows%2A>
- <xref:System.ServiceModel.Security.WindowsClientCredential>
- [Securing Clients](../../../wcf/securing-clients.md)
- [Working with Certificates](../../../wcf/feature-details/working-with-certificates.md)
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
