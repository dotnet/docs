---
title: "How to: Secure Messages within Reliable Sessions | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: aee33e50-936f-4486-9ca8-c1520c19a62d
caps.latest.revision: 8
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
---
# How to: Secure Messages within Reliable Sessions
This topic outlines the steps required to enable message-level security for messages exchanged within a reliable session using one of the system-provided bindings that support such a session, but not by default. You can enable a secure, reliable session either imperatively by using code or declaratively in the configuration file. This procedure uses the client and service configuration files to enable the secure, reliable session.  
  
 This procedure consists of the following three key tasks:  
  
1.  Specify that the client and service exchange messages within a reliable session.  
  
2.  Require message-level security within the reliable session.  
  
3.  Specify the client credential type that the client must use to be authenticated with the service.  
  
 It is important in the first task that the endpoint configuration element contain a `bindingConfiguration` attribute that references a binding configuration named (in this example) "MessageSecurity." The [\<binding>](../../../../docs/framework/misc/binding.md) configuration element can then reference this name to enable reliable sessions by setting the `enabled` attribute of the [reliableSession](http://msdn.microsoft.com/en-us/9c93818a-7dfa-43d5-b3a1-1aafccf3a00b) element to `true`. You can require that the ordered delivery assurances are available within a reliable session by setting the `ordered` attribute to `true`.  
  
 For the source copy of the example on which this configuration procedure is based, see the [WS Reliable Session](../../../../docs/framework/wcf/samples/ws-reliable-session.md).  
  
 The essential items of the second task are accomplished by setting the `mode` attribute of the <`security`> element contained in the <`binding`> element of the client and service to `Message`.  
  
 The essential items of the third task are accomplished by setting the `clientCredentialType` attribute of the <`message`> element contained in the <`security`> element of the client and service to `Certificate`.  
  
> [!NOTE]
>  When using message security with reliable sessions, if the client is not authenticated, Reliable Messaging attempts to authenticate the client until a timeout occurs instead of throwing an exception upon first failure.  
  
### To configure the service with a WSHttpBinding to use a reliable session  
  
1.  This procedure is described in [How to: Exchange Messages Within a Reliable Session](../../../../docs/framework/wcf/feature-details/how-to-exchange-messages-within-a-reliable-session.md).  
  
### To configure the client with a WSHttpBinding to use a reliable session  
  
1.  This procedure is described in [How to: Exchange Messages Within a Reliable Session](../../../../docs/framework/wcf/feature-details/how-to-exchange-messages-within-a-reliable-session.md).  
  
### To set the mode and ClientCredentialType in configuration  
  
1.  Add an appropriate binding element to the [\<bindings>](../../../../docs/framework/configure-apps/file-schema/wcf/bindings.md) element of the configuration file. The following example adds a [\<wsHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md) element.  
  
2.  Add a <`binding`> element and set its `name` attribute to an appropriate value.  
  
3.  Add a `<security>` element and set the `mode` attribute to `Message`.  
  
     The following example sets the mode to `Message`, and then sets the `clientCredentialType` attribute of the <`message`> element to `Certificate`.  
  
    ```  
    <wsHttpBinding>  
    <binding name="MessageSecurity">  
        <security mode="Message" />  
           <message clientCredentialType = " Certificate" />  
        </security>  
    </binding>  
    </wsHttpBinding >  
    ```