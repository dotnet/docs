---
title: "Web Services Protocols Interoperability Guide"
ms.date: "03/30/2017"
ms.assetid: f2981678-ebdb-433d-899b-467f7df95fb2
---
# Web Services Protocols Interoperability Guide
Windows Communication Foundation (WCF) implements a number of Web services protocols. Many of these protocols include a number of options and extensibility points left to the discretion of the implementer. This topic provides a list of Web services protocols WCF implements. Other topics within this section provide implementation details for each protocol supported.  
  
## Web Services Protocols Implemented by WCF  
 WCF provides support for Web services (WS) infrastructure protocols through channels and Web services application protocols through the contracts feature. Interoperability for application protocols is accomplished through XML Schema description language 1.0 (XSD) and Web Services Description Language (WSDL) 1.1.  
  
 Infrastructure protocols interoperability is provided by the WS-* specifications. WCF channels provide support for a number of WS-\* infrastructure protocols. WCF channels are configured using binding elements. The following tables contain the full list of the WS-\* infrastructure protocols implemented by various WCF binding elements.  
  
 <xref:System.ServiceModel.Channels.HttpTransportBindingElement> supports the specifications in the following table.  
  
|Specification/document|Link|  
|-----------------------------|----------|  
|HTTP 1.1|[RFC 2616](https://go.microsoft.com/fwlink/?LinkId=90372)|  
|SOAP 1.1 HTTP Binding|[Simple Object Access Protocol (SOAP) 1.1](https://go.microsoft.com/fwlink/?LinkId=90520), Section 7|  
|SOAP 1.2 HTTP Binding|[SOAP Version 1.2 Part 2: Adjuncts (Second Edition)](https://go.microsoft.com/fwlink/?LinkId=95329), Section 7|  
  
 <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement> and <xref:System.ServiceModel.Channels.MtomMessageEncodingBindingElement> support the specifications in the following table.  
  
|Specification/Document|Link|  
|-----------------------------|----------|  
|XML|[Extensible Markup Language (XML) 1.0 (Fourth Edition)](https://go.microsoft.com/fwlink/?LinkId=15139)|  
|SOAP 1.1|[Simple Object Access Protocol (SOAP) 1.1](https://go.microsoft.com/fwlink/?LinkId=96687)|  
|SOAP 1.2 Core|[SOAP Version 1.2 Part 1: Messaging Framework (Second Edition)](https://go.microsoft.com/fwlink/?LinkId=94664)|  
|WS-Addressing 2004/08|[Web Services Addressing (WS-Addressing)](https://go.microsoft.com/fwlink/?LinkId=81239)|  
|W3C Web Services Addressing 1.0 - Core|[Web Services Addressing 1.0 - Core](https://go.microsoft.com/fwlink/?LinkId=96688)|  
|W3C Web Services Addressing 1.0 - SOAP Binding|[Web Services Addressing 1.0 - SOAP Binding](https://go.microsoft.com/fwlink/?LinkId=96689)|  
|W3C Web Services Addressing 1.0 - WSDL Binding*|[Web Services Addressing 1.0 - WSDL Binding](https://go.microsoft.com/fwlink/?LinkId=96690)|  
|W3C Web Services Addressing 1.0 Metadata|[Web Services Addressing 1.0 - Metadata](http://www.w3.org/TR/ws-addr-metadata/)|  
|WSDL SOAP1.1 Binding|[Web Services Description Language (WSDL) 1.1](https://go.microsoft.com/fwlink/?LinkId=96160)|  
|WSDL SOAP1.2 Binding|[WSDL 1.1 Binding Extension for SOAP 1.2](https://go.microsoft.com/fwlink/?LinkId=96691)|  
  
 <xref:System.ServiceModel.Channels.MtomMessageEncodingBindingElement> supports the specifications in the following table.  
  
|Specification/document|Link|  
|-----------------------------|----------|  
|XOP|[XML-binary Optimized Packaging](https://go.microsoft.com/fwlink/?LinkId=96714)|  
|MTOM + SOAP1.2 Binding|[SOAP Message Transmission Optimization Mechanism](https://go.microsoft.com/fwlink/?LinkId=96713)|  
|MTOM SOAP 1.1 Binding|[SOAP 1.1 Binding for MTOM 1.0](https://go.microsoft.com/fwlink/?LinkId=96712)|  
|MTOM WS-PolicyAssertions|To be published.|  
  
 <xref:System.ServiceModel.Channels.SecurityBindingElement> supports the specifications in the following table.  
  
|Specification/document|Link|  
|-----------------------------|----------|  
|WSS: SOAP Message Security 1.0|[Web Services Security: SOAP Message Security 1.0](https://go.microsoft.com/fwlink/?LinkId=94684)|  
|WSS: Username Token Profile 1.0|[Web Services Security UsernameToken Profile 1.0](https://go.microsoft.com/fwlink/?LinkId=95334)<br /><br /> require Password/@Type=PasswordText (default)|  
|WSS: X.509 Token Profile 1.0|[Web Services Security X.509 Certificate Token Profile](https://go.microsoft.com/fwlink/?LinkId=95335)|  
|WSS: SAML 1.1 Token Profile 1.0|[Web Services Security: SAML Token Profile](https://go.microsoft.com/fwlink/?LinkId=96693)|  
|WSS: SOAP Message Security 1.1|[Web Services Security: SOAP Message Security 1.1](https://go.microsoft.com/fwlink/?LinkId=91240)|  
|WSS Username Token Profile 1.1|[Web Services Security UsernameToken Profile 1.1](https://go.microsoft.com/fwlink/?LinkId=95331)<br /><br /> do not implement password-based key derivation;<br /><br /> require Password/@Type=PasswordText (default)|  
|WSS: X509 Token Profile 1.1|[Web Services Security X.509 Certificate Token Profile 1.1](https://go.microsoft.com/fwlink/?LinkId=95332)|  
|WSS: Kerberos Token Profile 1.1|[Web Services Security Kerberos Token Profile 1.1](https://go.microsoft.com/fwlink/?LinkId=95333)|  
|WSS: SAML 1.1 Token Profile 1.1|[Web Services Security SAML Token Profile 1.1](https://go.microsoft.com/fwlink/?LinkId=96694)|  
|WS-Secure Conversation|[Web Services Secure Conversation Language](https://go.microsoft.com/fwlink/?LinkId=95317)|  
|WS-Trust 1.4|[Web Services Trust Language](https://go.microsoft.com/fwlink/?LinkId=169514)|  
|WS-SecurityPolicy 2005/07|[Web Services Secure Conversation Language](https://go.microsoft.com/fwlink/?LinkId=95317)<br /><br /> As amended by errata submitted to OASIS WS-SX Technical Committee.<br /><br /> [ws-sx message](https://go.microsoft.com/fwlink/?LinkId=96700)|  
|WS-ReliableMessaging 1.1|[Reliable Messaging Protocol version 1.1](../../../../docs/framework/wcf/feature-details/reliable-messaging-protocol-version-1-1.md)|  
  
 <xref:System.ServiceModel.Channels.TransactionFlowBindingElement> supports the specifications in the following table.  
  
|Specification/Document|Link|  
|-----------------------------|----------|  
|WS-Coordination|[Web Services Coordination](https://go.microsoft.com/fwlink/?LinkId=95324)|  
|WS-AtomicTransaction|[Web Services Atomic Transaction](https://go.microsoft.com/fwlink/?LinkId=95323)|  
  
 The <xref:System.ServiceModel.Description.MetadataExporter>, <xref:System.ServiceModel.Description.MetadataImporter>, <xref:System.ServiceModel.Description.WsdlExporter>, <xref:System.ServiceModel.Description.WsdlImporter>, and <xref:System.ServiceModel.Description.MetadataResolver> classes provide support for the following metadata specifications:  
  
-   [XML Schema Part 1: Structures Second Edition](https://go.microsoft.com/fwlink/?LinkId=3536)  
  
-   [XML Schema Part 2: Data types Second Edition](https://go.microsoft.com/fwlink/?LinkId=40138)  
  
-   [WSDL 1.1](https://go.microsoft.com/fwlink/?LinkId=96160)  
  
-   [WS-Policy 1.2](https://go.microsoft.com/fwlink/?LinkId=96705)  
  
-   [WS-Policy 1.5](https://go.microsoft.com/fwlink/?LinkId=96706)  
  
-   [WS-PolicyAttachment 1.2](https://go.microsoft.com/fwlink/?LinkId=96707)  
  
-   [WS-MetadataExchange 1.1](https://go.microsoft.com/fwlink/?LinkId=94868)  
  
-   [WS-Transfer Get for metadata retrieval](https://go.microsoft.com/fwlink/?LinkId=96708)  
  
 In addition, the following Interoperability Profiles are implemented across WCF:  
  
-   [Basic Profile 1.1](https://go.microsoft.com/fwlink/?LinkId=69313)  
  
-   [Simple SOAP Binding 1.0](https://go.microsoft.com/fwlink/?LinkId=96710)  
  
-   [Basic Security Profile 1.0 Working Draft](https://go.microsoft.com/fwlink/?LinkId=96711)  
  
## See Also  
 [Web Services Protocols Supported by System-Provided Interoperability Bindings](../../../../docs/framework/wcf/feature-details/web-services-protocols-supported-by-system-provided-interoperability-bindings.md)  
 [Messaging Protocols](../../../../docs/framework/wcf/feature-details/messaging-protocols.md)  
 [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md)  
 [WSDL and Policy](../../../../docs/framework/wcf/feature-details/wsdl-and-policy.md)  
 [Security Protocols](../../../../docs/framework/wcf/feature-details/security-protocols.md)  
 [Reliable Messaging Protocol version 1.0](../../../../docs/framework/wcf/feature-details/reliable-messaging-protocol-version-1-0.md)  
 [Reliable Messaging Protocol version 1.1](../../../../docs/framework/wcf/feature-details/reliable-messaging-protocol-version-1-1.md)  
 [Transaction Protocols](../../../../docs/framework/wcf/feature-details/transaction-protocols.md)  
 [Context Exchange Protocol](../../../../docs/framework/wcf/feature-details/context-exchange-protocol.md)
