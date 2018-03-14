---
title: "&lt;soapProcessing&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e8707027-e6b8-4539-893d-3cd7c13fbc18
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# &lt;soapProcessing&gt;

Defines the client endpoint behavior used to marshal messages between different binding types and message versions.

**\<system.ServiceModel>**   
&nbsp;&nbsp;**\<behaviors>**   
&nbsp;&nbsp;&nbsp;&nbsp;**\<endpointBehaviors>**   
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<behavior>**   
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<soapProcessing>**

## Syntax

```xml
<soapProcessing processMessages="true|false" />
```

## Attributes and elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

|                   | Description |
| ----------------- | ----------- |
| `processMessages` | A Boolean value that specifies whether messages should be marshaled between SOAP message versions. |

### Child elements

None

### Parent elements

|     | Description |
| --- | ----------- |
| [**\<behavior>**](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md) | Specifies an endpoint behavior. |

## Remarks

SOAP processing is the process where messages are converted between message versions.

The [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] Routing Service can convert messages from one protocol to another. If the incoming and outgoing Message Versions are different, a new message of the correct version is created. Processing messages from one <!--zz <xref:System.ServiceModel.Channel.MessageVersion> --> `MessageVersion`  to another is accomplished by constructing a new [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] message that contains the body part and relevant headers from the incoming [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] message. Headers that are specific to addressing, or that are understood at the router level, are not used during construction of the new WCF message because these headers are either of a different version (in the case of addressing headers) or have been processed as part of the communication between the client and the router.

Whether a header is placed in the outbound message is determined by whether or not it was marked as understood as it passed through the incoming channel layer. Headers that are not understood (such as custom headers) are not removed and so pass through the routing service by being copied to the outbound message. The body of the message is copied to the outbound message. The message is then sent out the outbound channel, at which point all of the headers and other envelope data specific to that communication protocol/transport will be created and added.

Such processing steps take place when the SOAP processing behavior is specified. This [\<soapProcessingExtension>](../../../../../docs/framework/configure-apps/file-schema/wcf/soapprocessing.md) behavior is an endpoint behavior that is applied to all client (outgoing) endpoints when the Routing Service starts up. default, the [\<routing>](../../../../../docs/framework/configure-apps/file-schema/wcf/routing-of-servicebehavior.md) behavior creates and attaches a new [\<soapProcessingExtension>](../../../../../docs/framework/configure-apps/file-schema/wcf/soapprocessing.md) behavior with `processMessages` set to `true` for each client endpoint. If you have a protocol that the Routing Service does not understand, or wish to override the default processing behavior, you can disable SOAP processing either for the entire Routing Service or just for particular endpoints.  To disable SOAP processing for the entire routing service on all endpoints, set the `soapProcessing` attribute of the [\<routing>](../../../../../docs/framework/configure-apps/file-schema/wcf/routing-of-servicebehavior.md) behavior to `false`. To turn off SOAP processing for a particular endpoint, use this behavior and set its `processMessages` attribute to `false`, then attach this behavior to the endpoint you do not want the default processing code to run at.  When the [\<routing>](../../../../../docs/framework/configure-apps/file-schema/wcf/routing-of-servicebehavior.md) behavior sets up the Routing Service, it will skip reapplying the endpoint behavior since one already exists.
