---
title: "&lt;reliableSession&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 129b4a59-37f0-4030-b664-03795d257d29
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;reliableSession&gt;
Defines setting for WS-Reliable Messaging. When this element is added to a custom binding, the resulting channel can support exactly-once delivery assurances.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<reliableSession>  
  
## Syntax  
  
```xml  
<reliableSession acknowledgementInterval="TimeSpan"  
        flowControlEnabled="Boolean"   
    inactivityTimeout="TimeSpan"  
    maxPendingChannels="Integer"  
    maxRetryCount="Integer"   
        maxTransferWindowSize="Integer"  
    reliableMessagingVersion="Default/WSReliableMessagingFebruary2005/WSReliableMessaging11"  
    ordered="Boolean" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|acknowledgementInterval|A <xref:System.TimeSpan> that contains the maximum time interval the channel is going to wait to send an acknowledgment for messages received up to that point. The default is 00:00:0.2.|  
|flowControlEnabled|A Boolean value that indicates whether advanced flow control, a Microsoft-specific implementation of flow control for WS-Reliable messaging, is activated. The default is `true`.|  
|inactivityTimeout|A <xref:System.TimeSpan> that specifies the maximum duration that the channel is going to allow the other communication party not to send any messages, before faulting the channel. The default is 00:10:00.<br /><br /> Activity on a channel is defined as receiving an application or infrastructure messages. This property controls the maximum amount of time to keep an inactive session alive. If longer time passes with no activity, the session is aborted by the infrastructure and the channel faults. **Note:**  It is not necessary for the application to periodically send messages to keep the connection alive.|  
|maxPendingChannels|An integer that specifies the maximum number of channels that can wait on the listener to be accepted. This value should be between 1 to 16384 inclusive. The default is 4.<br /><br /> Channels are pending when they are waiting to be accepted. Once that limit is reached, no channels are created. Rather, they are put in pending mode until this number goes down (by accepting pending channels). This is a per-factory limit.<br /><br /> When the threshold is reached and a remote application tries to establish a new reliable session, the request is denied and the open operation that prompted this faults. This limit does not apply to the number of pending outgoing channels.|  
|maxRetryCount|An integer that specifies the maximum number of times a reliable channel attempts to retransmit a message it has not received an acknowledgment for, by calling Send on its underlying channel.<br /><br /> This value should be greater than zero. The default is 8.<br /><br /> This value should be an integer greater than zero. If an acknowledgment is not received after the last retransmission, the channel faults.<br /><br /> A message is considered to be transferred if its delivery at the recipient has been acknowledged by the recipient.<br /><br /> If an acknowledgment has not been received within a certain amount of time for a message that has been transmitted, the infrastructure automatically retransmits the message. The infrastructure tries to resend the message for at most the number of times specified by this property. If an acknowledgment is not received after the last retransmission, the channel faults.<br /><br /> The infrastructure uses an exponential back-off algorithm to determine when to retransmit, based on a computed average round-trip time. The time initially starts at 1 second before retransmission and doubling the delay with every attempt, which results in approximately 8.5 minutes passing between the first transmission attempt and the last retransmission attempt. The time for the first retransmission attempt is adjusted according to the calculated round-trip time and the resulting stretch of time that those attempts take varies accordingly. This allows the retransmission time to dynamically adapt to varying network conditions.|  
|maxTransferWindowSize|An integer that specifies the maximum size of the buffer. Valid values are from 1 to 4096 inclusive.<br /><br /> On the client, this attribute defines the maximum size of the buffer used by a reliable channel to hold messages not yet acknowledged by the receiver. The unit of the quota is a message. If the buffer is full, further SEND operations are blocked.<br /><br /> On the receiver, this attribute defines the maximum size of the buffer used by the channel to store incoming messages not yet dispatched to the application. If the buffer is full, further messages are silently dropped by the receiver and require retransmission by the client.|  
|ordered|A Boolean that specifies whether messages are guaranteed to arrive in the order they were sent. If this setting is `false`, messages can arrive out of order. The default is `true`.|  
|reliableMessagingVersion|A valid value from <xref:System.ServiceModel.ReliableMessagingVersion> that specifies the WS-ReliableMessaging version to be used.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../../../docs/framework/misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  
 Reliable sessions provide features for reliable messaging and sessions. Reliable messaging retries communication on failure and allows delivery assurances such as in-order arrival of messages to be specified. Sessions maintain state for clients between calls. This element also optionally provides ordered message delivery. This implemented session can cross SOAP and transport intermediaries.  
  
 Each binding element represents a processing step when sending or receiving messages. At runtime, binding elements create the channel factories and listeners that are necessary to build outgoing and incoming channel stacks required to send and receive messages. The `reliableSession` provides an optional layer in the stack that can establish a reliable session between endpoints and configure the behavior of this session.  
  
 For more information, see [Reliable Sessions](../../../../../docs/framework/wcf/feature-details/reliable-sessions.md).  
  
## Example  
 The following example demonstrates how to configure a custom binding with various transport and message encoding elements, especially enabling reliable sessions, which maintains client state and specifies in-order delivery assurances. This feature is configured in the application configuration files for the client and service. The example show the service configuration.  
  
```xml  
<?xml version="1.0" encoding="utf-8" ?>  
<configuration>  
  <system.serviceModel>  
    <services>  
      <service   
          name="Microsoft.ServiceModel.Samples.CalculatorService"  
          behaviorConfiguration="CalculatorServiceBehavior">  
        <!-- This endpoint is exposed at the base address provided by host: http://localhost/servicemodelsamples/service.svc  -->  
        <!-- specify customBinding binding and a binding configuration to use -->  
        <endpoint address=""  
                  binding="customBinding"  
                  bindingConfiguration="Binding1"   
                  contract="Microsoft.ServiceModel.Samples.ICalculator" />  
        <!-- The mex endpoint is exposed at http://localhost/servicemodelsamples/service.svc/mex -->  
        <endpoint address="mex"  
                  binding="mexHttpBinding"  
                  contract="IMetadataExchange" />  
      </service>  
    </services>  
  
    <!-- custom binding configuration - configures HTTP transport, reliable sessions -->  
    <bindings>  
      <customBinding>  
        <binding name="Binding1">  
          <reliableSession />  
          <security authenticationMode="SecureConversation"  
                     requireSecurityContextCancellation="true">  
          </security>  
          <compositeDuplex />  
          <oneWay />  
          <textMessageEncoding messageVersion="Soap12WSAddressing10" writeEncoding="utf-8" />  
          <httpTransport authenticationScheme="Anonymous" bypassProxyOnLocal="false"  
                        hostNameComparisonMode="StrongWildcard"   
                        proxyAuthenticationScheme="Anonymous" realm=""   
                        useDefaultWebProxy="true" />  
        </binding>  
      </customBinding>  
    </bindings>  
  
    <!--For debugging purposes set the includeExceptionDetailInFaults attribute to true-->  
    <behaviors>  
      <serviceBehaviors>  
        <behavior name="CalculatorServiceBehavior">  
          <serviceMetadata httpGetEnabled="True"/>  
          <serviceDebug includeExceptionDetailInFaults="False" />  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
  </system.serviceModel>  
</configuration>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ReliableSessionElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 <xref:System.ServiceModel.Channels.ReliableSessionBindingElement>  
 [Reliable Sessions](../../../../../docs/framework/wcf/feature-details/reliable-sessions.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)
