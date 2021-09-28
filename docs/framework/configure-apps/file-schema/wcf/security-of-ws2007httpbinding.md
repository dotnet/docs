---
description: "Learn more about: <security> of <ws2007HttpBinding>"
title: "<security> of <ws2007HttpBinding>"
ms.date: "03/30/2017"
ms.assetid: fdda0ff7-b462-4e26-af52-e87ddab71945
---
# \<security> of \<ws2007HttpBinding>

Represents the security settings used with the [\<ws2007HttpBinding>](ws2007httpbinding.md) element.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<ws2007HttpBinding>**](ws2007httpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<security>**  
  
## Syntax  
  
```xml  
<system.serviceModel>
  <bindings>
    <ws2007HttpBinding>
      <binding name = "String">
        <security mode="None/Message/Transport/TransportWithMessageCredential">
          <transport>
          </transport>
          <message>
          </message>
        </security>
      </binding>
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
|`Transport`|Security is provided using HTTPS. The service must be configured with Secure Sockets Layer (SSL) certificates. The message is entirely secured using HTTPS and the service is authenticated by the client using the service’s SSL certificate. The client authentication is controlled through the `ClientCredentials` attribute of the [\<transport>](transport-of-ws2007httpbinding.md) element.|  
|`Message`|Security is provided using SOAP message security. By default, the SOAP body is encrypted and signed. This mode offers a variety of features, such as whether the service credentials are available at the client out of band, the algorithm suite to use, and what level of protection to apply to the message body through the <xref:System.ServiceModel.Security.SecurityMessageProperty>. Client authentication is performed once for each session and the results of authentication are cached for the duration of the session.|  
|`TransportWithMessageCredential`|In this mode, HTTPS provides integrity, confidentiality, and server authentication, and SOAP message security provides client authentication. By default, client authentication is performed once for each session and the results of authentication are cached for the duration of the session.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<transport>](transport-of-ws2007httpbinding.md)|Defines the transport security settings. This element corresponds to the <xref:System.ServiceModel.Configuration.HttpTransportSecurityElement> type. These settings are applied only when the mode is set to Transport.|  
|[\<message>](message-of-ws2007httpbinding.md)|Defines the security settings for the message. This element corresponds to the <xref:System.ServiceModel.Configuration.MessageSecurityOverHttpElement> type. These settings are not applied when the mode is set to Transport.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<ws2007HttpBinding>](ws2007httpbinding.md)|A secure binding for HTTP transport applications.|  
  
## Remarks  

 This element is designed for interoperation with services that implement WS-* specifications. The transport security for this binding is Secure Sockets Layer (SSL) over HTTP, or HTTPS.  
  
## See also

- <xref:System.ServiceModel.WSHttpSecurity>
- <xref:System.ServiceModel.WSHttpBinding.Security%2A>
- <xref:System.ServiceModel.Configuration.WSHttpBindingElement.Security%2A>
- <xref:System.ServiceModel.Configuration.WSHttpSecurityElement>
- <xref:System.ServiceModel.BasicHttpSecurity>
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](bindings.md)
