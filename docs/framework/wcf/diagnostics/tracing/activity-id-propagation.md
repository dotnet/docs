---
title: "Activity ID Propagation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cd1c1ae5-cc8a-4f51-90c9-f7b476bcfe70
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Activity ID Propagation
Propagation happens when ServiceModel activity tracing is enabled (ServiceModel propagation) or disabled (User-to-User activity propagation).  
  
## ServiceModel Activity Tracing is Enabled  
 If ServiceModel ActivityTracing is enabled, propagation happens between ProcessAction activities.  
  
### Server  
 When the `propagateActivity` attribute is set to `true` on both the client and server, the ID of the `ProcessAction` activity in the server is identical to the ID in the propagated `ActivityId` message header.  
  
 When no `ActivityId` header is present in the message (that is, `propagateActivity`=`false` on the client), or when `propagateActivity`=`false` on the server, the server generates a new activity ID.  
  
### Client  
 If the client is synchronously single threaded, the client disregards any settings of `propagateActivity` at the client or server. Instead, the response is handled in the request activity. If the client is asynchronous or synchronous multithreaded, `propagateActivity`=`true` in the client, and there is an activity ID header in the message sent by the server, the client retrieves the activity ID from the message, and transfers to the Process Action activity that contains the propagated activity ID. Otherwise, the client transfers from Process Message activity to a new Process Action activity. This extra transfer to a new Process Action activity is done for consistency. Inside this activity, the client retrieves the activity ID of the BeginCall activity from the local thread context, when the thread is allocated for response message processing. It then transfers to the initial Process Action activity.  
  
 If the client is duplex, the client acts as server on receiving the message.  
  
### Propagation in Fault Messages  
 There is no difference in handling valid and fault messages. If `propagateActivity`=`true`, the activity ID added to the SOAP fault message headers is identical to the ambient activity.  
  
## ServiceModel Activity Tracing is Disabled  
 If ServiceModel ActivityTracing is disabled, propagation occurs between user code activities directly without going through ServiceModel activities. A user-defined activity ID is also propagated through the message activity ID header.  
  
 If `propagateActivity`=`true` and `ActivityTracing`=`off` for a ServiceModel trace listener (regardless of whether tracing is enabled on ServiceModel), the following happen on either the client or server:  
  
-   On operation request or sending response, the activity ID in TLS is propagated out of user code until a message is formed. An activity ID header is also inserted into the message before it is sent.  
  
-   On receiving request or receiving response, the activity ID is retrieved from the message header as soon as the received message object is created. The activity ID in TLS is propagated as soon as the message disappears from scope until user code is reached.  
  
 These actions guarantee that user traces will appear in the same activity if propagation is on. However, it makes no guarantee on ServiceModel traces. ServiceModel traces occur in a user code activity only if the processing of those traces is executed on the same thread where the user code activity was set.  
  
 In general, ServiceModel traces can be observed in the following places:  
  
-   If ServiceModel tracing is disabled, all emitted traces appear in user activities. If propagation is enabled at both the server and client, these traces will be in the same activity.  
  
-   If ServiceModel tracing is enabled, but ActivityTracing is disabled, user traces appear in the same activity if propagation is enabled on both ends. ServiceModel traces appear in the default 0000 activity, unless they occur in the same thread as the user code processing where the activity is initially set.  
  
-   If both ServiceModel tracing and ActivityTracing are enabled, user traces appear in user-defined activities, and ServiceModel traces appear in ServiceModel-defined activities. Propagation happens at ServiceModel level.
