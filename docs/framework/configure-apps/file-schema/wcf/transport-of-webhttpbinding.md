---
title: "&lt;transport&gt; of &lt;webHttpBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f150fb19-7de1-44af-81f4-86cad881cd05
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;transport&gt; of &lt;webHttpBinding&gt;
Defines the transport-level security settings for a service endpoint configured to receive HTTP requests.  
  
 \<system.ServiceModel>  
\<bindings>  
\<webHttpBinding>  
\<binding>  
\<security>  
\<transport>  
  
## Syntax  
  
```xml  
<webHttpBinding>  
    <binding>  
        <security  
        mode="None|Transport|Message|TransportWithMessageCredential|TransportCredentialOnly">  
            <transport clientCredentialType="None|Basic|Digest|Ntlm|Windows"  
             proxyCredentialType="None|Basic|Digest|Ntlm|Windows" realm="string" >  
                <extendedProtectionPolicy  
                     policyEnforcement="Never|WhenSupported|Always"  
                     protectionScenario="TransportSelected|TrustedProxy">  
                    <customServiceNames></customServiceNames>  
                        </extendedProtectionPolicy>  
            </transport>  
        </security>  
    </binding>  
</WebHttpBinding>  
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
|`Certificate`|Uses X.509 certificates to authenticate the client.|  
|`Digest`|Uses digest authentication.|  
|`Ntlm`|Uses NTLM authentication as a fallback with a Windows domain.|  
|`Windows`|Uses integrated Windows authentication.|  
  
## proxyCredentialType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`None`|Security is disabled.|  
|`Basic`|Uses basic authentication.|  
|`Digest`|Uses digest authentication.|  
|`Ntlm`|Uses NTLM as a fallback with a Windows domain.|  
|`Windows`|Uses integrated Windows authentication.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-webhttpbinding.md)|Represents the security capabilities of the [\<wsHttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md) element.|  
  
## See Also  
 <xref:System.ServiceModel.HttpTransportSecurity>  
 <xref:System.ServiceModel.Configuration.WebHttpSecurityElement.Transport%2A>  
 <xref:System.ServiceModel.WebHttpSecurity.Transport%2A>  
 <xref:System.ServiceModel.Configuration.HttpTransportSecurityElement>  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)  
 [WCF Web HTTP Programming Model](../../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-model.md)
