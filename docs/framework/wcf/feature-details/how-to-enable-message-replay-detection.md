---
title: "How to: Enable Message Replay Detection"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "WCF security"
  - "replay detection [WCF]"
  - "WCF, custom bindings"
  - "WCF, security"
ms.assetid: 8b847e91-69a3-49e1-9e5f-0c455e50d804
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Enable Message Replay Detection
A replay attack occurs when an attacker copies a stream of messages between two parties and replays the stream to one or more of the parties. Unless mitigated, the computers subject to the attack will process the stream as legitimate messages, resulting in a range of bad consequences, such as redundant orders of an item.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] message replay detection, see [Message Replay Detection](http://go.microsoft.com/fwlink/?LinkId=88536).  
  
 The following procedure demonstrates various properties that you can use to control replay detection using [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)].  
  
### To control replay detection on the client using code  
  
1.  Create a <xref:System.ServiceModel.Channels.SecurityBindingElement> to use in a <xref:System.ServiceModel.Channels.CustomBinding>. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md). The following example uses a <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> created with the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateKerberosBindingElement%2A> of the <xref:System.ServiceModel.Channels.SecurityBindingElement> class.  
  
2.  Use the <xref:System.ServiceModel.Channels.SecurityBindingElement.LocalClientSettings%2A> property to return a reference to the <xref:System.ServiceModel.Channels.LocalClientSecuritySettings> class and set any of the following properties, as appropriate:  
  
    1.  `DetectReplay`. A Boolean value. This governs whether the client should detect replays from the server. The default is `true`.  
  
    2.  `MaxClockSkew`. A <xref:System.TimeSpan> value. Governs how much time skew the replay mechanism can tolerate between the client and the server. The security mechanism examines the time stamp sent and determines whether it was sent too far back in the past. The default is 5 minutes.  
  
    3.  `ReplayWindow`. A `TimeSpan` value. This governs how long a message can live in the network after the server sends it (through intermediaries) before reaching the client. The client tracks the signatures of the messages sent within the latest `ReplayWindow` for the purposes of replay detection.  
  
    4.  `ReplayCacheSize`. An integer value. The client stores the signatures of the message in a cache. This setting specifies how many signatures the cache can store. If the number of messages sent within the last replay window reaches the cache limit, new messages are rejected until the oldest cached signatures reach the time limit. The default is 500000.  
  
### To control replay detection on the service using code  
  
1.  Create a <xref:System.ServiceModel.Channels.SecurityBindingElement> to use in a <xref:System.ServiceModel.Channels.CustomBinding>.  
  
2.  Use the <xref:System.ServiceModel.Channels.SecurityBindingElement.LocalServiceSettings%2A> property to return a reference to the <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings> class, and set the properties as described previously.  
  
### To control replay detection in configuration for the client or service  
  
1.  Create a [\<customBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md).  
  
2.  Create a `<security>` element.  
  
3.  Create a [\<localClientSettings>](../../../../docs/framework/configure-apps/file-schema/wcf/localclientsettings-element.md) or [\<localServiceSettings>](../../../../docs/framework/configure-apps/file-schema/wcf/localservicesettings-element.md).  
  
4.  Set the following attribute values, as appropriate: `detectReplays`, `maxClockSkew`, `replayWindow`, and `replayCacheSize`. The following example sets the attributes of both a `<localServiceSettings>` and a `<localClientSettings>` element:  
  
    ```xml  
    <customBinding>  
      <binding name="NewBinding0">  
       <textMessageEncoding />  
        <security>  
         <localClientSettings   
          replayCacheSize="800000"   
          maxClockSkew="00:03:00"  
          replayWindow="00:03:00" />  
         <localServiceSettings   
          replayCacheSize="800000"   
          maxClockSkew="00:03:00"  
          replayWindow="00:03:00" />  
        <secureConversationBootstrap />  
       </security>  
      <httpTransport />  
     </binding>  
    </customBinding>  
    ```  
  
## Example  
 The following example creates a <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> using the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateKerberosBindingElement%2A> method, and sets the replay properties of the binding.  
  
 [!code-csharp[c_ReplayDetection#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_replaydetection/cs/source.cs#1)]
 [!code-vb[c_ReplayDetection#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_replaydetection/vb/source.vb#1)]  
  
## Scope of Replay: Message Security Only  
 Note that the following procedures apply only to Message security mode. For Transport and Transport with Message Credential modes, the transport mechanisms detect replays.  
  
## Secure Conversation Notes  
 For bindings that enable secure conversations, you can adjust these settings both for the application channel as well as for the secure conversation bootstrap binding. For example, you can turn off replays for the application channel but enable them for the bootstrap channel that establishes the secure conversation.  
  
 If you do not use secure conversation sessions, replay detection does not guarantee detecting replays in server farm scenarios and when the process is recycled. This applies to the following system-provided bindings:  
  
-   <xref:System.ServiceModel.BasicHttpBinding>.  
  
-   <xref:System.ServiceModel.WSHttpBinding> with the <xref:System.ServiceModel.NonDualMessageSecurityOverHttp.EstablishSecurityContext%2A> property set to `false`.  
  
## Compiling the Code  
  
-   The following namespaces are required to compile the code:  
  
-   <xref:System>  
  
-   <xref:System.ServiceModel>  
  
-   <xref:System.ServiceModel.Channels>  
  
## See Also  
 <xref:System.ServiceModel.Channels.LocalClientSecuritySettings>  
 <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings>  
 [Secure Conversations and Secure Sessions](../../../../docs/framework/wcf/feature-details/secure-conversations-and-secure-sessions.md)  
 [\<localClientSettings>](../../../../docs/framework/configure-apps/file-schema/wcf/localclientsettings-element.md)  
 [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)
