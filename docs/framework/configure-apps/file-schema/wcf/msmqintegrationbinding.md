---
title: "&lt;msmqIntegrationBinding&gt;"
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
  - "msmqIntegrationBinding Element"
ms.assetid: edf277f3-e3bf-4ed8-9f55-83b5788430a7
caps.latest.revision: 34
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;msmqIntegrationBinding&gt;
Defines a binding that provides queuing support by routing messages through MSMQ.  
  
 \<system.ServiceModel>  
\<bindings>  
msmqIntegrationBinding  
  
## Syntax  
  
```xml  
<msmqIntegrationBinding>  
   <binding   
       closeTimeout="TimeSpan"   
       customDeadLetterQueue="Uri"  
       deadLetterQueue="Uri"  
       durable="Boolean"  
       exactlyOnce="Boolean"   
       maxReceivedMessageSize"Integer"  
       maxRetryCycles="Integer"   
       name="string"   
       openTimeout="TimeSpan"        receiveContextEnabled="Boolean"  
       receiveErrorHandling="Drop/Fault/Move/Reject"  
       receiveTimeout="TimeSpan"   
       receiveRetryCount="Integer"  
       retryCycleDelay="TimeSpan"    
       sendTimeout="TimeSpan"   
       serializationFormat="XML/Binary/ActiveX/ByteArray/Stream">  
       timeToLive="TimeSpan"    
       useMsmqTracing="Boolean  
       useSourceJournal="Boolean"  
   </binding>  
</msmqIntegrationBinding>   
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|closeTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for a close operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|customDeadLetterQueue|A URI that contains the location of the per-application dead letter queue, where messages that have expired or that have failed transfer or delivery are placed.<br /><br /> The dead letter queue is a queue on the queue manager of the sending application for expired messages that have failed to be delivered.<br /><br /> The URI that is specified by <xref:System.ServiceModel.MsmqBindingBase.CustomDeadLetterQueue%2A> must use the net.msmq scheme.|  
|deadLetterQueue|A <xref:System.ServiceModel.MsmqBindingBase.DeadLetterQueue%2A>.value specifying which type of dead-letter queue to use, if any<br /><br /> A dead-letter queue is the location that messages that have failed to be delivered to the application will be transferred.<br /><br /> For messages that require exactlyOnce assurance (i.e., the `exactlyOnce` attribute is set to `true`), this attribute defaults to the system-wide transactional dead-letter queue in MSMQ.<br /><br /> For messages that require no assurances, this attribute defaults to `null`.|  
|durable|A Boolean value that indicates whether the message is durable or volatile in the queue. A durable message survives a queue manager crash, while a volatile message does not. Volatile messages are useful when applications require lower latency and can tolerate occasional lost messages. If the `exactlyOnce` attribute is set to `true`, the messages must be durable. The default is `true`.|  
|exactlyOnce|A Boolean value that indicates whether each message is delivered only once. The sender will then be notified of delivery failures. When `durable` is `false`, this attribute is ignored and messages are transferred without delivery assurance. The default is `true`. For more information, see <xref:System.ServiceModel.MsmqBindingBase.ExactlyOnce%2A>.|  
|maxReceivedMessageSize|A positive integer that defines the maximum message size, in bytes, including headers, that is processed by this binding. The sender of a message exceeding this limit will receive a SOAP fault. The receiver drops the message and creates an entry of the event in the trace log. The default is 65536. This bound on message size is intended to limit exposure to Denial of Service (DoS) attacks.|  
|maxRetryCycles|An integer that indicates the number of retry cycles used by the poison-message detection feature. A message becomes a poison message when it fails all delivery attempts of all cycles. The default is 2. For more information, see <xref:System.ServiceModel.MsmqBindingBase.MaxRetryCycles%2A>.|  
|name|A string that contains the configuration name of the binding. This value should be unique because it is used as an identification for the binding. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).|  
|openTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for an open operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|receiveErrorHandling|A <xref:System.ServiceModel.ReceiveErrorHandling> value that specifies how poison and nondispatchable messages are handled.|  
|receiveRetryCount|An integer that specifies the maximum number of immediate retries the queue manager should attempt if transmission of a message from the application queue to the application fails.<br /><br /> If the maximum number of delivery attempts is reached and the message is not accessed by the application, then the message is sent to a retry queue for redelivery at a later time. The amount of time before the message is transferred back to the sending queue is controlled by `retryCycleDelay`. If retry cycles reach the `maxRetryCycles` value, then the message is either sent to the poison-message queue, or a negative acknowledgement is sent back to the sender.|  
|receiveTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for a receive operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:10:00.|  
|receiveContextEnabled|A Boolean that specifies if receive context for processing messages in queues is enabled. When this is set to `true`, a service can "peek" a message on the queue to begin processing it, and, if anything goes wrong and an exception is thrown, it remains on the queue. Services can also "lock" messages in order to retry processing at a later point in time. ReceiveContext provides a mechanism for "completing" the message once processed so it can be removed from the queue.Messages are no longer being read and re-written to queues over the network, and individual messages aren’t bouncing across different service instances during processing.|  
|retryCycleDelay|A TimeSpan value that specifies the time delay between retry cycles when attempting to deliver a message that could not be delivered immediately. The value defines only the minimum wait time because actual wait time can be longer. The default value is 00:30:00. For more information, see <xref:System.ServiceModel.MsmqBindingBase.RetryCycleDelay%2A>.|  
|sendTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for a send operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|serializationFormat|Defines the format used for serialization of the message body. This attribute is of type <xref:System.ServiceModel.MsmqIntegration.MsmqMessageSerializationFormat>.|  
|timeToLive|A TimeSpan value that specifies how long the messages are valid before they are expired and put into the dead-letter queue. The default is 1.00:00:00.<br /><br /> This attribute is set to ensure that time-sensitive messages do not become stale before they are processed by the receiving applications. A message in a queue that is not consumed by the receiving application within the time interval specified is said to be expired. Expired messages are sent to special queue called the dead letter queue. The location of the dead letter queue is set with the `DeadLetterQueue` attribute or to the appropriate default, based on assurances.|  
|useMsmqTracing|A Boolean value that specifies whether messages processed by this binding should be traced. The default is `false`. When tracing is enabled, report messages are created and sent to the report queue each time the message leaves or arrives at a Message Queuing computer.|  
|useSourceJournal|A Boolean value that specifies copies of messages processed by this binding should be stored in the source journal. The default is `false`.<br /><br /> Queued applications that want to keep a record of messages that have left the computer's outgoing queue can copy the messages to a journal queue. Once a message leaves the outgoing queue and an acknowledgment is received that the message was received on the destination computer, a copy of the message is kept in the sending computer's system journal queue.|  
  
## {serializationFormat} Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Xml|XML format|  
|Binary|Binary format|  
|ActiveX|ActiveX format|  
|ByteArray|Serializes the object to an array of bytes.|  
|Stream|The body formatted as a stream|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-msmqintegrationbinding.md)|Defines the security settings for the binding. This element is of type <xref:System.ServiceModel.Configuration.MsmqIntegrationSecurityElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<bindings>](../../../../../docs/framework/configure-apps/file-schema/wcf/bindings.md)|This element holds a collection of standard and custom bindings.|  
  
## Remarks  
 This binding element can be used to enable Windows Communication Foundation (WCF) applications to send messages to and receive messages from existing MSMQ applications that use either COM, MSMQ native APIs, or the types defined in the <xref:System.Messaging?displayProperty=nameWithType> namespace You can use this configuration element to specify ways to address the queue, transfer assurances, whether messages must be durably stored, and how messages should be protected and authenticated. For more information, see [How to: Exchange Messages with WCF Endpoints and Message Queuing Applications](../../../../../docs/framework/wcf/feature-details/how-to-exchange-messages-with-wcf-endpoints-and-message-queuing-applications.md).  
  
## Example  
  
```xml  
<configuration>  
<system.ServiceModel>  
    <bindings>  
       <msmqIntegrationBinding>  
           <binding   
                    closeTimeout="00:00:10"   
                    openTimeout="00:00:20"   
                    receiveTimeout="00:00:30"   
                    sendTimeout="00:00:40"   
                    deadLetterQueue="net.msmq://localhost/blah"   
                    durable="true"   
                    exactlyOnce="true"   
                    maxReceivedMessageSize="1000"   
                    maxImmediateRetries="11"   
                    maxRetryCycles="12"  
                    poisonMessageHandling="Disabled"   
                    rejectAfterLastRetry="false"   
                    retryCycleDelay="00:05:55"   
                    timeToLive="00:11:11"   
                    useSourceJournal="true"   
                    useMsmqTracing="true"   
                    serializationFormat="Binary">  
                    <security mode="None" />  
           </binding>  
       </msmqIntegrationBinding  
   </bindings>  
</system.ServiceModel>  
</configuration>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.MsmqIntegrationBindingElement>  
 <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding>  
 <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBindingElement>  
 [\<binding>](../../../../../docs/framework/misc/binding.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [Queues in WCF](../../../../../docs/framework/wcf/feature-details/queues-in-wcf.md)
