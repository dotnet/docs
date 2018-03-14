---
title: "&lt;security&gt; of &lt;webHttpBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 727cf3d2-6f56-48ad-a59f-ba423edb9c83
caps.latest.revision: 9
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;security&gt; of &lt;webHttpBinding&gt;
Specifies the security requirements for an endpoint configured with a [\<wsHttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md).  
  
 \<system.ServiceModel>  
\<bindings>  
\<webHttpBinding>  
\<binding>  
\<security>  
  
## Syntax  
  
```xml  
<system.ServiceModel>  
    <bindings>  
        <webHttpBinding>  
            <binding name = "string">  
              <security mode="None/Transport/TransportCredentialOnly">  
                                    <transport clientCredentialType =   
                                     "Basic/Certificate/Digest/None/Ntlm/Windows"  
                                     proxyCredentialType="Basic/Digest/None/Ntlm/Windows"  
                                     realm="string" />  
              </security>  
        </webHttpBinding>  
    </bindings>  
</system.ServiceModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|mode|Specifies whether transport-level security or no security is used by an endpoint. The default is `None`. This attribute is of type <xref:System.ServiceModel.WebHttpSecurityMode>.|  
  
## Mode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|Security is disabled.|  
|Transport|Security is provided using HTTPS. The service needs to be configured with SSL certificates. The message is entirely secured using HTTPS and the service is authenticated by the client using the service’s SSL certificate. The client authentication is controlled through the `ClientCredentialType` attribute of the [\<transport>](../../../../../docs/framework/configure-apps/file-schema/wcf/transport-of-webhttpbinding.md).|  
|TransportCredentialOnly|This mode does not provide message integrity and confidentiality. It provides HTTP-based client authentication. This mode should be used with caution. It should be used in environments where the transport security is being provided by other means (such as IPSec) and only client authentication is provided by the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] infrastructure.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<transport>](../../../../../docs/framework/configure-apps/file-schema/wcf/transport-of-webhttpbinding.md)|Defines the transport security settings. This element corresponds to the <xref:System.ServiceModel.Configuration.HttpTransportSecurityElement> type.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<webHttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/webhttpbinding.md)|A binding element that is used to configure endpoints for [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] Web services that respond to HTTP requests instead of SOAP messages.|  
  
## See Also  
 <xref:System.ServiceModel.Configuration.WebHttpBindingElement>  
 <xref:System.ServiceModel.Configuration.WSHttpSecurityElement>  
 <xref:System.ServiceModel.WebHttpBinding.Security%2A>  
 <xref:System.ServiceModel.Configuration.WebHttpBindingElement.Security%2A>  
 <xref:System.ServiceModel.WebHttpSecurity>  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Selecting a Credential Type](../../../../../docs/framework/wcf/feature-details/selecting-a-credential-type.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)  
 [WCF Web HTTP Programming Model](../../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-model.md)
