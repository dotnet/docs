---
title: "&lt;security&gt; of &lt;basicHttpBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6432708d-5465-4bd9-bfc2-466742db99cb
caps.latest.revision: 16
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;security&gt; of &lt;basicHttpBinding&gt;
Defines the security capabilities of the [\<basicHttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/basichttpbinding.md).  
  
 \<system.ServiceModel>  
\<bindings>  
\<basicHttpBinding>  
\<binding>  
\<security>  
  
## Syntax  
  
```xml  
<security mode="Message/None/Transport/TransportWithCredential">  
   <transport  
      clientCredentialType="Basic/Certificate/Digest/None/Ntlm/Windows"  
      proxyCredentialType="Basic/Digest/None/Ntlm/Windows"  
      realm="string" />  
   <message  
      algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"  
            clientCredentialType="Certificate/IssuedToken/None/UserName/Windows" />  
</security>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|mode|Optional. Specifies the type of security that is used. The default is `None`. This attribute is of type <xref:System.ServiceModel.BasicHttpSecurityMode>.|  
  
## mode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|-   Messages are not secured during transfer.|  
|Transport|Security is provided using HTTPS transport. The SOAP messages are secured using HTTPS. The service is authenticated to the client using the service's X.509 certificate. The client is authenticated using the ClientCredentialType supplied. See the [\<transport>](../../../../../docs/framework/configure-apps/file-schema/wcf/transport-of-basichttpbinding.md).|  
|Message|Security is provided using SOAP message security. By default, the body is encrypted and signed. For this binding, the system requires that the server certificate be provided to the client out of band. The only valid `ClientCredentialType` for this binding is `Certificate`.|  
|TransportWithMessageCredential|Integrity, confidentiality and server authentication are provided by transport security. Client authentication is provided by means of SOAP message security. This mode is relevant when the user is authenticating using username/password and there is an existing HTTP deployment for securing message transfer.|  
|TransportCredentialOnly|This mode does not provide message integrity and confidentiality. It provides http-based client authentication. This mode should be used with caution. It should be used in environments where the transport security is being provided by other means (such as IPSec) and only client authentication is provided by the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] infrastructure.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<transport>](../../../../../docs/framework/configure-apps/file-schema/wcf/transport-of-basichttpbinding.md)|Defines the transport security settings for a basic HTTP service. This element corresponds to <xref:System.ServiceModel.HttpTransportSecurity>.|  
|[\<message>](../../../../../docs/framework/configure-apps/file-schema/wcf/message-of-basichttpbinding.md)|Defines the message security settings for a basic HTTP service. This element corresponds to <xref:System.ServiceModel.BasicHttpMessageSecurity>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|binding|The binding element of the [\<basicHttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/basichttpbinding.md).|  
  
## Remarks  
 By default, the SOAP message is not secured and the client is not authenticated. This element enables you to configure additional security settings for the `basicHttpBinding` element.  
  
## See Also  
 <xref:System.ServiceModel.BasicHttpBinding.Security%2A>  
 <xref:System.ServiceModel.Configuration.BasicHttpBindingElement.Security%2A>  
 <xref:System.ServiceModel.Configuration.BasicHttpSecurityElement>  
 <xref:System.ServiceModel.BasicHttpSecurity>  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Selecting a Credential Type](../../../../../docs/framework/wcf/feature-details/selecting-a-credential-type.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)
