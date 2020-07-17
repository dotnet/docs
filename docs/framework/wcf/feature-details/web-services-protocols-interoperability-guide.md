---
title: Web services protocols interoperability guide
ms.date: 03/30/2017
ms.assetid: f2981678-ebdb-433d-899b-467f7df95fb2
---
# Web services protocols interoperability guide

Windows Communication Foundation (WCF) implements a number of Web services protocols. Many of these protocols include a number of options and extensibility points left to the discretion of the implementer. This topic provides a list of Web services protocols WCF implements. Other topics within this section provide implementation details for each protocol supported.

## Web services protocols implemented by WCF

WCF provides support for Web services (WS) infrastructure protocols through channels and Web services application protocols through the contracts feature. Interoperability for application protocols is accomplished through XML Schema description language 1.0 (XSD) and Web Services Description Language (WSDL) 1.1.

Infrastructure protocols interoperability is provided by the WS-* specifications. WCF channels provide support for a number of WS-\* infrastructure protocols. WCF channels are configured using binding elements. The following tables contain the full list of the WS-\* infrastructure protocols implemented by various WCF binding elements.

<xref:System.ServiceModel.Channels.HttpTransportBindingElement> supports the specifications in the following table.

|Specification/document|Link|
|-----------------------------|----------|
|HTTP 1.1|[RFC 2616](https://www.rfc-editor.org/rfc/rfc2616.txt)|
|SOAP 1.1 HTTP Binding|[Simple Object Access Protocol (SOAP) 1.1](https://www.w3.org/TR/2000/NOTE-SOAP-20000508/), Section 7|
|SOAP 1.2 HTTP Binding|[SOAP Version 1.2 Part 2: Adjuncts (Second Edition)](https://www.w3.org/TR/soap12-part2/), Section 7|

<xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement> and <xref:System.ServiceModel.Channels.MtomMessageEncodingBindingElement> support the specifications in the following table.

|Specification/Document|Link|
|-----------------------------|----------|
|XML|[Extensible Markup Language (XML) 1.0 (Fourth Edition)](https://www.w3.org/TR/REC-xml/)|
|SOAP 1.1|[Simple Object Access Protocol (SOAP) 1.1](https://www.w3.org/TR/2000/NOTE-SOAP-20000508/)|
|SOAP 1.2 Core|[SOAP Version 1.2 Part 1: Messaging Framework (Second Edition)](https://www.w3.org/TR/2007/REC-soap12-part1-20070427/)|
|WS-Addressing 2004/08|[Web Services Addressing (WS-Addressing)](https://www.w3.org/Submission/2004/SUBM-ws-addressing-20040810/)|
|W3C Web Services Addressing 1.0 - Core|[Web Services Addressing 1.0 - Core](https://www.w3.org/TR/2006/REC-ws-addr-core-20060509/)|
|W3C Web Services Addressing 1.0 - SOAP Binding|[Web Services Addressing 1.0 - SOAP Binding](https://www.w3.org/TR/2006/REC-ws-addr-soap-20060509/)|
|W3C Web Services Addressing 1.0 - WSDL Binding*|[Web Services Addressing 1.0 - WSDL Binding](https://www.w3.org/TR/2006/CR-ws-addr-wsdl-20060529/)|
|W3C Web Services Addressing 1.0 Metadata|[Web Services Addressing 1.0 - Metadata](https://www.w3.org/TR/ws-addr-metadata/)|
|WSDL SOAP1.1 Binding|[Web Services Description Language (WSDL) 1.1](https://www.w3.org/TR/wsdl/)|
|WSDL SOAP1.2 Binding|[WSDL 1.1 Binding Extension for SOAP 1.2](https://www.w3.org/Submission/wsdl11soap12/)|

<xref:System.ServiceModel.Channels.MtomMessageEncodingBindingElement> supports the specifications in the following table.

|Specification/document|Link|
|-----------------------------|----------|
|XOP|[XML-binary Optimized Packaging](https://www.w3.org/TR/xop10/)|
|MTOM + SOAP1.2 Binding|[SOAP Message Transmission Optimization Mechanism](https://www.w3.org/TR/soap12-mtom/)|
|MTOM SOAP 1.1 Binding|[SOAP 1.1 Binding for MTOM 1.0](https://www.w3.org/Submission/soap11mtom10/)|
|MTOM WS-PolicyAssertions|[MTOM Serialization Policy Assertion (WS-MTOMPolicy)](https://www.w3.org/Submission/WS-MTOMPolicy/)|

<xref:System.ServiceModel.Channels.SecurityBindingElement> supports the specifications in the following table.

|Specification/document|Link|
|-----------------------------|----------|
|WSS: SOAP Message Security 1.0|[Web Services Security: SOAP Message Security 1.0](https://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0.pdf)|
|WSS: Username Token Profile 1.0|[Web Services Security UsernameToken Profile 1.0](https://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0.pdf)<br /><br /> require Password/@Type=PasswordText (default)|
|WSS: X.509 Token Profile 1.0|[Web Services Security X.509 Certificate Token Profile](https://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0.pdf)|
|WSS: SAML 1.1 Token Profile 1.0|[Web Services Security: SAML Token Profile](https://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.0.pdf)|
|WSS: SOAP Message Security 1.1|[Web Services Security: SOAP Message Security 1.1](https://www.oasis-open.org/committees/download.php/16790/wss-v1.1-spec-os-SOAPMessageSecurity.pdf)|
|WSS Username Token Profile 1.1|[Web Services Security UsernameToken Profile 1.1](https://www.oasis-open.org/committees/download.php/16782/wss-v1.1-spec-os-UsernameTokenProfile.pdf)<br /><br /> do not implement password-based key derivation;<br /><br /> require Password/@Type=PasswordText (default)|
|WSS: X509 Token Profile 1.1|[Web Services Security X.509 Certificate Token Profile 1.1](https://www.oasis-open.org/committees/download.php/16785/wss-v1.1-spec-os-x509TokenProfile.pdf)|
|WSS: Kerberos Token Profile 1.1|[Web Services Security Kerberos Token Profile 1.1](https://www.oasis-open.org/committees/download.php/16788/wss-v1.1-spec-os-KerberosTokenProfile.pdf)|
|WSS: SAML 1.1 Token Profile 1.1|[Web Services Security SAML Token Profile 1.1](https://www.oasis-open.org/committees/download.php/16768/wss-v1.1-spec-os-SAMLTokenProfile.pdf)|
|WS-Secure Conversation|[Web Services Secure Conversation Language](https://specs.xmlsoap.org/ws/2005/02/sc/ws-secureconversation.pdf)|
|WS-Trust 1.4|[Web Services Trust Language](https://docs.oasis-open.org/ws-sx/ws-trust/200802)|
|WS-SecurityPolicy 2005/07|[Web Services Secure Conversation Language](https://specs.xmlsoap.org/ws/2005/02/sc/ws-secureconversation.pdf)<br /><br /> As amended by errata submitted to OASIS WS-SX Technical Committee.<br /><br /> [ws-sx message](https://lists.oasis-open.org/archives/ws-sx/200512/msg00017.html)|
|WS-ReliableMessaging 1.1|[Reliable Messaging Protocol version 1.1](reliable-messaging-protocol-version-1-1.md)|

<xref:System.ServiceModel.Channels.TransactionFlowBindingElement> supports the specifications in the following table.

|Specification/Document|Link|
|-----------------------------|----------|
|WS-Coordination|[Web Services Coordination](https://docs.microsoft.com/previous-versions/ms951231(v=msdn.10))|
|WS-AtomicTransaction|[Web Services Atomic Transaction](https://specs.xmlsoap.org/ws/2004/10/wsat/wsat.pdf)|

The <xref:System.ServiceModel.Description.MetadataExporter>, <xref:System.ServiceModel.Description.MetadataImporter>, <xref:System.ServiceModel.Description.WsdlExporter>, <xref:System.ServiceModel.Description.WsdlImporter>, and <xref:System.ServiceModel.Description.MetadataResolver> classes provide support for the following metadata specifications:

- [XML Schema Part 1: Structures Second Edition](https://www.w3.org/TR/xmlschema-1/)

- [XML Schema Part 2: Data types Second Edition](https://www.w3.org/TR/xmlschema-2/)

- [WSDL 1.1](https://www.w3.org/TR/wsdl/)

- [WS-Policy 1.2](https://www.w3.org/Submission/2006/SUBM-WS-Policy-20060425/)

- [WS-Policy 1.5](https://www.w3.org/TR/ws-policy/)

- [WS-PolicyAttachment 1.2](https://www.w3.org/Submission/2006/SUBM-WS-PolicyAttachment-20060425/)

- [WS-MetadataExchange 1.1](https://specs.xmlsoap.org/ws/2004/09/mex/WS-MetadataExchange.pdf)

- [WS-Transfer Get for metadata retrieval](https://www.w3.org/Submission/2006/SUBM-WS-Transfer-20060315/)

In addition, the following Interoperability Profiles are implemented across WCF:

- [Basic Profile 1.1](http://www.ws-i.org/Profiles/BasicProfile-1.1-2004-08-24.html)

- [Simple SOAP Binding 1.0](http://www.ws-i.org/Profiles/SimpleSoapBindingProfile-1.0-2004-08-24.html)

- [Basic Security Profile 1.0 Working Draft](http://www.ws-i.org/Profiles/BasicSecurityProfile-1.0-2006-03-29.html)

## See also

- [Web Services Protocols Supported by System-Provided Interoperability Bindings](web-services-protocols-supported-by-system-provided-interoperability-bindings.md)
- [Messaging Protocols](messaging-protocols.md)
- [Data Contract Schema Reference](data-contract-schema-reference.md)
- [WSDL and Policy](wsdl-and-policy.md)
- [Security Protocols](security-protocols.md)
- [Reliable Messaging Protocol version 1.0](reliable-messaging-protocol-version-1-0.md)
- [Reliable Messaging Protocol version 1.1](reliable-messaging-protocol-version-1-1.md)
- [Transaction Protocols](transaction-protocols.md)
- [Context Exchange Protocol](context-exchange-protocol.md)
