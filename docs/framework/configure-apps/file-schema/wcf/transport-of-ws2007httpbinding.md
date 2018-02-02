---
title: "&lt;transport&gt; of &lt;ws2007HttpBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 692befa3-8b0b-4ec5-b601-755874e98eb0
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;transport&gt; of &lt;ws2007HttpBinding&gt;
Defines authentication settings for the HTTP transport.  
  
 \<system.serviceModel>  
\<bindings>  
\<ws2007HttpBinding>  
\<binding>  
\<security>  
\<transport>  
  
## Syntax  
  
```  
transport clientCredentialType =   
       "Basic/Certificate/Digest/None/Ntlm/Windows"  
       proxyCredentialType="Basic/Digest/None/Ntlm/Windows"  
       realm="string"   
```  
  
## Type  
 <xref:System.ServiceModel.HttpTransportSecurity>  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`clientCredentialType`|Specifies the credential used to authenticate the client to the service. This attribute is of type <xref:System.ServiceModel.HttpClientCredentialType>.|  
|`proxyCredentialType`|Specifies the credential used to authenticate the client to a domain proxy. This attribute is of type <xref:System.ServiceModel.HttpProxyCredentialType>.|  
|`realm`|The authentication realm for digest or basic authentication. The default is an empty string.<br /><br /> An authentication realm specifies at least the name of the host that performs the authentication. It can also specify a collection of users who have access. A user can query the authentication realm to determine which one of the several possible usernames and passwords can be used.|  
  
## clientCredentialType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|Security is disabled.|  
|Basic|Uses basic authentication.|  
|Digest|Uses digest authentication.|  
|Ntlm|Uses NTLM authentication as a fallback with a Windows domain.|  
|Windows|Uses integrated Windows authentication.|  
|Certificate|Uses X.509 certificates to authenticate the client.|  
  
## proxyCredentialType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|Security is disabled.|  
|Basic|Uses basic authentication.|  
|Digest|Uses digest authentication.|  
|Ntlm|Uses NTLM as a fallback with a Windows domain.|  
|Windows|Uses integrated Windows authentication.|  
|Certificate|Uses X.509 certificates to authenticate the client.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-ws2007httpbinding.md)|Represents the security capabilities of the [\<ws2007HttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/ws2007httpbinding.md) element.|  
  
## See Also  
 <xref:System.ServiceModel.HttpTransportSecurity>  
 <xref:System.ServiceModel.Configuration.BasicHttpSecurityElement.Transport%2A>  
 <xref:System.ServiceModel.WSHttpSecurity.Transport%2A>  
 <xref:System.ServiceModel.Configuration.WSHttpTransportSecurityElement>  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)
