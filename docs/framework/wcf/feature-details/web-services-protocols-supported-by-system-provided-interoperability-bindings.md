---
title: "Web Services Protocols Supported by System-Provided Interoperability Bindings"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WS-protocols"
  - "Web services protocols"
  - "Windows Communication Foundation, Web service protocols"
ms.assetid: 1f7fc4ff-30fe-4e46-adda-91caad3b06c6
caps.latest.revision: 39
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Web Services Protocols Supported by System-Provided Interoperability Bindings
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] is built to interoperate with Web services that support a set of specifications known as Web services specifications. To simplify service configuration for interoperability best practices, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] introduces three interoperable system-provided bindings: <xref:System.ServiceModel.BasicHttpBinding?displayProperty=nameWithType>, <xref:System.ServiceModel.WSHttpBinding?displayProperty=nameWithType>, and <xref:System.ServiceModel.WSDualHttpBinding?displayProperty=nameWithType>. For interoperability with Organization for the Advancement of Structured Information Standards (OASIS) standards, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] includes one interoperable system-provided binding: <xref:System.ServiceModel.WS2007HttpBinding?displayProperty=nameWithType>. For metadata publication, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] includes two interoperable system-provided bindings: [\<mexHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/mexhttpbinding.md) and [\<mexHttpsBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/mexhttpsbinding.md). This topic lists specifications that system-provided interoperable bindings support.  
  
## Web Services Protocols Supported by basicHttpBinding, wsHttpBinding, ws2007HttpBinding, and wsDualHttpBinding Bindings  
  
### All Bindings  
 The [\<basicHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/basichttpbinding.md), [\<wsHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md), and [\<ws2007HttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/ws2007httpbinding.md) bindings support the following protocols.  
  
> [!NOTE]
>  For information about bindings used to publish metadata, see the "System-Provided Metadata Bindings" section later in this topic.  
  
|Category|Protocol|Specification and Usage|  
|--------------|--------------|-----------------------------|  
|Transport|HTTP 1.1|[HTTP 1.1](http://go.microsoft.com/fwlink/?LinkId=84048)<br /><br /> `BasicHttpBinding`, `WSHttpBinding`, and `WS2007HttpBinding` use the HTTP and HTTPS transports.|  
|Messaging|MTOM|[MTOM](http://go.microsoft.com/fwlink/?LinkId=95326)<br /><br /> `basicHttpBinding`, `wsHttpBinding`, and `ws2007HttpBinding` support Message Transmission Optimization Mechanism (MTOM). Not used by default. To use MTOM, set the `messageEncoding` attribute to `"Mtom"`.<br /><br /> Example:<br /><br /> `<wsHttpBinding> <binding messageEncoding="Mtom"/> </wsHttpBinding>`|  
|Metadata|WSDL 1.1|[WSDL 1.1](http://go.microsoft.com/fwlink/?LinkId=94859)<br /><br /> [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses Web Services Description Language (WSDL) to describe services.|  
|Metadata|WS-Policy|[WS-Policy](http://go.microsoft.com/fwlink/?LinkId=94864)<br /><br /> [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the WS-Policy specification together with domain-specific assertions to describe service requirements and capabilities.|  
|Metadata|WS-Policy 1.5|[WS-Policy 1.5](http://go.microsoft.com/fwlink/?LinkId=95327)<br /><br /> [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the WS-Policy specification together with domain-specific assertions to describe service requirements and capabilities.|  
|Metadata|WS-PolicyAttachment|[WS-PolicyAttachment](http://go.microsoft.com/fwlink/?LinkId=95328)<br /><br /> [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements WS-PolicyAttachment to attach policy expressions at various scopes in Web Services Description Language (WSDL).|  
|Metadata|WS-MetadataExchange|[WS-MetadataExchange](http://go.microsoft.com/fwlink/?LinkId=94868)<br /><br /> [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements WS-MetadataExchange to retrieve XML Schema, WSDL, and WS-Policy.|  
  
### basicHttpBinding  
  
|Category|Protocol|Specification and Usage|  
|--------------|--------------|-----------------------------|  
|Messaging|SOAP 1.1|[SOAP 1.1](http://go.microsoft.com/fwlink/?LinkId=90520)<br /><br /> In accordance with Basic Profile 1.1, the `basicHttpBinding` element implements the SOAP 1.1 message protocol.|  
|Security|WSS SOAP Message Security 1.0|[WSS SOAP Message Security 1.0](http://go.microsoft.com/fwlink/?LinkId=94684)<br /><br /> In accordance with the Basic Security Profile, the `basicHttpBinding` element implements the Web Services Security (WSS) SOAP Message Security 1.0 specification for user name/password and X.509-based security.<br /><br /> `<basicHttpBinding> <binding name="Binding1"> <security mode="TransportWithMessageCredential &#124;                     "Message" .../> </binding> </basicHttpBinding>`|  
|Security|WSS SOAP Message Security UsernameToken Profile 1.0|[WSS SOAP Message Security UsernameToken Profile 1.0](http://go.microsoft.com/fwlink/?LinkId=95334)<br /><br /> `<basicHttpBinding> <binding name="Binding1"> <security mode="TransportWithMessageCredential"> <transport clientCredentialType="Basic"/> </security> </basicHttpBinding>`|  
|Security|WSS SOAP Message Security X.509 Certificate Token Profile 1.0|[WSS SOAP Message Security X.509 Certificate Token Profile 1.0](http://go.microsoft.com/fwlink/?LinkId=95335)<br /><br /> `<basicHttpBinding>   <security mode="Message"> <message clientCredentialType="Certificate"/> </security> </basicHttpBinding>`|  
  
### wsHttpBinding, ws2007HttpBinding, and wsDualHttpBinding  
  
|Category|Protocol|Specification and Usage|  
|--------------|--------------|-----------------------------|  
|Messaging|SOAP 1.2|[Primer](http://go.microsoft.com/fwlink/?LinkId=48282)<br /><br /> [Messaging framework](http://go.microsoft.com/fwlink/?LinkId=94664)<br /><br /> [Adjuncts (including HTTP binding)](http://go.microsoft.com/fwlink/?LinkId=95329)|  
|Messaging|WS-Addressing 2005/08|[Web Services Addressing 1.0 - Core](http://go.microsoft.com/fwlink/?LinkId=90574)<br /><br /> [Web Services Addressing 1.0 - SOAP](http://go.microsoft.com/fwlink/?LinkId=95330)<br /><br /> The `wsHttpBinding`, `ws2007HttpBinding`, and `wsDualHttpBinding` implement the World Wide Web Consortium (W3C) WS-Addressing recommendation to enable asynchronous messaging, message correlation, and transport-neutral addressing mechanisms.<br /><br /> WCF does not support encryption of WS-Addressing headers although this is allowed by the WS-* specifications.|  
|Messaging|WS-Addressing 1.0 - Metadata|[WS-Addressing 1.0 Metadata](http://www.w3.org/2007/05/addressing/metadata) Support for this protocol is enabled by setting the policy version in ServiceMetadata behavior - with policyversion set to 1.2 (the default), The wsdl description is compliant with WS-Addressing wsdl, with policyversion set to 1.5, the wsdl description is compliant with ws-addressing metadata.<br /><br /> WCF does not support encryption of WS-Addressing headers although this is allowed by the WS-* specifications.|  
|Security|WSS SOAP Message Security 1.0|[WSS SOAP Message Security 1.0](http://go.microsoft.com/fwlink/?LinkId=94684)<br /><br /> Use when the `securityMode` attribute is set to "wsSecurityOverHttp" (default) and parameters are configured using a `wsSecurity` child element.<br /><br /> `<wsHttpBinding>   <binding name="myBinding">      <security mode="Message" .../>   </binding> </wsHttpBinding>`|  
|Security|WSS SOAP Message Security UsernameToken Profile 1.1|[WSS SOAP Message Security UsernameToken Profile 1.0](http://go.microsoft.com/fwlink/?LinkId=95331)<br /><br /> Use when the `wsSecurity` element's `authenticationMode` attribute is set to "Username".<br /><br /> `<wsHttpBinding>   <binding name="MyBinding">     <security mode="Message>       <message           clientCredentialType="UserName        negotiateServiceCredential="false"        establishSecurityContext="false"/>     </security> </binding> </wsHttpBinding>`|  
|Security|WSS SOAP Message Security X.509 Certificate Token Profile 1.1|[WSS SOAP Message Security X.509 Certificate Token Profile 1.1](http://go.microsoft.com/fwlink/?LinkId=95332)<br /><br /> Use for message protection when the `wsSecurity` element’s `authenticationMode` attribute is set to "Username", "Certificate", or "None". Additionally, use this for client authentication when the `wsSecurity` element’s `authenticationMode` attribute is set to "Certificate".<br /><br /> `<wsHttpBinding>   <binding name="MyBinding">     <security mode="Message>       <message           clientCredentialType="Certificate"        negotiateServiceCredential="false"        establishSecurityContext="false"/>     </security>   </binding> </wsHttpBinding>`|  
|Security|WSS SOAP Message Security  Kerberos Token Profile 1.1|[WSS SOAP Message Security Kerberos Token Profile 1.1](http://go.microsoft.com/fwlink/?LinkId=95333)<br /><br /> Use for authentication and message protection when the `wsSecurity` element’s `authenticationMode` attribute is set to "Windows".<br /><br /> `<wsHttpBinding>   <binding name="MyBinding">     <security mode="Message>       <message           clientCredentialType="Windows"        negotiateServiceCredential="false"        establishSecurityContext="false"/>     </security>   </binding> </wsHttpBinding>`|  
|Security|WS-SecureConversation|[WS-SecureConversation](http://go.microsoft.com/fwlink/?LinkId=95317)<br /><br /> Use to provide a secure session when the `security/@mode` attribute is set to "Message" and the `message/@establishSecurityContext` attribute is set to "true" (default).|  
|Security|WS-Trust|[WS-Trust](http://go.microsoft.com/fwlink/?LinkId=95318)<br /><br /> Used by WS-SecureConversation (see above).|  
|Reliable Messaging|WS-ReliableMessaging|[WS-ReliableMessaging](http://go.microsoft.com/fwlink/?LinkId=95322)<br /><br /> Use when the binding is configured to use `reliableSession`.<br /><br /> `<wsHttpBinding>  <binding name="myBinding">    <reliableSession/>   </binding> </wsHttpBinding>`|  
|Transactions|WS-AtomicTransaction|[WS-AtomicTransaction](http://go.microsoft.com/fwlink/?LinkId=95323)<br /><br /> Use for communication between transaction managers. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients and services always use local transaction managers.|  
|Transactions|WS-Coordination|[WS-Coordination](http://go.microsoft.com/fwlink/?LinkId=95324)<br /><br /> Use to flow the transaction context when the `flowTransactions` attribute is set to "Allowed" or "Required".<br /><br /> `<wsHttpBinding>   <binding transactionFlow="true"/> </wsHttpBinding>`|  
  
## wsFederationHttpBinding and ws2007FederationHttpBinding  
 The [\<wsFederationHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wsfederationhttpbinding.md) and [\<ws2007FederationHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/ws2007federationhttpbinding.md) elements are introduced to provide support for federated scenarios, where a third party issues a token used to authenticate a client. In addition to the protocols used by `wsHttpBinding`, `wsFederationHttpBinding` leverages:  
  
-   `WS-Trust` for token issuance.  
  
-   WSS Security Assertions Markup Language (SAML) Token Profile 1.0 and 1.1 for the most commonly issued token format.  
  
 Example:  
  
```xml  
<wsFederationHttpBinding>  
  <binding name="myBinding">  
     <security mode="Message">  
       <message issuedKeyType="Symmetric"   
                issuedTokenType="http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1">  
         <issuerMetadata address =   
         'http://localhost/FederationSample/HomeRealmSTS/STS.svc/mex'>  
       </message>  
     </security>  
  </binding>  
</wsFederationHttpBinding>  
```  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Federation](../../../../docs/framework/wcf/feature-details/federation.md) .  
  
## System-Provided Metadata Bindings  
 The following tables describe the protocols supported by the system-provided interoperable metadata bindings exposed by the <xref:System.ServiceModel.Description.MetadataExchangeBindings?displayProperty=nameWithType> class.  
  
### mexHttpBinding  
 The [\<mexHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/mexhttpbinding.md) binding supports the following protocols. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using this binding, see [Publishing Metadata](../../../../docs/framework/wcf/feature-details/publishing-metadata.md).  
  
|Category|Protocol|Specification and Usage|  
|--------------|--------------|-----------------------------|  
|Transport|HTTP 1.1|[HTTP 1.1](http://go.microsoft.com/fwlink/?LinkId=84048)|  
|Messaging|SOAP 1.2|[Primer](http://go.microsoft.com/fwlink/?LinkId=48282)<br /><br /> [Messaging framework](http://go.microsoft.com/fwlink/?LinkId=94664)<br /><br /> [Adjuncts (including HTTP binding)](http://go.microsoft.com/fwlink/?LinkId=95329)|  
|Messaging|WS-Addressing 2005/08|[Web Services Addressing 1.0 - Core](http://go.microsoft.com/fwlink/?LinkId=90574)<br /><br /> [Web Services Addressing 1.0 - SOAP](http://go.microsoft.com/fwlink/?LinkId=95330)|  
|Metadata|WS-MetadataExchange|[WS-MetadataExchange](http://go.microsoft.com/fwlink/?LinkId=94868)<br /><br /> [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements WS-MetadataExchange to retrieve XML Schema, WSDL, and WS-Policy.|  
  
### mexHttpsBinding  
 [\<mexHttpsBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/mexhttpsbinding.md) supports the following protocols. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using this binding, see [Publishing Metadata](../../../../docs/framework/wcf/feature-details/publishing-metadata.md).  
  
|Category|Protocol|Specification and Usage|  
|--------------|--------------|-----------------------------|  
|Transport|HTTP 1.1|[HTTP 1.1](http://go.microsoft.com/fwlink/?LinkId=84048)<br /><br /> Transport security is enabled.|  
|Messaging|SOAP 1.2|[Primer](http://go.microsoft.com/fwlink/?LinkId=48282)<br /><br /> [Messaging framework](http://go.microsoft.com/fwlink/?LinkId=94664)<br /><br /> [Adjuncts (including HTTP binding)](http://go.microsoft.com/fwlink/?LinkId=95329)|  
|Messaging|WS-Addressing 2005/08|[Web Services Addressing 1.0 - Core](http://go.microsoft.com/fwlink/?LinkId=90574)<br /><br /> [Web Services Addressing 1.0 - SOAP](http://go.microsoft.com/fwlink/?LinkId=95330)|  
|Metadata|WS-MetadataExchange|[WS-MetadataExchange](http://go.microsoft.com/fwlink/?LinkId=94868)<br /><br /> [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements WS-MetadataExchange to retrieve XML Schema, WSDL, and WS-Policy.|  
  
## See Also  
 [System-Provided Bindings](../../../../docs/framework/wcf/system-provided-bindings.md)  
 [\<basicHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/basichttpbinding.md)  
 [\<wsHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md)  
 [\<wsDualHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wsdualhttpbinding.md)  
 [\<mexHttpsBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/mexhttpsbinding.md)  
 [\<mexHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/mexhttpbinding.md)
