---
title: "Activity List"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5540e185-ce8e-4db3-83b0-2b9f5bf71829
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Activity List
This topic lists all the activities defined by [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)].  
  
> [!NOTE]
>  You can also define activities programmatically to group user traces. For more information, see [Emitting User-Code Traces](../../../../../docs/framework/wcf/diagnostics/tracing/emitting-user-code-traces.md).  
  
## ServiceModel Activities  
 The following table lists all activities for major usage scenarios.  
  
|Label|Activity Name|Activity Type|Description|  
|-----------|-------------------|-------------------|-----------------|  
|A, M|Ambient activity|N/A (this is not controlled by ServiceModel)|The activity whose ID is set in TLS before any calls to ServiceModel code (client side or server side).<br /><br /> Example: An activity where  open is called on the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] client or serviceHost.open is called.|  
|B|Construct<br /><br /> ChannelFactory. ContractType : ‘[Type]’.|Construct||  
|C|Open<br /><br /> [ClientBase&#124;ChannelFactory]. ContractType : ‘[Type]’.|Open||  
|I|Close [ClientBase&#124;ChannelFactory]. ContractType : ‘[Type]’.|Close||  
|M|Construct ServiceHost. ServiceType: ‘[Type]’.|Construct||  
|N|Open ServiceHost. ServiceType: ‘[Type]’.|Open||  
|Z|Close ServiceHost. ServiceType: ‘[Type]’.|Close||  
|O|Listen at ‘[address]’.|ListenAt|This and the next activity are transport-specific. The ListenAt activity represents the content that maps to the address where the channel listener listens at. In the case of MSMQ, it is the queue itself since the queue maps to one address. This activity listens for incoming connections in the case of connection-oriented transports, for MSMQ messages in the case of MSMQ. This activity is created during ServiceHost.Open(), and contains the traces related to creating and disposing the listener, as well as transferring out to all ReceiveBytes activities.|  
|P|Receive bytes on connection ‘[address]’. Receive MSMQ message.|ReceiveBytes|In this activity, data that will eventually get a [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] message is processed. Incoming bytes are waited in the case of connection-oriented transport or http. For TCP/named-pipe, the lifetime of this activity is the lifetime of the connection, as it is created when the connection is created. For http, it is of the lifetime of a message request and is created when the message is sent. This activity contains the traces related to creating and disposing the connection if applicable, as well as transfers out to all message (object) processing activities.<br /><br /> In the case of MSMQ, it is the activity where the MSMQ message is retrieved.|  
|Q|Process message [number]. (Note, [number] is a monotonically increasing value which starts at 1.)|ProcessMessage|Process an incoming message. This activity starts when all the data (bytes, MSMQ message) are received to form a [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] message object. Traces within this activity deal with header processing.<br /><br /> Once a message that can be dispatched is formed, the ServiceHost ProcessAction activity is switched to after looking up the corresponding Activity ID.|  
|D, S|Process action ‘[action]’.|ProcessAction|Process the message through the Transport/Security/RM stack for dispatching the message to user code on receive, and in the reverse order on send.<br /><br /> On the server, this activity uses the propagated Activity ID if it is sent in the message header via "Activity Propagation"; otherwise, a new GUID is created.<br /><br /> The response message for request/reply contracts is also processed in that activity.|  
|T|Execute ‘[IContract.Operation]’.|ExecuteUserCode|Execute user code after dispatch on the service side. This activity provides a boundary to delineate ServiceHost code from user-provided code.|  
  
## Security Activities  
 The following table lists all activities related to Security.  
  
|Activity Name|Activity Type|Description|  
|-------------------|-------------------|-----------------|  
|Setup secure session|SetupSecurity|Exists on the client side only. Contains all RST*/SCT exchanges for authentication and setting the security context. If `propagateActivity`=`true`, this activity is merged with the service’s corresponding Process Action RST\*/SCT activities.|  
|Close secure session|SetupSecurity|Exists on the client side. Contains the Cancel message exchange for closing the secure session. If `propagateActivity`=`true`, this activity is merged with the Process Action "Cancel" from the service.|  
  
 The following table lists all activities related to COM+.  
  
|Activity Name|Activity Type|Description|  
|-------------------|-------------------|-----------------|  
|Create COM+ instance|TransferToCOMPlus|1 activity instance for each COM+ call from [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] code|  
|Execute COM+ \<operation>|TransferToCOMPlus|1 activity instance for each COM+ call from [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] code|  
  
## WMI Activities  
 The following table lists all activities related to WMI.  
  
|Activity Name|Activity Type|Description|  
|-------------------|-------------------|-----------------|  
|WMI get|WMIGetObject|User is retrieving data from WMI.|  
|WMI put|WmiPutInstance|User is updating data with WMI.|
