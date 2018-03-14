---
title: "Reliable Messaging Protocol version 1.0"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a5509a5c-de24-4bc2-9a48-19138055dcce
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Reliable Messaging Protocol version 1.0
This topic covers [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] implementation details for the WS-Reliable Messaging February 2005 (version 1.0) protocol necessary for interoperation using the HTTP transport. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] follows the WS-Reliable Messaging specification with the constraints and clarifications explained in this topic. Note that the WS-ReliableMessaging version 1.0 protocol is implemented starting with the [!INCLUDE[vstecwinfx](../../../../includes/vstecwinfx-md.md)].  
  
 The WS-Reliable Messaging February 2005 protocol is implemented in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] by the <xref:System.ServiceModel.Channels.ReliableSessionBindingElement>.  
  
 For convenience, the topic uses the following roles:  
  
-   Initiator: the client that initiates WS-Reliable Message sequence creation  
  
-   Responder: the service that receives the initiator's requests  
  
 This document uses the prefixes and namespaces in the following table.  
  
|Prefix|Namespace|  
|------------|---------------|  
|wsrm|http://schemas.xmlsoap.org/ws/2005/02/rm|  
|netrm|http://schemas.microsoft.com/ws/2006/05/rm|  
|s|http://www.w3.org/2003/05/soap-envelope|  
|wsa|http://schemas.xmlsoap.org/ws/2005/08/addressing|  
|wsse|http://docs.oasis-open.org/wss/2004/01/oasis-200401-wssecurity-secext-1.0.xsd|  
  
## Messaging  
  
### Sequence Establishment Messages  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements `CreateSequence` and `CreateSequenceResponse` messages to establish a reliable message sequence. The following constraints apply:  
  
-   B1101: The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator does not generate the optional Expires element in the `CreateSequence` message or, in the cases when the `CreateSequence` message contains an `Offer` element, the optional `Expires` element in the `Offer` element.  
  
-   B1102: When accessing the `CreateSequence` message, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]`Responder` sends and receives both `Expires` elements if they exist, but does not use their values.  
  
 WS-Reliable Messaging introduces the `Offer` mechanism to establish the two converse correlated sequences that form a session.  
  
-   R1103: If `CreateSequence` contains an `Offer` element, the Reliable Messaging Responder must either accept the sequence and respond with `CreateSequenceResponse` that contains a `wsrm:Accept` element, forming two correlated converse sequences or reject the `CreateSequence` request.  
  
-   R1104: `SequenceAcknowledgement` and application messages flowing on converse sequence must be sent to the `ReplyTo` endpoint reference of the `CreateSequence`.  
  
-   R1105: `AcksTo` and `ReplyTo` endpoint references in the `CreateSequence` must have address values that match the octet-wise.  
  
     The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder verifies that the URI portion of the `AcksTo` and `ReplyTo` EPRs are identical before creating a sequence.  
  
-   R1106: `AcksTo` and `ReplyTo` Endpoint References in the `CreateSequence` should have the same set of reference parameters.  
  
     [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not enforce but assumes that [reference parameters] of `AcksTo` and `ReplyTo` on `CreateSequence` are identical and uses [reference parameters] from `ReplyTo` endpoint reference for acknowledgements and converse sequence messages.  
  
-   R1107: When two converse sequences are established using the `Offer` mechanism, `SequenceAcknowledgement` and application messages flowing on converse sequences must be sent to the `ReplyTo` endpoint reference of the `CreateSequence`.  
  
-   R1108: When two converse sequences are established using the Offer mechanism, the `[address]` property of the `wsrm:AcksTo` Endpoint Reference child element of the `wsrm:Accept` element of the `CreateSequenceResponse` must match byte-wise the destination URI of the `CreateSequence`.  
  
-   R1109: When two converse sequences are established using the `Offer` mechanism, messages sent by initiator and acknowledgements to messages by responder must be sent to the same Endpoint Reference.  
  
     [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses WS-Reliable Messaging to establish reliable sessions between the Initiator and Responder. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]'s WS-Reliable Messaging implementation provides reliable session for one-way, request-reply and full duplex messaging patterns. The WS-Reliable Messaging `Offer` mechanism on `CreateSequence`/`CreateSequenceResponse` lets you establish two correlated converse sequences, and provides a session protocol that is suitable for all message endpoints. Because [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides a security guarantee for such a session including end-to-end protection for session integrity, it is practical to ensure messages intended to the same party are arriving at the same destination. This also allows piggy-backing of sequence acknowledgements on application messages. Therefore, constraints R1104, R1105, and R1108 apply to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
 An example of a `CreateSequence` message.  
  
```xml  
<s:Envelope>  
  <s:Header>  
    <a:Action s:mustUnderstand="1">  
      http://schemas.xmlsoap.org/ws/2005/02/rm/CreateSequence  
    </a:Action>  
    <a:ReplyTo>  
      <a:Address>          
         http://Business456.com/clientA        
      </a:Address>  
    </a:ReplyTo>  
    <a:MessageID>  
      urn:uuid:addabbbf-60cb-44d3-8c5b-9e0841629a36  
    </a:MessageID>  
    <a:To s:mustUnderstand="1">  
      http://Business456.com/clientA  
    </a:To>  
  </s:Header>  
  <s:Body>  
    <wsrm:CreateSequence>  
      <wsrm:AcksTo>  
       <wsa:Address>  
         http://Business456.com/clientA  
       </wsa:Address>  
     </wsrm:AcksTo>  
     <wsrm:Offer>  
      <wsrm:Identifier>  
        urn:uuid:0afb8d36-bf26-4776-b8cf-8c91fddb5496  
      </wsrm:Identifier>  
     </wsrm:Offer>  
   </wsrm:CreateSequence>  
  </s:Body>  
</s:Envelope>  
```  
  
 An example of a `CreateSequenceResponse` message.  
  
```xml  
<s:Envelope>  
  <s:Header>  
    <a:Action s:mustUnderstand="1">  
      http://schemas.xmlsoap.org/ws/2005/02/rm/CreateSequenceResponse  
    </a:Action>  
    <a:RelatesTo>  
      urn:uuid:addabbbf-60cb-44d3-8c5b-9e0841629a36  
    </a:RelatesTo>  
    <a:To s:mustUnderstand="1">  
      http://Business456.com/clientA  
    </a:To>  
  </s:Header>  
  <s:Body>  
   <wsrm:CreateSequenceResponse>  
    <Identifier>  
     urn:uuid:eea0a36c-b38a-43e8-8c76-2fabe2d76386  
    </Identifier>  
    <Accept>  
    <AcksTo>  
      <a:Address>  
        http://BusinessABC.com/serviceA  
      </a:Address>  
    </AcksTo>  
    </Accept>  
   </wsrm:CreateSequenceResponse>  
  </s:Body>  
</s:Envelope>  
```  
  
### Sequence  
 The following is a list of constraints that apply to sequences:  
  
-   B1201:[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] generates and accesses sequence numbers no higher than `xs:long`’s maximum inclusive value, 9223372036854775807.  
  
-   B1202:[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] always generates an empty-bodied last message with the action URI of http://schemas.xmlsoap.org/ws/2005/02/rm/LastMessage.  
  
-   B1203: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] receives and delivers a message with a Sequence header that contains a `LastMessage` element as long as the action URI is not http://schemas.xmlsoap.org/ws/2005/02/rm/LastMessage.  
  
 An example of a Sequence Header.  
  
```xml  
<wsrm:Sequence>  
  <wsrm:Identifier>  
    urn:uuid:addabbbf-60cb-44d3-8c5b-9e0841629a36  
  </wsrm:Identifier>  
  <wsrm:MessageNumber>  
    10  
  </wsrm:MessageNumber>  
  <wsrm:LastMessage/>  
 </wsrm:Sequence>  
```  
  
### AckRequested Header  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses `AckRequested` Header as a keep-alive mechanism. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not generate the optional `MessageNumber` element. Upon receiving a message with an `AckRequested` header that contains the `MessageNumber` element, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] ignores the `MessageNumber` element’s value, as shown in the following example.  
  
```xml  
<wsrm:AckRequested>  
  <wsrm:Identifier>  
    urn:uuid:addabbbf-60cb-44d3-8c5b-9e0841629a36  
  </wsrm:Identifier>  
</wsrm:AckRequested>  
```  
  
### SequenceAcknowledgement Header  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses piggy-back mechanism for sequence acknowledgements provided in WS-Reliable Messaging.  
  
-   R1401: When two converse sequences are established using the `Offer` mechanism, the `SequenceAcknowledgement` header may be included in any application message transmitted to the intended recipient.  
  
-   B1402: When [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] must generate an acknowledgement prior to receiving any sequence messages (for example, to satisfy an `AckRequested` message), [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] generates a `SequenceAcknowledgement` header that contains the range 0-0, as shown in the following example.  
  
    ```xml  
    <wsrm:SequenceAcknowledgement>  
      <wsrm:Identifier>  
        urn:uuid:addabbbf-60cb-44d3-8c5b-9e0841629a36  
      </wsrm:Identifier>  
      <wsrm:AcknowledgementRange Upper="0" Lower="0"/>  
    </wsrm:SequenceAcknowledgement>  
    ```  
  
-   B1403: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not generate `SequenceAcknowledgement` headers that contain a `Nack` element but supports `Nack` elements.  
  
### WS-ReliableMessaging Faults  
 The following is a list of constraints that apply to the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implementation of WS-Reliable Messaging faults:  
  
-   B1501: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not generate `MessageNumberRollover` faults.  
  
-   B1502:[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint may generate `CreateSequenceRefused` faults as described in the specification.  
  
-   B1503:When the service endpoint reaches its connection limit and cannot process new connections, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] generates an additional `CreateSequenceRefused` fault subcode, `netrm:ConnectionLimitReached`, as shown in the following example.  
  
    ```xml  
    <s:Envelope>  
      <s:Header>  
        <wsa:Action>  
          http://schemas.xmlsoap.org/ws/2005/08/addressing/fault  
        </wsa:Action>  
      </s:Header>  
      <s:Body>  
        <s:Fault>  
          <s:Code>  
            <s:Value>  
              s:Receiver  
            </s:Value>  
            <s:Subcode>  
              <s:Value>  
                wsrm:CreateSequenceRefused  
              </s:Value>  
              <s:Subcode>  
                <s:Value>  
                  netrm:ConnectionLimitReached  
                </s:Value>  
              </s:Subcode>  
            </s:Subcode>  
          </s:Code>  
          <s:Reason>  
            <s:Text xml:lang="en">  
              [Reason]  
            </s:Text>  
          </s:Reason>  
        </s:Fault>  
      </s:Body>  
    </s:Envelope>  
    ```  
  
### WS-Addressing Faults  
 Because WS-Reliable Messaging uses WS-Addressing, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WS-Reliable Messaging implementation may generate WS-Addressing faults. This section covers the WS-Addressing faults that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] explicitly generates at the WS-Reliable Messaging layer:  
  
-   B1601:[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] generates the fault Message Addressing Header Required when one of the following is true:  
  
    -   A message is missing a `Sequence` header and an `Action` header.  
  
    -   A `CreateSequence` message is missing a `MessageId` header.  
  
    -   A `CreateSequence` message is missing a `ReplyTo` header.  
  
-   B1602:[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] generates the fault Action Not Supported in reply to a message that is missing a `Sequence` header and has an `Action` header that is not a recognized in the WS-Reliable Messaging specification.  
  
-   B1603:[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] generates the fault Endpoint Unavailable to indicate that the endpoint does not process the sequence based upon examination of the `CreateSequence` message’s addressing headers.  
  
## Protocol Composition  
  
### Composition with WS-Addressing  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports two versions of WS-Addressing: WS-Addressing 2004/08 [WS-ADDR] and W3C WS-Addressing 1.0 Recommendations [WS-ADDR-CORE] and [WS-ADDR-SOAP].  
  
 While the WS-Reliable Messaging specification mentions only WS-Addressing 2004/08, it does not restrict the WS-Addressing version to be used. The following is a list of constraints that apply to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]:  
  
-   R2101:Both WS-Addressing 2004/08 and WS-Addressing 1.0 can be used with WS-Reliable Messaging.  
  
-   R2102:A single version of WS-Addressing must be used throughout a given WS-Reliable Messaging sequence or a pair of converse sequences correlated by using the `wsrm:Offer` mechanism.  
  
### Composition with SOAP  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports use of both SOAP 1.1 and SOAP 1.2 with WS-Reliable Messaging.  
  
### Composition with WS-Security and WS-SecureConversation  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides protection for WS-Reliable Messaging sequences by using secure Transport (HTTPS), composition with WS-Security, and composition with WS-Secure Conversation. The following is a list of constraints that apply to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]:  
  
-   R2301:To protect the integrity of a WS-Reliable Messaging sequence in addition to the integrity and confidentiality of individual messages, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] requires that WS-Secure Conversation must be used.  
  
-   R2302:AWS-Secure Conversation session must be established prior to establishing WS-Reliable Messaging sequence(s).  
  
-   R2303: If the WS-Reliable Messaging sequence lifetime exceeds the WS-Secure Conversation session’s lifetime, the `SecurityContextToken` established by using WS-Secure Conversation must be renewed by using the corresponding WS-Secure Conversation Renewal binding.  
  
-   B2304:WS-Reliable Messaging sequence or a pair of correlated converse sequences are always bound to a single WS-SecureConversation session.  
  
     The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] source generates the `wsse:SecurityTokenReference` element in the element extensibility section of the `CreateSequence` message.  
  
-   R2305:When composed with WS-Secure Conversation, a `CreateSequence` message must contain the `wsse:SecurityTokenReference` element.  
  
## WS-Reliable Messaging WS-Policy Assertion  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses WS-Reliable Messaging WS-Policy Assertion `wsrm:RMAssertion` to describe endpoints capabilities. The following is a list of constraints that apply to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]:  
  
-   B3001: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] attaches `wsrm:RMAssertion` WS-Policy Assertion to `wsdl:binding` elements. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports both attachments to `wsdl:binding` and `wsdl:port` elements.  
  
-   B3002: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports the following optional properties of WS-Reliable Messaging assertion and provides control over them on the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]`ReliableMessagingBindingElement`:  
  
    -   `wsrm:InactivityTimeout`  
  
    -   `wsrm:AcknowledgementInterval`  
  
     The following is an example.  
  
    ```xml  
    <wsrm:RMAssertion>  
      <wsrm:InactivityTimeout Milliseconds="600000" />  
      <wsrm:AcknowledgementInterval Milliseconds="200" />  
    </wsrm:RMAssertion>  
    ```  
  
## Flow Control WS-Reliable Messaging Extension  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses WS-Reliable Messaging extensibility to provide optional additional tighter control over sequence message flow.  
  
 Flow control is enabled by setting the `ReliableSessionBindingElement`’s `FlowControlEnabled``bool` property to `true`. The following is a list of constraints that apply to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]:  
  
-   B4001: When Reliable Messaging Flow Control is enabled, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] generates a `netrm:BufferRemaining` element in the element extensibility of the `SequenceAcknowledgement` header.  
  
-   B4002: When Reliable Messaging Flow Control is enabled, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not require a `netrm:BufferRemaining` element to be present in `SequenceAcknowledgement` header, as shown in the following example.  
  
    ```xml  
    <wsrm:SequenceAcknowledgement>  
      <wsrm:Identifier>  
        http://fabrikam123.com/abc  
      </wsrm:Identifier>  
      <wsrm:AcknowledgementRange Upper="1" Lower="1"/>             
      <netrm:BufferRemaining>  
        8  
      </netrm:BufferRemaining>  
    </wsrm:SequenceAcknowledgement>  
    ```  
  
-   B4003: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses `netrm:BufferRemaining` to indicate how many new messages the Reliable Messaging Destination can buffer.  
  
-   B4004:The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Reliable Messaging Service throttles the number of messages transmitted when the Reliable Messaging destination application cannot receive messages quickly. The Reliable Messaging destination buffers messages and the element’s value drops to 0.  
  
-   B4005: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] generates `netrm:BufferRemaining` integer values between 0 and 4096 inclusive, and reads integer values between 0 and `xs:int`’s `maxInclusive` value 214748364 inclusive.  
  
## Message Exchange Patterns  
 This section describes [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]'s behavior when WS-Reliable Messaging is used for different Message Exchange Patterns. For each Message Exchange Pattern the following two deployments scenarios are considered:  
  
-   Non-Addressable Initiator: Initiator is behind firewall; Responder can deliver messages to Initiator only on HTTP responses.  
  
-   Addressable Initiator: Initiator and Responder both can be sent HTTP requests; in other words, two converse HTTP connections can be established.  
  
### One-way, Non-addressable Initiator  
  
#### Binding  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides a one-way message exchange pattern using one sequence over one HTTP channel. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the HTTP requests to transmit all messages from the RMS to the RMD and the HTTP response to transmit all messages from the RMD to the RMS.  
  
#### CreateSequence Exchange  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator generates a `CreateSequence` message with no offer. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder ensures the `CreateSequence` has no offer before creating a sequence. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder replies to the `CreateSequence` request with a `CreateSequenceResponse` message.  
  
#### SequenceAcknowledgement  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator processes acknowledgements on the reply of all messages except the `CreateSequence` message and fault messages. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder always generates a stand-alone acknowledgement in the response to both sequence and `AckRequested` messages.  
  
#### TerminateSequence message  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] treats `TerminateSequence` as a one-way operation, meaning the HTTP response has an empty body and HTTP 202 status code.  
  
### One Way, Addressable Initiator  
  
#### Binding  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides a one-way message exchange pattern using one sequence over an inbound and an outbound Http channel. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the HTTP requests to transmit all messages. All HTTP responses have an empty body and HTTP 202 status code.  
  
#### CreateSequence Exchange  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator generates a `CreateSequence` message with no offer. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder ensures that the `CreateSequence` has no offer before creating a sequence. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder transmits the `CreateSequenceResponse` message on an HTTP request addressed with the `ReplyTo` endpoint reference.  
  
### Duplex, Addressable Initiator  
  
#### Binding  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides a fully asynchronous two-way message exchange pattern using two sequences over an inbound and an outbound HTTP channel. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the HTTP requests to transmit all messages. All HTTP responses have an empty body and HTTP 202 status code.  
  
#### CreateSequence Exchange  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator generates a `CreateSequence` message with an offer. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder ensures that the `CreateSequence` has an offer before creating a sequence. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] sends the `CreateSequenceResponse` on the HTTP request addressed to the `CreateSequence`’s `ReplyTo` endpoint reference.  
  
#### Sequence Lifetime  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] treats the two sequences as one fully duplex session.  
  
 Upon generating a fault that faults one sequence, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] expects the remote endpoint to fault both sequences. Upon reading a fault that faults one sequence, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] faults both sequences.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can close its outbound sequence and continue to process messages on its inbound sequence. Conversely, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can process the close of the inbound sequence and continue to send messages on its outbound sequence.  
  
### Request-Reply, Non-Addressable Initiator  
  
#### Binding  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides a one-way and request-reply message exchange pattern using two sequences over one HTTP channel. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the HTTP requests to transmit the request sequence’s messages and uses the HTTP responses to transmit the reply sequence’s messages.  
  
#### CreateSequence Exchange  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator generates a `CreateSequence` message with an offer. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder ensures that the `CreateSequence` has an offer before creating a sequence. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder replies to the `CreateSequence` request with a `CreateSequenceResponse` message.  
  
#### One-way Message  
 To complete a one-way message exchange protocol successfully, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator transmits a request sequence message on the HTTP request and receives a standalone `SequenceAcknowledgement` message on the HTTP response. The `SequenceAcknowledgement` must acknowledge the message transmitted.  
  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder can reply to the request with an acknowledgement, a fault, or a response with an empty body and HTTP 202 status code.  
  
#### Two Way Messages  
 To complete a two way message exchange protocol successfully, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator transmits a request sequence message on the HTTP request and receives a reply sequence message on the HTTP response. The response must carry a `SequenceAcknowledgement` acknowledging the request sequence message transmitted.  
  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder can reply to the request with an application reply, a fault or a response with an empty body and HTTP 202 status code.  
  
 Because of the presence of one-way messages and the timing of application replies, the request sequence message’s sequence number and the response message’s sequence number have no correlation.  
  
#### Retrying Replies  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] relies on HTTP request-reply correlation for two-way message exchange protocol correlation. Because of this, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator does not stop retrying a request sequence message when the request sequence message is acknowledged but rather when the HTTP response carries an acknowledgement, user message, or fault. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder retries replies on the HTTP request leg of the request to which the reply is correlated.  
  
#### LastMessage Exchange  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator generates and transmits an empty bodied last message on the HTTP request leg. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] requires a response but ignores the actual response message. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder replies to the request sequence’s empty-bodied last message with the reply sequence’s empty-bodied last message.  
  
 If the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder receives a last message in which the action URI is not http://schemas.xmlsoap.org/ws/2005/02/rm/LastMessage, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] replies with a last message. In the case of a two-way message exchange protocol, the last message carries the application message; in the case of a one-way message exchange protocol, the last message is empty.  
  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder does not require an acknowledgement for the reply sequence’s empty-bodied last message.  
  
#### TerminateSequence Exchange  
 When all requests have received a valid reply, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator generates and transmits the request sequence’s `TerminateSequence` message on the HTTP request leg. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] requires a response but ignores the actual response message. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder replies to the request sequence’s `TerminateSequence` message with the reply sequence’s `TerminateSequence` message.  
  
 In a normal shutdown sequence, both `TerminateSequence` messages carry a full range `SequenceAcknowledgement`.  
  
### Request/Reply, Addressable Initiator  
  
#### Binding  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides a request-reply message exchange pattern using two sequences over an inbound and an outbound HTTP channel. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the HTTP requests to transmit all messages. All HTTP responses have an empty body and HTTP 202 status code.  
  
#### CreateSequence Exchange  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator generates a `CreateSequence` message with an offer. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder ensures that the `CreateSequence` has an offer before creating a sequence. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] sends the `CreateSequenceResponse` on the HTTP request addressed to the `CreateSequence`’s `ReplyTo` endpoint reference.  
  
#### Request/Reply Correlation  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator ensures all application request messages bear a `MessageId` and a `ReplyTo` endpoint reference. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Initiator applies the `CreateSequence` message’s `ReplyTo` endpoint reference on each application request message. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder requires that incoming request messages bear a `MessageId` and a `ReplyTo`. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Responder ensures that the endpoint reference’s URI of both the `CreateSequence` and all application request messages are identical.
