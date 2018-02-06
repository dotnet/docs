---
title: "Messaging Protocols"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5b20bca7-87b3-4c8f-811b-f215b5987104
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Messaging Protocols
The [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] channel stack employs encoding and transport channels to transform internal message representation into its wire format and send it by using a particular transport. The most common transport used for Web services interoperability is HTTP, and the most common encodings used by Web services are XML-based SOAP 1.1, SOAP 1.2, and Message Transmission Optimization Mechanism (MTOM).  
  
 This topic covers [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implementation details for the following protocols employed by <xref:System.ServiceModel.Channels.HttpTransportBindingElement>.  
  
|Specification/document|Link|  
|-----------------------------|----------|  
|HTTP 1.1|http://www.ietf.org/rfc/rfc2616.txt|  
|SOAP 1.1 HTTP Binding|http://www.w3.org/TR/2000/NOTE-SOAP-20000508/, Section 7|  
|SOAP 1.2 HTTP Binding|http://www.w3.org/TR/soap12-part2/, Section 7|  
  
 This topic covers [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implementation details for the following protocols  that <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement> and <xref:System.ServiceModel.Channels.MtomMessageEncodingBindingElement> employ.  
  
|Specification/Document|Link|  
|-----------------------------|----------|  
|XML|http://www.w3.org/TR/REC-xml|  
|SOAP 1.1|http://www.w3.org/TR/2000/NOTE-SOAP-20000508/|  
|SOAP 1.2 Core|http://www.w3.org/TR/soap12-part1/|  
|WS-Addressing 2004/08|http://www.w3.org/Submission/2004/SUBM-ws-addressing-20040810/|  
|W3C Web Services Addressing 1.0 - Core|http://www.w3.org/TR/2006/REC-ws-addr-core-20060509|  
|W3C Web Services Addressing 1.0 - SOAP Binding|http://www.w3.org/TR/2006/REC-ws-addr-soap-20060509|  
|W3C Web Services Addressing 1.0 - WSDL Binding|http://www.w3.org/TR/2006/CR-ws-addr-wsdl-20060529/|  
W3C Web Services Addressing 1.0 - Metadata|http://www.w3.org/TR/ws-addr-metadata/|  
|WSDL SOAP1.1 Binding|http://www.w3.org/TR/wsdl/|  
|WSDL SOAP1.2 Binding|http://www.w3.org/Submission/wsdl11soap12/|  
  
 This topic covers [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implementation details for the following protocols that <xref:System.ServiceModel.Channels.MtomMessageEncodingBindingElement> employs.  
  
|Specification/document|Link|  
|-----------------------------|----------|  
|XOP|http://www.w3.org/TR/xop10/|  
|MTOM + SOAP 1.2 Binding|http://www.w3.org/TR/soap12-mtom/|  
|MTOM SOAP 1.1 Binding|http://www.w3.org/Submission/soap11mtom10/|  
|MTOM WS-Policy Assertion|http://www.w3.org/Submission/2006/SUBM-WS-MTOMPolicy-20061101/.|  
  
 The following XML namespaces and associated prefixes are used throughout this topic.  
  
|Prefix|Namespace Uniform Resource Identifier (URI)|  
|------------|---------------------------------------------------|  
|s11|http://schemas.xmlsoap.org/soap/envelope|  
|s12|http://www.w3.org/2003/05/soap-envelope|  
|wsa|http://www.w3.org/2004/08/addressing|  
|wsam|http://www.w3.org/2007/05/addressing/metadata|  
|wsap|http://schemas.xmlsoap.org/ws/2004/09/policy/addressing|  
|wsa10|http://www.w3.org/2005/08/addressing|  
|wsaw10|http://www.w3.org/2006/05/addressing/wsdl|  
|xop|http://www.w3.org/2004/08/xop/include|  
|xmime|http://www.w3.org/2004/06/xmlmime<br /><br /> http://www.w3.org/2005/05/xmlmime|  
dp|http://schemas.microsoft.com/net/2006/06/duplex|  
  
## SOAP 1.1 and SOAP 1.2  
  
### Envelope and Processing Model  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements SOAP 1.1 envelope processing following Basic Profile 1.1 (BP11) and Basic Profile 1.0 (SSBP10). SOAP 1.2 Envelope processing is implemented following SOAP12-Part1.  
  
 This section explains certain implementation choices taken by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] with regard to BP11 and SOAP12-Part1.  
  
#### Mandatory Header Processing  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] follows rules for processing headers marked `mustUnderstand` described in the SOAP 1.1 and SOAP 1.2 specifications, with the following variations.  
  
 A message that enters the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel stack is processed by individual channels configured by associated binding elements, for example, Text Message Encoding, Security, Reliable Messaging, and Transactions. Each channel recognizes headers from the associated namespace and marks them as understood. Once a message enters the dispatcher, the operation formatter reads headers expected by the corresponding message/operation contract and marks them understood. Then the dispatcher verifies whether any remaining headers are not understood but marked as `mustUnderstand` and throws an exception. Messages that contain `mustUnderstand` headers that are targeted at the recipient are not processed by recipient application code.  
  
 Such layered processing allows for separation between infrastructure layers and application layers of the SOAP node:  
  
-   B1111: Headers that are not understood are detected after the message is processed by the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure channel stack, but before it is processed by application  
  
     The `mustUnderstand` header value differs between SOAP 1.1 and SOAP 1.2. Basic Profile 1.1 requires that the `mustUnderstand` value be 0 or 1 for SOAP 1.1 messages. SOAP 1.2 allows 0, 1, `false`, and `true` as values, but recommends emitting a canonical representation of `xs:boolean` values (`false`, `true`).  
  
-   B1112: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] emits `mustUnderstand` values 0 and 1 for both SOAP 1.1 and SOAP 1.2 versions of the SOAP envelope. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] accepts the entire value space of `xs:boolean` for the `mustUnderstand` header (0, 1, `false`, `true`)  
  
#### SOAP Faults  
 The following is a list of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]-specific SOAP fault implementations.  
  
-   B2121: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] returns the following SOAP 1.1 Fault Codes: `s11:mustUnderstand`, `s11:Client`, and `s11:Server`.  
  
-   B2122: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] returns the following SOAP 1.2 Fault Codes: `s12:MustUnderstand`, `s12:Sender`, and `s12:Receiver`.  
  
### HTTP Binding  
  
#### SOAP 1.1 HTTP Binding  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements SOAP1.1 HTTP binding following the Basic Profile 1.1 specification section 3.4 with the following clarifications:  
  
-   B2211: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service does not implement redirection of HTTP POST requests.  
  
-   B2212: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients support HTTP Cookies in accordance with 3.4.8.  
  
#### SOAP 1.2 HTTP Binding  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements SOAP 1.2 HTTP binding as described in the SOAP 1.2-part 2 (SOAP12Part2) specification with the following clarifications.  
  
 SOAP 1.2 introduced an optional action parameter for the `application/soap+xml` media type. This parameter is useful to optimize message dispatch without requiring that the body of the SOAP message be parsed when WS-Addressing is not used.  
  
-   R2221: The `application/soap+xml` action parameter, when present on a SOAP 1.2 request, must match the `soapAction` attribute on the `wsoap12:operation` element inside the corresponding WSDL binding.  
  
-   R2222: The `application/soap+xml` action parameter, when present on a SOAP 1.2 message, must match `wsa:Action` when WS-Addressing 2004/08 or WS-Addressing 1.0 are used.  
  
 When WS-Addressing is disabled and an incoming request does not contain an action parameter, message `Action` is considered not specified.  
  
## WS-Addressing  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements 3 versions of WS-Addressing:  
  
-   WS-Addressing 2004/08  
  
-   W3C Web Services Addressing 1.0 Core  (ADDR10-CORE) and SOAP Binding (ADDR10-SOAP)  
  
-   WS-Addressing 1.0 - Metadata  
  
### Endpoint References  
 All versions of WS-Addressing that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements use endpoint references to describe endpoints.  
  
#### Endpoint References and WS-Addressing Versions  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements a number of the infrastructure protocols that use WS-Addressing and in particular the `EndpointReference` element and `W3C.WsAddressing.EndpointReferenceType` class (for example, WS-ReliableMessaging, WS-SecureConversation, and WS-Trust). [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports the use of either version of WS-Addressing with other infrastructure protocols. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoints support one version of WS-Addressing per endpoint.  
  
 For R3111, the namespace for the `EndpointReference` element or type used in messages exchanged with a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint must match the version of WS-Addressing implemented by this endpoint.  
  
 For example, if a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint implements WS-ReliableMessaging, the `AcksTo` header returned by such an endpoint inside `CreateSequenceResponse` uses the WS-Addressing version that the `EncodingBinding` element specifies for this endpoint.  
  
#### Endpoint References and Metadata  
 A number of scenarios require communicating metadata or a reference to metadata for a given endpoint.  
  
 B3121: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] employs mechanisms described in the WS-MetadataExchange (MEX) specification Section 6 to include metadata for endpoint references by value or by reference.  
  
 Consider a scenario where a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service requires authentication using a Security Assertions Markup Language (SAML) token issued by the token issuer at http://sts.fabrikam123.com. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint describes this authentication requirement by using `sp:IssuedToken` assertion with a nested `sp:Issuer` assertion pointing to the token issuer. Client applications that access the `sp:Issuer` assertion need to know how to communicate with the token issuer endpoint. The client needs to know metadata about the token issuer. Using the endpoint reference metadata extensions defined in MEX, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides a reference to the token issuer metadata.  
  
```xml  
<sp:IssuedToken>  
  <sp:Issuer>  
    <wsa10:Address>  
      http://sts.fabrikam123.com  
    </wsa10:Address>  
    <wsa10:Metadata>  
      <mex:Metadata>  
        <mex:MetadataSection>  
          <mex:MetadataReference>  
            <wsa10:Address>  
              http://sts.fabrikam123.com/mex  
            </wsa10:Address>  
          </mex:MetadataReference>  
        </mex:MetadataSection>  
      </mex:Metadata>  
    </wsa10:Metadata>  
  </sp:Issuer>  
</sp:IssuedToken>  
```  
  
### Message Addressing Headers  
  
#### Message Headers  
 For both WS-Addressing versions, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the following message headers as prescribed by the specifications `wsa:To`, `wsa:ReplyTo`, `wsa:Action`, `wsa:MessageID`,and `wsa:RelatesTo`.  
  
 B3211: For all WS-Addressing versions, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] honors, but does not produce out of the box, WS-Addressing message headers `wsa:FaultTo` and `wsa:From`.  
  
 Applications that interact with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications can add these message headers and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] will process them accordingly.  
  
#### Reference Parameters and Properties  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements processing of endpoint reference parameters and reference p  
  
 roperties in accordance with respective specifications.  
  
 B3221: When configured to use WS-Addressing 2004/08, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoints do not differentiate between processing Reference Properties and Reference Parameters.  
  
### Message Exchange Patterns  
 The sequence of messages involved in the Web service operation invocation is referred to as the *message exchange pattern*. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports one-way, request-reply, and duplex message exchange patterns. This section clarifies WS-Addressing requirements on message processing depending on the message exchange pattern being used.  
  
 Throughout this section, the requester sends the first message and the responder receives the first message.  
  
#### One-Way Message  
 When a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint is configured to support messages with a given `Action` to follow a one-way pattern, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint follows the following behaviors and requirements. Unless otherwise specified, behaviors and rules apply for both versions of WS-Addressing supported in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]:  
  
-   R3311: The requester must include `wsa:To`, `wsa:Action`, and headers for all reference parameters specified by the endpoint reference. When WS-Addressing 2004/08 is used and [reference properties] are specified by the endpoint reference, the corresponding headers must be added to the message too.  
  
-   B3312: The requester may include `MessageID`, `ReplyTo`, and `FaultTo` headers. The receiver infrastructure will ignore them, and they will be passed to the application.  
  
-   R3313: When HTTP is used and no message is being sent on the HTTP response leg, the responder must send an HTTP response with an empty body and an HTTP 202 status code.  
  
     When the HTTP transport is in use and the operation contract declares a message one-way, the HTTP response can still be used for sending infrastructure messages—for example, reliable messaging can send a `SequenceAcknowledgement` message on an HTTP response.  
  
-   B3314: The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] responder does not send a fault message in response to a one-way message.  
  
#### Request-Reply  
 When a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint is configured for a message with a given `Action` to follow the request-reply pattern, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint follows the behaviors and requirements below. Unless specified otherwise, behaviors and rules apply for both versions of WS-Addressing supported in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]:  
  
-   R3321: The requester must include in the request `wsa:To`, `wsa:Action`, `wsa:MessageID`, and headers for all reference parameters or reference properties (or both) specified by the endpoint reference.  
  
-   R3322: When WS-Addressing 2004/08 is used, `ReplyTo` must also be included in the request.  
  
-   R3323: When WS-Addressing 1.0 is used and `ReplyTo` is not present in the request, a default endpoint reference with the [address] property equal to "http://www.w3.org/2005/08/addressing/anonymous" is used.  
  
-   R3324: The requester must include `wsa:To`, `wsa:Action`, and `wsa:RelatesTo` headers in the reply message, as well as headers for all reference parameters or reference properties (or both) specified by the `ReplyTo` endpoint reference in the request.  
  
### Web Services Addressing Faults  
 R3411: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] produces the following faults defined by WS-Addressing 2004/08.  
  
|Code|Cause|  
|----------|-----------|  
|wsa:DestinationUnreachable|The message arrived with a `ReplyTo` that is different from the reply address established for this channel; there is no endpoint listening at the address specified in the To header.|  
|wsa:ActionNotSupported|the infrastructure channels or dispatcher associated with the endpoint do not recognize the action specified in the `Action` header.|  
  
 R3412: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] produces the following faults defined by WS-Addressing 1.0.  
  
|Code|Cause|  
|----------|-----------|  
|wsa10:InvalidAddressingHeader|Duplicate `wsa:To`, `wsa:ReplyTo`, `wsa:From` or `wsa:MessageID`. Duplicate `wsa:RelatesTo` with the same `RelationshipType`.|  
|wsa10:MessageAddressingHeaderRequired|The required Addressing header is missing.|  
|wsa10:DestinationUnreachable|The message arrived with a `ReplyTo` that is different from the reply address established for this channel. There is no endpoint listening at the address specified in the To header.|  
|wsa10:ActionNotSupported|An action specified in the `Action` header is not recognized by the infrastructure channels or dispatcher associated with the endpoint.|  
|wsa10:EndpointUnavailable|The RM channel sends this fault back, indicating the endpoint will not process the sequence based upon examination of the `CreateSequence` message’s addressing headers.|  
  
 Code in the preceding tables maps to `FaultCode` in SOAP 1.1 and `SubCode` (with Code=Sender) in SOAP 1.2.  
  
### WSDL 1.1 Binding and WS-Policy Assertions  
  
#### Indicating Use of WS-Addressing  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses policy assertions to indicate endpoint support for a particular WS-Addressing version.  
  
 The following policy assertion has Endpoint Policy Subject [WS-PA] and indicates messages sent and received from the endpoint must use WS-Addressing 2004/08.  
  
```xml  
<wsap:UsingAddressing />  
```  
  
 This policy assertion augments the WS-Addressing 2004/08 specification.  
  
 The following policy assertion this indicates that messages sent/received must use WS-Addressing 1.0.  
  
```xml
<wsam:Addressing/>   
```  
  
 The following policy assertion has an Endpoint Policy Subject [WS-PA] and indicates that messages sent and received from the endpoint must use WS-Addressing 2004/08.  
  
```xml  
<wsaw10:UsingAddressing />  
```  
  
 The `wsaw10:UsingAddressing` element is borrowed from [WS-Addressing-WSDL] and is used in the context of WS-Policy in compliance with that specification, section 3.1.2.  
  
 Use of Addressing does not alter the semantics of WSDL 1.1, SOAP 1.1, and SOAP 1.2 HTTP Bindings. For example, if a reply is expected to a request that is sent to an endpoint that uses Addressing and WSDL SOAP 1.x HTTP binding, the reply must be sent by using the HTTP response.  
  
 For replies sent over the http response, the WS-AM assertion is:  
  
```xml  
<wsam:AnonymousResponses/>  
```  
  
 The complete policy assertion might look like this:  
  
```xml  
<wsam:Addressing>  
    <wsp:Policy>  
        <wsam:AnonymousResponses />   
    </wsp:Policy>  
</wsam:Addressing>  
```  
  
 However, there are message exchange patterns that benefit from having two independent converse HTTP connections established between the requester and the responder, for example, unsolicited one-way messages sent by the responder.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] offers a feature by which two underlying transport channels can form a Composite Duplex channel, where one channel is used for input messages and the other is used for output messages. In the case of the HTTP Transport, Composite Duplex provides two converse HTTP connections. The requester uses one connection to send messages to the responder, and the responder uses the other to send messages back to the requester.  
  
 For replies sent over separate http requests, the ws-am assertion is  
  
```xml  
<wsam:NonAnonymousResponses/>  
```  
  
 The complete policy assertion might look like this:  
  
```xml  
<wsam:Addressing>  
    <wsp:Policy>  
      <wsam:NonAnonymousResponses />   
   </wsp:Policy>  
  </wsam:Addressing>  
```  
  
 Use of the following assertion that has Endpoint Policy Subject [WS-PA] on endpoints that use WSDL 1.1 SOAP 1.x HTTP bindings requires two separate converse HTTP connections to be used for messages flowing from requester to responder and responder to requester, respectively.  
  
```xml  
<cdp:CompositeDuplex/>  
```  
  
 The previous statement leads to the following requirements on the `wsa:ReplyTo` header for request messages:  
  
-   R3514: Request messages sent to an endpoint must have a `ReplyTo` header with the `[address]` property not equal to "http://www.w3.org/2005/08/addressing/anonymous" if the endpoint uses a WSDL 1.1 SOAP 1.x HTTP binding and has a policy alternative with a `wsap10:UsingAddressing` or `wsap:UsingAddressing` assertion coupled with `cdp:CompositeDuplex` attached.  
  
-   R3515: Request messages sent to an endpoint must have a `ReplyTo` header with the `[address]` property equal to "http://www.w3.org/2005/08/addressing/anonymous", or not have a `ReplyTo` header at all, if the endpoint uses a WSDL 1.1 SOAP 1.x HTTP binding and has a policy alternative with `wsap10:UsingAddressing` assertion and no `cdp:CompositeDuplex` assertion attached.  
  
-   R3516: Request messages sent to an endpoint must have a `ReplyTo` header with an `[address]` property equal to "http://www.w3.org/2005/08/addressing/anonymous" if the endpoint uses a WSDL 1.1 SOAP 1.x HTTP binding and has a policy alternative with `wsap:UsingAddressing` assertion and no `cdp:CompositeDuplex` assertion attached.  
  
 The WS-addressing WSDL specification attempts to describe similar protocol bindings by introducing an element `<wsaw:Anonymous/>` with three textual values (required, optional, and prohibited) to indicate requirements on the `wsa:ReplyTo` header (section 3.2). Unfortunately, such element definition is not particularly usable as an assertion in the context of WS-Policy, because it requires domain-specific extensions to support the intersection of alternatives using such an element as an assertion. Such element definition also indicates the value of the `ReplyTo` header as opposed to the endpoint behavior on the wire, which makes it specific to HTTP transport.  
  
#### Action Definition  
 WS-Addressing 2004/08 defines a `wsa:Action` attribute for the `wsdl:portType/wsdl:operation/[wsdl:input | wsdl:output | wsdl:fault]` elements. WS-Addressing 1.0 WSDL Binding (WS-ADDR10-WSDL) defines a similar attribute, `wsaw10:Action`.  
  
 The only difference between the two is the default Action pattern semantics described in section 3.3.2 of WS-ADDR and section 4.4.4 of WS-ADDR10-WSDL, respectively.  
  
 It is a reasonable to have two endpoints that share the same `portType` (or contract, in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] terminology) but using different versions of WS-Addressing. But given that Action is defined by the `portType` and should not change across the endpoints that implement the `portType`, it becomes impossible to support both default action patterns.  
  
 To resolve this controversy, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports a single version of the `Action` attribute.  
  
 B3521: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the `wsaw10:Action` attribute on `wsdl:portType/wsdl:operation/[wsdl:input | wsdl:output | wsdl:fault]` elements as defined in WS-ADDR10-WSDL to determine the `Action` URI for the corresponding messages irrespective of the WS-Addressing version used by the endpoint.  
  
#### Use Endpoint Reference Inside WSDL Port  
 WS-ADDR10-WSDL section 4.1 extends the `wsdl:port` element to include the `<wsa10:EndpointReference…/>` child element to describe the endpoint in WS-Addressing terms. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] expands this utility on WS-Addressing 2004/08, allowing `<wsa:EndpointReference…/>` to appear as a child element of `wsdl:port`.  
  
-   R3531: If an endpoint has an attached policy alternative with a `<wsaw10:UsingAddressing/>` policy assertion, the corresponding `wsdl:port` element can contain a child element `<wsa10:EndpointReference …/>`.  
  
-   R3532: If a `wsdl:port` contains a child element `<wsa10:EndpointReference …/>`, the `wsa10:EndpointReference/wsa10:Address` child element value must match the value of the `@address` attribute of the sibling `wsdl:port`/`wsdl:location` element.  
  
-   R3533: If an endpoint has an attached policy alternative with `<wsap:UsingAddressing/>` policy assertion, the corresponding `wsdl:port` element can contain a child element `<wsa:EndpointReference …/>`.  
  
-   R3534: If a `wsdl:port` contains a child element `<wsa:EndpointReference …/>`, the `wsa:EndpointReference/wsa:Address` child element value must match the value of the `@address` attribute of the sibling `wsdl:port`/`wsdl:location` element.  
  
### Composition with WS-Security  
 According to security consideration sections in WS-ADDR and WS-ADDR10, all addressing message headers are recommended to be signed together with the message body to bind them together.  
  
 When WS-Security is used for message integrity protection, WS-Addressing message headers as well as headers resulted from reference parameters or properties (or both) must be signed together with the body of the message.  
  
### Examples  
  
#### One-Way Message  
 In this scenario, the sender sends a one-way message to the receiver. SOAP 1.2, HTTP 1.1, and W3C WS-Addressing 1.0 are used.  
  
 The Request Message Structure: The message headers include `wsa10:To` and `wsa10:Action` elements. The message body includes a specific `<app:Ping>` element from the application namespace.  
  
 HTTP Headers: The destination in POST matches the URI in the `wsa10:To` element.  
  
 The Content-Type header has the value of `application/soap+xml` as required by SOAP 1.2. Parameters `charset` and `action` are included. The `action` parameter of the Content-Type header matches the value of the `wsa10:Action` message header.  
  
```  
POST http://fabrikam123.com/Service HTTP/1.1  
Content-Type: application/soap+xml; charset=utf-8;    
              action="http://fabrikam123.com/Service/OneWay"  
Host: 131.107.72.15  
Content-Length: 1501  
Expect: 100-continue  
Proxy-Connection: Keep-Alive  
<s12:Envelope>  
  <s12:Header>  
    <wsa10:To s12:mustUnderstand="1">  
        http://fabrikam123.com/Service  
    </wsa10:To>  
    <wsa10:Action s12:mustUnderstand="1">  
        http://fabrikam123.com/Service/OneWay   
    </wsa10:Action>  
  </s12:Header>  
  <s12:Body>  
    <Ping xmlns="http://fabrikam123.com/Service/">  
      <Text>Hello World</Text>  
    </Ping>  
  </s12:Body>  
</s12:Envelope>  
```  
  
 The receiver responds with an empty HTTP response and status 202. An example of the HTTP response:  
  
```  
HTTP/1.1 202 Accepted  
Date: Fri, 15 Jul 2005 08:56:07 GMT  
Server: Microsoft-IIS/6.0  
MicrosoftOfficeWebServer: 5.0_Pub  
X-Powered-By: ASP.NET  
X-AspNet-Version: 2.0.50215  
Cache-Control: private  
Content-Length: 0  
```  
  
## SOAP Message Transmission Optimization Mechanism  
 This section describes the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implementation details for the HTTP SOAP MTOM. MTOM technology is SOAP message encoding mechanism of the same class as traditional text/XML encoding or [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Binary encoding. MTOM includes the following:  
  
-   An XML encoding and packaging mechanism described by [XOP] that optimizes XML information items containing base64-encoded binary data into separate binary parts.  
  
-   A MIME encapsulation of the XOP package that serializes the XML Infoset and each binary part of the XOP package into a separate MIME part.  
  
-   A MIME XOP encoding applied to SOAP 1.x Envelope.  
  
-   An HTTP transport binding.  
  
 It is possible to use MTOM with non-HTTP transports with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. However, in this topic we will focus on HTTP.  
  
 The MTOM format leverages a large set of specifications covering MTOM itself, XOP, and MIME. Modularity of this specification set makes it somewhat difficult to reconstruct exact requirements on the format and processing semantics. This section describes the format and processing requirements for MTOM HTTP binding.  
  
### MTOM Message Encoding  
  
#### Generating MTOM messages  
 The [XOP] section 3.1 describes the process of encoding XML with element information items that contain base64 values into an abstractly defined XOP package.  
  
 The following sequence of steps describes the MTOM-specific encoding process:  
  
1.  Ensure that the SOAP Envelope to be encoded contains no element information item with a `[namespace name]` of "http://www.w3.org/2004/08/xop/include" and a `[local name]` of `Include`.  
  
2.  Create an empty MIME package.  
  
3.  Identify within the Original XML Infoset the element information items to be optimized. For the items to be optimized, the characters that make up the `[children]` of the element information item must be in the canonical form of `xs:base64Binary` (see XSD-2, 3.2.16 base64Binary) and must not contain any whitespace characters preceding, inline with, or following the non-whitespace content.  
  
4.  Create an XOP SOAP Envelope that is a copy of the Original SOAP Envelope, but with the children of each element information item identified in the previous step replaced by an `xop:Include` element information item constructed as follows:  
  
    1.  Transform the replaced characters into binary data by processing them as base64-encoded data.  
  
    2.  Generate a unique Content-ID header value that satisfies requirements R3133 and R3134.  
  
    3.  Generate a Content-Transfer-Encoding MIME header with the value binary.  
  
    4.  If the element information item being optimized (the [parent] of the newly inserted `xop:Include` element information item) has an `xmime:contentType` attribute information item, generate a Content-Type MIME header with the value of the `xmime:contentType` attribute.  
  
    5.  Generate a new binary MIME part with content formed by binary data decoded from the replaced characters processed as base64, Content-ID header from 4b, Content- Transfer-Encoding header from 4c, Content-Type header if generated in step 4d.  
  
    6.  Add an `href` attribute to the `xop:Include` element with the value cid: uri derived from Content-ID header value generated in step 4b. Remove the enclosing "\<" and ">" characters, URL-escape the remaining string, and add the prefix `cid:`. The following minimum character set is required to be escaped by RFC1738 and RFC2396. Other characters can be escaped.  
  
        ```  
        Hexadecimal 00-1F , 7F, 20, "<" | ">" | "#" | "%" | <">  
        "{" | "}" | "|" | "\" | "^" | "[" | "]" | "`" | "~" | "^"  
        ```  
  
5.  Create a root MIME part with the XOP SOAP Envelope from step 4.  
  
6.  Write the HTTP headers, including the HTTP Content-Type header.  
  
7.  Write the MIME package.  
  
#### Processing MTOM messages  
 Processing of an MTOM message is the exact reverse of the process described in the preceding "Generating MTOM messages" section:  
  
1.  Ensure the root MIME part has the Content-Type `application/xop+xml`.  
  
2.  Construct a SOAP Envelope by parsing the root MIME part of the package as an XML document. Character encoding is determined by the `charset` parameter of the Content-Type of the root MIME part.  
  
3.  For each element information item in the constructed SOAP Envelope, which has, as the sole member of its [children] property, an `xop:Include` element information item:  
  
    1.  Remove the `cid:` prefix and unescape all URI-escape sequences (RFC 2396) in the value of the `@href` attribute of the `xop:Include` element. Enclose the result string in "\<", ">".  
  
    2.  Locate the MIME part with the Content-ID header value that matches the string derived in step 3a.  
  
    3.  Replace the `xop:Include` element information item that appears in the `children` property of each item with the character information items that represent the canonical base64 encoding (see XSD-2, 3.2.16 base64Binary) of the entity body of the MIME part identified in step 3b (effectively replace the `xop:Include` element information item with the data reconstructed from the package part).  
  
#### HTTP Content-Type Header  
 The following is a list of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clarifications for the format of the HTTP Content-Type header of a SOAP 1.x MTOM-encoded message derived from requirements stated in the MTOM specification itself and are derived from MTOM and RFC 2387.  
  
-   R4131: An HTTP Content-Type header must have the value of multipart/related (case-insensitive) and its parameters. Parameter names are case-insensitive. Parameter order is not significant.  
  
-   The full Backus-Naur Form (BNF) of the Content-Type header for MIME messages is listed in RFC 2045, section 5.1.  
  
-   R4132: An HTTP Content-Type header must have a type parameter with the value `application/xop+xml` enclosed in double quotation marks.  
  
 While the requirement to use double quotation marks is not explicit in RFC 2387, the text observes that all of the multipart/related media type parameters most likely contain reserved characters like "@" or "/" and therefore need double quotation marks.  
  
-   R4133: An HTTP Content-Type header should have a start parameter with the value of the Content-ID header of the MIME part that contains the SOAP 1.x Envelope, enclosed in double quotation marks. If the start parameter is omitted, the first MIME part must contain the SOAP 1.x Envelope.  
  
-   R4134: An HTTP Content-Type header for a SOAP 1.1 MTOM encoded message must include the start-info parameter with the value of text/xml, enclosed in double quotation marks.  
  
-   R4135: An HTTP Content-Type header for a SOAP 1.2 MTOM-encoded message must include the start-info parameter with the value of `application/soap+xml`, enclosed in double quotation marks.  
  
-   R4136: HTTP Content-Type header for a SOAP 1.x MTOM-encoded message must have the boundary parameter with the value (enclosed in double quotation marks) that matches the MIME boundary BNF defined in RFC 2046, section 5.1.1  
  
    ```  
    boundary := 0*69<bchars> bcharsnospace   
    bchars := bcharsnospace / " "   
    bcharsnospace :=    DIGIT / ALPHA / "'" / "(" / ")" / "+"   
                        / "_" / "," / "-" / "." / "/" / ":" / "=" / "?"  
    ```  
  
     Examples:  
  
     CORRECT  
  
    ```  
    Content-Type: multipart/related; type="application/xop+xml";start=" <part0@tempuri.org>";boundary="uuid:0ca0e16e-feb1-426c-97d8-c4508ada5e82+id=1";start-info="text/xml"  
    ```  
  
     CORRECT  
  
    ```  
    Content-Type: Multipart/Related; type="application/xop+xml";start-info="text/xml";boundary="uuid:0ca0e16e-feb1-426c-97d8-c4508ada5e82+id=1"  
    ```  
  
     INCORRECT  
  
    ```  
    Content-Type: Multipart/Related; type=application/xop+xml;start=" <part0@tempuri.org>";start-info="text/xml";boundary="uuid:0ca0e16e-feb1-426c-97d8-c4508ada5e82+id=1"   
    ```  
  
#### Infoset MIME Part  
 The SOAP 1.x Envelope is encapsulated as a root part of the XOP MIME package and is often called the `infoset` part.  
  
-   R4141: The SOAP 1.x Envelope must be encapsulated as a root part of the XOP MIME package, called the `infoset` part and referenced from the HTTP Content-Type.  
  
-   R4142: The SOAP `Infoset` part must include the following MIME headers: `Content-ID`, `Content-Transfer-Encoding`, and `Content-Type`.  
  
 The format of the Content-ID header is defined by RFC 2045 as  
  
```  
"Content-ID" ":" msg-id  
```  
  
 where `msg-id` is defined in RFC 2822 (that supersedes RFC 822, referenced in RFC 2045) as:  
  
```  
msg-id    =       [CFWS] "<" id-left "@" id-right ">" [CFWS]  
```  
  
 and is effectively an email address enclosed within "\<" and  ">". The `[CFWS]` prefix and suffix were added in RFC 2822 to carry comments and should not be used to preserve interoperability.  
  
 R4143: The value of the Content-ID header for the Infoset MIME part must follow `msg-id` production from RFC 2822 with the `[CFWS]` prefix and suffix parts omitted.  
  
 A number of MIME implementations relaxed requirements for the value enclosed within "\<" and ">" to be an email address and used `absoluteURI` enclosed in "\<" , ">" in addition to the email address. This version of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses values of the Content-ID MIME header of the form:  
  
```  
Content-ID: <http://tempuri.org/0>   
```  
  
 R4144: MTOM processors should accept Content-ID header values that match the following relaxed `msg-id`.  
  
```  
msg-id-relaxed =     [CFWS] "<" (absoluteURI | mail-address) ">" [CFWS]  
mail-address   =     id-left "@" id-right  
```  
  
 MIME (RFC 2045) provides the Content-Transfer-Encoding header to communicate encoding of the content of the MIME part. The default defined for Content-Transfer-Encoding is 7-bit, which is not suitable for most SOAP messages, so the Content-Transfer-Encoding header is needed for greater interoperability:  
  
-   R4145: The SOAP Infoset part must contain the Content-Transfer-Encoding header.  
  
-   R4146: If the SOAP Envelope character encoding is UTF-8, the value of the Content-Transfer-Encoding header must be 8-bit.  
  
-   R4147: If the SOAP Envelope character encoding is UTF-16, the value of the Content-Transfer-Encoding header must be binary.  
  
-   According to [XOP] section 5,  
  
-   R4148: SOAP1.1 Infoset part must contain Content-Type header with media type application/xop+xml and parameters type="text/xml" and charset  
  
    ```  
    Content-Type: application/xop+xml;  
                  charset=utf-8;type="text/xml"  
    ```  
  
-   R4149: The SOAP 1.2 Infoset part must contain the Content-Type header with media type `application/xop+xml` and parameters type="`application/soap+xml`" and `charset`.  
  
    ```  
    Content-Type: application/xop+xml;  
                  charset=utf-8;type="application/soap+xml"  
    ```  
  
     While XOP defines the `charset` parameter for `application/xop+xml` to be optional, it is needed for interoperability similar to the BP 1.1 requirement on the `charset` parameter for the `text/xml` media type.  
  
-   R41410: The `type` and `charset` parameters must be present on the Content-Type header of the SOAP 1.x Infoset part.  
  
#### WCF Endpoint Support for MTOM  
 The purpose of MTOM is to encode a SOAP message to optimize base64-encoded data. The following is a list of constraints:  
  
-   R4151: Any element information item that contains base64-encoded data may be optimized.  
  
-   B4152: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] optimizes element information items that contain base64-encoded data and exceed 1024 bytes in length.  
  
 A [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint configured to use MTOM will always send MTOM-encoded messages. Even if no parts meet the required criteria, the message is still MTOM-encoded (serialized as a MIME package with a single MIME part containing the SOAP envelope).  
  
### WS-Policy Assertion for MTOM  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the following policy assertion to indicate MTOM usage by endpoint:  
  
```xml  
<wsoma:OptimizedMimeSerialization ... />  
```  
  
-   R4211: The preceding policy assertion has an Endpoint Policy Subject and specifies that all messages sent to and received from the endpoint must be optimized using MTOM.  
  
-   B4212: When configured to use MTOM optimization, an [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint adds an MTOM Policy assertion to the policy attached to the corresponding `wsdl:binding`.  
  
### Composition with WS-Security  
 MTOM is an encoding mechanism that is similar to `text/xml` and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Binary XML. MTOM offers natural composition with WS-Security and other WS-* protocols: a message secured using WS-Security can be optimized using MTOM.  
  
### Examples  
  
#### WCF SOAP 1.1 Message Encoded Using MTOM  
  
```  
POST http://131.107.72.15/Mtom/svc/service.svc/Soap11MtomUTF8 HTTP/1.1  
SOAPAction: "http://xmlsoap.org/echoBinaryAsString"  
Content-Type: multipart/related;type="application/xop+xml";  
              start="<http://tempuri.org/0>";start-info="text/xml";  
       boundary="uuid:0ca0e16e-feb1-426c-97d8-c4508ada5e82+id=1"  
Host: 131.107.72.15  
Content-Length: 1501  
--uuid:0ca0e16e-feb1-426c-97d8-c4508ada5e82+id=1  
Content-ID: <http://tempuri.org/0>  
Content-Transfer-Encoding: 8bit  
Content-Type: application/xop+xml;charset=utf-8;type="text/xml"  
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">  
  <s:Body>  
    <EchoBinaryAsString xmlns="http://xmlsoap.org/Ping">  
      <array>  
        <xop:Include   
         href="cid:http%3A%2F%2Ftempuri.org%2F1%2F632618206521093670"   
         xmlns:xop="http://www.w3.org/2004/08/xop/include"/>  
      </array>  
    </EchoBinaryAsString>  
  </s:Body>  
</s:Envelope>  
--uuid:0ca0e16e-feb1-426c-97d8-c4508ada5e82+id=1  
Content-ID: <http://tempuri.org/1/632618206521093670>  
Content-Transfer-Encoding: binary  
Content-Type: application/octet-stream  
…Binary Content..  
--uuid:0ca0e16e-feb1-426c-97d8-c4508ada5e82+id=1  
```  
  
#### WCF Secure SOAP 1.2 Message Encoded Using MTOM  
 In this example, a message is encoded using MTOM and SOAP 1.2 that is protected using WS-Security. The binary parts identified for encoding are the contents of the `BinarySecurityToken`, `CipherValue` of the `EncryptedData` corresponding to the encrypted signature and encrypted body. Note that the `CipherValue` of the `EncryptedKey` was not identified for optimization by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], because its length is less then 1024 bytes.  
  
```  
POST http://131.107.72.15/Mtom/service.svc/Soap12MtomSecureSignEncrypt HTTP/1.1  
Content-Type: multipart/related; type="application/xop+xml";  
              start="<http://tempuri.org/0>";  
            boundary="uuid:0ca0e16e-feb1-426c-97d8-c4508ada5e82+id=3";  
              start-info="application/soap+xml";   
              action="http://xmlsoap.org/echoBinaryAsString"  
Host: 131.107.72.15  
Content-Length: 1941  
--uuid:0ca0e16e-feb1-426c-97d8-c4508ada5e82+id=3  
Content-ID: <http://tempuri.org/0>  
Content-Transfer-Encoding: 8bit  
Content-Type: application/xop+xml;charset=utf-8;type="application/soap+xml"  
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" xmlns:u="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd">  
  <s:Header>  
    <o:Security s:mustUnderstand="1" xmlns:o="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd">  
      <u:Timestamp u:Id="uuid-4d4ee765-5717-4d53-9ac9-99bddc07df6c-5">  
        <u:Created>2005-09-09T06:57:32.488Z</u:Created>  
        <u:Expires>2005-09-09T07:02:32.488Z</u:Expires>  
      </u:Timestamp>  
      <o:BinarySecurityToken u:Id="uuid-4d4ee765-5717-4d53-9ac9-99bddc07df6c-2" ValueType="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3" EncodingType="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary">  
        <xop:Include href="cid:http%3A%2F%2Ftempuri.org%2F1%2F632618206525089430" xmlns:xop="http://www.w3.org/2004/08/xop/include"/>  
      </o:BinarySecurityToken>  
      <e:EncryptedKey Id="_1" xmlns:e="http://www.w3.org/2001/04/xmlenc#">  
        <e:EncryptionMethod Algorithm="http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p"/>  
        <KeyInfo xmlns="http://www.w3.org/2000/09/xmldsig#">  
          <o:SecurityTokenReference>  
            <o:KeyIdentifier ValueType="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509SubjectKeyIdentifier">Xeg55vRyK3ZhAEhEf+YT0z986L0=</o:KeyIdentifier>  
          </o:SecurityTokenReference>  
        </KeyInfo>  
        <e:CipherData>          <e:CipherValue>oQfpxwT8/SAGyZQzKE2b4yO6dXuQj7pwJ+5CGL3Rf7C06bQ5ttMoQ9GLJcQYkXTzin+WwHEgs5bj5ml9HKTW9QAU5JJ6lksdymmQvWP5ZtGPBVchO4sofEGoCKmBiZL/DYS/cnbzgnc/3a6NYnc10y2fWGaGLiqa00zijAw7o0Y=</e:CipherValue>  
        </e:CipherData>  
      </e:EncryptedKey>  
      <c:DerivedKeyToken u:Id="_2" xmlns:c="http://schemas.xmlsoap.org/ws/2005/02/sc">  
        <o:SecurityTokenReference>  
          <o:Reference URI="#_1"/>  
        </o:SecurityTokenReference>  
        <c:Nonce>OrEPRX7fISIS4sXYWPMv3g==</c:Nonce>  
      </c:DerivedKeyToken>  
      <e:ReferenceList xmlns:e="http://www.w3.org/2001/04/xmlenc#">  
        <e:DataReference URI="#_3"/>  
        <e:DataReference URI="#_4"/>  
      </e:ReferenceList>  
      <e:EncryptedData Id="_4" Type="http://www.w3.org/2001/04/xmlenc#Element" xmlns:e="http://www.w3.org/2001/04/xmlenc#">  
        <e:EncryptionMethod Algorithm="http://www.w3.org/2001/04/xmlenc#aes256-cbc"/>  
        <KeyInfo xmlns="http://www.w3.org/2000/09/xmldsig#">  
          <o:SecurityTokenReference>  
            <o:Reference URI="#_2"/>  
          </o:SecurityTokenReference>  
        </KeyInfo>  
        <e:CipherData>  
          <e:CipherValue>  
            <xop:Include href="cid:http%3A%2F%2Ftempuri.org%2F2%2F632618206525089430" xmlns:xop="http://www.w3.org/2004/08/xop/include"/>  
          </e:CipherValue>  
        </e:CipherData>  
      </e:EncryptedData>  
    </o:Security>  
  </s:Header>  
  <s:Body u:Id="_0">  
    <e:EncryptedData Id="_3" Type="http://www.w3.org/2001/04/xmlenc#Content" xmlns:e="http://www.w3.org/2001/04/xmlenc#">  
      <e:EncryptionMethod Algorithm="http://www.w3.org/2001/04/xmlenc#aes256-cbc"/>  
      <KeyInfo xmlns="http://www.w3.org/2000/09/xmldsig#">  
        <o:SecurityTokenReference xmlns:o="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd">  
          <o:Reference URI="#_2"/>  
        </o:SecurityTokenReference>  
      </KeyInfo>  
      <e:CipherData>  
        <e:CipherValue>  
          <xop:Include href="cid:http%3A%2F%2Ftempuri.org%2F3%2F632618206525089430" xmlns:xop="http://www.w3.org/2004/08/xop/include"/>  
        </e:CipherValue>  
      </e:CipherData>  
    </e:EncryptedData>  
  </s:Body>  
</s:Envelope>  
--uuid:0ca0e16e-feb1-426c-97d8-c4508ada5e82+id=3  
Content-ID: <http://tempuri.org/1/632618206525089430>  
Content-Transfer-Encoding: binary  
Content-Type: application/octet-stream  
...Binary content of BinarySecurityToken - X509 Certificate...  
--uuid:0ca0e16e-feb1-426c-97d8-c4508ada5e82+id=3  
Content-ID: <http://tempuri.org/2/632618206525089430>  
Content-Transfer-Encoding: binary  
Content-Type: application/octet-stream  
...Binary serialization of the encrypted primary signature...  
--uuid:0ca0e16e-feb1-426c-97d8-c4508ada5e82+id=3  
Content-ID: <http://tempuri.org/3/632618206525089430>  
Content-Transfer-Encoding: binary  
Content-Type: application/octet-stream  
...Binary serialization of the encrypted Body...  
--uuid:0ca0e16e-feb1-426c-97d8-c4508ada5e82+id=3--  
```
