---
title: "&lt;security&gt; of &lt;ws2007HttpBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fdda0ff7-b462-4e26-af52-e87ddab71945
caps.latest.revision: 10
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;security&gt; of &lt;ws2007HttpBinding&gt;
Represents the security settings used with the [\<ws2007HttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/ws2007httpbinding.md) element.  
  
 \<system.serviceModel>  
\<bindings>  
\<ws2007HttpBinding>  
\<binding>  
\<security>  
  
## Syntax  
  
```xml  
<system.serviceModel>  
    <bindings>  
        <ws2007HttpBinding>  
            <binding name = "string">  
              <security mode="None/Message/Transport/TransportWithMessageCredential">  
                  <transport>  
                  </transport>  
                  <message>  
                  </message>  
              </security  
        </ws2007HttpBinding>  
    </bindings>  
</system.ServiceModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`mode`|-   Optional. Specifies the type of security that is applied. The default is `Message`.<br /><br /> This attribute is of type <xref:System.ServiceModel.SecurityMode>.|  
  
## Mode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`None`|Security is disabled.|  
|`Transport`|Security is provided using HTTPS. The service must be configured with Secure Sockets Layer (SSL) certificates. The message is entirely secured using HTTPS and the service is authenticated by the client using the service’s SSL certificate. The client authentication is controlled through the `ClientCredentials` attribute of the [\<transport>](../../../../../docs/framework/configure-apps/file-schema/wcf/transport-of-ws2007httpbinding.md) element.|  
|`Message`|Security is provided using SOAP message security. By default, the SOAP body is encrypted and signed. This mode offers a variety of features, such as whether the service credentials are available at the client out of band, the algorithm suite to use, and what level of protection to apply to the message body through the <xref:System.ServiceModel.Security.SecurityMessageProperty>. Client authentication is performed once for each session and the results of authentication are cached for the duration of the session.|  
|`TransportWithMessageCredential`|In this mode, HTTPS provides integrity, confidentiality, and server authentication, and SOAP message security provides client authentication. By default, client authentication is performed once for each session and the results of authentication are cached for the duration of the session.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<transport>](../../../../../docs/framework/configure-apps/file-schema/wcf/transport-of-ws2007httpbinding.md)|Defines the transport security settings. This element corresponds to the <xref:System.ServiceModel.Configuration.HttpTransportSecurityElement> type. These settings are applied only when the mode is set to Transport.|  
|[\<message>](../../../../../docs/framework/configure-apps/file-schema/wcf/message-of-ws2007httpbinding.md)|Defines the security settings for the message. This element corresponds to the <xref:System.ServiceModel.Configuration.MessageSecurityOverHttpElement> type. These settings are not applied when the mode is set to Transport.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<ws2007HttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/ws2007httpbinding.md)|A secure binding for HTTP transport applications.|  
  
## Remarks  
 This element is designed for interoperation with services that implement WS-* specifications. The transport security for this binding is Secure Sockets Layer (SSL) over HTTP, or HTTPS.  
  
## See Also  
 <xref:System.ServiceModel.WSHttpSecurity>  
 <xref:System.ServiceModel.WSHttpBinding.Security%2A>  
 <xref:System.ServiceModel.Configuration.WSHttpBindingElement.Security%2A>  
 <xref:System.ServiceModel.Configuration.WSHttpSecurityElement>  
 <xref:System.ServiceModel.BasicHttpSecurity>  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)
