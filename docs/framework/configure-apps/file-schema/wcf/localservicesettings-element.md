---
title: "&lt;localServiceSettings&gt; element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0658549c-3f65-46dd-8c5c-9895441ed734
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;localServiceSettings&gt; element
Specifies the security settings of a local service for this binding.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<security>  
  
## Syntax  
  
```xml  
<security>  
   <localServiceSettings detectReplays="Boolean"  
      inactivityTimeout="TimeSpan"  
      issuedCookieLifeTime="TimeSpan"  
      maxCachedCookies="Integer"   
      maxClockSkew="TimeSpan"   
      maxPendingSessions="Integer"  
      maxStatefulNegotiations="Integer"  
      negotiationTimeout="TimeSpan"  
      reconnectTransportOnFailure="Boolean"  
            replayCacheSize="Integer"  
      replayWindow="TimeSpan"  
      sessionKeyRenewalInterval="TimeSpan"  
      sessionKeyRolloverInterval="TimeSpan"  
      timestampValidityDuration="TimeSpan" />  
</security>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`detectReplays`|A Boolean value that specifies whether replay attacks against the channel are detected and dealt with automatically. The default is `false`.|  
|`inactivityTimeout`|A positive <xref:System.TimeSpan> that specifies the duration of inactivity the channel waits before it times out. The default is "01:00:00".|  
|`issuedCookieLifeTime`|A <xref:System.TimeSpan> that specifies the lifetime issued to all new security cookies. Cookies that exceed their lifetime are recycled and need to be negotiated again. The default value is "10:00:00".|  
|`maxCachedCookies`|A positive integer that specifies the maximum number of cookies that can be cached. The default is 1000.|  
|`maxClockSkew`|A <xref:System.TimeSpan> that specifies the maximum time difference between the system clocks of the two communicating parties. The default value is "00:05:00".<br /><br /> When this value is set to the default, the receiver accepts messages with send-time time stamps up to 5 minutes later or earlier than the time the message was received. Messages that do not pass the send-time test are rejected. This setting is used in conjunction with the `replayWindow` attribute.|  
|`maxPendingSessions`|A positive integer that specifies the maximum number of pending security sessions that the service supports. When this limit is reached, all new clients receive SOAP faults. The default value is 1000.|  
|`maxStatefulNegotiations`|A positive integer that specifies the number of security negotiations that can be active concurrently. Negotiation sessions in excess of the limit are queued and can only be completed when a space below the limit becomes available. The default value is 1024.|  
|`negotiationTimeout`|A <xref:System.TimeSpan> that specifies the lifetime of the security policy used by channel. When the time expires, the channel renegotiates with the client for a new security policy. The default value is "00:02:00".|  
|`reconnectTransportOnFailure`|A Boolean value that specifies whether connections using WS-Reliable messaging will attempt to reconnect after transport failures. The default is `true`, which means that infinite attempts to reconnect are attempted. The cycle is broken by the inactivity time-out, which causes the channel to throw an exception when it cannot be reconnected.|  
|`replayCacheSize`|A positive integer that specifies the number of cached nonces used for replay detection. If this limit is exceeded, the oldest nonce is removed and a new nonce is created for the new message. The default value is 500000.|  
|`replayWindow`|A <xref:System.TimeSpan> that specifies the duration in which individual message nonces are valid.<br /><br /> After this duration, a message sent with the same nonce as the one sent before will not be accepted. This attribute is used in conjunction with the `maxClockSkew` attribute to prevent replay attacks. An attacker could replay a message after its replay window has expired. This message, however, would fail the `maxClockSkew` test which rejects messages with send-time timestamps up to a specified time later or earlier than the time the message was received.|  
|`sessionKeyRenewalInterval`|A <xref:System.TimeSpan> that specifies the duration after which the initiator will renew the key for the security session. The default is "10:00:00".|  
|`sessionKeyRolloverInterval`|A <xref:System.TimeSpan> that specifies the time interval a previous session key is valid on incoming messages during a key renewal. The default is "00:05:00".<br /><br /> During key renewal, the client and server must always send messages using the most current available key. Both parties will accept incoming messages secured with the previous session key until the rollover time expires.|  
|`timestampValidityDuration`|A positive <xref:System.TimeSpan> that specifies the duration in which a time stamp is valid. The default is "00:15:00".|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-custombinding.md)|Specifies the security options for a custom binding.|  
|[\<secureConversationBootstrap>](../../../../../docs/framework/configure-apps/file-schema/wcf/secureconversationbootstrap.md)|Specifies the default values used for initiating a secure conversation service.|  
  
## Remarks  
 The settings are local because they are not published as part of the security policy of the service and do not affect the client's binding.  
  
 The following attributes of the `localServiceSecuritySettings` element can help mitigate a denial-of-service (DOS) security attack:  
  
-   `maxCachedCookies`: controls the maximum number of time-bounded SecurityContextTokens that are cached by the server after doing SPNEGO or SSL negotiation.  
  
-   `issuedCookieLifetime`: controls the lifetime of the SecurityContextTokens that are issued by the server following SPNEGO or SSL negotiation. The server caches the SecurityContextTokens for this period of time.  
  
-   `maxPendingSessions`: controls the maximum number of secure conversations that are established at the server but for which no application messages have been processed. This quota prevents clients from establishing secure conversations at the service, thereby causing the service to maintain state for each client, but never using them.  
  
-   `inactivityTimeout`: controls the maximum time that the service keeps a secure conversation alive without ever receiving an application message on it. This quota prevents clients from establishing secure conversations at the service, thereby causing the service to maintain state for each client, but never using them.  
  
 In a secure conversation session, note that both `inactivityTimeout` and the `receiveTimeout` attributes on the binding affect session timeout. The shorter of the two determines when timeouts occur.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.LocalServiceSecuritySettingsElement>  
 <xref:System.ServiceModel.Configuration.SecurityElementBase.LocalServiceSettings%2A>  
 <xref:System.ServiceModel.Channels.SecurityBindingElement.LocalServiceSettings%2A>  
 <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)  
 [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)  
 [Custom Binding Security](../../../../../docs/framework/wcf/samples/custom-binding-security.md)
