---
description: "Learn more about: <httpDigest> Element"
title: "<httpDigest> Element"
ms.date: "03/30/2017"
ms.assetid: 3da4f276-dfd9-4247-8c07-01d83618727c
---
# \<httpDigest> Element

Specifies a digest type credential used when authenticating the client to a service.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpointBehaviors>**](endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<clientCredentials>**](clientcredentials.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<httpDigest>**  
  
## Syntax  
  
```xml  
<httpDigest impersonationLevel="Identification/Impersonation/Delegation/Anonymous/None" />
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`impersonationLevel`|Sets the impersonation preference that the client communicates to the server. The impersonation mode that the client selects is not enforced on the server. Valid values include the following:<br /><br /> -   Identification: The server can get the identity and privileges of the client, but cannot impersonate the client.<br />-   Impersonation: The server can impersonate the client's security context on the local system.<br />-   Delegation: The server can impersonate the client's security context on remote systems.<br />-   Anonymous: The server cannot impersonate or identify the client.<br />-   None: An impersonation level is not assigned.<br /><br /> The default is Identification. This attribute is of type <xref:System.Security.Principal.TokenImpersonationLevel>.|  
  
### Child Elements  

 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<clientCredentials>](clientcredentials.md)|Specifies the credentials used to authenticate a client to a service.|  
  
## Remarks  

 A digest is a hash determined by using an algorithm and a set of inputs. The authenticator and the authenticated agree upon an algorithm and exchange the data used as inputs. The client can calculate the hash and send it to the service. The service also calculates the hash and compares the values. A match validates the client.  
  
 This feature must be enabled with Active Directory on Windows and Internet Information Services (IIS). For more information, see [Digest Authentication in IIS 6.0](/previous-versions/windows/it-pro/windows-server-2003/cc782661(v=ws.10)).  
  
## See also

- <xref:System.ServiceModel.Configuration.ClientCredentialsElement>
- <xref:System.ServiceModel.Configuration.ClientCredentialsElement.HttpDigest%2A>
- <xref:System.ServiceModel.Description.ClientCredentials>
- <xref:System.ServiceModel.Description.ClientCredentials.HttpDigest%2A>
- <xref:System.ServiceModel.Configuration.HttpDigestClientElement>
- <xref:System.ServiceModel.Security.HttpDigestClientCredential>
- [Security Behaviors](../../../wcf/feature-details/security-behaviors-in-wcf.md)
- [Securing Clients](../../../wcf/securing-clients.md)
- [Working with Certificates](../../../wcf/feature-details/working-with-certificates.md)
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
