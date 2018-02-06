---
title: "WSDL and Policy"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cea87440-3519-4640-8494-b8a2b0e88c84
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WSDL and Policy
This topic covers [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] WSDL 1.1, WS-Policy and WS-PolicyAttachment implementation details, as well as additional WS-Policy assertions and WSDL 1.1 extensions introduced by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements WS-Policy and WS-PolicyAttachment specifications submitted to W3C with constraints and clarifications described in this document.  
  
 This document uses the prefixes and namespaces shown in the following table.  
  
|Prefix|Namespace|  
|------------|---------------|  
|wsp (WS-Policy 1.2)|http://schemas.xmlsoap.org/ws/2004/09/policy|  
|wsp (WS-Policy 1.5)|http://www.w3.org/ns/ws-policy|  
|http|http://schemas.microsoft.com/ws/06/2004/policy/http|  
|msmq|http://schemas.microsoft.com/ws/06/2004/mspolicy/msmq|  
|msf|http://schemas.microsoft.com/ws/2006/05/framing/policy|  
|mssp|http://schemas.microsoft.com/ws/2005/07/securitypolicy|  
|msc|http://schemas.microsoft.com/ws/2005/12/wsdl/contract|  
|cdp|http://schemas.microsoft.com/net/2006/06/duplex|  
  
## WCF WSDL1.1 Extensions  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the following WSDL1.1 extensions to describe contract session requirements.  
  
 wsdl:portType/wsdl:operation/@msc:isInitiating  
 xs:boolean, indicates this operation initiates a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] session; the default value is `false`.  
  
 wsdl:portType/wsdl:operation/@msc:isTerminating  
 xs:boolean, indicates this operation terminates a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] session; the default value is `false`.  
  
 wsdl:portType/wsdl:operation/@msc:usingSession  
 xs:boolean, indicates this contract requires session to be established.  
  
### SOAP 1.x HTTP Binding Transport URIs  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the following URIs to indicate transports to be used for WSDL 1.1, SOAP 1.1, and SOAP 1.2 binding extension elements.  
  
|Transport|URI|  
|---------------|---------|  
|HTTP|http://schemas.xmlsoap.org/soap/http|  
|TCP|http://schemas.microsoft.com/soap/tcp|  
|MSMQ|http://schemas.microsoft.com/soap/msmq|  
|Named Pipes|http://schemas.microsoft.com/soap/named-pipe|  
  
## Policy Assertions Implemented by WCF  
 In addition to policy assertions introduced in the Web Services specifications (WS-*) and mentioned in other sections of this document, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements the following policy assertions.  
  
|Policy assertion|Policy subject|Description|  
|----------------------|--------------------|-----------------|  
|http:HttpBasicAuthentication|Endpoint|Endpoint uses HTTP Basic Authentication.|  
|http:HttpDigestAuthentication|Endpoint|Endpoint uses HTTP Digest Authentication.|  
|http:HttpNegotiateAuthentication|Endpoint|Endpoint uses HTTP Negotiate Authentication.|  
|http:HttpNtlmAuthentication|Endpoint|Endpoint uses HTTP NTLM Authentication.|  
|msf:Streamed|Endpoint|Endpoint uses streamed message framing. This assertion is used with the Message Framing protocol provided for transports such as TCP, and named pipes.|  
|msf:SslTransportSecurity|Endpoint|Endpoint uses transport-layer security (TLS) with message framing.|  
|msf:WindowsTransportSecurity|Endpoint|Endpoint uses Security Provider Negotiation (SPNEGO) with message framing.|  
|msmq:MsmqBestEffort|Endpoint|MSMQ with best-effort guarantees.|  
|msmq:MsmqSession|Endpoint|MSMQ with Session guarantees.|  
|msmq:MsmqVolatile|Endpoint|MSMQ Volatile.|  
|msmq:Authenticated|Endpoint|Authentication is used with MSMQ transport.|  
|msmq:WindowsDomain|Endpoint|MSMQ uses Windows Domain authentication.|  
|cdp:CompositeDuplex|Endpoint|Endpoint uses two separate converse transport connections for in and out messages.|  
|mssp:RsaToken|Nested|RSA key token assertion. This requirement is typically satisfied by an RSA key serialized directly as part of the key information in an endorsing signature.|  
|mssp:SslContextToken|Nested|Requires that a SecurityContextToken obtained using binary TLS handshake using WS-Trust be used. Nested assertions include: sp:RequireDerivedKeys, mssp:MustNotSendCancel, mssp:RequireClientCertificate.|  
|mssp:MustNotSendCancel|Nested|Specifies a requirement that a request security token (RST) request messages [WS-Trust] using the Cancel binding [WS-Trust, WS-SC] not be sent to the issuer of a given SecurityContextToken. If this assertion is present, then such request messages must not be sent to the issuer. If this assertion is not present, then such request messages can be sent to the issuer.|  
|mssp:RequireClientCertificate|Nested|This optional element specifies a requirement for a client certificate to be provided as part of the TLSNEGO protocol. If this assertion is present, then a client certificate must be provided. If this assertion is not present, then a client certificate must not be provided. This assertion must not be used outside of mssp:SslContextToken.|  
  
## See Also  
 [Custom WSDL Publication](../../../../docs/framework/wcf/samples/custom-wsdl-publication.md)  
 [How to: Export Custom WSDL](../../../../docs/framework/wcf/extending/how-to-export-custom-wsdl.md)  
 [How to: Import Custom WSDL](../../../../docs/framework/wcf/extending/how-to-import-custom-wsdl.md)
