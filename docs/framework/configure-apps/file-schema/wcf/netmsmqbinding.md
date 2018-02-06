---
title: "&lt;netMsmqBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a68b44d7-7799-43a3-9e63-f07c782810a6
caps.latest.revision: 35
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;netMsmqBinding&gt;
Defines a queued binding suitable for cross-machine communication.  
  
 \<system.ServiceModel>  
\<bindings>  
\<netMsmqBinding>  
  
## Syntax  
  
```xml  
<netMsmqBinding>  
    <binding   
       closeTimeout="TimeSpan"   
       customDeadLetterQueue="Uri"  
       deadLetterQueue="Uri"  
       durable="Boolean"  
       exactlyOnce="Boolean"   
       maxBufferPoolSize="Integer"  
       maxReceivedMessageSize"Integer"  
       maxRetryCycles="Integer"   
       name="string"   
       openTimeout="TimeSpan"   
       poisonMessageHandling="Disabled/EnabledIfSupported"   
       queueTransferProtocol="Native/Srmp/SrmpSecure"  
       receiveErrorHandling="Drop/Fault/Move/Reject"  
       receiveTimeout="TimeSpan"   
       receiveRetryCount="Integer"  
       rejectAfterLastRetry="Boolean"   
       retryCycleDelay="TimeSpan"    
       sendTimeout="TimeSpan"   
       timeToLive="TimeSpan"    
       useActiveDirectory="Boolean"  
       useMsmqTracing="Boolean  
       useSourceJournal="Boolean"  
          <security>  
                  <message    
                        algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"  
            clientCredentialType="None/Windows/UserName/Certificate/InfoCard "/>  
                  <transport msmqAuthenticationMode="None/WindowsDomain/Certificate"  
            msmqEncryptionAlgorithm="RC4Stream/AES"  
            msmqProtectionLevel="None/Sign/EncryptAndSign"  
            msmqSecureHashAlgorithm="MD5/SHA1/SHA256/SHA512" />  
          </security>  
       <readerQuotas             maxArrayLength="Integer"            maxBytesPerRead="Integer"            maxDepth="Integer"             maxNameTableCharCount="Integer"                     maxStringContentLength="Integer" />   </binding></netMsmqBinding>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`closeTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a close operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|`customDeadLetterQueue`|A URI that contains the location of the per-application dead letter queue, where messages that have expired or that have failed transfer or delivery are placed.<br /><br /> The dead letter queue is a queue on the queue manager of the sending application for expired messages that have failed to be delivered.<br /><br /> The URI that is specified by <xref:System.ServiceModel.MsmqBindingBase.CustomDeadLetterQueue%2A> must use the net.msmq scheme.|  
|`deadLetterQueue`|A <xref:System.ServiceModel.MsmqBindingBase.DeadLetterQueue%2A> value specifying which type of dead-letter queue to use, if any.<br /><br /> A dead-letter queue is the place where messages that have failed to be delivered to the application will be transferred.<br /><br /> For messages that require `exactlyOnce` assurance (that is, the `exactlyOnce` attribute is set to `true`), this attribute defaults to the system-wide transactional dead-letter queue in MSMQ.<br /><br /> For messages that require no assurances, this attribute defaults to `null`.|  
|`durable`|A Boolean value that indicates whether the message is durable or volatile in the queue. A durable message survives a queue manager crash, while a volatile message does not. Volatile messages are useful when applications require lower latency and can tolerate occasional lost messages. If the `exactlyOnce` attribute is set to `true`, the messages must be durable. The default is `true`.|  
|`exactlyOnce`|A Boolean value that indicates whether each message processed by this binding is delivered only once. The sender will then be notified of delivery failures. When `durable` is `false`, this attribute is ignored and messages are transferred without delivery assurance. The default is `true`. For more information, see <xref:System.ServiceModel.MsmqBindingBase.ExactlyOnce%2A>.|  
|`maxBufferPoolSize`|An integer that specifies the maximum buffer pool size for this binding. The default is 8.|  
|`maxReceivedMessageSize`|A positive integer that defines the maximum message size, in bytes, including headers, that is processed by this binding. The sender of a message exceeding this limit will receive a SOAP fault. The receiver drops the message and creates an entry of the event in the trace log. The default is 65536. This bound on message size is intended to limit exposure to Denial of Service (DoS) attacks.|  
|`maxRetryCycles`|An integer that indicates the number of retry cycles used by the poison-message detection feature. A message becomes a poison message when it fails all delivery attempts of all cycles. The default is 3. For more information, see <xref:System.ServiceModel.MsmqBindingBase.MaxRetryCycles%2A>.|  
|`name`|Required attribute. A string that contains the configuration name of the binding. This value should be unique because it is used as an identification for the binding. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).|  
|`openTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for an open operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|`QueueTransferProtocol`|A valid <xref:System.ServiceModel.QueueTransferProtocol> value that specifies the queued communication channel transport that this binding uses. MSMQ does not support Active Directory addressing when using SOAP Reliable Messaging Protocol. Therefore, you should not set this attribute to `Srmp` or `Srmps` when the `u``seActiveDirectory` attribute is set to `true`.|  
|`receiveErrorHandling`|A <xref:System.ServiceModel.ReceiveErrorHandling> value that specifies how poison and nondispatchable messages are handled.|  
|`receiveRetryCount`|An integer that specifies the maximum number of times the queue manager should attempt to send a message before transferring it to the retry queue.|  
|`receiveTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a receive operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:10:00.|  
|`retryCycleDelay`|A TimeSpan value that specifies the time delay between retry cycles when attempting to deliver a message that could not be delivered immediately. The value defines only the minimum wait time because actual wait time can be longer. The default value is 00:10:00. For more information, see <xref:System.ServiceModel.MsmqBindingBase.RetryCycleDelay%2A>.|  
|`sendTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a send operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|`timeToLive`|A TimeSpan value that specifies how long the messages are valid before they are expired and put into the dead-letter queue. The default is 1.00:00:00.<br /><br /> This attribute is set to ensure that time-sensitive messages do not become stale before they are processed by the receiving applications. A message in a queue that is not consumed by the receiving application within the time interval specified is said to be expired. Expired messages are sent to special queue called the dead letter queue. The location of the dead letter queue is set with the `DeadLetterQueue` attribute or to the appropriate default, based on assurances.|  
|`usingActiveDirectory`|A Boolean value that specifies if queue addresses should be converted using Active Directory.<br /><br /> MSMQ queue addresses can consist of path names or direct format names. With a direct format name, MSMQ resolves the computer name using DNS, NetBIOS or IP. With a path name, MSMQ resolves the computer name using Active Directory.<br /><br /> By default, [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] queued transport converts the URI of a message queue to a direct format name. By setting the `UseActiveDirectory` property to true, an application can specify that the queued transport should resolve the computer name using Active Directory rather than DNS, NetBIOS, or IP.|  
|`useMsmqTracing`|A Boolean value that specifies whether messages processed by this binding should be traced. The default is `false`. When tracing is enabled, report messages are created and sent to the report queue each time the message leaves or arrives at a Message Queuing computer.|  
|`useSourceJournal`|A Boolean value that specifies copies of messages processed by this binding should be stored in the source journal. The default is `false`.<br /><br /> Queued applications that want to keep a record of messages that have left the computer's outgoing queue can copy the messages to a journal queue. Once a message leaves the outgoing queue and an acknowledgment is received that the message was received on the destination computer, a copy of the message is kept in the sending computer's system journal queue.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<readerQuotas>](http://msdn.microsoft.com/library/3e5e42ff-cef8-478f-bf14-034449239bfd)|Defines the constraints on the complexity of SOAP messages that can be processed by endpoints configured with this binding. This element is of type <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>.|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-netmsmqbinding.md)|Defines the security settings for the binding. This element is of type <xref:System.ServiceModel.Configuration.NetMsmqSecurityElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<bindings>](../../../../../docs/framework/configure-apps/file-schema/wcf/bindings.md)|This element holds a collection of standard and custom bindings.|  
  
## Remarks  
 The `netMsmqBinding` binding provides support for queuing by leveraging Microsoft Message Queuing (MSMQ) as a transport and enables support for loosely coupled applications, failure isolation, load leveling and disconnected operations. For a discussion of these features, see [Queues in WCF](../../../../../docs/framework/wcf/feature-details/queues-in-wcf.md).  
  
## Example  
  
```xml  
<configuration>  
<system.ServiceModel>  
    <bindings>  
           <netMsmqBinding>  
                <binding   
                         closeTimeout="00:00:10"   
                         openTimeout="00:00:20"   
                         receiveTimeout="00:00:30"  
                         sendTimeout="00:00:40"  
                         deadLetterQueue="net.msmq://localhost/blah"   
                         durable="true"   
                         exactlyOnce="true"   
                         maxReceivedMessageSize="1000"  
                         maxRetries="11"  
                         maxRetryCycles="12"   
                         poisonMessageHandling="Disabled"   
                         rejectAfterLastRetry="false"   
                         retryCycleDelay="00:05:55"   
                         timeToLive="00:11:11"   
                         sourceJournal="true"  
                         useMsmqTracing="true"  
                         useActiveDirectory="true">  
                         <security>  
                             <message clientCredentialType="Windows" />  
                         </security>  
            </netMsmqBinding>  
    </bindings>  
</system.ServiceModel>  
</configuration>  
```  
  
## See Also  
 <xref:System.ServiceModel.NetMsmqBinding>  
 <xref:System.ServiceModel.Configuration.NetMsmqBindingElement>  
 [\<binding>](../../../../../docs/framework/misc/binding.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [Queues in WCF](../../../../../docs/framework/wcf/feature-details/queues-in-wcf.md)
