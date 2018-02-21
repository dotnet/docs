---
title: "&lt;transport&gt; of &lt;wsHttpBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 21e38acf-450a-4bda-82b6-de305e1f7cd8
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;transport&gt; of &lt;wsHttpBinding&gt;
Defines authentication settings for the HTTP transport.  
  
 \<system.serviceModel>  
\<bindings>  
\<wsHttpBinding>  
\<binding>  
\<security>  
\<transport>  
  
## Syntax  
  
```xml  
<wsHttpBinding>  
    <binding>  
        <security mode="None|Transport|TransportWithMessageCredential|TransportCredentialOnly">  
            <transport  
            clientCredentialType="Basic|Certificate|Digest|None|Ntlm|Windows"  
            proxyCredentialType="Basic|Digest|None|Ntlm|Windows"  
            realm="string" />  
                <extendedProtectionPolicy policyEnforcement="Never|WhenSupported|Always" protectionScenario="TransportSelected|TrustedProxy">  
                    <customServiceNames></customServiceNames>  
                </extendedProtecutionPolicy>  
            </transport>  
        </security>  
    </binding>  
</wsHttpBinding>  
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
|`realm`|A string that specifies the authentication realm for digest or basic authentication. The default is an empty string.<br /><br /> An authentication realm specifies at least the name of the host that performs the authentication. It can also specify a collection of users that has access. A user can query the authentication realm to ascertain which one of the several possible usernames and passwords can be used.|  
|`policyEnforcement`|This enumeration specifies when the <xref:System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy> should be enforced.<br /><br /> 1.  Never – The policy is never enforced (Extended Protection is disabled).<br />2.  WhenSupported – The policy is enforced only if the client supports Extended Protection.<br />3.  Always – The policy is always enforced. Clients which don’t support Extended Protection will fail to authenticate.|  
  
## clientCredentialType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`None`|Security is disabled.|  
|`Basic`|Uses basic authentication.|  
|`Digest`|Uses digest authentication.|  
|`Ntlm`|Uses NTLM authentication as a fallback with a Windows domain.|  
|`Windows`|Uses integrated Windows authentication.|  
|`Certificate`|Uses X.509 certificates to authenticate the client.|  
  
## proxyCredentialType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`None`|Security is disabled.|  
|`Basic`|Uses basic authentication.|  
|`Digest`|Uses digest authentication.|  
|`Ntlm`|Uses NTLM as a fallback with a Windows domain.|  
|`Windows`|Uses integrated Windows authentication.|  
|`Certificate`|Uses X.509 certificates to authenticate the client.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-wshttpbinding.md)|Represents the security capabilities of the [\<wsHttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md).|  
  
## See Also  
 <xref:System.ServiceModel.HttpTransportSecurity>  
 <xref:System.ServiceModel.WSHttpSecurity.Transport%2A>  
 <xref:System.ServiceModel.Configuration.WSHttpSecurityElement.Transport%2A>  
 <xref:System.ServiceModel.Configuration.HttpTransportSecurityElement>  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)
