---
title: "<security> of <webHttpBinding>"
ms.date: "03/30/2017"
ms.assetid: 727cf3d2-6f56-48ad-a59f-ba423edb9c83
---
# \<security> of \<webHttpBinding>
Specifies the security requirements for an endpoint configured with a [\<webHttpBinding>](webhttpbinding.md).  
  
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
      <binding name = "String">
        <security mode="None/Transport/TransportCredentialOnly">
          <transport clientCredentialType="Basic/Certificate/Digest/None/Ntlm/Windows"
                     proxyCredentialType="Basic/Digest/None/Ntlm/Windows"
                     realm="String" />
        </security>
      </binding>
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
|Transport|Security is provided using HTTPS. The service needs to be configured with SSL certificates. The message is entirely secured using HTTPS and the service is authenticated by the client using the service’s SSL certificate. The client authentication is controlled through the `ClientCredentialType` attribute of the [\<transport>](transport-of-webhttpbinding.md).|  
|TransportCredentialOnly|This mode does not provide message integrity and confidentiality. It provides HTTP-based client authentication. This mode should be used with caution. It should be used in environments where the transport security is being provided by other means (such as IPSec) and only client authentication is provided by the WCF infrastructure.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<transport>](transport-of-webhttpbinding.md)|Defines the transport security settings. This element corresponds to the <xref:System.ServiceModel.Configuration.HttpTransportSecurityElement> type.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<webHttpBinding>](webhttpbinding.md)|A binding element that is used to configure endpoints for Windows Communication Foundation (WCF) Web services that respond to HTTP requests instead of SOAP messages.|  
  
## See also

- <xref:System.ServiceModel.Configuration.WebHttpBindingElement>
- <xref:System.ServiceModel.Configuration.WSHttpSecurityElement>
- <xref:System.ServiceModel.WebHttpBinding.Security%2A>
- <xref:System.ServiceModel.Configuration.WebHttpBindingElement.Security%2A>
- <xref:System.ServiceModel.WebHttpSecurity>
- [Securing Services and Clients](../../feature-details/securing-services-and-clients.md)
- [Selecting a Credential Type](../../feature-details/selecting-a-credential-type.md)
- [Bindings](../../bindings.md)
- [Configuring System-Provided Bindings](../../feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../using-bindings-to-configure-services-and-clients.md)
- [\<binding>](../../../misc/binding.md)
- [WCF Web HTTP Programming Model](../../feature-details/wcf-web-http-programming-model.md)
