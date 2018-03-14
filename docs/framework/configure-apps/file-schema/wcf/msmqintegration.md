---
title: "&lt;msmqIntegration&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ab677405-1ffe-457a-803f-00c1770e51e2
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;msmqIntegration&gt;
Specifies a MSMQ transport for custom binding.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<msmqIntegration>  
  
## Syntax  
  
```xml  
<msmqIntegration>  
        customDeadLetterQueue="Uri"  
        deadLetterQueue="Custom/None/System"  
    durable="Boolean"  
    exactlyOnce="Boolean"  
    manualAddressing="Boolean"  
    maxBufferPoolSize="Integer"  
    maxImmediateRetries="Integer"  
    maxReceivedMessageSize="Integer"  
    maxRetryCycles="Integer"  
    rejectAfterLastRetry="Boolean"  
    retryCycleDelay="TimeSpan"  
    serializationFormat="XML/Binary/ActiveX/ByteArray/Stream"  
    timeToLive="TimeSpan"  
    useSourceJournal="Boolean"  
    useMsmqTracing="Boolean"  
    <msmqTransportSecurity>  
    </msmqTransportSecurity>  
</msmqIntegration>  
```  
  
## Type  
 `Type`  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|customDeadLetterQueue|A URI that indicates the location of the per-application dead letter queue, where messages that have expired or failed to be delivered to the application are transferred.<br /><br /> For messages that require ExactlyOnce assurances (that is, `exactlyOnce` is set to `true`), this attribute defaults to the system-wide transactional dead-letter queue in MSMQ.<br /><br /> For messages that require no assurances (that is, `exactlyOnce` is set to `false`), this attribute defaults to `null`.<br /><br /> The value must use the net.msmq scheme. The default is `null`.<br /><br /> If `d``eadLetterQueue` is set to `None` or `System`, then this attribute must be set to `null`. If this attribute is not `null`, then `deadLetterQueue` must be set to `Custom`.|  
|deadLetterQueue|Specifies the type of dead letter queue to use.<br /><br /> Valid values include<br /><br /> -   Custom: Custom deadletter queue.<br />-   None: No deadletter queue is to be used.<br />-   System: Use the system deadletter queue.<br /><br /> This attribute is of type DeadLetterQueue.|  
|durable|A Boolean value that specifies whether the messages processed by this binding are durable or volatile. The default is `true`.<br /><br /> A durable message survives a queue manager crash, while a volatile message does not. Volatile messages are useful when applications require lower latency and can tolerate occasional lost messages.<br /><br /> If `exactlyOnce` is set to `true`, the messages must be durable.|  
|exactlyOnce|A Boolean that specifies whether messages processed by this binding will be received exactly once. The default is `true`.<br /><br /> A message can be sent with or without assurances. An assurance enables an application to ensure that a sent message reached the receiving message queue, or if it did not, the application can determine this by reading the dead letter queue.<br /><br /> `exactlyOnce`, when set to `true`, indicates that MSMQ will ensure that a sent message is delivered to the receiving message queue once and only once, and if delivery fails, the message is sent to the dead letter queue.<br /><br /> Messages sent with `exactlyOnce` set to `true` must be sent to a transactional queue only.|  
|manualAddressing|A Boolean value that enables the user to take control of message addressing. This property is usually used in router scenarios, where the application determines which one of several destinations to send a message to.<br /><br /> When set to `true`, the channel assumes the message has already been addressed and does not add any additional information to it. The user can then address every message individually.<br /><br /> When set to `false`, the default Windows Communication Foundation (WCF) addressing mechanism automatically creates addresses for all messages.<br /><br /> The default is `false`.|  
|maxBufferPoolSize|A positive integer that specifies the maximum size of the buffer pool. The default is 524288.<br /><br /> Many parts of WCF use buffers. Creating and destroying buffers each time they are used is expensive, and garbage collection for buffers is also expensive. With buffer pools, you can take a buffer from the pool, use it, and return it to the pool once you are done. Thus the overhead in creating and destroying buffers is avoided.|  
|maxImmediateRetries|An integer that specifies the maximum number of immediate retry attempts on a message that is read from the application queue.. The default is 5.<br /><br /> If the maximum number of immediate retries for the message is attempted and the message is not consumed by the application, then the message is sent to a retry queue for retrying at some later point in time. If no retry cycles are specified, then the messages is either sent to the poison message queue, or a negative acknowledgment is sent back to the sender.|  
|maxReceivedMessageSize|A positive integer that specifies the maximum message size in bytes including headers. The sender of a message receives a SOAP fault when the message is too large for the receiver. The receiver drops the message and creates an entry of the event in the trace log. The default is 65536.|  
|maxRetryCycles|An integer that specifies the maximum number of retry cycles to attempt delivery of messages to the receiving application. The default is <xref:System.Int32.MaxValue>.<br /><br /> A single retry cycle attempts to deliver a message to an application a specified number of times. The number of attempts made is set by the `maxImmediateRetries` attribute. If the application fails to consume the message after the attempts at delivery have been exhausted, the message is sent to a retry queue. Subsequent retry cycles consist of the message being returned from the retry queue to the application queue to attempt delivery to the application again, after a delay specified by the `retryCycleDelay` attribute. The `maxRetryCycles` attribute specifies the number of retry cycles the application uses to attempt to deliver the message.|  
|rejectAfterLastRetry|A Boolean value that specifies what action to take for a message that has failed delivery after the maximum number of retries have been attempted.<br /><br /> `true` means that a negative acknowledgment is returned to the sender and the message is dropped; `false` means that the message is sent to the poison message queue. The default is `false`.<br /><br /> If the value is `false`, the receiving application can read the poison message queue to process poison messages (that is, messages that have failed delivery).<br /><br /> MSMQ 3.0 does not support returning a negative acknowledgment to the sender, so this attribute will be ignored in MSMQ 3.0.|  
|retryCycleDelay|A <xref:System.TimeSpan> that specifies the time delay between retry cycles when attempting to deliver a message that could not be delivered immediately. The default is 00:10:00.<br /><br /> A single retry cycle attempts to deliver a message to a receiving application a specified number of times. The number of attempts made is specified by the `maxImmediateRetries` attribute. If the application fails to consume the message after the specified number of immediate retries, the message is sent to a retry queue. Subsequent retry cycles consist of the message being returned from the retry queue to the application queue to attempt delivery to the application again, after a delay specified by the `retryCycleDelay` attribute. The number of retry cycles is specified by `maxRetryCycles` attribute.|  
|serializationFormat|Specifies the formatter that is used to serialize objects that are sent as part of an MSMQ message. Valid values are<br /><br /> -   ActiveX: The ActiveX formatter is used when serializing COM objects.<br />-   Binary:  Serializes the object to a binary packet.<br />-   ByteArray:  Serializes the object to an array of bytes.<br />-   Stream:  Serializes the object to a stream.<br />-   Xml:  Serializes the object to an XML packet. The default is XML.<br /><br /> This attribute is of type <xref:System.ServiceModel.MsmqIntegration.MsmqMessageSerializationFormat>.|  
|timeToLive|A <xref:System.TimeSpan> that specifies how long the messages are valid before they expired and are put in the dead-letter queue. The default is 1.00:00:00, which means 1 day.<br /><br /> This attribute is set to ensure that time-sensitive messages do not become stale before they are processed by the receiving applications. A message in a queue that is not consumed by the receiving application within the time interval specified is said to be expired. Expired messages are sent to special queue called the dead letter queue. The location of the dead letter queue is set with the `customDeadLetterQueue` attribute or to the appropriate default, based on assurances.|  
|useMsmqTracing|A Boolean value that specifies whether messages processed by this binding should be traced. The default is `false`.<br /><br /> When tracing is enabled, report messages are created and sent to the report queue each time the message leaves or arrives at a Message Queuing computer.|  
|useSourceJournal|A Boolean value that specifies whether copies of messages processed by this binding should be stored in the source journal queue. The default is `false`.<br /><br /> Queued applications that want to keep a record of messages that have left the computer's outgoing queue can copy the messages to a journal queue. Once a message leaves the outgoing queue and an acknowledgment is received that the message was received on the destination computer, a copy of the message is kept in the sending computer's system journal queue.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|msmqTransportSecurity|Specifies transport security settings for this binding. This element is of type <xref:System.ServiceModel.Configuration.MsmqTransportSecurityElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../../../docs/framework/misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## See Also  
 <xref:System.ServiceModel.Configuration.MsmqIntegrationElement>  
 <xref:System.ServiceModel.Channels.TransportBindingElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Transports](../../../../../docs/framework/wcf/feature-details/transports.md)  
 [Queues in WCF](../../../../../docs/framework/wcf/feature-details/queues-in-wcf.md)  
 [Choosing a Transport](../../../../../docs/framework/wcf/feature-details/choosing-a-transport.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)
