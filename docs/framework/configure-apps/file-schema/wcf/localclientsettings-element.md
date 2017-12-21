---
title: "&lt;localClientSettings&gt; element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4680ace5-f4e1-4fcb-b9d8-a4a4af5cd7ae
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;localClientSettings&gt; element
Specifies the security settings of a local client for this binding.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<security>  
  
## Syntax  
  
```xml  
<security>  
   <localClientSettings cacheCookies="Boolean"  
      cookieRenewalThresholdPercentage="Integer"  
      detectReplays="Boolean"  
      maxClockSkew="TimeSpan"  
      maxCookieCachingTime="TimeSpan"  
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
|`cacheCookies`|A Boolean value that specifies whether cookie caching is enabled. The default is `false`.|  
|`cookieRenewalThresholdPercentage`|An integer that specifies the maximum percentage of cookies that can be renewed. This value should be between 0 and 100 inclusively. The default is 90.|  
|`detectReplays`|A Boolean value that specifies whether replay attacks against the channel are detected and dealt with automatically. The default is `false`.|  
|`maxClockSkew`|A <xref:System.TimeSpan> that specifies the maximum time difference between the system clocks of the two communicating parties. The default value is "00:05:00".<br /><br /> When this value is set to the default, the receiver accepts messages with send-time time stamps up to 5 minutes later or earlier than the time the message was received. Messages that do not pass the send-time test are rejected. This setting is used in conjunction with the `replayWindow` attribute.|  
|`maxCookieCachingTime`|A <xref:System.TimeSpan> that specifies the maximum lifetime of cookies. The default value is "10675199.02:48:05.4775807".|  
|`reconnectTransportOnFailure`|A Boolean value that specifies whether connections using WS-Reliable messaging will attempt to reconnect after transport failures. The default is `true`, which means that infinite attempts to reconnect are attempted. The cycle is broken by the inactivity time-out, which causes the channel to throw an exception when it cannot be reconnected.|  
|`replayCacheSize`|A positive integer that specifies the number of cached nonces used for replay detection. If this limit is exceeded, the oldest nonce is removed and a new nonce is created for the new message. The default value is 500000.|  
|`replayWindow`|A <xref:System.TimeSpan> that specifies the duration in which individual message nonces are valid.<br /><br /> After this duration, a message sent with the same nonce as the one sent before will not be accepted. This attribute is used in conjunction with the `maxClockSkew` attribute to prevent replay attacks. An attacker could replay a message after its replay window has expired. This message, however, would fail the `maxClockSkew` test which rejects messages with send-time timestamps up to a specified time later or earlier than the time the message was received.|  
|`sessionKeyRenewalInterval`|A <xref:System.TimeSpan> that specifies the duration after which the initiator will renew the key for the security session. The default is "10:00:00".|  
|`sessionKeyRolloverInterval`|A <xref:System.TimeSpan> that specifies the time interval a previous session key is valid on incoming messages during a key renewal. The default is "00:05:00".<br /><br /> During key renewal, the client and server must always send messages using the most current available key. Both parties will accept incoming messages secured with the previous session key until the rollover time expires.|  
|`timestampValidityDuration`|A positive <xref:System.TimeSpan> that specifies the duration in which a time stamp is valid. The default is "00:15:00".|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-custombinding.md)|Specifies the security options for a custom binding.|  
|[\<secureConversationBootstrap>](../../../../../docs/framework/configure-apps/file-schema/wcf/secureconversationbootstrap.md)|Specifies the default values used for initiating a secure conversation service.|  
  
## Remarks  
 The settings are local in the sense that they are not settings derived from the security policy of the service.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.LocalClientSecuritySettingsElement>  
 <xref:System.ServiceModel.Configuration.SecurityElementBase.LocalClientSettings%2A>  
 <xref:System.ServiceModel.Channels.SecurityBindingElement.LocalClientSettings%2A>  
 <xref:System.ServiceModel.Channels.LocalClientSecuritySettings>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)  
 [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)  
 [Custom Binding Security](../../../../../docs/framework/wcf/samples/custom-binding-security.md)
