---
title: "Activity Tracing in Message Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 68862534-3b2e-4270-b097-8121b12a2c97
caps.latest.revision: 7
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Activity Tracing in Message Security
This topic describes activity tracing for security processing, which happens in the following three phases.  
  
-   Negotiation/SCT exchange. This can happen at the transport later (through binary data exchange) or message layer (through SOAP message exchanges).  
  
-   Message encryption/decryption, with signature verification and authentication. Traces appear in the ambient activity, typically "Process Action."  
  
-   Authorization and verification. This can happen locally or when communicating between endpoints.  
  
## Negotiation/SCT exchange  
 In the negotiation/SCT exchange phase, two activity types are created on the client: "Set up Secure Session" and "Close Secure Session." "Set up Secure Session" encompasses traces for the RST/RSTR/SCT message exchanges, while "Close Secure Session" includes traces for the Cancel message.  
  
 On the server, each request/reply for the RST/RSTR/SCT appears in its own activity. If `propagateActivity`=`true` on both the server and client, activities on the server have the same ID, and appear together in the "Setup Secure Session" when viewed through Service Trace Viewer.  
  
 This activity tracing model is valid for user name/password authentication, certificate authentication, and NTLM authentication.  
  
 The following table lists the activities and traces for negotiation and SCT exchange.  
  
||Time when Negotiation/SCT exchange happens|Activities|Traces|  
|-|-------------------------------------------------|----------------|------------|  
|Secure Transport<br /><br /> (HTTPS, SSL)|On first message received.|Traces are emitted in the ambient activity.|-   Exchange traces<br />-   Secure channel established<br />-   Share secrets obtained.|  
|Secure Message Layer<br /><br /> (WSHTTP)|On first message received.|On the client:<br /><br /> -   "Setup Secure Session" out of "Process Action" of that first message, for each request/reply for RST/RSTR/SCT.<br />-   "Close Secure Session" for the CANCEL exchange, out of the "Close Proxy activity." This activity may happen out of some other ambient activity, depending on when the secure session is closed.<br /><br /> On the server:<br /><br /> -   One "Process Action" activity for each request/reply for RST/SCT/Cancel on the server. If `propagateActivity`=`true`, RST/RSTR/SCT activities are merged with "Set up Security Session", and Cancel is merged with the "Close" activity from the client.<br /><br /> There are two stages for "Set up Secure Session":<br /><br /> 1.  Authentication negotiation. This is optional if the client already has the proper credentials. This phase can be done through secure transport, or through message exchanges. In the latter case, 1 or 2 RST/RSTR exchanges can happen. For these exchanges, traces are emitted in new request/reply activities as previously designed.<br />2.  Secure session establishment (SCT), in which one RST/RSTR exchange happens here. This has the same ambient activities as described previously.|-   Exchange traces<br />-   Secure channel established<br />-   Share secrets obtained.|  
  
> [!NOTE]
>  In mixed security mode, negotiation authentication happens in binary exchanges, but SCT happens in message exchange. In pure transport mode, negotiation happens only in transport with no additional activities.  
  
## Message Encryption and Decryption  
 The following table lists the activities and traces for message encryption/decryption, as well as signature authentication.  
  
||Secure Transport<br /><br /> (HTTPS, SSL) and Secure Message Layer<br /><br /> (WSHTTP)|  
|-|---------------------------------------------------------------------------------|  
|Time when message encryption/decryption, as well as signature authentication happens|On message received|  
|Activities|Traces are emitted in the ProcessAction activity on the client and server.|  
|Traces|-   sendSecurityHeader (sender):<br />-   Sign message<br />-   Encrypt request data<br />-   receiveSecurityHeader (receiver):<br />-   Verify signature<br />-   Decrypt response data<br />-   Authentication|  
  
> [!NOTE]
>  In pure transport mode, message encryption/decryption happens only in transport with no additional activities.  
  
## Authorization and Verification  
 The following table lists the activities and traces for authorization.  
  
||Time when authorization happens|Activities|Traces|  
|-|-------------------------------------|----------------|------------|  
|Local (default)|After the message is decrypted on the server|Traces are emitted in the ProcessAction activity at the server.|User authorized.|  
|Remote|After the message is decrypted on the server|Traces are emitted in a new activity invoked by the ProcessAction activity.|User authorized.|
